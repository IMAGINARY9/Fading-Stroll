# Fading Stroll

A minimalist survival simulator set in an endless cosmos. You are a tiny star navigating a world of cosmic entities. Grow by consuming weaker entities, escape attacks from stronger ones, unlock body type variants with unique abilities, and climb the strength hierarchy.

## Preview

<img src="Fading stroll/Assets/Images/preview.jpg" alt="Fading Stroll Preview" style="max-width:600px; width:100%; height:auto;">

## Quick Facts

- **Project Path:** Fading-Stroll/Fading stroll/
- **Unity Version:** 2021.3.8f1
- **Graphics Pipeline:** Built-in Renderer with 2D Physics
- **Target Platforms:** Android, iOS, Windows, WebGL
- **Status:** Published Release
- **Genre:** Survival Simulator
- **Art Style:** Minimalist (geometric shapes, particle effects)

## Gameplay Overview

In Fading Stroll, you control a growing entity in an infinite cosmos filled with other entities. The core gameplay loop is simple but challenging: consume smaller entities to grow, avoid larger ones that can consume you, acquire upgrades to increase your strength, and survive as long as possible.

### Core Mechanics

**Movement & Control:** Use joystick (mobile) or keyboard arrow keys (desktop) to navigate. Movement applies force-based physics with acceleration and deceleration for fluid, responsive control.

**Consumption & Growth:** Collide with smaller entities to consume them. Your entity grows in both size and mass proportional to what you consume. Score increases based on consumed mass.

**Threat Management:** Larger entities will pursue and attempt to consume you. Physical mass determines dominance; smaller entities cannot damage larger ones. Avoid entities larger than yourself or retreat to safety.

**Upgrades & Progression:** Spend accumulated score to purchase level upgrades. Upgrades increase your base size and strength. The upgrade system has five tiers (levels 1-5). Higher levels require exponentially more score but grant substantial size increases.

**Body Type Selection:** Unlock different body types as you progress. Each body type has unique mechanics:
- **Attractive (Locked initially):** Pulls nearby smaller entities toward you; useful for passive consumption.
- **Fading (Unlocked later):** Has a light that dims when stationary. Keep moving to maintain your light; standing still causes you to fade away.
- **Explosive:** Detonates on destruction, dealing splash damage to nearby entities.
- **Colorful:** Spawns with random color variations; purely visual distinction.
- **Attracted:** Small, fast entities drawn to larger bodies. Easy to consume but vulnerable.

**Spawner System:** Entities continuously spawn around the player as they move. Spawners position themselves ahead of your movement direction, creating a constant stream of entities to interact with. A Factory system determines spawn distribution based on weighted probability ranges.

**Physics & Collision:** All interactive entities use 2D Rigidbody physics with gravity. Collisions determine dominance based on mass. Particle effects visualize destruction and impact.

## Controls

| Platform | Movement | Menu | Action |
|----------|----------|------|--------|
| **Mobile** | Joystick | On-screen | Tap upgrade button |
| **Desktop** | Arrow keys or WASD | Esc | Click upgrade button |

## How to Play

1. **Start:** You begin as a small entity with level 1 size.
2. **Consume:** Move around and collide with entities smaller than you. Your size increases and score accumulates.
3. **Avoid:** Larger entities will pursue you. Run away or move strategically to avoid them.
4. **Upgrade:** Access the menu and use your score to purchase level upgrades. Each upgrade increases your base size permanently.
5. **Unlock Bodies:** Upon reaching certain levels, new body types unlock. Switch to different body types to experience unique mechanics.
6. **Survive:** Continue consuming, upgrading, and surviving. The game has no win condition; play until defeated or you reach maximum level (5).
7. **Reset:** Reach level 5 to unlock a progress reset option. This allows you to restart with the opportunity to reach higher maximum scores.

## Game Loop Progression

| Phase | Description |
|-------|-------------|
| **Consume & Grow** | Collide with smaller entities; gain score proportional to their mass. |
| **Avoid & Escape** | Monitor larger entities; use movement to stay clear or find safety. |
| **Accumulate Score** | Score builds automatically as you consume. Check current score in UI. |
| **Purchase Upgrade** | Spend score on level upgrades when you have surplus funds. |
| **Unlock New Bodies** | At specific levels, new body types become available. Switch types in the menu. |
| **Repeat** | Continue the cycle until level 5 or game over. |

