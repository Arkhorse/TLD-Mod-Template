// ---------------------------------------------
// FileUtilities - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace TEMPLATE.Utilities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class FileUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Attempts to get all file names in the given path
        /// </summary>
        /// <param name="path">The absolute path to scan</param>
        /// <param name="pattern">Any pattern to use to limit which files are considered</param>
        /// <param name="files">The output</param>
        public static void TryGetDirectoryFiles(string path, string pattern, out List<string>? files)
        {
            files = new();
            try
            {
                string[]? raw = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                files = raw.ToList();
            }
            catch (Exception e)
            {
                Main.Logger.Log($"TryGetDirectoryFiles({path}, {pattern}): Attempting to get file names failed:", FlaggedLoggingLevel.Exception, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ReplacementFile"></param>
        public static void ReplaceFile(string FileName, string ReplacementFile)
        {
            File.Replace(FileName, ReplacementFile, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="ReplacementFile"></param>
        /// <param name="BackupFileName"></param>
        public static void ReplaceFile(string FileName, string ReplacementFile, string BackupFileName)
        {
            File.Replace(FileName, ReplacementFile, BackupFileName);
        }

        #region Hash Utilities
        /// <summary>
        /// Creates an MD5 hash calculation of the input file
        /// </summary>
        /// <param name="inputFile">The path to the file to calculate</param>
        /// <returns></returns>
        public static string CreateMD5Hash(string inputFile)
        {
            //return if arg is null or empty
            if (string.IsNullOrWhiteSpace(inputFile))
                return "-1";

            //return if the file does not exist
            if (!File.Exists(inputFile))
                return "-1";

            FileStream? stream  = null;
            string result       = string.Empty;
            using (stream = File.OpenRead(inputFile))
            {
                result = CreateMD5Hash(stream);
            }

            if (result.Equals("-1"))
            {
                Main.Logger.Log($"Failed to check MD5 of file {inputFile}", FlaggedLoggingLevel.Error);
            }
            return result;
        }

        /// <summary>
        /// Creates an MD5 hash calculation from and stream object
        /// </summary>
        /// <param name="stream">The stream object to calculate from</param>
        /// <returns>The MD5 calculated hash</returns>
        /// <exception cref="ArgumentNullException"/>
        public static string CreateMD5Hash(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            //Create a new Stringbuilder to collect the bytes
            StringBuilder sBuilder = new StringBuilder();
            MD5 md5Hash;
            try
            {
                using (md5Hash = MD5.Create())
                {
                    //Convert the input string to a byte array and compute the hash
                    byte[] data = md5Hash.ComputeHash(stream);
                    stream.Close();

                    //Loop through each byte of the hashed data 
                    //and format each one as a hexadecimal string.
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                }
            }
            catch (Exception ex)
            {
                Main.Logger.Log("CreateMD5Hash::Caught exception:", FlaggedLoggingLevel.Exception, ex);
                return "-1";
            }

            //Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Creates an MD5 hash calculation of the input file
        /// </summary>
        /// <param name="inputFile">The path to the file to calculate</param>
        /// <returns></returns>
        public static async Task<string> CreateMD5HashAsync(string inputFile)
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming
            //Task taskA = Task.Run( () => Console.WriteLine("Hello from taskA."));
            //https://stackoverflow.com/questions/38423472/what-is-the-difference-between-task-run-and-task-factory-startnew
            /*
                in the .NET Framework 4.5 Developer Preview, we’ve introduced the new Task.Run method. This in no way obsoletes Task.Factory.StartNew,
                but rather should simply be thought of as a quick way to use Task.Factory.StartNew without needing to specify a bunch of parameters.
                It’s a shortcut. In fact, Task.Run is actually implemented in terms of the same logic used for Task.Factory.StartNew, just passing in
                some default parameters. When you pass an Action to Task.Run:

                'Task.Run(someAction);'

                it's exactly equivalent to:

                'Task.Factory.StartNew(someAction, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);'
             */
            return await Task.Run(() => CreateMD5Hash(inputFile));
        }

        /// <summary>
        /// Creates an MD5 hash calculation from and stream object
        /// </summary>
        /// <param name="stream">The stream object to calculate from</param>
        /// <returns>The MD5 calculated hash</returns>
        /// <exception cref="ArgumentNullException"/>
        public static async Task<string> CreateMD5HashAsync(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            return await Task.Run(() => CreateMD5Hash(stream));
        }
        #endregion

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);
    }
}
