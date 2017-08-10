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

    Create an empty game object and a corresponding C# script, name both **HandCursor**. To associate them, go to the game object's **Inspector** view and drag the script to the blank area below **Add Component** (refer to [step 3 in the introduction tutorial](unity-tutorials-introduction.md#step-3---creating-a-script-that-generate-new-3d-primitives-in-the-scene) to read about associating a script with a game object).

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

1. The final task for this step is to express the palm position, arriving from the **Gestures Service** in depth-camera (3D) coordinates, in screen (2D) coordinates.

    The hand-skeleton is provided in units of millimeters, in the following left-handed coordinate system:

    ![Hand skeleton coordinate system](Images\UnityHandSkeletonCoordinates.png)

    Ideally, we would like the **Main Camera** in our scene to see your hand from the perspective of your eyes. If we can achieve this - the 3D cursor's projection to the screen will follow your hand in a way that feels intuitive.

    In an attempt to approximate the desired perspective, we will use the below coefficients to map the hand-skeleton (which is given in depth-camera view-space) to the 3D cursor (that we want to know in **Main Camera** view-space). Add these public members to **HandCursor.cs**:

    [!code-csharp[OnGui](CodeSnippets\ScaleAndOffset.cs)]

    With this preparation, we are ready to compute the actual conversion of the palm position to a cursor position. Update **GetCursorScreenPosition()** with the following contents:

    [!code-csharp[OnGui](CodeSnippets\GetCursorScreenPosition.cs)]

    Note that the **PalmPosition** property of the **skeleton** corresponds to the location of the center of the hand:

    ![Palm position landmark](Images\UnityPalmPosition.png)

1. In the **Inspector** window of the **HandCursor** game object, disable the **"Is Mouse Mode"** checkbox. This will activate the "else{...}" branch of the if-statement above. play the scene and raise your right hand in front of the depth-camera. You should be able to control the cursor by moving your hand.