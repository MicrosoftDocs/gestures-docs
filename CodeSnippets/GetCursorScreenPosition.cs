    private Vector3 GetCursorScreenPosition()
    {
        if (IsMouseMode)
        {
            // Step 1.5: Return mouse screen position.
            return Input.mousePosition;
        }
        else
        {
            // Step 1.9: Replace mouse position with palm position.
            var skeleton = GesturesManager.Instance.StableSkeletons[Hand.RightHand];
            if (skeleton == null)
            {
                return Vector2.zero;
            }

            // Convert PalmPosition to screen space
            var palmCameraPosition = Vector3.Scale(skeleton.PalmPosition, PalmUnitsScale) + PalmUnitsOffset;
            var palmWorldPosition = Camera.main.transform.TransformPoint(palmCameraPosition);
            var palmScreenPosition = (Vector2)Camera.main.WorldToScreenPoint(palmWorldPosition);
            return palmScreenPosition;
        }
    }