// ---------------------------------------------
// AssetBundleUtilities - by The Illusion
// Additional Credits:
//		STBlade (VIA MODCOMPONENT)
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace TEMPLATE.Utilities
{
	/// <summary>
	/// Alternative asset loading methods to avoid triggering the AssetLoader patches
	/// </summary>
	internal static class AssetBundleUtilities
	{
		/// <summary>
		/// Loads an asset without triggering the AssetLoader patches
		/// </summary>
		public static UnityEngine.Object LoadAsset(AssetBundle assetBundle, string name)
		{
			return LoadAsset(assetBundle, name, Il2CppType.Of<UnityEngine.Object>());
		}
		/// <summary>
		/// Loads an asset without triggering the AssetLoader patches
		/// </summary>
		public static T? LoadAsset<T>(AssetBundle assetBundle, string name) where T : UnityEngine.Object
		{
			return LoadAsset(assetBundle, name, Il2CppType.Of<T>())?.TryCast<T>();
		}
		/// <summary>
		/// Loads an asset without triggering the AssetLoader patches
		/// </summary>
		public static UnityEngine.Object LoadAsset(AssetBundle assetBundle, string name, Il2CppSystem.Type type)
		{
			if (assetBundle == null)
			{
				throw new BadMemeException("The asset bundle cannot be null");
			}
			if (name == null)
			{
				throw new BadMemeException("The input asset name cannot be null");
			}
			if (name.Length == 0)
			{
				throw new BadMemeException("The input asset name cannot be empty");
			}
			if (type == null)
			{
				throw new BadMemeException("The input type cannot be null");
			}
			return assetBundle.LoadAsset_Internal(name, type);
		}
		/// <summary>
		/// Load an asset from Addressables
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public static T LoadAsset<T>(string assetName) => Addressables.LoadAssetAsync<T>(assetName).WaitForCompletion();
	}
}
