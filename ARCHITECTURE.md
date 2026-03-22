# Fading Stroll - Architecture & Design

This document describes the internal architecture, systems, and design patterns used in Fading Stroll.

---

## Overview

Fading Stroll uses a component-based architecture with a custom update tick system (`MonoCache`) to reduce reflection overhead. Systems communicate through events and interfaces, enabling loose coupling and extensibility. Physics-based gameplay is driven by force application and collision detection.

---

## Key Systems

### Player System

**Components:**

- **PlayerMove:** Handles cross-platform input (keyboard arrows/WASD or joystick). Applies force-based movement with configurable acceleration, deceleration, and velocity power curves.
  - `Acceleration`: Rate of velocity increase
  - `Deceleration`: Rate of velocity decrease
  - `VelPower`: Exponent for acceleration curve (liquidity control)
  - `Speed`: Base movement speed (affected by mass)

- **PlayerSetup:** Initializes player size and physics properties at startup based on current level. Sets `Rigidbody2D.density` proportionally to level.

- **PlayerInfo:** Tracks current player level and manages score collection from consumed entities. Broadcasts `PlayerDestroy` event when the player is destroyed.

- **PlayerUpgrade:** Manages level progression, upgrade pricing, and UI interaction.
  - Calculates upgrade cost using exponential formula: `63.5962f * Mathf.Pow(Level + 0.1f, 4.1182f)`
  - Enforces level cap at 5
  - Manages unlock thresholds for body types
  - Provides reset progression option at max level

**Configuration:**
- `PlayerMoveConfig` ScriptableObject externalizes movement parameters for balance tuning without code changes

**Interface Implementation:**
- Exposes `IScoreCollector` to receive mass values from consumed entities

---

### Spawner System

**Architecture: Factory Pattern**

Spawners generate entities probabilistically based on weighted ranges, avoiding hard-coded type-checking.

**Components:**

- **SpawnersController:** Parent controller managing spawner positioning. Positions spawners ahead of the player's movement direction (predictive placement) at a configurable distance (`_distance`) and angle spread (`_angle`).
  - 8-directional spawner placement around the player
  - Updates every `OnTick()` based on player movement direction
  - Uses quaternion calculations for rotation

- **SpawnersContainer:** Simple container for spawner transforms. Exposes `Spawners` array for parent controller and update component.

- **SpawnersUpdate:** Handles entity instantiation with two phases:
  1. **PreSpawn:** Initial world population with safe zone avoidance
  2. **NewSpawn:** Continuous spawning on timer (`_tickRate`)

- **Factory:** Implements weighted probability spawning. Each `BodySpawnType` defines:
  - `Prefab`: Entity prefab to instantiate
  - `Range`: Probability range (X to Y, 0-1 scale)
  
  **Example ranges:**
  ```
  Attracted: 0.0 - 0.5 (50% spawn rate)
  Fading: 0.5 - 0.7 (20% spawn rate)
  Explosive: 0.7 - 0.9 (20% spawn rate)
  Colorful: 0.9 - 1.0 (10% spawn rate)
  ```

- **BodySpawnType:** Simple serializable container for spawn definition.

---

### Body Type System

**Architecture: Inheritance Hierarchy**

All interactive entities inherit from `InteractiveBody`, with specializations for unique mechanics.

**Base Class: InteractiveBody**

Handles common functionality for all interactive entities:
- Rigidbody2D physics setup
- Initial impulse-based dash on spawn
- Lifecycle callbacks: `OnAwake()`, `LateAwake()`

**Derived Types:**

1. **AttractiveBody**
   - Creates gravity-like pull effect on nearby smaller entities
   - Calculates attraction radius using logarithmic formula: `4 * log(mass) - 2`
   - Uses `Overlap` collider component to detect nearby entities
   - Applies force using gravity constant: `G = 0.1667f`
   - Force calculation: `F = G * thisBody.mass * otherBody.mass / (distance²)`
   - Useful for passive entity gathering without player movement

2. **FadingBody**
   - Light-based survival mechanic with visual feedback
   - Maintains `Light2D` component that dims over time
   - When stationary (velocity near zero), light decreases at rate `_fadingPower`
   - Light resets to full when moving
   - Entity destroys itself when light intensity reaches zero
   - Requires constant movement to survive; high-skill mechanic

3. **ExplosiveBody**
   - Detonates on destruction with visual particle effects
   - Particle count scales with entity mass: `(short)(Mass * 100)`
   - Particle size scales with entity size: `scale * 0.2f`
   - Particle color inherits from sprite renderer
   - Useful offensively when surrounded

4. **ColorfulBody**
   - Purely cosmetic variation
   - Randomizes sprite color on spawn using configurable range
   - No gameplay mechanical difference
   - Provides visual variety and player customization

5. **AttractedBody**
   - Small, fast entities attracted to larger bodies
   - Implements `IAttracted` interface for pull mechanics
   - Base class for other attracted variants
   - Serves as entry-level consumption targets for new players

---

### Data & Persistence System

**Architecture: Serializable Model + Persistent Manager**

