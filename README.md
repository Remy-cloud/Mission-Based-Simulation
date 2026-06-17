# A Mental Health Awareness Simulation

A first-person interactive Unity simulation designed to raise awareness about mental health across Africa, built as a summative assessment for the Unity Mission-Based Simulation module.

---

## GCGO Statement

**Grand Challenges and Global Opportunities:** Regional Integration and Healthcare

**Mission Statement:** To raise awareness about mental health in Africa by educating people on common mental health conditions, the stigma that prevents people from seeking help, and the resources available across the continent, while highlighting how regional collaboration can help close the gap in mental health support.

---

## Problem Context

Mental health remains one of the most under-addressed healthcare challenges across Africa. Conditions such as anxiety, depression, and PTSD affect tens of millions of people, yet mental health continues to receive a tiny fraction of national health budgets, and stigma keeps most people from ever seeking help.

This matters because untreated mental illness has real consequences: lost education, broken families, and preventable loss of life. It connects directly to the Healthcare GCGO because mental health is health, and to Regional Integration because the shortage of mental health professionals and resources is a shared challenge across African nations, one that becomes easier to address when knowledge, resources, and support systems are shared across borders rather than tackled in isolation.

This simulation was built to make these realities tangible rather than abstract, turning statistics into an experience the player walks through.

---

## Simulation Overview

The simulation places the player inside a single-story house, where each room represents a stage in a journey through mental health awareness.

**What it does:** The player walks through a sequence of rooms, each themed around a different aspect of mental health (an introduction to mental health, common disorders, stigma in Africa, and finally breaking the stigma and finding help). Information is presented through wall panels, standing boards, photo frames, a mirror, a newspaper clipping board, hanging banners, and a TV screen displaying a helpline. To progress between rooms, the player must pass a short multiple-choice quiz testing what they learned, reinforcing the educational content rather than letting the player simply walk past it.

**Target users:** Students, young adults, and the general public, anywhere awareness and basic mental health literacy is the goal, with a particular focus on African audiences and the cultural context of stigma.

**Key interactions:**
- First-person walking and looking, controlled via Unity's New Input System
- Raycast-based interaction with doors (look at a door, press E to open or close it)
- Reading awareness content on a variety of in-world display surfaces
- Multiple-choice quizzes that gate progress between rooms
- A Main Menu with a Start button and short description of the experience

---

## Unity Mechanics Implemented

**User Interface (UI):** Built with Unity UI and TextMeshPro throughout. This includes the Main Menu (title, description, Start/Quit buttons), the in-game "Press E to interact" prompt, the multiple-choice quiz panels (question text, three answer buttons, result text), and world-space canvases used to display awareness content directly on in-scene objects such as boards, frames, the mirror, and the TV screen.

**Scripting:** Custom C# scripts drive every system in the simulation. `PlayerMovement` handles first-person movement and look using the New Input System. `PlayerInteraction` casts the interaction raycast, drives the Line Renderer, and detects when the player is looking at a door. `DoorInteraction` controls door rotation and open/close state. `Room2Manager`, `Room3Manager`, and `ExitManager` each manage their room's quiz logic, tracking question progress, scoring answers, and unlocking doors once the player answers enough questions correctly. `MenuManager` handles scene transitions from the Main Menu, and `ScreenFade` provides a fade-in transition at the start of the experience.

**Collision-based interactions:** Box colliders set as triggers detect when the player enters a room, used to close the entry door behind the player and to begin a room's quiz sequence when the player returns to that doorway. Mesh and box colliders on the house, walls, and doors prevent the player from walking through solid geometry.

**Raycast-based interactions:** A raycast is fired every frame from the player's camera. When it hits an object tagged "Door," an on-screen prompt appears ("Press E to Open/Close Door"), and pressing the Interact action (bound through the New Input System) toggles that specific door via its `DoorInteraction` script. Removing this raycast would mean the player has no way to detect or trigger doors at all, since door interaction is entirely raycast-driven rather than collision-driven.

**Line Renderer:** A Line Renderer is attached to the player and updated every frame to draw a visible line from the camera to whatever point the raycast hits (or out to maximum range if nothing is hit). This gives the player clear visual feedback about exactly where their interaction raycast is pointing. An alternative would have been a simple screen-space crosshair, but the Line Renderer was chosen to make the raycast's behavior visually explicit, directly demonstrating the required mechanic in-world.

---

## Additional Features

Beyond the core module requirements, the following features were implemented:

1. **Background audio system** — An ambient music track plays on loop throughout the simulation via an Audio Source, set to 2D playback so it persists independently of player position, supporting the reflective tone of the experience.
2. **Screen fade transition** — A coroutine-driven UI fade takes the screen from black to clear at the start of the simulation, giving the experience a more polished, intentional opening rather than dropping the player straight into the scene.
3. **Mixed-media information display** — Rather than relying on a single repeated display style, the simulation uses a variety of presentation methods across rooms (wall posters, standing boards, photo frames, a mirror with reflective text, a newspaper clipping board, hanging banners, and a TV screen) to keep the museum-like exploration visually varied.

---

## Build Information

**WebGL Deployment Link:** https://remy-cloud.github.io/Mission-Based-Simulation/

**Android Build (APK):** https://drive.google.com/file/d/1HbMimLnslXlTnFeBiynsw0KviMTrRaHQ/view?usp=sharing

**Instructions for running the project:**

*WebGL:* Open the deployment link in a modern desktop browser. Use WASD to move, mouse to look around, and E to interact with doors when the on-screen prompt appears.

*Android:* Download the APK and install it on an Android device or emulator with installation from unknown sources enabled. 

Note: the current build uses keyboard and mouse input bindings through Unity's New Input System, designed primarily for WebGL/desktop play. On-screen touch controls (virtual joystick and interact button) were not implemented in this submission due to time constraints and are noted here as a planned improvement; the Android build was compiled, installed, and verified to launch and render correctly on an Android emulator.

*Unity Editor:* Open the project in Unity, ensure the MainMenu scene is set as the starting scene in Build Settings, and press Play.

---

## Reflection

Building this simulation surfaced a number of real production challenges beyond the core Unity mechanics, including managing asset and texture sizes for WebGL deployment, correctly wiring the New Input System across player movement, UI, and interaction, and structuring door and quiz logic so that each room's progression felt intentional rather than scripted in isolation. Given more time, the most valuable additions would be proper on-screen touch controls for mobile platforms, and expanding the quiz content with a larger question pool so repeat playthroughs feel fresh.