<a id="readme-top"></a>
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<br />
<div align="center">
  <a href="https://github.com/jbs4bmx/ArmbandCore">
    <img src="./images/ABCBanner.png" alt="logo" width="640" height="320">
  </a>

  <h3 align="center">Armband Core</h3>

  <p align="center">
    Core framework enabling the Armband slot to function as an armor slot, with optional advanced armor behavior systems.
  </p>

  [![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X611JH15)
</div>

---

## About The Project
**Type:** Client Mod</br>
**Disclaimer:** _Provided as-is with no guarantee of support._

ArmbandCore modifies the EFT client to allow the **Armband** equipment slot to function as a true armor slot.
This enables modders and players to create armbands with real armor properties that behave consistently with the rest of the armor system.

As of version **4.0.1**:
  - ArmbandCore's versioning is structured to match the versioning scheme of SPT to allow for the quick identification of compatible mod versions with SPT.
  - ArmbandCore also includes an optional suite of **experimental armor behavior systems**, including:
    - Multi-layer armor damage distribution
    - Explosive damage redirection
    - Throughput suppression
    - Blunt damage suppression
    - Fragmentation damage suppression
    - Armband‑specific armor logic
    - Debugging tools for armor and hit tracing

If your mod adds custom armbands with armor stats, simply list ArmbandCore as a dependency and the framework will handle the rest.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Features

### ✔ Core Functionality
- Converts the **Armband** slot into a valid armor slot.
- Ensures armband armor participates in EFT’s armor pipeline.
- Fully client-side; no server mod required.

### ✔ Debug Tools
- Armor inspector (WIP)
- Hit tracing (WIP)

### ✔ Experimental Armor Systems (Optional)
- **Multi-Layer Armor Resolution**
  Distributes ballistic armor damage across all worn armor pieces.

- **Explosive Armor Protection**
  Redirects explosive damage to armor instead of the player.

- **Armband-Only Explosive Targeting**
  Forces all explosive damage to hit the armband armor.

- **Throughput Damage Suppression**
  Blocks ballistic/explosive leak-through damage.

- **Blunt Damage Suppression**
  Blocks blunt trauma damage.

- **Fragmentation Damage Suppression**
  Blocks grenade fragmentation damage.



<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Built With

| Category | Name | Link |
| :------: | :--: | :--: |
| <img src="./images/icons/CS.svg" width="48"> | C# | [C# Documentation][CSharp-url] |
| <img src="./images/icons/VisualStudio-Dark.svg" width="48"> | Visual Studio | [Visual Studio Website][VisualStudio-url] |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Getting Started

_For the purpose of these directions, “[SPT]” refers to your SPT installation directory._

### Prerequisites for Building
You will need:
1. Visual Studio (or another C# compiler)
2. The following referenced assemblies:
   - `Assembly-CSharp.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\Assembly-CSharp.dll`
   - `0Harmony.dll` - Found in:`[SPT]\BepInEx\core\0Harmony.dll`
   - `BepInEx.dll` - Found in:`[SPT]\BepInEx\core\BepInEx.dll`
   - `ItemComponent.Types.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\ItemComponent.Types.dll`
   - `spt-common.dll` - Found in:`[SPT]\BepInEx\plugins\spt\spt-common.dll`
   - `spt-core.dll` - Found in:`[SPT]\BepInEx\plugins\spt\spt-core.dll`
   - `UnityEngine.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\UnityEngine.dll`
   - `UnityEngine.CoreModule.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\UnityEngine.CoreModule.dll`
   - `UnityEngine.IMGUIModule.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\UnityEngine.IMGUIModule.dll`
   - `UnityEngine.InputLegacyModule.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\UnityEngine.InputLegacyModule.dll`
   - `UnityEngine.TextRenderingModule.dll` - Found in:`[SPT]\EscapeFromTarkov_Data\Managed\UnityEngine.TextRenderingModule.dll`
3. For full compatibility with EFT systems, you may be required to modify your `.csproj` file so that it references `Assembly-CSharp.dll` before all other referenced assemblies. The order that they show up as in the IDE doesn't matter as much, but the order in the project file is important.

### Installation
Extract the mod into the root of your `[SPT]` folder (the same directory as `EscapeFromTarkov.exe`).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Configuration

ArmbandCore includes several optional experimental systems.</br>
These can be toggled in the F12 BepInEx configuration menu:

### **Debug Options**
- `Enable Armor Inspector (WIP)`
- `Enable Hit Tracing (WIP)`</br>
These options are a work in progress. They are meant to show debugging information in the logs to aid in development of this or related mods.

### **Experimental Options (All Armor)**
- `Enable Multi-Layer Armor Damage Resolution`</br>
This allows you to wear multiple types of armor along with armband armor and have them work together. Previous versions of ABC did not permit the use of armband armor while wearing other types of armor.

### **Experimental Options (Armband Armor Only)**
- `Enable Protection From Explosives`
- `Redirect All Explosive Damage to Armband Armor`
- `Disable Throughput Damage`
- `Disable Blunt Damage`
- `Disable Fragmentation Damage`</br>
These options are all relevant only to armor placed/worn in the armband slot. All other armor types will be ignored. Explosions and Ballistics in EFT have multiple components to them - These options should cover that range of components.</br>
To enable a sudo "God mode", enable all of these options at the same time and use an armband armor mod such as [Holtzman Shield](https://github.com/jbs4bmx/HoltzmanShield).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Roadmap

- [✅] Armband slot armor integration.
- [❓] Multi-layer armor system (WIP).
- [❓] Debug logging (WIP).
- [✅] Explosive redirection.
- [✅] Throughput/blunt/fragmentation suppression via configuration options.

Suggest changes or report issues [here](https://github.com/jbs4bmx/ArmbandCore/issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Contributing

Contributions are welcome and appreciated.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push the branch
5. Open a pull request

If you’d like to support development, you can also buy me a coffee:

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X611JH15)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## License

Distributed under the MIT License.</br>
See `LICENSE` or `LICENSE.txt` for details.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## Acknowledgments
  - SPT team
  - EFT modding community
  - Contributors and testers

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

[contributors-shield]: https://img.shields.io/github/contributors/jbs4bmx/ArmbandCore.svg?style=for-the-badge
[contributors-url]: https://github.com/jbs4bmx/ArmbandCore/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jbs4bmx/ArmbandCore.svg?style=for-the-badge
[forks-url]: https://github.com/jbs4bmx/ArmbandCore/network/members
[stars-shield]: https://img.shields.io/github/stars/jbs4bmx/ArmbandCore.svg?style=for-the-badge
[stars-url]: https://github.com/jbs4bmx/ArmbandCore/stargazers
[issues-shield]: https://img.shields.io/github/issues/jbs4bmx/ArmbandCore.svg?style=for-the-badge
[issues-url]: https://github.com/jbs4bmx/ArmbandCore/issues
[license-shield]: https://img.shields.io/github/license/jbs4bmx/ArmbandCore.svg?style=for-the-badge
[license-url]: https://github.com/jbs4bmx/ArmbandCore/blob/master/LICENSE.txt

[CSharp-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[VisualStudio-url]: https://visualstudio.microsoft.com/