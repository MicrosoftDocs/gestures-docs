    private Vector3 GetCursorScreenPosition()
    {
        if (IsMouseMode)
        {
            // Step 1.a Return mouse position on screen.
            return Input.mousePosition;
        }
        else
        {
            // Step 1.b Replace mouse position with palm position.
            return Vector3.zero;
        }
    }