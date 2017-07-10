# Overview

## What is Project Prague?

Project Prague is an SDK (software development kit) that allows you to create NUI (natural user interface) experiences based on hand gesture input. We provide a .NET API (application programming interface) enabling you to easily design and code up your own customized hand gestures and integrate them into your applications.

The building blocks of a gesture are hand poses and hand motions. Using simple constraints specified in an intuitive language, we allow you to define any hand pose and any hand motion you like. You can string together a sequence of hand poses and hand motions to specify a gesture. Once your gesture is defined and registered with our runtime, we will notify you whenever we detect that your user has performed the gesture with their hand. At this point you can run the desired logic to respond to the detected gesture.

Using Project Prague, you will enable your users to use hand gestures to intuitively control music and videos, bookmark and like web content, send an emoji on IM (instant messaging) applications, interact with a digital assistant, create and run PowerPoint slideshows, manipulate three-dimensional objects, play games using their hands alone, and much more.

## Getting started with Project Prague

### Hardware and software requirements

Please make sure your system meets the following requirements before you proceed to set up Project Prague:

Category     | Minimal | Recommended
------------ | ------------ | -------------
Camera       | [Intel (R) RealSense (TM) SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html)
CPU | Intel (R) Core (TM) i5 series, 4 logical cores | Intel (R) Core (TM) i7 series, 8 logical cores
Free RAM | 1GB | 2GB
Operating System | Windows 10 | Windows 10 with Creator's Update installed

### Setting up Project Prague on your machine

To get Project Prague running on your machine you will need to:

1. Connect your [Intel (R) RealSense (TM) SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html) to a USB 3.0 port and place it below your computer's monitor, as illustrated in the image below:
    
    ![RealSense camera desktop setup](Images\RealSenseDesktopSetup.png)

