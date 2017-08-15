    private void Update()
    {
        // Step 2.2: Add highlight material to hovered object
        // Step 3: TODO, do not change hover object when grabbing
        if (HighlightMaterial)
        {
            // Stop highlighting previous hovered object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.RemoveMaterial(HighlightMaterial);
            }

            // Raycast to find the object currently under the cursor
            _hoveredGameObject =  GetHoveredObject();

            // Add highlight material to hovered object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.AppendMaterial(HighlightMaterial);
            }
        }

        // Step 3: Handle Grabbing
    }