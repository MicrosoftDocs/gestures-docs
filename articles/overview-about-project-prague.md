# Overview

## What is project Prague?

Project Prague is an SDK (software development kit) that allows you to create NUI (natural user interface) experiences based on hand gesture input. We provide an API (application programming interface) enabling you to easily design and code up your own customized hand gestures and integrate them into your applications.

The building blocks of a gesture are hand poses and hand motions. Using simple constraints specified in an intuitive language, we allow you to define any hand pose and any hand motion you like. You can string a sequence of hand poses and hand motions to specify a gesture. Once your gesture is defined and registered with our runtime, we will notify you whenever we detect that your user has performed the gesture with their hand. At this point you can run the desired logic to respond to the detected gesture.

Using project Prague, you can enable your users to intuitively control music and videos, bookmark and like web content, send an emoji on IM (instant messaging) applications, interact with a digital assistant, create and run PowerPoint slideshows, manipulate three-dimensional objects and play games using their hands alone.

## Getting started with project Prague

To get project Prague running on your machine you will need to:

1. Purchase an [Intel (R) RealSense (TM) SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html). Connect the camera to a USB 3.0 port (please avoid using a charging port, use an "SS" port instead) and place it below your computer monitor, directed at your face, as illustrated in the image:

![RealSense camera desktop setup](Images\RealSenseDesktopSetup.jpg)

1. Install project Prague runtime from [the official url](https://aka.ms/moriah/alef/setup). The installation will create shortcuts on your desktop pointing to our compiled samples. Please run one of the samples to verify that your setup is correct. Also, note that if the installation completed successfully, an environment variable named "MicrosoftGesturesInstallDir" has been created, pointing to a directory where all project Prague assemblies are located.

## Understanding gestures in project Prague

Before you can start writing gestures, you should get familiar with the basic building blocks of a gesture - hand poses and hand motions.

### Hand pose

A hand pose refers to a snapshot of the hand at a given moment. The hand pose contains a complete description of the state of the palm and the fingers in that snapshot. In our API, a hand pose is represented by the HandPose class, which is made up of various constraints as illustrated below:

![HandPose and constraints](Images\HandPoseAndConstraints.png)

You can specify any hand pose you like by characterizing all the constraints describing the pose as illustrated below:

![HandPose examples](Images\HandPoseExample.png)

### Hand motion

When moving your finger or your palm you are tracing a one-dimensional curve through space. We call such a curve a hand motion. In our API, a hand motion is represented by the HandMotion class. A hand motion is associated with a hand part (either a palm or a finger) and made up of a sequence of motion building blocks. The available building blocks are illustrated below:

![HandMotion building blocks](Images\HandMotionScript.png)

An example of a hand motion described as a sequence of arc building blocks:

![Motion - simple example](Images\MotionExample.png)

### Gesture

The straight forward way to think of a gesture is as a sequence of hand poses and\or hand motions. In our API, a gesture is represented by the Gesture class. A Gesture class holds a state machine which represents a sequence of hand poses and hand motions, as shown in the example below:

![Gesture example](Images\GestureExample.png)

The "SlingShot" gesture in the example is made up of two hand poses, named "NotPinching" and "Pinch", and one hand motion, named "Retract". Note that the "NotPinching" hand pose is used twice in the sequence - once at the beginning and once again and at the end. Imagine holding a slingshot in your left hand, grasping its pocket with the thumb and index fingers of your right hand, pulling the pocket back and releasing it to let the projectile fly. By following these instructions you will have executed a gesture with your hand. The description of this gesture in terms of the project Prague language is given in the "SlingShot" example.

## Creating gestures in project Prague

We will now give an example illustrating how to code up a simple gesture using the project Prague API. The gesture we will implement is called "RotateRight":

![Rotate right FSM](Images\RotateRightFsm.png)

Intuitively, when you performing the "RotateRight" gesture, a user would expect some object in the foreground application to be rotated right in 90°. You could use this gesture, for instance, to trigger the rotation of an image in a PowerPoint slideshow.

The following code demonstrates one possible way to define the "RotateRight" gesture:

    ```cs
    var lockObject = new HandPose("LockObject", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb);,
                                                new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb));

    var rotateObject = new HandPose("RotateObject", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                                    new FingertipPlacementRelation(Finger.Index, RelativePlacement.Right, Finger.Thumb);,
                                                    new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb));
    
    var rotateRight = new Gesture("RotateRight", lockObject, rotateObject);
    ```

The "RotateRight" gesture is a sequence of two hand poses - "LockObject" and "RotateObject". Both poses require the thumb and index to be open, pointing forward and not touching each other. The difference between the poses is that "LockObject" specifies that the index finger should be above the thumb and the "RotateObject" specifies that the index finger should be right of the thumb. The transition between "LockObject" and "RotateRight", therefore, corresponds to a rotation of the hand to the right.

Note that the middle, ring and pinky fingers do not participate in the definition of the "RotateRight" gesture. This makes sense because we do not wish to constrain the state of these fingers in any way. In other words, these fingers are free to assume any state during the execution of the "RotateRight" gesture.

Having defined the gesture, you need to hook up the event indicating gesture detection to the appropriate handler in your target application:

    ```cs
    rotateRight.Triggered += (sender, args) => { /* This is called when the user performs the "RotateRight" gesture */ };
    ```

Finally, you should register the new gesture with the project Prague runtime:

    ```cs
    var gesturesService = GesturesServiceEndpointFactory.Create();
    gesturesService.ConnectAsync().Wait();
    gesturesService.RegisterGesture(rotateRight).Wait();
    ```

When you wish to stop the detection of the "RotateRight" gesture, you can unregister it as follows:

    ```cs
    gesturesService.UnregisterGesture(rotateRight).Wait();
    ```

When done working with the runtime, you should dispose the end point object:

    ```cs
    gesturesService?.Dispose();
    ```

Please note that in order for the above code to compile, you will need to reference the following assemblies, located in the directory indicated by the MicrosoftGesturesInstallDir environment variable:

* Microsoft.Gestures.dll
* Microsoft.Gestures.Endpoint.dll