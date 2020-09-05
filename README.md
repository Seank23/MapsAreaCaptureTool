# MapsAreaCaptureTool

![MapsAreaCaptureTool](https://github.com/Seank23/MapsAreaCaptureTool/blob/master/Images/CaptureTool1.PNG)

A simple tool to help plan out large area captures in Google Maps. Select the area you want to capture and the tool will determine what individual captures should be made at a desired quality level.

## How To Use
Pan around the map using the right mouse button (RMB) to find the area you would like to capture. Hold the left mouse button (LMB) and drag to select an area, your selection will be shown as a red rectangle on release and the bounded upper-left and lower-right coordinates of your selection will be entered respectively.
Next select a quality setting and overlap value and click Calculate, the tool will spilt your selected area into tiles representing the captures you should make to cover the area. Hovering over each tile will show the URL that will display this area in Google Maps, double clicking in the tile will copy this to the clipboard.
<br>
Additional tiles can be added by selecting a new area and clicking Calculate, if Align Captures is checked these will be aligned on the same grid as previous captures. To remove tiles, select the tiles you wish to remove and click Remove.

## Current Limitations
- Aligning captures of different sizes may not work correctly.
