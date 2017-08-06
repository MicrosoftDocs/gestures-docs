# Introduction to Gestures in Unity®

This tutorial will introduce you to adding gestures to a Unity application. You will create a simple Unity project that generates a random 3D-primitive every time the user executes a certain gesture. The final version of the Unity project you will arrive at by the end of this tutorial can be found in [our open source GitHub repository](https://github.com/Microsoft/Gestures-Samples).

This tutorial assumes you have basic familiarity with the C# programming language. It should take you approximately 30 minutes to complete the tutorial.

## System Requirements

First, make sure your PC meets the [Project Prague requirements](index.md#hardware-and-software-requirements) and [install Project Prague](index.md#setting-up-project-prague-on-your-machine).

You will need the following tools for this tutorial

- [Unity](https://unity3d.com/get-unity/download) editor version 5.5 or higher.
- [Visual Studio 2015](https://www.visualstudio.com/vs/older-downloads/) with [Visual Studio Tools for Unity](https://www.visualstudio.com/vs/unity-tools/).

## Step 1 - Create and Configure a New Unity Project

Launch the Unity editor and create a new project in a location of your choice:

![Create new unity project](Images\UnityCreateNewProject.png)

Download the Project Prague Toolkit from the [Unity asset store](https://www.assetstore.unity3d.com/en/), and import it to your project:

![Import Project Prague toolkit](Images\UnityImportPackage.png)

At this point, you should give your scene a name and save it:

![Save scene](Images\UnitySaveScene.png)

## Step 2 - Connecting to the Gestures Service

We will now establish a connection between our Unity application and the [Gestures Service](getting-started-gestures-service.md). Please make sure that your [depth camera](index.md#supported-depth-cameras) is connected to the computer and that the Gestures Service is running (launch it using the **Microsoft.Gestures.Service** shortcut on your desktop).

In the **Project** window of the Unity editor, browse to the **Prefabs** directory (under **Project Prague**):

![Project Prague prefabs](Images\UnityProjectPraguePrefabs.png)

We will use the **GesturesManager** prefab in order to communicate with the [Gestures Service](getting-started-gestures-service.md). Every Unity project that works with gestures, must have exactly one **GesturesManager** instance in the scene.

We will also use the **UIManager** prefab to display useful information about the state of the **GesturesManager**.

Drag and drop the corresponding prefabs to your scene:

![Add prefabs to scene](Images\UnityAddPrefabs.png)

Now run the application by pressing the **play** button or using the Ctrl+P keyboard shortcut. If the application is able to establish a connection with the Gestures Service, you will see a green icon in the bottom right corner:

![Connection to service](Images\UnityConnectionToService.png)

If you do not see the green icon, you are most likely experiencing camera related problems. Please refer to our [camera troubleshooting page](troubleshooting-camera.md) for further assistance.

## Step 3 - Creating a Script that Generate New 3D-Primitives in the Scene

To demonstrate how gestures can be used in a Unity game, we will now add a Unity game object that has a C#-script function that generates a new 3D-primitive in the scene. We will later use this function as a callback\event-handler that will be executed each time a certain gesture is detected.

Use the **GameObject** menu to  **Create Empty** and rename the new object to **PrimitiveFactory**:

![Create new game object](Images\UnityCreateGameObject.png)

 In the **Project** window, create a new folder under **Assets** and name it **Scripts**. This folder will contain the code which will be executed upon gesture detection.

![Create Scripts folder](Images\UnityCreateNewFolder.png)

In the **Scripts** folder, create a new script named **PrimitiveFactory** (no need to add the .cs extension to the script name):

![Create new script](Images\UnityCreateScript.png)

To associate the **PrimitiveFactory** script with the **PrimitiveFactory** game object, drag and drop the script to the game object's **Inspector** window:

![Associate script](Images\UnityAssociateScript.png)

In the **Project** window of the Unity editor, double click on the **PrimitiveFactory** script icon to open it in Visual Studio. Replace the contents of PrimitiveFactory.cs with the following code:

[!code-csharp[PrimitiveFactory](CodeSnippets\PrimitiveFactory.cs)]

Run the application and use your mouse pointer to left-click anywhere in the scene. Every click will instantiate a new randomly generated 3D-primitive:

![Ptimitives being generateded](Images\UnityObjectSpawn.png)

## Step 4 - Using a Gesture to Generate New 3D-Primitives in the Scene

In this final step, we will create the necessary wiring such that a gesture can be used to perform the 3D-primitive generation.

The purpose of the **GestureTrigger** prefab provided with the [Project Prague Unity Toolkit](https://www.assetstore.unity3d.com/en/) is to designate any function in your Unity project as a response to the detection of a certain gesture.

Drag and drop the **GestureTrigger** prefab from the **Project** window to your scene in the **Hierarchy** window:

![Add GestureTrigger prefab](Images\UnityAddGestureTriggerPrefab.png)

Select the newly created **GestureTrigger** object in the **Hierarchy** window and examine its features in the **Inspector** window:

![GestureTrigger inspector](Images\UnityGestureTriggerInspector.png)

The sections numbered 1 to 4 above allow you to configure a gesture and its corresponding handler function:

1. Check this box to specify a custom gesture in XAML language, or
1. Select a gesture from a set of predefined stock-gestures that we have prepared for your convenience.
1. Specify which functions need to be executed when the gesture is detected.
1. Specify which functions need to be executed when a certain state in the gesture state-machine is identified.

Visit our [overview page](index.md#gesture) to read more about the concept and structure of a gesture in Project Prague.

In this tutorial we will focus on the sections numbered 2 and 3. Namely, we will wire the predefined **tap** stock-gesture to trigger the **CreateRandomPrimitive()** method of the **PrimitiveFactory** game object. Sections 1 and 4 of the **GestureTrigger** user interface will be covered in succeeding tutorials.

Make sure **GestureTrigger** is still the selected object in the **Hierarchy** window and choose the **tap** gesture from the **Stock Gesture** drop-down list in the **Inspector** window:

![Set tap as the stock gesture](Images\UnityGestureTriggerTap.png)

To make the functions of **PrimitiveFactory** available for **GestureTrigger**, click the **+** sign in the **On Trigger ()** pane, then drag and drop the **PrimitiveFactory** game object from the **Hierarchy** window to the **None (object)** box in the **Inspector**:

![Add PrimitiveFactory to objects](Images\UnityAddingEventHandler.png)

Finally, to make **CreateRandomPrimitive()** run every time the **tap** gesture is detected, in the **Inspector** window of **GestureTrigger** - click the **No Function** drop-down, select **PrimitiveFactory** and **CreateRandomPrimitive ()**:

![Hook CreateRandomPrimitive() event handler](Images\UnityHookingEventHandler.png)

Run the application now. You should be able to generate new 3D-primitives by either clicking the left mouse button or performing the **tap** gesture with your right hand:

![Tap gesture animation](Images\UnityTapGesture.gif)