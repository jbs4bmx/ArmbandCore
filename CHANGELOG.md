# 🔄 ARMBANDCORE FULL CHANGE LOG 🔄

## 🚧 02 January, 2026 - 4.0.1 (For SPT 4.0.0+)
Overview</br>
Major Update - Happy New Year. This update introduces a full suite of experimental armor‑handling features centered around the Armband armor slot, along with expanded multi‑armor support, explosive redirection, and optional damage‑type suppression. The mod now provides a flexible, slot‑specific armor framework that integrates cleanly with EFT 0.16’s damage pipeline.

Update - Version support for SPT 4.0.0+ and EFT 0.16.9.0.40087</br>
Update - License, Copyright, and versioning information.</br>

New Features
  * Multi‑Layer Armor Damage Resolution (Experimental)
    - Ballistic armor damage can now be distributed across multiple worn armor pieces.
    - Armband armor participates fully in ballistic damage sharing.
    - Configurable toggle: Enable Multi-Layer Armor Damage Resolution.
  * Explosive Damage Redirection (Armband‑Only Experimental System)
    - Explosive damage can now be redirected away from the player and into armor durability.
    - Optional mode to redirect all explosive damage exclusively to the armband armor.
    - Configurable toggles:
    - Enable Protection From Explosives
    - Redirect All Explosive Damage to Armband Armor
  * Throughput Damage Suppression (Armband‑Only)
    - Prevents ballistic and explosive throughput damage from reaching the player.
    - Only applies when armband armor is equipped.
    - Configurable toggle: Disable Throughput Damage.
  * Blunt Damage Suppression (Armband‑Only)
    - Blocks all blunt trauma damage that would normally bypass armor.
    - Only applies when armband armor is equipped.
    - Configurable toggle: Disable Blunt Damage.
  * Fragmentation Damage Suppression (Armband‑Only)
    - Blocks grenade fragmentation damage from reaching the player.
    - Only applies when armband armor is equipped.
    - Configurable toggle: Disable Fragmentation Damage.

Technical Improvements
  * Added ArmbandArmorHelper
    - Centralized helper for retrieving the armband armor component.
    - Ensures all armband‑specific features behave consistently.
  * Updated Damage Pipeline Patches
    - Added patches for:
    - Player.ApplyExplosionDamageToArmor
    - Player.ApplyDamageInfo
    - Ensures correct interception of ballistic, explosive, blunt, and fragmentation damage.
  * Cleaned Up Legacy Code
    - Removed unused variables and outdated method signatures.
    - Updated all patches to match EFT 0.16.9’s API.
    - Ensured compatibility with SPT 4.0.0.

Debugging Tools
  * Hit Tracing (WIP)
    - Optional detailed logging of ballistic impacts.
  * Armor Inspector (WIP)
    - Optional logging of detected armor components.
Both are disabled by default.

Notes
  - All “Armband Armor” experimental options only activate when the player is wearing armor in the Armband slot.
  - Multi‑Layer Armor remains a global system and affects all armor pieces.
  - This release is fully compatible with EFT 0.16.9 and SPT 4.0.0.

## 🚧 20 March, 2025 - 311.1.1 (For SPT 3.11.0+)
Update - Version support for SPT 3.11.0 and EFT 0.16.1.3.35392</br>

## 🚧 27 November, 2024 - 310.0.1 (For SPT 3.10.0+)
Update - Version support for SPT 3.10.0 and EFT 0.15.5.1.33420</br>

## 🚧 12 July, 2024 - 390.0.1 (For SPT 3.9.0+)
Update - Version support for SPT 3.9.0 and EFT 0.14.9.1.30626</br>


# 🗒 Other Notes
Previous versions unavailable.
