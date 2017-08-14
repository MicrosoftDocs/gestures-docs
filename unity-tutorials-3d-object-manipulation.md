# 3D Object Manipulation

This tutorial will introduce you to using gesture and skeleton input to enrich the user interface of the games and applications you make with Unity. In this tutorial we will create a 3D cursor controlled by the hand. We will use this cursor to select objects and move them in 3D space.

The final version of the Unity project obtained in this tutorial can be found in our open-source [samples GitHub repository](https://github.com/Microsoft/Gestures-Samples). After you clone the repository, follow these steps to run the final  product of this tutorial:

1. Launch Unity, in the **Projects** tab select **Open**.
1. Browse to the **Unity\GesturesTutorial** directory within the cloned repository.
1. When the project loads, go to the **Project** window and select the **Assets** directory.
1. Double-click the **3D Object Manipulation** scene in the **Assets** directory.
1. Press the play button (or **Ctrl+P**) to run the scene.

This tutorial assumes you have basic familiarity with the C# programming language and some experience with the Unity IDE - we expect you to know how to create projects, scenes, game objects and scripts. The tutorial will take approximately 30 minutes to complete.

## Prerequisites

Complete the [introduction tutorial](unity-tutorials-introduction.md#system-requirements).

## Step 1 - Hand Cursor

1. Open the project you've created in the [introduction tutorial](unity-tutorials-introduction.md#system-requirements). Press **Ctrl+N** to create a new scene and **Ctrl+S** to save the scene, naming it **3D Object Manipulation**.

1. Like in [step 2 of the introduction tutorial](unity-tutorials-introduction.md#step-2-connecting-to-the-gestures-service), add the **GestureManager** and **UIManager** prefabs to the scene.

1. We will start by drawing a cursor using the mouse position. Later, we will replace the mouse with the palm.

    Create an empty game object and a corresponding C# script, name both **HandCursor**. To associate them, go to the game object's **Inspector** view and drag the script to the blank area below **Add Component** (refer to [step 3 in the introduction tutorial](unity-tutorials-introduction.md#step-3---creating-a-script-that-generates-a-new-3d-primitive-in-the-scene) to read about associating a script with a game object).

1. Open the **HandCursor** script in Visual Studio (double click the script icon in the **Project** window) and replace its contents with the following code:

    [!code-csharp[HandCursor](CodeSnippets\HandCursor.cs)]

    As you can see, the **HandCursor** methods are not yet implemented. For now, they contain place-holders and comments.

1. To control the cursor using the mouse only, use the following implementation for the **GetCursorScreenPosition()** method:

    [!code-csharp[GetCursorPosition](CodeSnippets\GetCursorPosition.cs)]

    To draw the cursor in the correct position every time the screen is refreshed, replace the contents of **OnGUI()** with:

    [!code-csharp[OnGui](CodeSnippets\OnGui.cs)]

1. We will use the **HandCursor.png** texture, provided with the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage), as our cursor image. Select the **HandCursor** game object in the **Hierarchy** window, locate the **HandCursor.png** under **MicrosoftGesturesToolkit/Textures** in the **Project** window and drag-and-drop it to the **Cursor Image** box in the **Inspector** window:

    ![Set HandCursor Image](Images\UnitySetHandCursorImage.png)

1. Play the scene now. Whenever the mouse pointer is within the scene borders, you will see a red cursor following it:

    ![Cursor following mouse](Images\UnityMouseCursor.png)

1. In order to use your hand to control the cursor, we first need to obtain access to the hand-skeleton information. The [**Gestures Service**](getting-started-gestures-service.md) computes a hand-skeleton and communicates it to all subscribing clients on a frame-by-frame basis. The **GestureManager** game object in our scene acts as a client of the **Gestures Service**. **GestureManager**'s **RegisterToSkeleton()** and **UnregisterFromSkeleton()** methods allow us to subscribe and unsubscribe to the hand-skeleton stream.

    To receive hand-skeleton information whenever the **HandCursor** game object is active, override its **OnEnbale()** and **OnDisable()** methods with the following code:

    [!code-csharp[OnGui](CodeSnippets\OnEnableOnDisable.cs)]

1. The final task for this step is to convert the palm position, arriving from the **Gestures Service** in depth-camera (3D) coordinates, to screen (2D) coordinates.

    The hand-skeleton is provided in units of millimeters, in the following left-handed coordinate system:

    ![Hand skeleton coordinate system](Images\UnityHandSkeletonCoordinates.png)

    Ideally, we would like the **Main Camera** in our scene to see your hand from the perspective of your eyes. If we can achieve this - the 3D cursor's projection to the screen will follow your hand in a way that feels intuitive.

    In an attempt to approximate the desired perspective, we will use the below coefficients to map the hand-skeleton (which is given in your depth-camera's view-space) to the 3D cursor (that we want to express in our **Main Camera**'s view-space). Add these public members to **HandCursor.cs**:

    [!code-csharp[OnGui](CodeSnippets\ScaleAndOffset.cs)]

    With this preparation, we are ready to compute the actual conversion of the palm position to a cursor position. Update **GetPalmCameraPosition()** and **GetCursorScreenPosition()** with the following contents:

    [!code-csharp[OnGui](CodeSnippets\GetCursorScreenPosition.cs)]

    Note that the **PalmPosition** property of the **skeleton** corresponds to the location of the center of the hand:

    ![Palm position landmark](Images\UnityPalmPosition.png)

1. In the **Inspector** window of the **HandCursor** game object, disable the **"Is Mouse Mode"** checkbox. This will activate the "else{...}" branch of the if-statement above. play the scene and raise your right hand in front of the depth-camera. You should be able to control the cursor by moving your hand.

## Step 2 - Highlight Object under Cursor

We would like to use our cursor to move objects in the scene. On this step of the tutorial, we implement a feature that will help us recognize which object is currently under the cursor by highlighting that object.

1. We will start by filling the scene with several primitive objects.

    For convenience, we recommend you attain the viewpoint of the the **Main Camera** before you start adding new objects to the scene. Select the **Main Camera** in the **Hierarchy** window, then go to the **GameObject** menu and select **Align View with Selected**.

    To instantiate new primitives, go to the **GameObject** menu again, select **3D Object** and pick one of the primitives in the sub-menu (**Cube**, **Sphere**, etc.). Repeat this process several times, moving each new primitive to a different location in space:

    ![Fill scene with primitives](Images\UnityPopulateSceneWithPrimitives.png)

> [!TIP]
> To move an object, click on it, press **w** and than drag it using the [**Move** gizmo](https://docs.unity3d.com/Manual/PositioningGameObjects.html#move).

1. Add a private member to the **HandCursor** class. We will use this member to store the game object currently under the cursor. For brevity, we will refer to this object as "the hovered object":

    [!code-csharp[OnGui](CodeSnippets\HoveredGameObject.cs)]

    Also add the following public members. We will soon use them to highlight the hovered object:

    [!code-csharp[OnGui](CodeSnippets\HovePublicMembers.cs)]

    To find the object currently under the cursor, we will use the following implementation for the **GetHoveredObject()** private method:

    [!code-csharp[OnGui](CodeSnippets\GetHoveredObject.cs)]

    To highlight the hovered object, replace the contents of **Update()** with the following:

    [!code-csharp[OnGui](CodeSnippets\Update.cs)]

    Save all changes to the **HandCursor.cs** script.

1. We will use the **OuterGlow.mat** material, provided with the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage), to highlight the hovered object.

    Select the **HandCursor** game object in the **Hierarchy** window, locate the **OuterGlow.mat** material under **MicrosoftGesturesToolkit/Materials** in the **Project** window and drag-and-drop it to the **Highlight Material** box in the **Inspector** window:

    ![Add the highlight material](Images\UnityAddHighlightMaterial.png)

1. Play the scene and move your hand to control the cursor. Every time an object is under the cursor, it will glow with a bluish halo:

    ![Play scene with glow effect](Images\UnityGlowScene.png)

## Step 3 - Move Object in 2D Using the Mouse

On this step we will enable our cursor to "grab" an object and move it in space. For now, the motion will be implemented to a 2D surface (a plane perpendicular to the **Main Camera**). As before, we will first implement this feature to work with mouse input and then move on to support hand input.

1. In the **HandCursor.cs** script, add the following private members:

    [!code-csharp[Object Grabbing - private members](CodeSnippets\ObjectGrabbingPrivateMembers.cs)]

    and the following public Member:

    [!code-csharp[Object gerabbing - private members](CodeSnippets\ObjectGrabbingPublicMember.cs)]

    We will make use of the new members in the object grabbing and moving logic.

1. Replace the assignment to **GUI.color** in the **OnGUI()** method with:

    [!code-csharp[Object grabbing - change cursor color](CodeSnippets\ObjectGrabbingChangeCursorColor.cs)]

    This will cause the cursor to change color once we enter grab mode.

1. We will now implement the **StartGrab()** and **StopGrab()** methods. We will use this methods when we want to enter or leave the grab mode:

    [!code-csharp[Start and stop grab](CodeSnippets\StartAndStopGrab.cs)]

1. In the **Update** method, we will now decide whether to enter or leave grab mode based on mouse-click input. And, if we are in grab mode - we will move the hovered object:

    [!code-csharp[Update method - grab related code](CodeSnippets\UpdateGrab.cs)]

    As you can see, the motion of the grabbed object is currently limited to a plane. We will add support for motion in the depth direction in the next step of the tutorial.

    In the **Inspector** window of the **HandCursor** game object, enable the **"Is Mouse Mode"** checkbox. Run the scene now, hover over an object and move it by clicking-and-dragging with the left mouse button. Note how the color of the cursor changes in grab mode.

## Step 4 - Move object in 2D Using the Hand

On this step we will introduce a hand gesture that will act as the trigger to enter and leave grab mode.

1. In the **Project** window, locate the **GestureTrigger** prefab under **MicrosoftGesturesToolkit\Prefabs**. Drag and drop it to the **Hierarchy** window to create a new game object your scene.

1. Examine the **GestureTrigger** game object in the **Inspector** window, select the **Use XAML** checkbox, expand the **Gesture XAML** section and paste in the following gesture definition:

    [!code[Grab Release Gesture](CodeSnippets\GrabReleaseGesture.xaml)]

    You should arrive at the following result:

    ![GrabReleaseGesture gesture definition](Images\UnityGrabReleaseGesture.png)

    <!--here should come an illustration and a discussion of the GrabRelease gesture segments and the trick of using Index-...-Pinky only-->

1. We would like to use the **GrabReleaseGesture** in the following manner
   - **GrabPose** detection will cause the cursor to enter grab mode, i.e., it should trigger **StartGrab()**.
   - **Idle** detection will cause the cursor to leave grab mode, i.e., it should trigger **StopGrab()**.

    To implement the wiring of gesture segment detection to method invocation, click twice on the **Add Gesture Segment Event** button in the **GestureTrigger** **Inspector** user interface. You've created two new user interface sections, each will serve to wire a different segment to its corresponding method:

    - In the **Segment #1** drop down list, select the **GrabPose**, Then click the **+** sign in the **On Trigger ()** section of the UI, drag the **HandCursor** object to the **None (Object)** box and select the **StartGrab()** method from the **No Function** drop-down list:

    ![GrabPose gesture trigger](Images\UnityGrabGestureTrigger.png)

    - In the **Segment #2** drop down list, select **Idle**, Then click the **+** sign in the **On Trigger ()** section of the UI, drag the **HandCursor** object to the **None (Object)** box and select the **StopGrab()** method from the **No Function** drop-down list:

    ![Idle gesture trigger](Images\UnityIdleGestureTrigger.png)

1. In the **Inspector** window of the **HandCursor** game object, disable the **"Is Mouse Mode"** checkbox. Run the scene now, hover over an object, grab it by clinching your hand into a fist, move the object to a new location and release it by spreading your fingers apart.

## Step 5 - Move Object in 3D Space

In this step, we will add the depth dimension to the motion. Since the mouse is inherently a 2D input device, we will be using the scroll wheel to simulate the depth motion.

1. Add the following private method to the **HandCursor.cs** script:

    [!code-csharp[GetCursorDepthDelta() method](CodeSnippets\GetCursorDepthDelta.cs)]

    And update the code to move the grabbed object in the **Update()** method:

    [!code-csharp[GetCursorDepthDelta() method](CodeSnippets\GrabbingBlockOfUpdate.cs)]

1. Now play the scene, both in **Mouse Mode** and not. Now the objects can move in all 3 directions.