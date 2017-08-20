    private Vector3 GetCursorScreenPosition()
    {
        // Step 1.3: Replace mouse position with palm position.
        var palmCameraPosition = GetPalmCameraPosition();
        var palmWorldPosition = Camera.main.transform.TransformPoint(palmCameraPosition);
        var palmScreenPosition = (Vector2)Camera.main.WorldToScreenPoint(palmWorldPosition);
        return palmScreenPosition;
    }