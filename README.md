# dMcCowan_CITA312_GalaxyStrike

#Controls
WASD to move
Left Shift to Boost (Increases movement speed while held)

This lab uses a master timeline to set keyframes for the player and enemy to animate along. Key frames are set by adding animation tracks to the guideline, setting the timeline to a desired time/frame, and then moving the animated  objects to the desired positions. It also uses the new input system which is nice in that code calls generalized bindings rather than specific keycodes. Lerp was applied to smooth the rotation applied by player movement. Clamp was used to keep the player within the view of the camera.