- **DataHolder:** Singleton-like manager for player progression state
  - Tracks: `Level` (1-5), `Score` (accumulated), `Mute` (audio toggle)
  - Broadcasts `LevelChanged` and `ScoreChanged` events on updates
  - Auto-saves on level-up or player destruction
  - Clamps level: 1 ≤ level ≤ 5
  - Score cannot go negative

- **ProgressData:** Serializable container for save data
  ```csharp
  Mute: bool
  Score: int
  Level: float
  ```

- **SaveSystem:** Handles file I/O
  - Uses `PlayerPrefs` for simplicity and cross-platform compatibility
  - Serializes `ProgressData` to JSON or binary format
  - Load called on `DataHolder.Awake()`
  - Save called on level-up and player destruction

**Persistence Flow:**
```
Player Loaded → DataHolder.Load() → ProgressData deserialized
Player Consumes Entity → Score increases → Save()
Player Upgrades → Level increases → Save()
Player Destroyed → Final Save()
Next Session → DataHolder.Load() → Progress restored
```

---

### Physics & Collision System

**Force-Based Movement:**

- Players apply force via `Rigidbody2D.AddForce()` rather than direct velocity manipulation
- Force magnitude calculated as: `movement = (speedDif * accelRate) ^ VelPower * sign(speedDif)`
- `VelPower` exponent controls acceleration smoothness; < 1.0 = smoother, > 1.0 = snappier

**Collision Dominance:**

Determined by entity mass:
- Larger entities consume smaller ones on collision
- Smaller entities are destroyed in collision with larger
- Equal-mass collisions result in no consumption

**Physics Constants:**
- Gravity constant `G = 0.1667f` for attraction calculations
- Density scales with player level (affects mass and physics response)
- Collision detection layer-based for optimization

---

### Update Management System

**Architecture: Custom Tick System (MonoCache Pattern)**

Rather than relying on MonoBehaviour's reflection-dependent `Update()` and `FixedUpdate()`, Fading Stroll uses an interface-based tick system.

**MonoCache (Base Class):**

Entities inherit from `MonoCache` instead of `MonoBehaviour` directly:
```csharp
public abstract class MonoCache : MonoBehaviour
{
    public virtual void Tick() { }        // Regular update
    public virtual void FixedTick() { }   // Physics update
}
```

**UpdateManager:**

Central controller that iterates over all MonoCache instances:
```csharp
public class UpdateManager : MonoBehaviour
{
    private void Update() 
    {
        for (int i = 0; i < MonoCache.allUpdate.Count; i++)
            MonoCache.allUpdate[i].Tick();
    }
    
    private void FixedUpdate() 
    {
        for (int i = 0; i < MonoCache.allFixedUpdate.Count; i++)
            MonoCache.allFixedUpdate[i].FixedTick();
    }
}
```

**Benefits:**
- No reflection overhead; all calls are direct method invocations
- Centralized control over update order
- Easier to profile and optimize
- Entities can disable updates without destroying themselves

---

## Design Patterns

### Factory Pattern

**Implementation:** `Factory` class with `BodySpawnType` configurations

```csharp
public class Factory
{
    [SerializeField] private BodySpawnType[] _bodies;
    
    public GameObject GetBody()
    {
        float chance = Random.value;
        foreach (var body in _bodies)
            if (CheckRange(body, chance)) 
                return Instantiate(body.Prefab);
        return null;
    }
}
```

**Benefits:**
- Spawning logic is separated from spawn decisions
- Probability ranges are externalized in Inspector
- New entity types added without code changes
- Type-safe: no string-based type names

---

### Observer Pattern

**Implementation:** C# events for loose coupling

```csharp
public static Action PlayerDestroy;           // PlayerInfo broadcasts
public Action<float> LevelChanged;             // DataHolder broadcasts
public Action<int> ScoreChanged;               // DataHolder broadcasts
public Action<int> AmmoChanged;                // Weapon broadcasts
```

**Benefits:**
- Systems react to events without direct references
- Multiple systems can subscribe to same event
- Easy to add/remove observers without modifying source
- Clear data flow through event names

---

### Component Pattern

**Principle:** Encapsulate single responsibility in each component

- `PlayerMove`: Input and movement only
- `PlayerSetup`: Initialization only
- `PlayerInfo`: Tracking and broadcasting only
- `PlayerUpgrade`: Progression and UI interaction
- `AttractiveBody`: Gravity mechanics
- `FadingBody`: Light-based survival
- `Patrol`, `Searcher`, etc. in other projects: Reusable AI components

**Benefits:**
- Components are independently testable
- Reusable across different entity types
- Clear separation of concerns
- Easier to maintain and extend

---

### ScriptableObject Configuration

**Implementation:** `PlayerMoveConfig` asset

```csharp
[CreateAssetMenu(fileName = "PlayerMoveConfig")]
public class PlayerMoveConfig : ScriptableObject
{
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Decceleration { get; private set; }
    [field: SerializeField] public float VelPower { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}
```

**Benefits:**
- Balance changes without recompiling
- Multiple configuration variants for different game modes
- Team members can tune externally
- Version control friendly for asset-based data

