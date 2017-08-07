    private Vector3 GetCursorScreenPosition()
    {
        if (IsMouseMode)
        {
            // Chapter 1.a Return mouse screen position
            return Input.mousePosition;
        }
        else
        {
            // Chapter 1.b Replace mouse screen position with Microsoft.Gestures palm position.
            var skeleton = GesturesManager.Instance.StableSkeletons[Hand.RightHand];
            if (skeleton == null)
            {
                return Vector2.zero;
            }

            // Convert PalmPosition to screen space
            var palmCamPos = Vector3.Scale(skeleton.PalmPosition, PalmUnitsScale) + PalmUnitsOffset;
            var palmWorldPos = Camera.main.transform.TransformPoint(palmCamPos);
            var palmScreenPos = (Vector2)Camera.main.WorldToScreenPoint(palmWorldPos);
            return palmScreenPos;
        }
    }