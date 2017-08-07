# 3D Hand Cursor

This tutorial will introduce you to using gesture and skeleton input to enrich the user interface of the games and applications you make with Unity. In this tutorial we will create a 3D cursor controlled by the hand. We will use this cursor to select objects and move them in 3D space.

The final version of the Unity project you will arrive at by the end of this tutorial can be found in [our open source GitHub repository](https://github.com/Microsoft/Gestures-Samples).

This tutorial assumes you have basic familiarity with the C# programming language. The tutorial will take approximately 30 minutes to complete.

## System Requirements

Check out the [introduction tutorial page](unity-tutorials-introduction.md#system-requirements) for the system requirements.

## Step 1 - Hand Cursor

Follow [step 1 from the introduction tutorial](unity-tutorials-introduction.md#step-1-create-and-configure-a-new-unity-project) to create a new Unity project and import the [Project Prague Unity Toolkit assets](https://www.assetstore.unity3d.com/en/) (alternatively, you can add a new scene to the project you've created in the introduction tutorial - this can be done by selecting **New Scene** in the **File** menu). When done, follow [step 2 from the introduction tutorial](unity-tutorials-introduction.md#step-2-connecting-to-the-gestures-service) to add the **GestureManager** and **UIManager** prefabs to your scene.

We will start by drawing a cursor based on the mouse position. We will later replace the mouse position with the hand position.

Create an empty game object and a corresponding C# script, name both **HandCursor** and associate between them by adding the script to the game object's components (refer to [step 3 in the introduction tutorial](unity-tutorials-introduction.md#step-3-creating-a-acript-that-generate-new-3d-primitives-in-the-scene) for guidance).

Open the **HandCursor** script in Visual Studio and replace its contents with the following code:

[!code-csharp[HandCursor](CodeSnippets\HandCursor.cs)]

As you can see, for now, the **HandCursor** methods are not yet implemented, they just contain place-holder comments.

We will start by adding the logic to control the cursor using the mouse only. Replace the **GetCursorScreenPosition()** method with the following code:

[!code-csharp[GetCursorPosition](CodeSnippets\GetCursorPosition.cs)

To draw the cursor in the correct position every time the screen is refreshed, replace the contents of **OnGUI()** with:

[!code-csharp[OnGui](CodeSnippets\OnGui.cs)

Now, we would like to associate the **HandCursor.png** image asset we've prepared for you in advance with the cursor. To this end, select the **HandCursor** game object in the **Hierarchy** window, locate the **HandCursor.png** under **GesturesToolkit/Textures** in the **Project** window and drag-and-drop it to the **Cursor Image** box in the **Inspector** window:

![Set HandCursor Image](Images\UnitySetHandCursorImage.png)