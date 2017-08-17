# 3D Object Manipulation (Mouse)

This tutorial serves as a preparation for the [3D Object Manipulation (Hand)](unity-tutorials-3d-object-manipulation.md) tutorial. In this tutorial, we will use existing Unity features to create a mouse-controlled cursor capable of moving objects in a 3D scene. In the [3D Object Manipulation (Hand)](unity-tutorials-3d-object-manipulation.md) tutorial, we will replace the mouse for hand gestures and motions.

The final version of the Unity project obtained in this tutorial can be found in our open-source [samples GitHub repository](https://github.com/Microsoft/Gestures-Samples). After you clone the repository, follow these steps to run the final product of this tutorial:

1. Launch Unity, in the **Projects** tab select **Open**.
1. Browse to the **Unity\GesturesTutorial** directory within the cloned repository.
1. When the project loads, go to the **Project** window and select the **Assets** directory.
1. Double-click the **3D Object Manipulation (Mouse)** scene in the **Assets** directory.
1. Press the play button (or **Ctrl+P**) to run the scene.

## Prerequisites

This tutorial assumes you have basic familiarity with the C# programming language and some experience with the Unity IDE - we expect you to know how to create projects, scenes, game objects and scripts. The tutorial will take approximately 30 minutes to complete.

## Step 1 - Create the MouseCursor Game Object

1. Open the project you've created in the [introduction tutorial](unity-tutorials-introduction.md#system-requirements) or create a new Unity project. If you choose to create a new project - refer to [step 1 in the introduction tutorial](unity-tutorials-introduction.md#step-1---create-and-configure-a-new-unity-project) to import the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage).

1. Press **Ctrl+N** to create a new scene and **Ctrl+S** to save the scene, naming it **3D Object Manipulation (Mouse)**.

1. Create an empty game object and a corresponding C# script, name both **MouseCursor**. To associate them, go to the game object's **Inspector** view and drag the script to the blank area below the **Add Component** button (refer to [step 3 in the introduction tutorial](unity-tutorials-introduction.md#step-3---creating-a-script-that-generates-a-new-3d-primitive-in-the-scene) to read about associating a script with a game object).

1. Open the **MouseCursor** script in Visual Studio (double click the script icon in the **Project** window) and replace its contents with the following code:

    [!code-csharp[MouseCursor](CodeSnippets\MouseCursor.cs)]

    As you can see, the **MouseCursor** methods are not yet implemented - they contain place-holders and comments.

1. To make the cursor follow the mouse pointer, replace the **GetCursorScreenPosition()** method in **MouseCursor.cs** with the following contents:

    [!code-csharp[GetCursorPosition](CodeSnippets\GetCursorPosition.cs)]

    To draw the cursor in the correct position every time the screen is refreshed, replace the contents of **OnGUI()** in **MouseCursor.cs** with:

    [!code-csharp[OnGui](CodeSnippets\OnGui.cs)]

1. We will use the **PragueCursor.png** texture, provided with the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage), as our cursor image. Select the **MouseCursor** game object in the **Hierarchy** window, locate the **PragueCursor.png** under **MicrosoftGesturesToolkit/Textures** in the **Project** window and drag-and-drop it to the **Cursor Image** box in the **Inspector** window:

    ![Set MouseCursor Image](Images\UnitySetMouseCursorImage.png)

1. Play the scene now. Whenever the mouse pointer is within the scene borders, you will see a red cursor following it:

    ![Cursor following mouse](Images\UnityMouseCursor.png)

## Step 2 - Highlight Object under Cursor

We would like to use our cursor to move objects in the scene. On this step of the tutorial, we implement a feature that will help us recognize which object is currently under the cursor by highlighting that object.

1. We will start by filling the scene with several primitive objects.

    For convenience, we recommend you attain the viewpoint of the the **Main Camera** before you start adding new objects to the scene. Select the **Main Camera** in the **Hierarchy** window, then go to the **GameObject** menu and select **Align View with Selected**.

    To instantiate new primitives, go to the **GameObject** menu again, select **3D Object** and pick one of the primitives in the sub-menu (**Cube**, **Sphere**, etc.). Repeat this process several times, moving each new primitive to a different location in space:

    ![Fill scene with primitives](Images\UnityPopulateSceneWithPrimitives.png)

