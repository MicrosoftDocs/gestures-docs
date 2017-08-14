    private void OnGUI()
    {
        // Step 1.5: Draw cursor texture at the cursor's position on the screen.
        var cursorPosition = (Vector2)GetCursorScreenPosition();

        // Invert y direction
        cursorPosition.y = Screen.height - cursorPosition.y;

        // prepare bounds for cursor texture
        var bounds = new Rect(cursorPosition - 0.5f * CursorSize, CursorSize);

        // Change the tint color to match our cursor mode
        var originalColor = GUI.color;

        // Step 3. Change cursor color when grab mode is on.
        // TODO Add a condition when setting GUI.color
        GUI.color = CursorTint;
        GUI.DrawTexture(bounds, CursorImage);
        GUI.color = originalColor;
    }