1. Install Project Prague runtime from [aka.ms/gestures/setup](http://aka.ms/gestures/setup). The installation will create shortcuts on your desktop pointing to our compiled samples.

1. When installation completes, a window titled "Microsoft Gestures Service" will be launched. This window displays information about gesture and pose detection in real-time.  Make sure that your fingers are detected successfully, as demonstrated below:

    ![Gesture Detection Dashboard](Images\MicrosoftGesturesService.png)

1. Note that Project Prague setup has added two applications to your Windows startup configuration. You can modify this configuration any time in the Startup tab of the Task Manager. We have configured the following applications to launch on Windows startup:

    * Microsoft.Gestures.Sync - an update client that will pull updated builds of Project Prague assemblies when we publish them.
    * Microsoft.Gestures.DiscoveryClient - a sample application providing gestures for various contexts - Windows shell, PowerPoint, Skype and YouTube. To learn more about this sample, follow [this link](https://review.docs.microsoft.com/en-us/gestures).

For a more detailed description of the setup process, please refer to the [Set up Project Prague](http://aka.ms/gestures/docs) section.

## Understanding gestures in Project Prague

Before you start writing gestures, you should get familiar with the basic building blocks of a gesture - hand poses and hand motions.

### Hand pose

A hand pose refers to a snapshot of the hand at a given moment. The hand pose contains a complete description of the state of the palm and the fingers in that snapshot. In our API, a hand pose is represented by the [HandPose](https://review.docs.microsoft.com/en-us/gestures) class, which is made up of various constraints as illustrated below:

![HandPose and constraints](Images\HandPoseAndConstraints.png)

To learn more about how to define a [HandPose](https://review.docs.microsoft.com/en-us/gestures) using the [PalmPose](https://review.docs.microsoft.com/en-us/gestures), [FingerPose](https://review.docs.microsoft.com/en-us/gestures), [FingertipPlacementRelation](https://review.docs.microsoft.com/en-us/gestures) and [FingertipDistanceRelation](https://review.docs.microsoft.com/en-us/gestures) constraints, refer to the corresponding pages in the [Concepts](https://review.docs.microsoft.com/en-us/gestures) section.

You can specify any hand pose you like by characterizing all the constraints describing that pose, as illustrated below:

![HandPose examples](Images\HandPoseExample.png)

The example above demonstrates all the constraints you can reasonably associate with the snapshot on the left. This example is given for educational purposes, to show you the meaning of the different terms used to specify constraints in the Project Prague language. In practice, you would never use such a large number of constraints to specify a hand pose. Instead, you should try to use the minimal number of constraints that capture the essence of the hand pose you are trying to describe. The following example is a practical way to describe the same pose:

![HandPose example simplified](Images\HandPoseExampleSimplified.png)

This last example captures well the essence of the pose in the snapshot - the pinching action performed by the thumb and index fingers. Notice that the middle, ring and pinky fingers are absent from the description of the hand pose, as they do not participate in the pinching action and are, therefore, not necessary to deliver the essence of the pose.

Using too many constraints when you define a hand pose (i.e., overfitting) can produce a pose which is hard to detect. This is because your user will have to adjust her hand to a very specific posture to satisfy all the constraints. Using too few constraints when you define a hand pose (i.e., underfitting) can make it too easy for the pose to get detected, and your user may perform the pose unintentionally.

### Hand motion

As you move your hand - one of your fingertips or, alternatively, the center of your palm, traces a curve through space. We refer to this curve as a "hand motion". In our API, a hand motion is represented by the [HandMotion](https://review.docs.microsoft.com/en-us/gestures) class. A hand motion is associated with a hand part (either the center of the palm one of the fingertips) and made up of a sequence of motion building blocks. The available building blocks are illustrated below:

![HandMotion building blocks](Images\HandMotionScript.png)

As you can see, all the building blocks describe motion which is two-dimensional. In other words - the entire motion is contained within a single plane. We have introduced this limitation intentionally, in order to provide a better user experience, since unconstrained three-dimensional hand motion can be difficult to execute accurately. You can choose one of three available planes to contain your hand motion, as illustrated below:

![Hand Motion Planes](Images\MotionPlanes.png)

Once you've decided which hand part should execute the motion and chosen a plane to contain it, all that is left is to specify the motion as a sequence of motion building blocks, for example:

![Motion - simple example](Images\MotionExample.png)

### Gesture

We think of a gesture as a state-machine whose states represent hand poses, hand motions, or even other gestures. In the state-machine there are initial states and receiving states. A path starting with an initial state and ending with a receiving state represents a sequence of actions (hand poses, hand motions and hand gestures) the user must carry out in order to trigger the detection of the corresponding gesture.

In our API, a gesture is represented by the [Gesture](https://review.docs.microsoft.com/en-us/gestures) class. Following is an example of a gesture whose state-machine is a simple sequence of hand poses and hand motions:

![Gesture example](Images\GestureExample.png)

The "Slingshot" gesture in the example is made up of a single hand motion, named "Retract", and three hand poses - two instances of "NotPinching" and one instance of "Pinch". The "Slingshot" gesture corresponds to the following action: Imagine you are holding a slingshot in your left hand, now grasp its pocket with the thumb and index fingers of your right hand and pull the pocket back to stretch the slingshot band, finally - release the pocket to let the projectile fly. By following these instructions you will have executed the "Slingshot" gesture with your right hand.

## Creating gestures in Project Prague

We will now give an example illustrating how to code up a simple gesture using the Project Prague API.

> [!IMPORTANT]
> The root namespace for all Project Prague .NET entities is Microsoft.Gestures

The gesture we will implement is called "RotateRight":

![Rotate right FSM](Images\RotateRightFsm.png)

Intuitively, when performing the "RotateRight" gesture, a user would expect some object in the foreground application to be rotated right by 90°. We have used this gesture, for instance, in our [Discovery Client](https://review.docs.microsoft.com/en-us/gestures), to trigger the rotation of an image in a PowerPoint slideshow.

The following code demonstrates one possible way to define the "RotateRight" gesture:

[!code-csharp[RotateRight gesture](CodeSnippets\RotateRightGesture.cs)]

The "RotateRight" gesture is a sequence of two hand poses - "RotateSet" and "RotateGo". Both poses require the thumb and index to be open, pointing forward and not touching each other. The difference between the poses is that "RotateSet" specifies that the index finger should be above the thumb and "RotateGo" specifies it should be right of the thumb. The transition between "RotateSet" and "RotateRight", therefore, corresponds to a rotation of the hand to the right.

Note that the middle, ring and pinky fingers do not participate in the definition of the "RotateRight" gesture. This makes sense because we do not wish to constrain the state of these fingers in any way. In other words, these fingers are free to assume any pose during the execution of the "RotateRight" gesture.

Having defined the gesture, you need to hook up the event indicating gesture detection to the appropriate handler in your target application:

[!code-csharp[RotateRight triggered event subscription](CodeSnippets\RotateRightTriggeredEvent.cs)]

The detection itself is performed in the Microsoft.Gestures.Service.exe process (this is the process associated with the "Microsoft Gestures Service" window discussed above). This process runs in the background and acts as a service for gesture detection. You will need to create a [GesturesServiceEndpoint](https://review.docs.microsoft.com/en-us/gestures) instance in order to communicate with this service. The following code snippet instantiates a [GesturesServiceEndpoint](https://review.docs.microsoft.com/en-us/gestures) and registers the "RotateRight" gesture for detection:

[!code-csharp[Connect to end-point](CodeSnippets\ConnectToEndPoint.cs)]

When you wish to stop the detection of the "RotateRight" gesture, you can unregister it as follows:

[!code-csharp[Unregister gesture](CodeSnippets\UnregisterGesture.cs)]

And your handler will no longer be triggered when the user executes the "RotateRight" gesture.

When you are finished working with gestures, you should dispose the [GesturesServiceEndpoint](https://review.docs.microsoft.com/en-us/gestures) object:

[!code-csharp[Dispose gestures service](CodeSnippets\DisposeGesturesService.cs)]

Please note that in order for the above code to compile, you will need to reference the following assemblies, located in the directory indicated by the MicrosoftGesturesInstallDir environment variable:

* Microsoft.Gestures.dll
* Microsoft.Gestures.Endpoint.dll
* Microsoft.Gestures.Protocol.dll

To experiment with a full sample of a use case for the "RotateRight" gesture, please refer to the "RotateSample" in our [GitHub samples repository](https://github.com/Microsoft/Gestures-Samples). In this repository, you will also find other samples displaying more advanced applications for gestures.