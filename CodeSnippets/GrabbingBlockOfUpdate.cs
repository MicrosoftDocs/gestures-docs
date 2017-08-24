            var plane = new Plane(Camera.main.transform.forward, _hoveredGameObject.transform.position);
            var ray = Camera.main.ScreenPointToRay(GetCursorScreenPosition());
            float distanceFromCamera;
            plane.Raycast(ray, out distanceFromCamera);
            // Scale distance according to cursor's distance coefficient
            distanceFromCamera *= GetCursorDistanceCoefficient();
            _hoveredGameObject.transform.position = ray.GetPoint(distanceFromCamera);