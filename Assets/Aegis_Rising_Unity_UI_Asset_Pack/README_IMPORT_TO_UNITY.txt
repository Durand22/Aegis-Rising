AEGIS RISING — UNITY UI ASSET STARTER PACK

Contents
- 21 organized folders for title/menu panels, level select, settings, controls, inventory, shop, pause, game over, victory, dialogs, HUD, abilities, projectiles, trails, impacts, pickups, transitions and effects.
- Buttons/Normal, Buttons/Hover_Selected and Buttons/Pressed contain separately cropped button examples.
- Unity_Reference_Panels contains the full generated catalog and larger menu-panel reference crops.

IMPORTANT
These are cropped assets from a generated catalog sheet, not a professionally authored source atlas. Some crops retain nearby labels/background pixels, and state samples may be approximate. The catalog itself is not a set of independent transparent layers. Check each crop in Unity and remove/replace any background or text you do not want. For production UI, rebuild text as Unity TextMeshPro labels and use Unity Button transition states (Normal, Highlighted, Pressed, Disabled) with separate sprites.

Unity import suggestions
1. Extract this ZIP under Assets/Art/UI/AegisRising/.
2. Select PNG files in Unity and set Texture Type = Sprite (2D and UI).
3. For pixel-art scaling, use Filter Mode = Point (no filter), Compression = None, and disable mip maps.
4. Build buttons with Image + Button components; assign Normal, Highlighted and Pressed sprites in the Button Sprite State.
5. Use sliced borders (Sprite Editor -> 9-slice) only for clean panel/button frames with suitable margins.
6. Use Canvas Scaler -> Scale With Screen Size for responsive menus.

Naming examples: btn_play_brush_normal.png, hud_portrait_and_bars.png, skill_dash.png, trail_long.png, impact_large.png.