## Architecture & Design

See [ARCHITECTURE.md](ARCHITECTURE.md) for comprehensive documentation of game systems, design patterns, and extensibility guide.

**Quick Summary:**
- Component-based architecture with custom `MonoCache` tick system
- Key systems: Player (movement, setup, progression), Spawner (Factory pattern), Body Types (inheritance hierarchy), Data Persistence
- Physics integration with force-based movement and collision-based dominance
- Design patterns: Factory Pattern (spawning), Observer Pattern (events), Component Pattern, ScriptableObject Configuration
- For detailed architecture, systems breakdown, physics model, and extensibility guide, see [ARCHITECTURE.md](ARCHITECTURE.md)

## Project Structure

```
Assets/
├── Scripts/
│   ├── Player/                 # Player control, setup, upgrades
│   │   ├── PlayerMove.cs       # Input and force-based movement
│   │   ├── PlayerSetup.cs      # Size and physics initialization
│   │   ├── PlayerInfo.cs       # Level and score tracking
│   │   ├── PlayerUpgrade.cs    # Upgrade UI and progression
│   │   └── PlayerMoveConfig.cs # Serialized movement parameters
│   ├── Bodies/                 # Entity type implementations
│   │   ├── InteractiveBody.cs  # Base class, physics setup
│   │   ├── AttractiveBody.cs   # Gravity-based pull mechanic
│   │   ├── FadingBody.cs       # Light-based survival mechanic
│   │   ├── ExplosiveBody.cs    # Particle destruction effects
│   │   ├── ColorfulBody.cs     # Random color variation
│   │   └── AttractedBody.cs    # Attracted entities, consumption
│   ├── Spawner/                # Entity generation
│   │   ├── SpawnersController.cs # Spawner positioning
│   │   ├── SpawnersContainer.cs  # Spawner transform storage
│   │   ├── SpawnersUpdate.cs     # Spawn timing and instantiation
│   │   ├── Factory.cs            # Weighted probability spawning
│   │   └── BodySpawnType.cs      # Spawn type definition
│   ├── Global/                 # Shared systems
│   │   ├── DataHolder.cs       # Player progress state
│   │   ├── ProgressData.cs     # Save data serialization
│   │   ├── SaveSystem.cs       # Persistence I/O
│   │   └── UpdateManager.cs    # Central update ticker
│   ├── Interfaces/             # Contract definitions
│   │   ├── IScoreCollector.cs  # Entities receiving score
│   │   └── IAttracted.cs       # Entities affected by attraction
│   ├── Tools/                  # Utilities and helpers
│   ├── Opening/                # Start scene and intro
│   └── UI/                     # HUD, menus, upgrade panels
├── Scenes/                     # Game scenes
├── Prefabs/                    # Entity prefabs (Player, Enemies, Bodies)
├── Materials/                  # Sprites, particle materials
├── Sounds/                     # Audio clips, background music
└── Images/                     # UI graphics, icons
```

## Installation & Setup

### Prerequisites

- Unity 2021.3.8f1 or later
- C# 9.0 support
- 2D Physics package (included by default)
- TextMesh Pro (included by default)

### First Run

1. Clone or extract the repository.
2. Open Unity Hub and add the project from Fading-Stroll/Fading stroll/ path.
3. Load the project in Unity Editor.
4. Open the main game scene from Assets/Scenes/.
5. Press Play to start.

## Building & Deployment

### Android

1. Navigate to **File → Build Settings**.
2. Switch to **Android** platform.
3. Go to **Player Settings** and configure:
   - Company Name: [Your Company]
   - Product Name: Fading Stroll
   - Version: [Release Version]
   - Bundle Version Code: [Increment for updates]
4. Click **Build** and save the APK or run with **Build and Run**.
5. Install on Android device or deploy to Play Store.

### iOS

1. In **Build Settings**, switch to **iOS**.
2. Set **Player Settings** (Company, Product name, version).
3. Click **Build** to generate the Xcode project.
4. Open the project in Xcode and configure signing certificates.
5. Build and deploy to App Store or TestFlight.

