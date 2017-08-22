    private Vector3 GetPalmCameraPosition()
    {
        // Convert palm position from depth-camera space to Main-Camera space
        var skeleton = GesturesManager.Instance.SmoothDefaultSkeleton;
        if (skeleton == null)
        {
            return Vector3.zero;
        }
        return Vector3.Scale(skeleton.PalmPosition, PalmUnitsScale) + PalmUnitsOffset;
    }