#region System Directives
global using System;
global using System.Text;
global using System.Text.RegularExpressions;
#endregion
#region Il2Cpp Directives
global using Il2CppInterop.Runtime;
global using Il2CppTLD.Gear;
#endregion
#region Unity Directives
global using UnityEngine.AddressableAssets;
#endregion
#region Mod Directives
global using TEMPLATE.Utilities;
global using TEMPLATE.Utilities.Enums;
global using TEMPLATE.Utilities.Exceptions;
global using TEMPLATE.Utilities.JSON;
global using ComplexLogger;
#endregion

namespace TEMPLATE
{

    /// <inheritdoc/>
	public class Main : MelonMod
	{
        /// <summary>
        /// 
        /// </summary>
        public static ComplexLogger<Main> Logger = new();

        /// <inheritdoc/>
        public override void OnInitializeMelon()
        {
            Spawn.SetupSpawner();
            Settings.OnLoad();
        }

        // used to do things when a scene is Initialized. This is what you want to use under normal circumstances
        /// <inheritdoc/>
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);
        }

        // Triggered when the scene has finished loading
        /// <inheritdoc/>
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
        }

        // triggered when scenes are unloaded
        /// <inheritdoc/>
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasUnloaded(buildIndex, sceneName);
        }

        // Use this to do things on update instead of patching GameManger.Update();
        /// <inheritdoc/>
        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }
    }
}