### WebGL

1. In **Build Settings**, switch to **WebGL**.
2. Configure **Player Settings** as needed.
3. Click **Build** and select an output folder.
4. Upload the generated `index.html` and supporting files to a web server.
5. Access via web browser.

### Windows / Mac / Linux

1. In **Build Settings**, select **PC, Mac & Linux Standalone**.
2. Select target platform (Windows, Mac OS X, or Linux).
3. Click **Build** and choose output directory.
4. Run the generated executable (.exe for Windows, .app for Mac, binary for Linux).

## Development Guide

### Understanding the Gameplay Loop

The core loop is driven by:
1. **Input Handling:** `PlayerMove` reads input and applies force.
2. **Spawning:** `SpawnersUpdate` instantiates entities continuously.
3. **Physics:** Rigidbody collisions determine interactions.
4. **Scoring:** `IScoreCollector` accumulates score.
5. **Progression:** `PlayerUpgrade` converts score into level increases.

### Adding New Body Types

1. Create a new class inheriting from `InteractiveBody` or `AttractiveBody`.
2. Implement unique logic in `OnAwake()` or `LateAwake()` or `OnTick()` / `OnFixedTick()`.
3. Override `Explode()` if custom destruction behavior is needed.
4. Create a prefab with the new script and sprite.
5. Add to the `Factory._bodies` array in the spawner with a probability range.
6. Unlock via level thresholds in `PlayerUpgrade` if gating is desired.

### Modifying Game Balance

Adjustable parameters are exposed in the Inspector:
- **PlayerMoveConfig:** Acceleration, Deceleration, Speed, VelPower
- **Player Level Range:** 1-5 (hard coded)
- **Upgrade Pricing:** Formula in `PlayerUpgrade.UpdatePrice()` — `63.5962f * Mathf.Pow(_playerData.Level + 0.1f, 4.1182f)`
- **Body Size Scaling:** `PlayerSetup` multiplies level by size factor (1x per level)
- **Spawner Distance:** `SpawnersController._distance` controls spawner proximity
- **Spawn Rate:** `SpawnersUpdate._tickRate` controls spawn interval

### Physics Tuning

- Adjust `InteractiveBody` impulse forces for dash behavior.
- Modify `AttractiveBody.G` constant to change pull force intensity.
- Adjust `CircleCollider2D.density` in `PlayerSetup` to balance physics response.

## Save & Progress System

Progress is automatically saved when:
- Player level increases (upgrade purchased).
- Player entity is destroyed.
- Application quits (optional auto-save).

Data saved includes:
- Current level (1-5)
- Accumulated score
- Mute setting

The system prevents save data loss on crash. Load data is applied on scene start via `DataHolder.Load()`.

## Known Issues & Limitations

- **Performance:** Large entity counts (100+) may impact frame rate on mobile devices. Consider implementing object pooling for optimization.
- **Balancing:** The upgrade cost formula may favor high-level grinding; tuning may be necessary based on player feedback.
- **Physics:** Rare physics glitches can occur with rapid collisions; consider adding collision debounce if needed.
- **Multiplayer:** Single-player only. No networked shared worlds.
- **Audio:** Background music and sound effects are present but may need volume balancing.

## Mobile Optimization Notes

- Current implementation supports both portrait and landscape.
- Joystick input is supported on Android via the Joystick Pack asset.
- Consider enabling resolution scaling and framerate limiting for battery conservation on mobile.

## Future Features

- Leaderboard system (cloud-based)
- Daily challenges with special modifiers
- New body type mechanics (e.g., Shield, Clone)
- Boss entities with unique AI
- Cosmetic customization (skins, trails)
- Difficulty modes (Casual, Survival, Hardcore)

## License

See LICENSE file in the repository.

## Credits

- **Concept & Design:** Minimalist survival mechanics
- **Development:** Unity 2021.3.8f1, C#
- **Physics & Interaction:** Custom 2D physics integration
- **UI/UX:** Responsive mobile and desktop interfaces
- **Art & Visual Effects:** Minimalist geometric assets with particle effects


