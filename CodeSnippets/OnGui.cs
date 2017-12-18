    private void OnGUI()
    {
        var cursorPosition = (Vector2)GetCursorScreenPosition();

        // Invert y direction
        cursorPosition.y = Screen.height - cursorPosition.y;

        // Prepare bounds for cursor texture
        var bounds = new Rect(cursorPosition - 0.5f * CursorSize, CursorSize);

        // Change the tint color to match our cursor mode
        var originalColor = GUI.color;        
        GUI.color = CursorTint;
     
        // Draw cursor texture at the cursor's position on the screen.
        GUI.DrawTexture(bounds, CursorImage);

        GUI.color = originalColor;
    }