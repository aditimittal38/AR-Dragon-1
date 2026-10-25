# AR Dragon - ISE 2 Progress

This is the working log for extending the ISE 1 AR Dragon project for ISE 2. Update the status and evidence as implementation is completed. Use this file later to prepare the final Word report; do not describe planned work as completed work.

## Assignment

The ISE 2 brief asks us to take the ISE 1 project and implement the VRTK method covered in Module 5. The Module 5 slides describe adding a VR camera rig, making objects interactable, adding locomotion, and customizing interactions.

## Current project status

Rechecked after the fresh pull on 2026-10-25:

- Unity project is using Unity 6.5.10f1 and URP.
- Target development/render machine is a Mac with an Apple M1 chip. Run the XR simulator in the Unity Editor on that Mac using keyboard and mouse; a headset is not required for the planned simulation.
- The project contains a Charizard glTF model and prefab, with an Animator, Rigidbody, and `CharizardController` attached.
- `SampleScene` contains an AR Session, XR Origin, AR Tracked Image Manager, AR camera components, and a Fixed Joystick prefab.
- The tracked-image manager has the `Charizard` reference image library assigned, and `ARTrackedImageSpawner` has the Charizard prefab assigned.
- `ARTrackedImageSpawner` instantiates Charizard on a newly detected image. `CharizardController` uses the joystick to move Charizard and trigger its flying animation.
- In `CharizardController`, the animation condition requires both joystick axes to be nonzero; straight horizontal or vertical joystick movement may move Charizard without triggering the flying animation.
- AR Foundation and ARCore are package dependencies. The two custom C# scripts show no current editor diagnostics.
- This is an AR Foundation/ARCore mobile AR setup. No VRTK or OpenXR package, tracked VR controller rig, grab/release interaction, or VR locomotion was found. XR Interaction Toolkit 3.0.11 has now been added to the package manifest; Unity still needs to resolve/import it.
- The scene wiring is present, but it has not been run or verified on a phone/headset in this audit.
- No VR headset is available. The chosen route is Unity's XR Device Simulator with XR Interaction Toolkit, which Module 5 lists as an alternative to VRTK. This is not a literal VRTK implementation and must be described accurately in the submission.

## Minimal implementation target

Preserve the existing AR scene and use the Charizard asset as the subject for a minimal editor-simulated XR demonstration in a separate scene. XR Interaction Toolkit is the selected Module 5 alternative because its XR Device Simulator drives simulated HMD/controllers with keyboard and mouse. Do not call this VRTK; the assignment wording specifically mentions VRTK, so disclose the alternative clearly.

- [x] Charizard model and prefab are present in the fresh pull.
- [x] User selected editor simulation and the XR Interaction Toolkit alternative.
- [x] Add XR Interaction Toolkit 3.0.11 to the package manifest; package resolution is still pending.
- [x] `VRDragonInteraction.cs` written — attaches to Charizard alongside `XRGrabInteractable`; triggers fly animation on grab, resets on release.
- [ ] Import XRI Starter Assets and XR Device Simulator samples in Unity Package Manager.
- [ ] Create a separate VR scene with XR Origin (Action-Based) rig and XR Device Simulator.
- [ ] Add Box Collider + XRGrabInteractable + VRDragonInteraction to Charizard prefab copy in that scene.
- [ ] Add Teleportation Area and Locomotion System for movement.
- [ ] Run in Play mode; capture screenshots of grab and teleport.

The existing mobile joystick is not a substitute for XR controller interaction. Record that testing used simulated input and not a physical headset.

## Unity Editor Setup Steps

The XR package is in the manifest, but the sample assets and demo scene still need to be imported in Unity:

1. On the Mac M1, open this project with Unity 6.5.10f1 and wait for Package Manager to resolve XR Interaction Toolkit 3.0.11. Use the matching Editor version if available; avoid upgrading the project just to resolve packages.
2. In Window > Package Manager, select XR Interaction Toolkit and import the `Starter Assets` and `XR Device Simulator` samples.
3. Create a new scene named `XRSimulatorDemo`; do not overwrite `SampleScene`.
4. Add the Starter Assets `XR Origin (XR Rig)` prefab and the `XR Device Simulator` prefab to the new scene.
5. Add a floor and the Starter Assets `Teleportation Environment` prefab. This prefab is configured for the rig's teleport interactor/provider.
6. Add the Charizard prefab. On its root, add a Box Collider and XR Grab Interactable; keep its existing Rigidbody.
7. Enter Play mode. Use the simulator's displayed key bindings to move the simulated head/controllers, grab Charizard, and teleport. Save screenshots only after each behavior visibly works.

