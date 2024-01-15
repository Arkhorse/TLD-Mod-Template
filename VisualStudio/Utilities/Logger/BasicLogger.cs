// ---------------------------------------------
// BasicLogger - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

using TEMPLATE.Utilities.Enums; // CHANGE: TEMPLATE

namespace TEMPLATE.Utilities.Logger
{
    public class BasicLogger : ComplexLogger
    {
        public void Message(string message) 
        {
            base.Log(message, FlaggedLoggingLevel.None);
        }

        public void Debug(string message)
        {
            base.Log(message, FlaggedLoggingLevel.Debug);
        }

        public void Warning(string message)
        {
            base.Log(message, FlaggedLoggingLevel.Warning);
        }

        public void Error(string message)
        {
            base.Log(message, FlaggedLoggingLevel.Error);
        }

        public void Exception(string message, System.Exception e)
        {
            base.Log(message, e, FlaggedLoggingLevel.Exception);
        }
    }
}