// ---------------------------------------------
// ImageUtilities - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

using MelonLoader.Utils;

namespace TEMPLATE.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public class ImageUtilities
	{
		/* NOTES
			This entire class cant be async. Unity throws a fit if you attempt to load images outside the main thread
		*/

		/// <summary>
		/// Get all images in a directory
		/// </summary>
		/// <param name="Foldername">The absolute path to the folder to load the images. Use <see cref="MelonEnvironment.ModsDirectory"/> to properly get the mods directory</param>
		/// <param name="ext">The extension that your files use</param>
		/// <param name="images">The result</param>
		/// <returns><see langword="true"/> if the operation was a success, otherwise <see langword="false"/></returns>
		public static bool GetImages(string Foldername, string ext, out List<Texture2D> images)
		{
			images = new();
			string[] files = Directory.GetFiles(Foldername, $"*{ext}");

			foreach (string file in files)
			{
				Texture2D? texture = GetImage(Foldername, file, ext);
				if (texture != null)
				{
					images.Add(texture);
				}
			}

			if (images.Count == 0) return false;
			return true;
		}
		/// <summary>
		/// Loads and converts a raw image
		/// </summary>
		/// <param name="FolderName">The name of the folder, without parents eg: "TEMPLATE". See: <see cref="MelonLoader.Utils.MelonEnvironment.ModsDirectory"/></param>
		/// <param name="FileName">The name of the image, without extension or foldername</param>
		/// <param name="ext">The extension of the file eg: "jpg"</param>
		/// <returns>The image if all related functions work, otherwise null</returns>
		public static Texture2D? GetImage(string FolderName, string FileName, string ext)
		{
			byte[]? file = null;
			string AbsoluteFileName = Path.Combine(MelonLoader.Utils.MelonEnvironment.ModsDirectory, FolderName, $"{FileName}.{ext}");

			Main.Logger.Log("GetImage", FlaggedLoggingLevel.Debug, LoggingSubType.IntraSeparator);

			if (!File.Exists(AbsoluteFileName))
			{
				Main.Logger.Log($"The file requested was not found {AbsoluteFileName}", FlaggedLoggingLevel.Error);
				return null;
			}

			Texture2D texture = new(4096, 4096);

			try
			{
				file = File.ReadAllBytes(AbsoluteFileName);

				if (file == null)
				{
					Main.Logger.Log($"Attempting to ReadAllBytes failed", FlaggedLoggingLevel.Warning);
					return null;
				}
			}
			catch (DirectoryNotFoundException dnfe)
			{
				Main.Logger.Log($"Directory was not found {FolderName}", FlaggedLoggingLevel.Exception, dnfe);
			}
			catch (FileNotFoundException fnfe)
			{
				Main.Logger.Log($"File was not found {FileName}", FlaggedLoggingLevel.Exception, fnfe);
			}
			catch (Exception e)
			{
				Main.Logger.Log($"Attempting to load requested file failed", FlaggedLoggingLevel.Exception, e);
			}

			#region Commented Out
			//if (ImageConversion.LoadImage(texture, file))
			//{
			//	Main.Logger.Log($"Successfully loaded file {FileName}", FlaggedLoggingLevel.Debug);

			//	return texture;
			//}
			//else
			//{
			//	string compression = (ext == "jpg") ? "RGB24 | DXT1" : (ext == "png") ? "ARGB32 | DXT5" : "UNKNOWN";
			//	Main.Logger.Log($"Could not convert the image \"{FileName}\" as the related compression \"{compression}\" is not supported on this platform", FlaggedLoggingLevel.Debug);
			//}
			#endregion

			texture.LoadRawTextureData(file);
			texture.Apply();
			Main.Logger.Log($"Successfully loaded file {FileName}", FlaggedLoggingLevel.Debug);
			Main.Logger.Log(FlaggedLoggingLevel.Debug, LoggingSubType.Separator);
			return texture ?? null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="FolderName"></param>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public static Texture2D? GetPNG(string FolderName, string FileName)
			=> GetImage(FolderName, FileName, "png");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="FolderName"></param>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public static Texture2D? GetJPG(string FolderName, string FileName)
			=> GetImage(FolderName, FileName, "jpg");
	}
}