var rotateSet = new HandPose("RotateSet", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                          new FingertipPlacementRelation(Finger.Index, RelativePlacement.Above, Finger.Thumb),
                                          new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb));

var rotateGo = new HandPose("RotateGo", new FingerPose(new[] { Finger.Thumb, Finger.Index }, FingerFlexion.Open, PoseDirection.Forward),
                                        new FingertipPlacementRelation(Finger.Index, RelativePlacement.Right, Finger.Thumb),
                                        new FingertipDistanceRelation(Finger.Index, RelativeDistance.NotTouching, Finger.Thumb));

var rotateRight = new Gesture("RotateRight", rotateSet, rotateGo);