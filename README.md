
| License | Commit Rate | Sponsers | Issues |
| :---: | :---: | :---: | :---: |
| ![GitHub](https://img.shields.io/github/license/Arkhorse/TLD-Mod-Template?style=for-the-badge) | ![Github](https://img.shields.io/github/commit-activity/y/Arkhorse/TLD-Mod-Template?style=for-the-badge) | ![GitHub Sponsors](https://img.shields.io/github/sponsors/Arkhorse?style=for-the-badge&link=https%3A%2F%2Fpaypal.me%2FArkhorse) | ![GitHub issues](https://img.shields.io/github/issues/Arkhorse/TLD-Mod-Template?style=for-the-badge) |

# About
This is a template for modifications which mod the game [The Long Dark](https://www.thelongdark.com). Unlike other templates, this one contains alot of extra code. This is intended to provide newer modders with the nessesary functions that have already been fully optimized. This will help ensure less messy mods.

# Usage

## Initial Steps
### Step One
Either download the repo as a zip, download via git fetch or [Github Desktop](https://desktop.github.com) or you can fork the repo. 
### Step Two
Which ever way you use, rename `TEMPLATE.cs` and `TEMPLATE.csproj` to match your namespace.
### Step Three
Then go into `TEMPLATE.cs` and rename the namespace using `F2` (if your using [Visual Studio](https://visualstudio.microsoft.com) or [Visual Studio Code](https://code.visualstudio.com)). This will rename the namespace wherever its used. This includes all using directives.

## Folder Structure Adherence
As you can see, this template uses a very clean folder structure to ensure things dont get messy. All content relating to each part of a mod has its own folder. `ModComponent` files go into `Distribuitable`, Unity Editor project files go into `Unity` and the assembly files go into `VisualStudio`.

### ModComponent Structure

### Unity Editor Structure

### Assembly Structure
For the most part, you can technically put any file anywhere. However this is a bad habit as it can be hard to read such a mod. The only absolutly required file location is the `AssemblyInfo.cs` file, which must be in `VisualStudio\Properties\AssemblyInfo.cs` as otherwise it will not be properly read by Visual Studio.

#### Patches
`NAMESPACE`: `TEMPLATE.Patches` <br />
Path: `VisualStudio\Patches` <br />
You should put your patches into this folder, using a single file per patch. Example:
```cs
namespace TEMPLATE
{
    [HarmonyPatch(typeof(Panel_FirstAid), nameof(Panel_FirstAid.Enable), new Type[] { typeof(bool) })]
    public class Panel_FirstAid_Enable
    {
        public static void Postfix(Panel_FirstAid __instance)
        {
            // do stuff
        }
    }
}
```
#### Properties
`NAMESPACE`: N/A <br />
Path: `VisualStudio\Properties` <br />
This folder is for assembly related stuff. For instance, this is where you will always find the `AssemblyInfo.cs` file.

#### Settings
`NAMESPACE`: (Optional)`TEMPLATE.Settings` <br />
Path: `VisualStudio\Settings` <br />
This folder is used for your settings file. As some mods have multiple settings pages, this folder was made to handle such situations

#### Utilities
`NAMESPACE`: `TEMPLATE.Utilities` <br />
Path: `VisualStudio\Utilities` <br />
This folder contains all your utilities.

##### Enums
`NAMESPACE`: `TEMPLATE.Utilities.Enums` <br />
Path: `VisualStudio\Utilities\Enums` <br />
This folder contains all your enums
##### Exceptions
`NAMESPACE`: `TEMPLATE.Utilities.Exceptions` <br />
Path: `VisualStudio\Utilities\Exceptions` <br />
This folder contains all your custom exceptions
##### JSON
`NAMESPACE`: `TEMPLATE.Utilities.JSON` <br />
Path: `VisualStudio\Utilities\JSON` <br />
This folder contains files related to hanlding `json` files. This includes a complete class which can load and save those files, both `synchronous` and `asynchronous`.
##### Logger
`NAMESPACE`: `TEMPLATE.Utilities.Logger` <br />
Path: `VisualStudio\Utilities\Logger` <br />
This contains the custom logger I have created for everyone. Allows for level based logging instead of build flag based logging

## Minimal Usage
If all you want is the bare minimum, you will want to download the template, then delete the following folders/files:
- `VisualStudio\Settings`
- `VisualStudio\Utilities`
- `VisualStudio\Spawner.cs`

# Nugets
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.Il2CppAssemblies.Windows?style=for-the-badge&label=Il2Cpp%20Assemblies)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.ModSettings?style=for-the-badge&label=Mod%20Settings)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.ModComponent?style=for-the-badge&label=Mod%20Component)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.LocalizationUtilities?style=for-the-badge&label=Localization%20Utilities)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.CraftingRevisions?style=for-the-badge&label=Crafting%20Revisions)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.GearSpawner?style=for-the-badge&label=Gear%20Spawner)
![Nuget](https://img.shields.io/nuget/v/STBlade.Modding.TLD.ModData?style=for-the-badge&label=Mod%20Data)
