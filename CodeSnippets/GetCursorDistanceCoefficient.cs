    private float GetCursorDistanceCoefficient()
    {
        return 1 + Input.mouseScrollDelta.y / 10;
    }