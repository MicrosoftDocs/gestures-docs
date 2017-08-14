    private void Update()
    {
        // Chapter 2.a Add highlight material to hovered object
        // Chapter 3. Do not change hover object when grabbing
        if (HighlightMaterial && !_isGrabbing)
        {
            // Stop highlighting old hover object
            if (_hoveredGO)
                _hoveredGO.RemoveMaterial(HighlightMaterial);

            // Raycast and find object under cursor
            _hoveredGO = GetHoverObject();

            // Add highlight material to hovered object
            if (_hoveredGO)
                _hoveredGO.AppendMaterial(HighlightMaterial);
        }

        // Chapter 3. Handle Grabbing
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
            var plane = new Plane(Camera.main.transform.forward, _hoveredGO.transform.position);
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            float distanceFromCamera;
            plane.Raycast(ray, out distanceFromCamera);
            _hoveredGO.transform.position = ray.GetPoint(distanceFromCamera);
        }
    }