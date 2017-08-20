    private void Update()
    {
        // Step 2.2: Add highlighting material to hovered object
        if (HighlightMaterial)
        {
            // Stop highlighting previous hovered object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.RemoveMaterial(HighlightMaterial);
            }

            // Raycast to find the object currently under the cursor
            _hoveredGameObject =  GetHoveredObject();

            // Add highlighting material to hovered object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.AppendMaterial(HighlightMaterial);
            }
        }
    }