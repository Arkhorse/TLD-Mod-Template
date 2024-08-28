// ---------------------------------------------
// LiquidUtilities - by The Illusion
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
    public class LiquidUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {

        /// <summary>
        /// Gets the current liquid type
        /// </summary>
        /// <param name="liquid">The liquid type to fetch</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static LiquidType? GetLiquid(Liquid liquid)
        {
            try
            {
                return liquid switch
                {
                    Liquid.Potable      => LiquidType.GetPotableWater(),
                    Liquid.NonPotable   => LiquidType.GetNonPotableWater(),
                    Liquid.Kerosene     => LiquidType.GetKerosene(),
                    Liquid.Antiseptic   => LiquidType.GetAntiseptic(),
                    _ => throw new NotImplementedException()
                };
            }
            catch (Exception e)
            {
                // this is here to give a proper error as otherwise ML does not log which mod threw the error
                Main.Logger.Log("GetLiquid::LiquidType was not found", FlaggedLoggingLevel.Exception, e);
                return null;
            }
        }
    }
}
