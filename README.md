# MapsAreaCaptureTool

![MapsAreaCaptureTool](https://github.com/Seank23/MapsAreaCaptureTool/blob/master/Images/CaptureTool1.PNG)

A simple tool to help plan out large area captures in Google Maps. Select the area you want to capture and the tool will determine what individual captures should be made at a desired quality level.

## Features
- Simple and easy to use GUI with interactive map.
- Support for various quality levels, or enter a custom camera altitude.
- Add areas of different capture quality in the project.
- Ability to specify an amount of overlap between captures tiles.
- Ability to align all capture tiles to a single grid.
- Ability to centre capture tiles around selection.

## How To Use
- Pan around the map using the right mouse button (RMB) to find the area you would like to capture. 
- Hold the left mouse button (LMB) and drag to select an area, your selection will be shown as a red rectangle on release and the bounded upper-left and lower-right coordinates of your selection will be entered respectively.
- Next select a quality setting and overlap value and click Calculate, the tool will spilt your selected area into tiles representing the captures you should make to cover the area. 
- Hovering over each tile will show the URL that will display this area in Google Maps, double clicking in the tile will copy this to the clipboard.
- Additional tiles can be added by selecting a new area and clicking Calculate, if Align Captures is checked these will be aligned on the same grid as previous captures. To remove tiles, select the tiles you wish to remove and click Remove.
- Once you have calculated the captures you need to make, you can save the project to open later by going to File - Save As and entering a name for your project. The file can be opened again by going to File - Open

## Setting Descriptions
- Quality: Specify the quailty of each tile, based on camera altitude (zoom level) in Google Maps. Preset values are: Low - 1000m, Medium - 500m, High - 250m, Ultra - 100m
- Overlap: Specifies the amount of overlap between adjacent captures, increasing this will make capture tiles smaller (makes them closer together to ensure they overlap when captured). Measured in percent of tile length/height.
- Align Captures: Aligns all capture tiles to a single grid to make adding additional tiles easier.
- Centre to Selection: Centres capture tiles around the selection if they do not fit inside, may by overriden by Align Captures if this is enabled.

## Current Limitations
- Aligning capture tiles can be buggy, especially with tiles of differing sizes.
- Red selection rectangle only visible after selection has been made.
