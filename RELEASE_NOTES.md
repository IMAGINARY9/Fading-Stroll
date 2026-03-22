# Fading Stroll - Release Notes

## v1.0.0 - Official Release

**Release Date:** March 2026

A minimalist survival simulator set in an endless cosmos. Grow stronger by consuming weaker entities, unlock unique body variants with special abilities, and progress through five upgrade levels in this physics-based indie game.

---

## Version Information

| Property | Value |
|----------|-------|
| **Engine** | Unity 2021.3.8f1 |
| **Graphics Pipeline** | Built-in Renderer with 2D Physics |
| **Physics** | Unity 2D Rigidbody with custom gravity calculations |
| **Input** | Cross-platform keyboard and joystick support |
| **Language** | C# 9.0 |
| **Save System** | PlayerPrefs-based persistence |
| **Platforms** | Android, iOS, WebGL, Windows, Mac, Linux |

---

## What's Included

This release contains:
- Complete survival simulator with physics-based gameplay
- Five unique body types (Attractive, Fading, Explosive, Colorful, Attracted)
- Five-tier upgrade progression system
- Cross-platform support (mobile and desktop)
- Automatic save/load with persistent progress
- Weighted spawn factory system
- Full source code and project files

For detailed gameplay mechanics, controls, and architecture, see [README.md](README.md).

---

## System Requirements

### Minimum
- **OS:** Windows 7+, macOS 10.13+, or Linux (Ubuntu 18.04+) / Android 6+, iOS 10+
- **Processor:** 1.5 GHz dual-core
- **Memory:** 2 GB RAM
- **Storage:** 500 MB disk space
- **Graphics:** OpenGL ES 3.0+ compatible GPU

### Recommended
- **OS:** Windows 10+, macOS 11+, or Linux (Ubuntu 20.04+) / Android 9+, iOS 12+
- **Processor:** 2.5 GHz quad-core
- **Memory:** 4 GB RAM
- **Storage:** SSD with 1 GB space
- **Graphics:** Dedicated GPU (NVIDIA GeForce GTX 760 or equivalent)

---

## Build Instructions

### Android
1. Open project in Unity 2021.3.8f1
2. File → Build Settings → Android
3. Configure Player Settings (company name, app name, version)
4. Click Build or Build and Run
5. Deploy APK to device or Play Store

### iOS
1. File → Build Settings → iOS
2. Configure Player Settings
3. Click Build to generate Xcode project
4. Open in Xcode; configure signing certificates
5. Build and deploy to App Store or TestFlight

### WebGL
1. File → Build Settings → WebGL
2. Click Build; select output folder
3. Upload generated files to web server
4. Access via browser URL

### Desktop (Windows/Mac/Linux)
1. File → Build Settings → PC, Mac & Linux Standalone
2. Select target platform
3. Click Build; choose output directory
4. Run generated executable

---

## Known Limitations

- **Performance:** Entity counts above 100 may impact mobile frame rates
- **Physics Edge Cases:** Rare glitches with rapid collisions possible
- **Balancing:** Upgrade formula may favor extended grinding; monitor progression
- **Multiplayer:** Single-player only; no networked worlds
- **Audio:** Complete but may need volume balancing

---

## Future Updates

Planned enhancements:
- Cloud-based leaderboard system
- Daily challenges with special modifiers
- New body type mechanics (Shield, Clone, Merge)
- Boss entities with unique AI
- Cosmetic customization (skins, trails)
- Difficulty modes (Casual, Survival, Hardcore)
- Seasonal content drops

---

## Getting Help

**For gameplay help:** See [README.md](README.md) for controls, "How to Play", and development guide  
**For architecture details:** See [ARCHITECTURE.md](ARCHITECTURE.md)  
**For bug reports or feedback:** Open an issue on GitHub  
**Full documentation:** See [README.md](README.md)

---

**License:** See [LICENSE](LICENSE)

#### Desktop (Windows/Mac/Linux)
1. File → Build Settings → PC, Mac & Linux Standalone
2. Select target platform
3. Click Build; choose output directory
4. Run generated executable

### System Requirements

**Minimum:**
- **OS:** Windows 7+, macOS 10.13+, or Linux (Ubuntu 18.04+) / Android 6+, iOS 10+
- **Processor:** 1.5 GHz dual-core
- **Memory:** 2 GB RAM
- **Storage:** 500 MB disk space
- **Graphics:** OpenGL ES 3.0+ compatible GPU

**Recommended:**
- **OS:** Windows 10+, macOS 11+, or Linux (Ubuntu 20.04+) / Android 9+, iOS 12+
- **Processor:** 2.5 GHz quad-core
- **Memory:** 4 GB RAM
- **Storage:** SSD with 1 GB space
- **Graphics:** Dedicated GPU (NVIDIA GeForce GTX 760 or equivalent)

### How to Play

1. **Start:** Begin as a small entity on level 1
2. **Consume:** Collide with smaller entities to grow and earn score
3. **Avoid:** Move away from larger entities that can consume you
4. **Upgrade:** Purchase level upgrades when you accumulate sufficient score
5. **Unlock Bodies:** New body types unlock at specific levels; experiment with each
6. **Survive:** Continue the cycle; reach level 5 for maximum strength
7. **Reset Progress:** Option to restart with accumulated knowledge and cosmetic rewards

### Accessibility Features

- Color-blind friendly palette options in settings
- Adjustable UI scaling for visibility
- Touch-friendly button sizes on mobile
- Keyboard shortcuts for desktop navigation

### Future Enhancements

Planned features for future releases:
- Cloud-based leaderboard system
- Daily challenges with special modifiers
- New body type mechanics (Shield, Clone, Merge)
- Boss entities with unique AI patterns
- Cosmetic customization (skins, trails, effects)
- Difficulty modes (Casual, Survival, Hardcore)
- Soundtrack expansion
- Seasonal content drops

### Feedback & Support

For bug reports, feature suggestions, or general feedback:
- Open an issue on GitHub
- Contact support through the game menu
- Participate in community discussions

### Credits

- **Game Design & Concept:** Minimalist survival simulator
- **Development:** Unity 2021.3.8f1, C#
- **Physics:** Custom 2D gravity and collision system
- **Art & Visual Effects:** Minimalist geometric style with particle systems
- **UI/UX:** Responsive cross-platform interface design

### License

See [LICENSE](LICENSE) file in the repository.

### Version History

**v1.0.0 (March 2026)**
- Initial official release
- Five body type implementations
- Five-tier upgrade system
- Multi-platform support (Android, iOS, WebGL, Desktop)
- Save/load functionality
- Spawn-based entity generation
- Physics-based movement and interaction

---

**Download:** [Release Page](releases)  
**Documentation:** See [README.md](README.md) for full gameplay and technical details  
**Issue Tracker:** [GitHub Issues](issues)  
**License:** See [LICENSE](LICENSE)
