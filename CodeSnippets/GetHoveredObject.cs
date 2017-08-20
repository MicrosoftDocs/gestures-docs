    private GameObject GetHoveredObject()
    {
        // Step 2.2: Cast a ray from camera towards the cursor.
        var cursorPosition = GetCursorScreenPosition();
        var ray = Camera.main.ScreenPointToRay(cursorPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance: 1000, layerMask: Mask.value))
        {
            return hit.collider.gameObject;
        }
        return null;
    }