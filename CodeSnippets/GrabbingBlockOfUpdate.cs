            var plane = new Plane(Camera.main.transform.forward, _hoveredGameObject.transform.position);
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            float distanceFromCamera;
            plane.Raycast(ray, out distanceFromCamera);
            // scale depth according to cursor's depth delta
            distanceFromCamera *= 1 + GetCursorDepthDelta();
            _hoveredGameObject.transform.position = ray.GetPoint(distanceFromCamera);