# Overview

## What is project Prague?

Project Prague is an SDK (software development kit) that allows you to create NUI (natural user interface) experiences based on hand gesture input. We provide an API (application programming interface) enabling you to easily design and code up your own customized hand gestures and integrate them into your applications.

The building blocks of a gesture are hand poses and hand motions. We allow you to define any hand pose or hand motion you like using simple constraints built with plain language. You can string a sequence of hand poses and hand motions together to create a gesture. Once your gesture is defined and registered with our runtime, we will notify you whenever we detect that your user has performed the gesture with their hand. You can use handle this detection event in You can select an action to assign in response. At this point you can run the desired logic to respond to the detected gesture.

Using project Prague, you can enable your users to intuitively control music and videos, bookmark and like web content, send an emoji on IM (instant messaging) applications, interact with a digital assistants, create and run PowerPoint slideshows, manipulate three-dimensional objects and play games using their hands alone.

## Getting started with project Prague

To get project Prague running on your machine you will need to:

1. Purchase an [Intel (R) RealSense (TM) SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html). Connect the camera to a USB 3.0 port (avoid using a charging port, use an "SS" port instead) and place it below your computer monitor as illustrated in the image: ![RealSense camera desktop setup](Images\RealSenseDesktopSetup.jpg)

1. Install project Prague runtime from [this url](https://aka.ms/moriah/alef/setup). The installation will create shortcuts on your desktop to out compiled samples.Please run one of the samples to verify the your setup is correct.

## Understanding gestures in project Prague

Before you can start writing gestures, you should get familiar with the basic building blocks of a gesture - hand poses and hand motions.

### Hand pose

A hand pose refers to a snapshot of the hand at given moment. The hand pose contains a complete description of the state of the palm and the fingers in that snapshot. In our API, a hand pose is represented by the HandPose class.

A hand pose is made up of various constraints as illustrated below:

![HandPose and constraints](Images\HandPoseAndConstraints.png)

You can specify any hand pose you like by characterizing all the constraints describing the pose as illustrated below:

![HandPose examples](Images\HandPoseExample.png)

### Hand motion

By moving your finger or your palm, you can trace a curve through space. We call such a curve a hand motion. In our API, a hand motion is represented by the HandMotion class. A hand motion is associated with a hand part (either a palm or a finger) and made up of a sequence of motion building blocks. The available building blocks are illustrated below:

![HandMotion building blocks](Images\HandMotionScript.png)

An example of a hand motion described as a sequence of arc building blocks:

![Motion - simple example](Images\MotionExample.png)

### Gesture

The most basic way to think of a gesture is as a sequence of hand poses and\or hand motions. In our API, a gesture is represented by the Gesture class. A Gesture class holds a state machine which represents the sequence of hand poses and hand motions, as shown in the example below:

![Gesture example](Images\GestureExample.png)

The "SlingShot" gesture in the example is made up of two hand poses, named "NotPinching" and "Pinch", and one hand motion, named "Retract". Note that the "NotPinching" hand pose is used twice in the sequence - once at the beginning once again and at the end. Imagine holding a slingshot in your left hand, grasping its pocket with the thumb and index fingers of your right hand, pulling it back and releasing it to let the projectile fly. By following these instructions you have executed a gesture with your hand. The description of this gesture in project Prague language is given in the "SlingShot" example.