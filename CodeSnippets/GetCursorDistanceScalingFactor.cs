    private float GetCursorDistanceScalingFactor()
    {
        return 1 + Input.mouseScrollDelta.y / 10;
    }