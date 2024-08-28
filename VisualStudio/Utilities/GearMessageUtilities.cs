// ---------------------------------------------
// GearMessageUtilities - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace TEMPLATE.Utilities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class GearMessageUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Adds a message to the <see cref="GearMessage"/> queue
        /// </summary>
        /// <param name="prefab">Name of the icon to display, MUST be part of the <c>Base_Atlas</c></param>
        /// <param name="header">What the header should be</param>
        /// <param name="message">The message</param>
        /// <param name="time">Amount of time to display this message</param>
        public static void AddGearMessage(string prefab, string header, string message, float time)
        {
            GearMessage.AddMessage(prefab, header, message, time);
        }
    }
}
