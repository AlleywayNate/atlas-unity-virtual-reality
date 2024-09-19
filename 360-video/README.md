# 360 Video Viewer

## Overview

The 360 Video Viewer is an interactive VR application designed to play 360-degree videos with a user-friendly interface. It allows users to switch between different videos using a scrollable UI, with smooth transitions and fade effects.

## Features

- **Video Playback**: Seamless playback and pausing of 360-degree videos.
- **UI Integration**: User interface with scrollable buttons to select and play videos.
- **Fade Effects**: Smooth fade-in and fade-out transitions during video changes.
- **VR Compatibility**: Optimized for VR platforms with intuitive controls and interactions.

## Getting Started

### Setup Instructions

1. **Prepare the Scene**:
   - Attach the `VideoManager360` script to a GameObject in your scene.
   - Configure video materials and assign them in the Inspector.
   - Set up a `VideoPlayer` component for video playback.

2. **Assign UI Buttons**:
   - Drag and drop UI buttons into the `Buttons` field of the `VideoManager360` script.
   - Link the `OnClick` events to the `SetSelectedVideoIndex` method of the script.

3. **Build Settings**:
   - Configure build settings for your target platform (e.g., VR, Windows).
   - Ensure all scenes are included in the build.

### Usage

- **Play Video**: Click on a button in the ScrollView to select and start a video.
- **Pause Video**: The video can be paused with a separate control (if implemented).

### Known Issues

- **UI Scaling in VR**: Ensure that UI elements are properly scaled and positioned in different VR environments.
- **Video Playback Performance**: Test on various hardware to ensure optimal performance.

## Testing Results

### Performance

- **Frame Rate**: Maintained a consistent frame rate of 90 FPS.
- **Resource Usage**: CPU and GPU usage remained within acceptable limits.

### Stability

- **Crashes**: No crashes were encountered during testing.
- **Freezes**: The application handled transitions and interactions smoothly.

### User Experience

- **UI Functionality**: UI elements were responsive and correctly positioned.
- **Ease of Use**: Users were able to navigate and select videos without difficulty.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

## Contact

For any questions or further information, please contact [your-email@example.com].
