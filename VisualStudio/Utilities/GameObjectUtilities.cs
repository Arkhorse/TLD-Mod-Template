


namespace TEMPLATE.Utilities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class GameObjectUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static List<GameObject> GetGameObjectsInScene()
		{
			List<GameObject> matches = new();

			for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
			{
				try
				{
					UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);

					List<GameObject> sceneObjects = scene.GetRootGameObjects().ToList();

					foreach (GameObject @object in sceneObjects)
					{
						if (@object != null)
						{
							matches.Add(@object);
						}
					}
				}
				catch { }
			}

			return matches;
		}

		// public static List<GameObject> GetGameObjectsOfType(Component component, string match)
		// {

		// }
	}
}
