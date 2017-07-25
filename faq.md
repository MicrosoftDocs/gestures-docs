# Frequently Asked Questions

### Does Project Prague SDK expose the vector data for the palm\finger positions and directions?

The SDK provides both the high level abstraction of the [gestures as they are described in the overview](index.md#gesture) above and also the raw skeleton we estimate. This skeleton is light-weight, namely, it exposes the palm & fingertip location and direction vectors (for the palm  - we also include an orientation vector to fix the full six degrees of freedom).

Depending on your needs, you could either use our simplistic high-level gesture specification language or weave in the use of the raw skeleton stream.

For an example of using the skeleton stream, refer to [our 3D camera code sample](https://github.com/Microsoft/Gestures-Samples/tree/master/Camera3D).