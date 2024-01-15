using MelonLoader.Utils;
using TEMPLATE.Utilities.Enums;
using TEMPLATE.Utilities.Logger;

namespace TEMPLATE.Utilities
{
    public class ImageUtilities
    {
        /// <summary>
        /// Loads and converts a raw image
        /// </summary>
        /// <param name="FolderName">The name of the folder, without parents eg: "TEMPLATE". See: <see cref="MelonEnvironment.ModsDirectory"/></param>
        /// <param name="FileName">The name of the image, without extension or foldername</param>
        /// <param name="ext">The extension of the file eg: "jpg"</param>
        /// <returns>The image if all related functions work, otherwise null</returns>
        public static Texture2D? GetImage(string FolderName, string FileName, string ext)
        {
            Main.Logger.WriteIntraSeparator("");

            Texture2D texture = new(2, 2) { name = FileName };
            byte[]? file = null;
            string AbsoluteFileName = Path.Combine(MelonEnvironment.ModsDirectory, FolderName, $"{FileName}.{ext}");

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
                Main.Logger.Log($"Attemping to load requested file failed", FlaggedLoggingLevel.Exception, e);
                return null;
            }

            if (ImageConversion.LoadImage(texture, file))
            {
                Main.Logger.Log($"Successfully loaded file {FileName}", FlaggedLoggingLevel.Debug);

                return texture;
            }
            else
            {
                string compression = (ext == "jpg") ? "RGB24 | DXT1" : (ext == "png") ? "ARGB32 | DXT5" : "UNKNOWN";
                Main.Logger.Log($"Could not convert the image \"{FileName}\" as the related compression \"{compression}\" is not supported on this platform", FlaggedLoggingLevel.Debug);
            }

            return null;
        }

        public static Texture2D? GetPNG(string FolderName, string FileName)
        {
            Main.Logger.Log($"GetPNG({FileName})", FlaggedLoggingLevel.Debug);

            return GetImage(FolderName, FileName, "png");
        }

        public static Texture2D? GetJPG(string FolderName, string FileName)
        {
            Main.Logger.Log($"GetJPG({FileName})", FlaggedLoggingLevel.Trace);

            return GetImage(FolderName, FileName, "jpg");
        }
    }
}