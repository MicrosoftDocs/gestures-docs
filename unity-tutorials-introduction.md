# Introduction to Gestures in Unity®

This tutorial will introduce you to adding gestures to a Unity application. You will create a simple Unity project that generates a random 3D-primitive every time the user executes a certain gesture.

This tutorial assumes you have basic familiarity with the C# programming language. It should take you approximately 20 minutes to complete the tutorial.

The final version of the Unity project obtained in this tutorial can be found in our open-source [samples GitHub repository](https://github.com/Microsoft/Gestures-Samples). After you clone the repository, follow these steps to run the final  product of this tutorial:
1. Launch Unity, in the **Projects** tab select **Open**.
2. Browse to the **Unity\GesturesTutorial** directory within the cloned repository.
3. When the project loads, go to the **Project** window and select the **Assets** directory.
4. Double-click the **Introduction** scene in the **Assets** directory.
5. Press the play button (or **Ctrl+P**) to run the scene.

## Prerequisites

Make sure you own one of the [supported depth cameras](index.md#supported-depth-cameras) and that your PC meets the [Project Prague requirements](index.md#hardware-and-software-requirements). Once you have the required hardware, [set up Project Prague](index.md#setting-up-project-prague-on-your-machine) on your machine.

You will also need the following software tools for this tutorial

- [Unity](https://unity3d.com/get-unity/download) editor version 5.5 or higher.
- Visual Studio 2015 or later with [Visual Studio Tools for Unity](https://www.visualstudio.com/vs/unity-tools/).

Refer to our [FAQ page](faq.md#i-have-visual-studio-2017-and-i-would-like-to-use-it-as-the-c#-script-editor-for-unity-what-do-i-need-to-do?) for help with installing Visual Studio Tools for Unity.

## Step 1 - Create and Configure a New Unity Project

1. Launch the Unity editor and create a new project in a location of your choice:

    ![Create new Unity project](Images\UnityCreateNewProject.png)

    Name the project **Introduction** and select a location where you would like to place it:

    ![Name the new Project](Images\UnityNameNewProject.png)

1. Clone our [GitHub samples repository](https://github.com/Microsoft/Gestures-Samples/tree/Unity), and import our [toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage) to your project - from the **Assets** menu, select **Import Package** and **Custom Package...**:

    ![Import Project Prague toolkit](Images\UnityImportPackageMenu.png)

    Browse to the package location on your disk (**Unity\GesturesTutorial** directory within the cloned repository) and open it:

    ![Locating Project Prague Unity package](Images\UnityBrowsingToPackageLocation.png)

    Choose to **Import** all the package contents:

    ![Import full package contents](Images\UnityImportAllPackageContents.png)

1. This is a good time to save your scene - press **Ctrl+S** and give your scene a name:

    ![Save scene](Images\UnitySaveScene.png)

    We recommend you save the scene (using **Ctrl+S**) at the end of every tutorial step.

## Step 2 - Connecting to the Gestures Service

We will now establish a connection between our Unity application and the [Gestures Service](getting-started-gestures-service.md). Please make sure that your [depth camera](index.md#supported-depth-cameras) is connected to the computer and that the Gestures Service is running (launch it using the **Microsoft.Gestures.Service** shortcut on your desktop).

1. In the **Project** window of the Unity editor, browse to the **Prefabs** directory (under **MicrosoftGesturesToolkit**):

    ![Project Prague prefabs](Images\UnityProjectPraguePrefabs.png)

    We will use the **GesturesManager** prefab in order to communicate with the [Gestures Service](getting-started-gestures-service.md). Every Unity scene that works with Project Prague, must contain exactly one instance of **GesturesManager**.

    We will also use the **UIManager** prefab to display useful information about the state of the **GesturesManager**.

    Drag and drop the corresponding prefabs to your scene:

    ![Add prefabs to scene](Images\UnityAddPrefabs.png)

1. Now run the application by pressing the **play** button or using the **Ctrl+P** keyboard shortcut. If the application is able to establish a connection with the Gestures Service, you will see a green icon in the bottom right corner:

    ![Connection to service](Images\UnityConnectionToService.png)

    If, instead of the green icon, what you are seeing is the red icon

    ![Unity disconnected icon](Images\UnityDisconnectedIcon.png)

    please make sure your **Gestures Service** is running - by clicking on the **Microsoft.Gestures.Service** desktop shortcut - and try playing the scene again.

> [!IMPORTANT]
> Don't forget to exit the play mode (by pressing the **play** button or **Ctrl+P** again) before you move to the next step. Any changes you make to the scene while it is playing will be discarded once you exit play mode.

## Step 3 - Creating a Script that Generates a New 3D-Primitive in the Scene

To demonstrate how gestures can be used in a Unity game, we will now add a Unity game object and associate it with C#-script that generates a new 3D-primitive in the scene. We will later use a method in this script as the callback\event-handler which will be executed each time a certain gesture is detected.

1. Use the **GameObject** menu to  **Create Empty** and rename the new object to **PrimitiveFactory**:

    ![Create new game object](Images\UnityCreateGameObject.png)

    In the **Project** window, create a new folder under **Assets** and name it **Scripts**. This folder will contain the code which will be executed upon gesture detection.

    ![Create Scripts folder](Images\UnityCreateNewFolder.png)

    In the **Scripts** folder, create a new script named **PrimitiveFactory** (no need to add the .cs extension to the script name):

    ![Create new script](Images\UnityCreateScript.png)

1. To associate the **PrimitiveFactory** script with the **PrimitiveFactory** game object, drag and drop the script to the game object's **Inspector** window:

    ![Associate script](Images\UnityAssociateScript.png)

    In the **Project** window of, double click the **PrimitiveFactory** script icon to edit the script in Visual Studio. Once open, replace the contents of PrimitiveFactory.cs with the following code:

    [!code-csharp[PrimitiveFactory](CodeSnippets\PrimitiveFactory.cs)]

1. Run the application and use your mouse pointer to left-click anywhere within the scene frame. Every click will instantiate a new randomly generated 3D-primitive:

    ![Ptimitives being generateded](Images\UnityObjectSpawn.png)

> [!TIP]
> Take a look at the **Console** window of the Unity editor. You will find various messages, warnings and errors there, generated by both our code and the Unity IDE.

## Step 4 - Using a Gesture to Generate New 3D-Primitives in the Scene

In this final step, we will create the necessary wiring so that you can use a gesture to trigger the 3D-primitive generation.

1. The **GestureTrigger** prefab provided with our Unity toolkit allows you to designate a method in your project to be executed whenever some gesture is detected.

    Drag and drop the **GestureTrigger** prefab from the **Project** window to your scene in the **Hierarchy** window:

    ![Add GestureTrigger prefab](Images\UnityAddGestureTriggerPrefab.png)

1. Select the **GestureTrigger** game object in the **Hierarchy** window, and turn to the **Inspector** window:

    ![GestureTrigger inspector](Images\UnityGestureTriggerInspector.png)

    The sections of the UI, numbered 1 to 4 above, allow you to configure a gesture and its effect:
    1. Check this box to specify a custom gesture in XAML language, or
    2. Select a gesture from a set of predefined stock-gestures that we have prepared for your convenience.
    3. Specify which method is to be executed when the gesture is detected.
    4. Specify which method is to be executed when a certain [state in the gesture state-machine](index.md#gesture) is identified.

    Visit our [overview page](index.md#gesture) to read more about the concept and structure of a gesture in Project Prague.

    In this tutorial we will focus on sections 2 and 3. Namely, we will wire the predefined **"tap"** stock-gesture to trigger the **CreateRandomPrimitive()** method of the **PrimitiveFactory** game object. Sections 1 and 4 of the **GestureTrigger** user interface will be covered in subsequent tutorials.

1. Make sure **GestureTrigger** is still the selected object in the **Hierarchy** window and choose the **tap** gesture from the **Stock Gesture** drop-down list in the **Inspector** window:

    ![Set tap as the stock gesture](Images\UnityGestureTriggerTap.png)

1. To make the functions of **PrimitiveFactory** available for **GestureTrigger**, click the **+** sign in the **On Trigger ()** pane, then drag and drop the **PrimitiveFactory** game object from the **Hierarchy** window to the **None (object)** box in the **Inspector**:

    ![Add PrimitiveFactory to objects](Images\UnityAddingEventHandler.png)

    Finally, to designate **CreateRandomPrimitive()** as the handler method for the **tap** gesture, click the **No Function** drop-down in the **Inspector** window of **GestureTrigger**, select **PrimitiveFactory** and **CreateRandomPrimitive ()**:

    ![Hook CreateRandomPrimitive() event handler](Images\UnityHookingEventHandler.png)

1. Run the application now. You should be still able to generate a new 3D-primitive using the left mouse button. Now, you should be also able to do that using the **tap** gesture (perform the gesture with your right hand):

    ![Tap Gesture Animation](Images\UnityTapGesture.png)