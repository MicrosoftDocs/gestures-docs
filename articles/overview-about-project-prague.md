# Overview

## What is project Prague?

Project Prague is an SDK (software development kit) that allows you to create NUI (natural user interface) experiences based on hand gesture input. We provide an API (application programming interface) enabling you to easily design and code up your own customized hand gestures and integrate them into your applications.

The building blocks of a gesture are hand poses and hand motions. We allow you to define any hand pose or hand motion you like using simple constraints built with plain language. You can string a sequence of hand poses and hand motions together to create a gesture. Once your gesture is defined and registered with our runtime, we will notify you whenever we detect that your user has performed the gesture with their hand. You can use handle this detection event in You can select an action to assign in response. At this point you can run the desired logic to respond to the detected gesture.

Using project Prague, you can enable your users to intuitively control music and videos, bookmark and like web content, send an emoji on IM (instant messaging) applications, interact with a digital assistants, create and run PowerPoint slideshows, manipulate three-dimensional objects and play games using their hands alone.

## Getting started with project Prague

To get project Prague running on your machine you will need to:

1. Purchase an [Intel (R) RealSense (TM) SR300 camera](https://click.intel.com/intelrealsense-developer-kit-featuring-sr300.html). Connect the camera to a USB 3.0 port (avoid using a charging port, use an "SS" port instead) and place it below your computer monitor as illustrated in the image: ![RealSense camera desktop setup](Images\RealSenseDesktopSetup.jpg)

1. Install project Prague runtime from [this url](aka.ms/gestures). The installation will create shortcuts on your desktop to out compiled samples.Please run one of the samples to verify the your setup is correct.