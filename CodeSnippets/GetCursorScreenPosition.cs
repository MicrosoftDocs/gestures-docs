    private Vector3 GetPalmCameraPosition()
    {
        // Step 1.9: Convert palm position from depth-camera space to Main-Camera space
        var skeleton = GesturesManager.Instance.StableSkeletons[Hand.RightHand];
        if (skeleton == null)
        {
            return Vector3.zero;
        }
        return Vector3.Scale(skeleton.PalmPosition, PalmUnitsScale) + PalmUnitsOffset;
    }

    private Vector3 GetCursorScreenPosition()
    {
        if (IsMouseMode)
        {
            // Step 1.5: Return mouse screen position.
            return Input.mousePosition;
        }
        
        // Step 1.9: Replace mouse position with palm position.
        var palmCameraPosition = GetPalmCameraPosition();
        var palmWorldPosition = Camera.main.transform.TransformPoint(palmCameraPosition);
        var palmScreenPosition = (Vector2)Camera.main.WorldToScreenPoint(palmWorldPosition);
        return palmScreenPosition;
    }