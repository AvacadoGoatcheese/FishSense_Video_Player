# FishSense_Video_Player
Video Player for Fishsense that can display multiple videos as well as pixel data on mouse

# Usage
Add videos using the onscreen buttons, and use the video playback controls at the bottom.

Then, to display pixel data, press the button at the top right to start doing so. Then, the location of your cursor (in pixels) will be displayed for the video you are hovering over. Use the toggle at the top of the screen to display either one or two videos.

Currently, this is written in WPF (Windows Presentation Foundation), which has no Mac/Unix port. The open source alternative to WPF, Avalonia, has no built in support for Video as of now. If future support is added to Avalonia, the project will ultimately be ported to Avalonia to allow for portability.
