AEGIS RISING — PAUSE MENU BUTTONS

Folders:
Buttons/normal — default button state
Buttons/hover_selected — highlighted/selected state
Buttons/pressed — pressed state
Title/paused_title.png — PAUSED title graphic

Buttons included: Resume, Restart Checkpoint, Settings, Controls, Quit to Main Menu.

Unity import: select PNGs and set Texture Type = Sprite (2D and UI), Sprite Mode = Single, Filter Mode = Point (no filter) for crisp pixel-art edges, Compression = None.
For a Unity Button component, assign Normal, Highlighted, and Pressed sprites in its Transition = Sprite Swap settings. The hover/selected image is used for Highlighted and Selected states.

These are individual crops from the generated button sheet with outer black removed where connected to the crop edge. Inspect edges and adjust crop/alpha if needed for your particular background.
