# ASoD's VanillaUpgraded

Source code for ASoD's Vanilla Upgraded mod.

If you use any of my code for your mods, all I ask is that you give credit for the portion you took.

# What does this mod do?

The goal of this mod is to upgrade the vanilla experience with tons of quality of life stuff. Current features are:

- Toggles for disabling adaptation and snapping in the build grid.
- New HUD window in world view that shows apoapsis, periapsis, eccentricity, and angle of your rocket.
- Timewarp now stops when entering a planet's SoI.*

**New Unit Displays:**

- Re-implements megameters (`Mm`) as a distance unit
- Adds `km/s` as a velocity unit
- Adds `kt` as a mass and thrust unit

**New Keybinds:**

- L to launch and skip warnings in build space
- Slash to instantly stop timewarp
- Backtick to set thrust to 0.1%
- Semicolon to timewarp to periapsis/apoapsis/escape*

Mod features can be individually disabled in the config window in the game's settings menu.

Tons more will be added in the future.

\*Timewarp stuff is inconsistent due to floating point errors and me being bad at math. If I find a better implementation I will use it.

# Installation

This mod uses SFS Modloader version 1.1.2 made by dani0105, which can be found [here.](https://github.com/105-Code/SFS-Modloader)

1. Install the modloader.
2. Download the latest ZIP.
3. Extract the root folder to `Spaceflight Simulator_Data\MODS`. Do not rename it or take the DLL out.


**This mod is untested on Mac.** Use at your own risk.
