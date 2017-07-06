var gesturesService = GesturesServiceEndpointFactory.Create();
await gesturesService.ConnectAsync();
await gesturesService.RegisterGesture(rotateRight);