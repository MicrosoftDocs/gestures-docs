    private Vector3 GetPalmCameraPosition()
    {
        // Step 2.2: Convert palm position from depth-camera space to Main-Camera space
        var skeleton = GesturesManager.Instance.StableSkeletons[Hand.RightHand];
        if (skeleton == null)
        {
            return Vector3.zero;
        }
        return Vector3.Scale(skeleton.PalmPosition, PalmUnitsScale) + PalmUnitsOffset;
    }