---

## Game Loop Flow

```
InitialPhase:
  1. DataHolder.Load() → Restore progress
  2. SpawnersUpdate.PreSpawn() → Populate world
  3. PlayerSetup → Initialize player size/physics

MainLoop (Per Frame):
  1. PlayerMove.Tick() → Read input, apply force
  2. Rigidbody Physics → Simulate forces, collisions
  3. Collision → Apply dominance (larger consumes smaller)
  4. PlayerInfo → Accumulate score
  5. SpawnersController.Tick() → Update spawner positions
  6. SpawnersUpdate.Tick() → Generate new entities at spawners
  7. DataHolder.Tick() → Broadcast progression events
  8. UI.Update() → Display current state

OnLevelUp:
  1. PlayerUpgrade → Increase level
  2. DataHolder.Level++ → Trigger LevelChanged event
  3. SaveSystem.Save() → Persist progress
  4. UI.UpdateLevel() → Display new level

OnPlayerDestroyed:
  1. PlayerInfo → Broadcast PlayerDestroy event
  2. SaveSystem.Save() → Final save with highest score
  3. UI.ShowGameOverScreen() → Present results
```

---

## Extensibility Guide

### Adding a New Body Type

1. Create class inheriting from `InteractiveBody` or `AttractiveBody`
2. Implement unique mechanics in `OnAwake()`, `LateAwake()`, or `OnTick()`/`OnFixedTick()`
3. Override `Explode()` if custom destruction behavior needed
4. Create prefab with sprite and physics
5. Add to `Factory._bodies[]` array with probability range
6. Optionally gate unlock via level threshold in `PlayerUpgrade`

**Example:**
```csharp
public class ShieldBody : InteractiveBody
{
    private float _shieldHealth = 10f;
    
    protected override void OnAwake()
    {
        // Shield setup
    }
    
    public override void OnFixedTick()
    {
        // Shield behavior
    }
}
```

### Modifying Game Balance

Game balance parameters are exposed in the Inspector:

**Movement:**
- `PlayerMoveConfig.Acceleration`
- `PlayerMoveConfig.Deceleration`
- `PlayerMoveConfig.Speed`
- `PlayerMoveConfig.VelPower`

**Progression:**
- `PlayerUpgrade.MaxPrice` (cap on upgrade costs)
- Formula in code: `63.5962f * Mathf.Pow(Level + 0.1f, 4.1182f)`
- Level cap (hard-coded at 5 in DataHolder)

**Physics:**
- `InteractiveBody` impulse forces (dash on spawn)
- `AttractiveBody.G` constant (gravity strength)
- `Rigidbody2D.density` scaling in `PlayerSetup`

**Spawning:**
- `SpawnersController._distance` (spawner proximity)
- `SpawnersUpdate._tickRate` (spawn interval)
- Factory probability ranges (weight distribution)
- Pre-spawn count and safe zone size

---

## Project Organization

```
Assets/Scripts/
├── Player/           # Player control and progression
│   ├── PlayerMove.cs
│   ├── PlayerSetup.cs
│   ├── PlayerInfo.cs
│   ├── PlayerUpgrade.cs
│   └── PlayerMoveConfig.cs
├── Bodies/           # Entity type implementations
│   ├── InteractiveBody.cs
│   ├── AttractiveBody.cs
│   ├── FadingBody.cs
│   ├── ExplosiveBody.cs
│   ├── ColorfulBody.cs
│   └── AttractedBody.cs
├── Spawner/          # Entity generation system
│   ├── SpawnersController.cs
│   ├── SpawnersContainer.cs
│   ├── SpawnersUpdate.cs
│   ├── Factory.cs
│   └── BodySpawnType.cs
├── Global/           # Shared systems
│   ├── DataHolder.cs
│   ├── ProgressData.cs
│   ├── SaveSystem.cs
│   ├── MonoCache.cs
│   └── UpdateManager.cs
├── Interfaces/       # Contract definitions
│   ├── IScoreCollector.cs
│   └── IAttracted.cs
├── Tools/            # Utilities
├── UI/               # HUD and menus
└── Opening/          # Start scene
```

---

## Performance Considerations

- **Memory:** Entity destruction handled by physics collisions; consider object pooling if spawn rates exceed 1000/second
- **Physics:** Collision layer masks prevent unnecessary checks; ensure proper layer setup
- **Updates:** MonoCache pattern reduces reflection overhead significantly
- **Attraction:** Overlap collider queries are cached; raycasting alternatives available for optimization

---

## Future Expansion Points

1. **New Body Types:** Shield (damage reduction), Clone (splits on touch), Merge (combines with similar)
2. **Difficulty Modes:** Casual (abundant entities), Hardcore (aggressive spawning)
3. **Leaderboard:** Cloud-based score tracking and rankings
4. **Cosmetics:** Skins, trails, color schemes beyond randomization
5. **Seasonal Events:** Limited-time body types, special modifiers
6. **Challenge Modes:** Daily challenges with unique rules and rewards

---

**See Also:** [README.md](README.md) for gameplay overview and build instructions