> [!TIP]
> To move an object, click on it, press **w** and than drag it using the [**Move** gizmo](https://docs.unity3d.com/Manual/PositioningGameObjects.html#move).

1. Add a private member to the **MouseCursor** class. We will use this member to store the game object currently under the cursor. For brevity, we will refer to this object as "the hovered object":

    [!code-csharp[HoveredGameObject](CodeSnippets\HoveredGameObject.cs)]

    Also add the following public members. We will soon use them to highlight the hovered object:

    [!code-csharp[HovePublicMembers](CodeSnippets\HoverPublicMembers.cs)]

    To find the object currently under the cursor, we will use the following implementation for the **GetHoveredObject()** private method:

    [!code-csharp[GetHoveredObject](CodeSnippets\GetHoveredObject.cs)]

    To highlight the hovered object, replace the contents of **Update()** with the following:

    [!code-csharp[Update](CodeSnippets\Update.cs)]

    Save all changes to the **MouseCursor.cs** script.

1. We will use the **OuterGlow.mat** material, provided with the [Project Prague toolkit for Unity](https://github.com/Microsoft/Gestures-Samples/blob/master/Unity/Microsoft.Gestures.Toolkit.unitypackage), to highlight the hovered object.

    Select the **MouseCursor** game object in the **Hierarchy** window, locate the **OuterGlow.mat** material under **MicrosoftGesturesToolkit/Materials** in the **Project** window and drag-and-drop it to the **Highlight Material** box in the **Inspector** window:

    ![Add the highlight material](Images\UnityAddHighlightMaterial.png)

1. Play the scene and move around with the cursor. Every time an object is under the cursor, it will glow with a bluish halo:

    ![Play scene with glow effect](Images\UnityGlowScene.png)

## Step 3 - Move Object in 3D Using the Mouse

On this step we will enable our cursor to "grab" an object and move it in space. For now, the motion will be restricted to a 2D plane. In the [final step](#Step-5---move-object-in-3d-space) we will add support for motion in the third dimension.

1. In the **MouseCursor.cs** script, prepare the following private member:

    [!code-csharp[Object Grabbing - private members](CodeSnippets\ObjectGrabbingPrivateMembers.cs)]

    And the following public Member:

    [!code-csharp[Object gerabbing - private members](CodeSnippets\ObjectGrabbingPublicMember.cs)]

1. Replace **OnGUI()** method with:

    [!code-csharp[Object grabbing - change cursor color](CodeSnippets\ObjectGrabbingChangeCursorColor.cs)]

    This will cause the cursor to change color to **GrabCursorTint** when it enters grab mode.

1. We are now ready to implement the **StartGrab()** and **StopGrab()** methods:

    [!code-csharp[Start and stop grab](CodeSnippets\StartAndStopGrab.cs)]

1. In the **Update()** method, we would like to add the following functionality:
    - Enter (leave) grab mode whenever the left mouse button is pressed (released) while an object is being hovered.
    - When in grab mode - the hovered object should follow the cursor.

    To achieve this, modify the **Update()** method as follows:

    [!code-csharp[Update method - grab related code](CodeSnippets\UpdateGrab.cs)]

1. Run the scene now, hover over an object and move it by pressing the left mouse button and dragging. Note that the color of the cursor changes to green in grab mode.

1. We will enable the grabbed object to move in the depth dimension. We will use the scroll wheel to control this dimension.

    Replace the contents of **GetCursorDepthDelta()** with the following:

    [!code-csharp[GetCursorDepthDelta() method](CodeSnippets\GetCursorDepthDelta.cs)]

1. We will now update the code that moves the grabbed object to take the cursor's "depth delta" into account. In the **Update()** method, replace the **IsGrabbing** if-block with:

    [!code-csharp[GetCursorDepthDelta() method](CodeSnippets\GrabbingBlockOfUpdate.cs)]

1. Try running the scene now. You should be able to move the grabbed object in all three dimensions, using the scroll wheel to move in the depth dimension.