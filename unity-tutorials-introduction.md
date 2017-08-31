# Introduction to Gestures in Unity®

This tutorial will teach you how to use the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage) in order to add gestures to a Unity application. We will create a simple Unity project that generates and destroys 3D-primitives every time the user executes certain gestures. We will then demonstrate how to use the **CameraGesturesController** prefab from our Unity toolkit in order to move the main scene camera with gestures.

This tutorial assumes you have basic familiarity with the C# programming language. We do not assume familiarity with the Unity environment.

This tutorial will take approximately 30 minutes to complete.

## Download the Final Result

The final Unity project obtained in this tutorial can be found in our open-source samples repository on [GitHub](https://github.com/Microsoft/Gestures-Samples). After you clone the repository, follow these steps to run the application:

1. Launch Unity, in the **Projects** tab select **Open**.
1. Browse to the [**Unity\Tutorials\Introduction**](https://github.com/Microsoft/Gestures-Samples/tree/master/Unity/Introduction) directory within the cloned repository.
1. Press the play button (or **Ctrl+P**) to run the scene.

## Prerequisites

Make sure you own one of our [supported depth cameras](index.md#supported-depth-cameras) and that your PC meets the [Project Prague requirements](index.md#hardware-and-software-requirements). Once you have all your hardware in place, [set up Project Prague](index.md#setting-up-project-prague-on-your-machine) on your machine.

You will also need the following software tools for this tutorial

- [Unity](https://unity3d.com/get-unity/download) editor version 5.5 or higher.
- Visual Studio 2015 or later with [Visual Studio Tools for Unity](https://www.visualstudio.com/vs/unity-tools/).

Refer to our [FAQ page](faq.md#i-have-visual-studio-2017-and-i-would-like-to-use-it-as-the-c-script-editor-for-unity-what-do-i-need-to-do) for help with installing Visual Studio Tools for Unity.

## Step 1 - Create and Configure a New Unity Project

1. Launch the Unity editor and create a new project in a location of your choice:

    ![Create new Unity project](Images\UnityCreateNewProject.png)

    Name the project **Introduction** and select a location where you would like to place it:

    ![Name the new Project](Images\UnityNameNewProject.png)

1. Clone our [GitHub samples repository](https://github.com/Microsoft/Gestures-Samples/tree/master/Unity), and import our [toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage) to your project - from the **Assets** menu, select **Import Package** and **Custom Package...**:

    ![Import Project Prague toolkit](Images\UnityImportPackageMenu.png)

    Browse to the package location on your disk (**Unity** directory within the cloned repository) and open it:

    ![Locating Project Prague Unity package](Images\UnityBrowsingToPackageLocation.png)

    Choose to **Import** all the package contents:

    ![Import full package contents](Images\UnityImportAllPackageContents.png)

1. This is a good time to save your scene - press **Ctrl+S** and give your scene a name:

    ![Save scene](Images\UnitySaveScene.png)

> [!TIP]
> It's a good practice to save the scene from time to time to avoid losing your work. We recommend you save the scene (using **Ctrl+S**) at the end of every tutorial step.

## Step 2 - Connecting to the Gestures Service

We will now establish a connection between our Unity application and the [**Gestures Service**](getting-started-gestures-service.md). Please make sure that your [depth camera](index.md#supported-depth-cameras) is connected to the computer and that the **Gestures Service** is running (launch it using the **Microsoft.Gestures.Service** shortcut that was created on your desktop during [Project Prague installation](index.md#setting-up-project-prague-on-your-machine)).

1. In the **Project** window of the Unity editor, browse to the **Prefabs** directory (under **MicrosoftGesturesToolkit**):

    ![Project Prague prefabs](Images\UnityProjectPraguePrefabs.png)

    We will use the **GesturesManager** prefab in order to communicate with the [Gestures Service](getting-started-gestures-service.md). Every Unity scene that works with Project Prague must contain exactly one instance of the **GesturesManager**.

    We will also use the **UIManager** prefab to display useful information about the state of connection to the **Gestures Service**.

    Drag and drop the corresponding prefabs to your scene:

    ![Add prefabs to scene](Images\UnityAddPrefabs.png)

1. Now play the scene by pressing the **play** button or using the **Ctrl+P** keyboard shortcut. Make sure that the icon in the bottom right corner is in the **Detecting** state:

    ![Connection to service](Images\UnityConnectionToService.png)

    This indicates that our application was able to establish a connection with the **Gestures Service** and that gesture detection is active.
    
    If, instead, the reported state is **Disconnected**:

    ![Unity disconnected icon](Images\UnityDisconnectedIcon.png)

    Please launch your **Gestures Service** (use the **Microsoft.Gestures.Service** desktop shortcut). The state should change to **Detecting** within several seconds of launching.

    If the reported state is **Connected**:

    ![Unity connected icon](Images\UnityConnected.png)

    Please make sure that the **Enable Detection** checkbox in the **Microsoft Gestures Service** window is checked:

    ![Gestures Service - enable detection](Images\UnityGesturesServiceEnableDetection.png)

> [!IMPORTANT]
> Don't forget to exit the play mode (by pressing the **play** button or **Ctrl+P** again) before you move to the next step. Any changes you make to the scene while it is playing will be discarded once you exit play mode.

## Step 3 - Creating a Script to Generate 3D-Primitives in the Scene

To demonstrate how gestures can be used in a Unity game, we will start by adding a new game object and associating it with a C#-script. We will program the script to generate a new 3D-primitive in the scene on every left mouse button click. On the next step, we will specify a gesture and configure it to trigger the primitive-generating code in our script.

1. Use the **GameObject** menu to **Create Empty**, rename the new object to **PrimitiveFactory**:

    ![Create new game object](Images\UnityCreateGameObject.png)

    In the **Project** window, create a new folder under **Assets** and name it **Scripts**. This folder will contain the code which will be executed upon gesture detection.

    ![Create Scripts folder](Images\UnityCreateNewFolder.png)

    In the **Scripts** folder, create a new script named **PrimitiveFactory** (no need to add the .cs extension to the script name):

    ![Create new script](Images\UnityCreateScript.png)

1. To associate the **PrimitiveFactory** script with the **PrimitiveFactory** game object, drag and drop the script to the blank area below the **Add Component** button in the game object's **Inspector** window:

    ![Associate script](Images\UnityAssociateScript.png)

    In the **Project** window, double click the **PrimitiveFactory** icon to edit the script in Visual Studio. Once open, replace the contents of PrimitiveFactory.cs with the following code:

    [!code-csharp[PrimitiveFactory](CodeSnippets\PrimitiveFactory.cs)]

1. Play the scene and use your mouse pointer to left-click anywhere within the scene frame. Every click will instantiate a new randomly generated 3D-primitive:

    ![Ptimitives being generateded](Images\UnityObjectSpawn.png)

> [!TIP]
> Take a look at the **Console** window of the Unity editor. You will find there various messages, warnings and errors, generated by the various entities in our scene and the Unity platform itself.

## Step 4 - Using a Gesture to Generate New 3D-Primitives in the Scene

On this step, we will create the necessary wiring so that you can use a gesture to trigger the 3D-primitive generation.

1. The **GestureTrigger** prefab provided with our Unity toolkit allows you to designate a method in your project to be executed whenever some gesture is detected.

    Drag and drop the **GestureTrigger** prefab from the **Project** window to your scene in the **Hierarchy** window:

    ![Add GestureTrigger prefab](Images\UnityAddGestureTriggerPrefab.png)

1. Select the **GestureTrigger** game object in the **Hierarchy** window, and turn to the **Inspector** window:

    ![GestureTrigger inspector](Images\UnityGestureTriggerInspector.png)

    The sections of the UI (user interface), numbered 1 to 4 above, allow you to configure a gesture and its effect:

    <br><table>
    <tr><td>1</td><td>Select in which way you would like to specify your gesture - either pick a gesture from a list of predefined "stock" gestures or specify a custom gesture in XAML language.</td></tr>
    <tr><td>2</td><td>Specify which method is to be executed when the gesture is detected.</td></tr>
    <tr><td>3</td><td>Specify which method is to be executed when a certain <a href="index.md#gesture">state in the gesture state-machine</a> is detected.</td></tr>
    </table>

    Visit our [overview page](index.md#gesture) to read more about the concept and structure of a gesture in Project Prague.

    In this tutorial we will focus on sections 1 and 2. Namely, we will wire the predefined **"Tap"** stock-gesture to trigger the **CreateRandomPrimitive()** method of the **PrimitiveFactory** game object. Using XAML to specify gestures and section 3 of the **GestureTrigger** UI will be covered in the [3D Object Manipulation tutorial](unity-tutorials-3d-object-manipulation-hand.md) tutorial.

1. Make sure **GestureTrigger** is still the selected object in the **Hierarchy** window and choose the **Tap** gesture from the **Stock Gesture** drop-down list in the **Inspector** window:

    ![Set Tap as the stock gesture](Images\UnityGestureTriggerTap.png)

1. To make the methods of **PrimitiveFactory** available for **GestureTrigger**, click the **+** sign in the **On Trigger ()** pane, then drag and drop the **PrimitiveFactory** game object from the **Hierarchy** window to the **None (object)** box in the **Inspector**:

    ![Add PrimitiveFactory to objects](Images\UnityAddingEventHandler.png)

    Finally, to designate **CreateRandomPrimitive()** as the handler method for the **Tap** gesture, click the **No Function** drop-down in the **Inspector** window of **GestureTrigger**, select **PrimitiveFactory** and **CreateRandomPrimitive ()**:

    ![Hook CreateRandomPrimitive() event handler](Images\UnityHookingEventHandler.png)

1. Play the scene now. You should still be able to generate a new 3D-primitive using the left mouse button. In addition, you should now be able to do that with the **Tap** gesture (perform with your **right** hand):

    ![Tap Gesture Animation](Images\UnityTapGesture.png)

    If you cannot successfullly use the **Tap** gesture to generate new primitives in the scene, please refer to the [troubleshooting section](#troubleshooting).

## Step 5 - Using a Gesture to Destroy all 3D-Primitives in the Scene

On this step, we will add a gesture to clear all previously generated 3D-primitives from the scene.

1. First, add a method named **DestroyAllPrimitives()** to our **PrimitiveFactory** script (PrimitiveFactory.cs should still be open in Visual Studio):

    [!code-csharp[DestroyAllPrimitives](CodeSnippets\DestroyAllPrimitives.cs)]

1. Before we wire the new method to a gesture, we will test it using the right mouse button. Replace the existing **Update()** method in the **PrimitiveFactory** script with the following code:

    [!code-csharp[UpdateDestroyPrimitives](CodeSnippets\UpdateDestroyPrimitives.cs)]

1. Play the scene. Create several primitives by clicking on the left mouse button. Destroy all primitives by clicking the right button.

1. We will now wire the **Finger Snap** gesture to invoke the **DestroyAllPrimitives()** method, like we did in [step 4](#step-4---using-a-gesture-to-generate-new-3d-primitives-in-the-scene):

    - Add another **GestureTrigger** game object to the scene.
    - In the **Inspector** view of the new **GestureTrigger** game object, select the **Finger Snap** gesture from the **Stock Gesture** drop-down list.
    - In the **On Trigger ()** pane, create a new element by pressing **+** sign. Drag and drop the **PrimitiveFactory** game object to the **None (Object)** box to associate it with the new **On Trigger ()** element.
    - Finally, click on the **No Function** drop-down list and select the **DestroyAllPrimitives()** of the **PrimitiveFactory** object.

1. Our **Discovery Client** demo application uses the **Finger Snap** gesture to open the start menu. Note that we are also using this gesture in our Unity application. You should disable or close the **Discovery Client** because we don't want **Finger Snap** to have any side-effects outside of Unity. To disable - click on the Project Prague tray icon and choose **Disable**:

    ![Disable the Discovery Client](Images\UnityDisableDiscoClient.png)

    You can always follow the same steps to re-enable the **Discovery Client**.

1. Now run the scene. Generate a few primitives using the **Tap** gesture and destroy them using the **Finger Snap** gesture (perform with your **right** hand):

    ![Snap gesture state machine](Images\UnitySnapGesture.png)

## Step 6 - Using a Gesture to Control the Camera

On this step we will use a Project Prague toolkit prefab to control the position of the main camera in the scene with gestures.

1. In the **Project** window, locate the **CameraGesturesController** prefab under the **MicrosoftGesturesToolkit\Prefabs** directory. Drag and drop it to your scene:

    <!-- Image that I'll take after Moshe renames the prefab -->

1. Play the scene. Now, in addition to creating and destroying objects, you can control the camera using the following **right hand** gesture:

    ![GrabReleaseGesture](Images\UnityGrabReleaseGestureStateMachine.png)

    Clinching your hand into a fist (**InitSpreadPose** → **GrabPose** transition) will cause the camera to "snap" to the hand - allowing you to tumble and dolly the camera by moving your fist through space.

    Releasing the clinch by spreading your fingers apart (**GrabPose** → **FinalSpreadPose** transition) will cause the camera to stop tracking your hand.

1. If you are curious, examine the **CameraGesturesController** game object in the **Inspector** window. Note that it has a **Gesture Trigger** component. We used this component to wire the different states in the **GrabReleaseGesture** to various methods in the **CameraManipulation** script (found in **MicrosoftGesturesToolkit\Scripts** directory).

    To learn more about specifying custom gestures with XAML and wiring their states to methods in a game object, refer to [step 3](unity-tutorials-3d-object-manipulation-hand.md#step-3---grab-and-move-object-using-gestures) of the [3D Object Manipulation tutorial](unity-tutorials-3d-object-manipulation-hand.md).

## Troubleshooting

If you've reached the end of [Step 4](#step-4---using-a-gesture-to-generate-new-3d-primitives-in-the-scene) and the **Tap** gesture is not working for you, please play the Unity scene, open the **Microsoft Gestures Service** window and verify the following:

![Microsoft Gestures Window](Images\UnityTroubleshooting.png)

1. When you bring your hand close to your depth camera, you can see your hand in the **image** section of the **Microsoft Gestures Service** window, with colorful arrows indicating the estimated positions of the fingers and palm. If you don't see such an image, you are probably experiencing camera issues - please refer to our [camera troubleshooting](troubleshooting-camera.md) page.
1. **UnityApp** appears in the list of **Clients** and **Unity_TapGesture** appears in the sub-list of gestures associated with the **UnityApp** client. If this is not the case, please verify that
    - You have the green **Connected** icon in the bottom right corner of your screen in Unity (see [step 2](#step-2---connecting-to-the-gestures-service)).
    - You have selected the correct gesture, **Tap**,  in the **GestureTrigger** user interface (see [step 4](#step-4---using-a-gesture-to-generate-new-3d-primitives-in-the-scene)).
1. When the Unity window is in the foreground and you execute the **Tap** gesture, the **TimeLine** associated with **Unity_TapGesture** should advance. If this is not the case, you are probably not executing the gesture correctly - make sure you are using your **right** hand and performing the **Tap** motion with your **thumb** and **index** fingers only.

If you still cannot use the **Tap** gesture to generate new 3D-primitives in the scene, please leave a comment on this page, and we will do our best to provide help.