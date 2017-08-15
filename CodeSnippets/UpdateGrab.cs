    private void Update()
    {
        // Step 2.2: Add highlight material to hovered object
        // Step 3:   Do not change hover object when grabbing
        if (HighlightMaterial && !_isGrabbing)
        {
            // Stop highlighting old hover object
            if (_hoveredGameObject)
                _hoveredGameObject.RemoveMaterial(HighlightMaterial);

            // Raycast and find object under cursor
            _hoveredGameObject = GetHoveredObject();

            // Add highlight material to hovered object
            if (_hoveredGameObject)
                _hoveredGameObject.AppendMaterial(HighlightMaterial);
        }

        // Step 3: Handle Grabbing
        if (IsMouseMode)
        {
            // Start grabbing object when left mouse button is down
            if (Input.GetMouseButtonDown(0))
                StartGrab();

            // Stop grabbing object when left mouse button is up
            if (Input.GetMouseButtonUp(0))
                StopGrab();
        }

        if (_isGrabbing)
        {    
            // move hovered object to follow the cursor position, while staying in the same plane
            var plane = new Plane(Camera.main.transform.forward, _hoveredGameObject.transform.position);
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            float distanceFromCamera;
            plane.Raycast(ray, out distanceFromCamera);
            _hoveredGameObject.transform.position = ray.GetPoint(distanceFromCamera);
        }
    }