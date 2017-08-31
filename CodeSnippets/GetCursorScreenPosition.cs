    private Vector3 GetCursorScreenPosition()
    {
        // Replace mouse position with palm position.
        var palmCameraPosition = GetPalmCameraPosition();
        var palmWorldPosition = Camera.main.transform.TransformPoint(palmCameraPosition);
        var palmScreenPosition = (Vector2)Camera.main.WorldToScreenPoint(palmWorldPosition);
        return palmScreenPosition;
    }