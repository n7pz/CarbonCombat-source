# Carbon Combat

**An ongoing source recovery and preservation project for Carbon Combat.**

> HEADS UP: **Work in progress.** The project is still being restored. Some assets and shaders have been fixed, but other issues remain.

## About

Carbon Combat is an older Unity-based game developed by CarbonTech Software LLC.

This project aims to recover, restore, and preserve the game's original Unity project so that it can be examined, opened, and worked on again.

The immediate goal is to establish a usable baseline of the recovered project before moving on to further development.

## Project Status

**Current checkpoint: Initial restoration — preparing for Git publication**

- [x] Recover the Unity project and its assets
- [x] Fix compilation errors
- [x] Fix critical car textures and prefabs
- [x] Fix critical water shaders
- [x] Restore remaining shaders
- [ ] Continue testing and documenting issues
- [ ] Establish a stable baseline for future development

This checklist reflects the current restoration work and will change as the project progresses.

A partially restored project is still worth preserving. Remaining issues are documented as work in progress rather than treated as a reason to delay publishing the source.

## Technical Information

**Target Unity version: Unity 3.5.2f2 and/or Unity3.5.6f4**

This repository targets Unity 3.5.2f2 and 3.5.6f4 specifically. Opening or upgrading the project directly in a different Unity version may cause compatibility problems, break assets or scripts, or result in editor instability.

For the initial restoration, use the target version rather than attempting an engine upgrade.

## Opening the Project

1. Clone or download this repository.
2. Obtain a compatible Unity 3.5.2f2 editor.
3. Open the recovered project using that editor.
4. Allow Unity to import the project assets.
5. Check the Console for errors and consult the repository's Issues page for known problems.

**Legacy editor:** [Unity 3.5.2 installer](https://beta.unity3d.com/download/UnitySetup-3.5.2.exe) [Unity 3.5.6 installer](https://beta.unity3d.com/download/UnitySetup-3.5.6.exe)

If the direct installer link is unavailable, let me know.

> **Note:** The project is not guaranteed to work out of the box. Some shaders, assets, and other components may still require restoration.

## Scope

This repository focuses on the recovered original Unity project and its restoration.

It is intended to provide a baseline for preservation, investigation, and continued work on the original project. Future development beyond that baseline may be maintained separately.

## Contributing and Bug Reports

Bug reports, technical findings, and contributions that help preserve or restore the project are welcome.

When reporting an issue, please include:

- A description of the problem.
- The Unity version being used.
- Steps to reproduce the issue.
- Relevant Console errors or screenshots, where applicable.

Where possible, distinguish issues inherited from the original game from problems introduced during restoration.

## Credits and Permission

Carbon Combat was originally developed by **CarbonTech Software LLC**.

Andrew at CarbonTech Software LLC has granted permission to publish the project's code and assets and to use the Carbon Combat name for this project, including future modernized distributions.

The original developers deserve credit for their work.

## Third-Party Components

The project may contain third-party libraries, plugins, or other components subject to their own licenses and redistribution terms.

Applicable third-party notices and licensing requirements must be respected. Permission to publish the recovered project does not necessarily override the separate terms of third-party components.

## Disclaimer

This is an independent preservation and restoration project. It is a work in progress and is not presented as a finished, fully functional revival of the original game.

Its purpose is to preserve the recovered project, document restoration work, and make further investigation possible.

## Known Issues

The project is still undergoing restoration. The following issues are known at this stage:

- **Remaining shaders:** Not all shaders have been restored, and some may render incorrectly. Vanilla scenes are expected to load, but custom maps are currently not working.
- **Legacy multiplayer and backend functionality:** The recovered executable and project may contain inherited bugs and incomplete functionality associated with legacy Photon networking or the original backend. The extent of these issues remains under investigation.
- **Legacy Unity compatibility:** The project targets Unity 3.5.2f2. Compatibility with modern Unity versions is not guaranteed.
- **Untested functionality:** Not every scene, asset, or gameplay system has been fully tested since recovery.
- **Additional issues:** Further problems may be discovered as restoration and testing continue.


This list is not exhaustive and will be updated as new issues are identified and existing ones are resolved.

If you encounter a reproducible problem, please check the [GitHub Issues](../../issues) page before opening a new report.

---

*More documentation will be added as the restoration progresses.*