The XR Device Simulator sample is designed for Editor testing and uses the Input System. If the sample rig or teleportation prefab differs in the installed package version, use that version's Starter Assets Demo Scene as the reference and record the actual setup in this log. The existing ARCore scene is still a mobile AR setup; the Mac M1 note applies to the separate simulated XR demo, not an ARCore macOS build.

## Implementation log

| Date | Change / test | Evidence | Status |
| --- | --- | --- | --- |
| 2026-10-25 | Inspected the initial workspace copy before the fresh pull. | Initial snapshot showed the default URP scene and settings; superseded by the fresh-pull audit below. | Superseded |
| 2026-10-25 | Rechecked project after fresh pull. | Found Charizard model, AR Foundation/ARCore scene setup, tracked-image spawner, animation/controller, and joystick. No VRTK setup; runtime behavior not device-tested. | Complete |
| 2026-10-25 | Selected editor simulation with the XR Interaction Toolkit alternative and added XRI 3.0.11 to `Packages/manifest.json`. | Manifest parses as JSON; Unity package resolution and scene setup remain pending. | In progress |
| 2026-10-25 | Created `Assets/Scripts/VRDragonInteraction.cs`. | Script uses `XRGrabInteractable` events (`selectEntered`/`selectExited`) to toggle `flyParam` animator bool. Requires `XRGrabInteractable` + `Animator` on the same GameObject. | Complete |

Add one row for each meaningful implementation step or test. Record the Unity version, headset/runtime, and any setup issue that affects the result.

## Evidence to collect for the final Word report

Save clear screenshots under `Documentation/Screenshots/` and note the actual filenames here. Capture the Unity hierarchy/Inspector for setup evidence and the running application for behavior evidence.

- [ ] XR Interaction Toolkit sample setup and XR Device Simulator rig in the Unity editor.
- [ ] Dragon scene and interactable configuration in the Inspector.
- [ ] Dragon being grabbed/moved and released in the running application.
- [ ] Locomotion working in the running application.
- [ ] Existing AR scene detecting the reference image and displaying the animated Charizard on a phone.
- [ ] Any errors or limitations encountered, with a brief explanation.

## Report outline

1. **Title and objective** - AR Dragon ISE 2: applying VRTK to the ISE 1 project.
2. **Relevant theory** - XR interaction concepts; tracked rigs; interactable objects; locomotion; note that XRI is used as a Module 5 alternative to VRTK.
3. **Tools and setup** - Unity version, XR Interaction Toolkit version, simulator controls, packages, and scene configuration.
4. **Implementation** - What was added and how the Dragon interaction and locomotion work.
5. **Screenshots and testing** - Use the evidence listed above; caption each image and state what it demonstrates.
6. **Result, limitations, and conclusion** - What worked, what could not be tested, and what was learned.

## Unity Editor steps (VRScene setup)

1. **File > New Scene** → save as `Assets/Scenes/VRScene.unity`.
2. Delete the default camera.
3. **GameObject > XR > XR Origin (Action-Based)** — this adds XR Origin, Camera Offset, Main Camera, Left/Right Controllers, and XR Interaction Manager.
4. In **Window > Package Manager**, find XR Interaction Toolkit → **Samples** → import **Starter Assets** and **XR Device Simulator**.
5. Drag the `XR Device Simulator` prefab (from `Assets/Samples/XR Interaction Toolkit/.../XR Device Simulator/`) into the scene — enables mouse+keyboard simulation in Play mode.
6. Create a **Plane** (scale 3,1,3) for the floor. Add component **Teleportation Area**.
7. On the XR Origin GameObject add **Locomotion System**, **Teleportation Provider**, **Snap Turn Provider (Action-Based)**.
8. Drag `CharizardPrefab` into the scene. On it:
   - Add **Box Collider**.
   - Add **XRGrabInteractable** (Movement Type: Kinematic).
   - Add **VRDragonInteraction** (our script).
9. Hit **Play**. In XR Device Simulator: hold RMB to rotate view; hold G + move mouse to move right controller; press G+left mouse to grab.
10. Screenshot the hierarchy, inspector, and running grab/teleport for the report.

## Notes for the report

- Explain only the XRI features actually used; do not present them as VRTK features.
- Distinguish simulated Play mode behavior from testing on a physical headset.
- Keep original screenshots and this progress log until the Word report is assembled.
