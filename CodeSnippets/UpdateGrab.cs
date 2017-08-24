    private void Update()
    {
        // Add highlighting material to hovered object
        // Do not change hovered object when grabbing
        if (HighlightMaterial && !_isGrabbing)
        {
            // Stop highlighting old hover object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.RemoveMaterial(HighlightMaterial);
            }

            // Raycast and find object under cursor
            _hoveredGameObject = GetHoveredObject();

            // Add highlighting material to hovered object
            if (_hoveredGameObject)
            {
                _hoveredGameObject.AppendMaterial(HighlightMaterial);
            }
        }

        // Start grabbing object when left mouse button is down
        if (Input.GetMouseButtonDown(0))
        {
            StartGrab();
        }

        // Stop grabbing object when left mouse button is up
        if (Input.GetMouseButtonUp(0))
        {
            StopGrab();
        }

        // Handle motion
        if (_isGrabbing)
        {    
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            _lastObjectDistance *= GetCursorDistanceCoefficient();
            _hoveredGameObject.transform.position = ray.GetPoint(_lastObjectDistance);
        }
    }