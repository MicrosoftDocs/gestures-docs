            var plane = new Plane(Camera.main.transform.forward, _hoveredGO.transform.position);
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            float distanceFromCamera;
            plane.Raycast(ray, out distanceFromCamera);
            // Step 5.1: scale depth according to cursor's depth delta
            distanceFromCamera *= 1 + GetCursorDepthDelta();
            _hoveredGO.transform.position = ray.GetPoint(distanceFromCamera);