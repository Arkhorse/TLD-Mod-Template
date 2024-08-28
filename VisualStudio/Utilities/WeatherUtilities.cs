// ---------------------------------------------
// WeatherUtilities - by The Illusion
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
    public static class WeatherUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
		/// <summary>
		/// Gets the localization key for the given WeatherStage
		/// </summary>
		/// <param name="stage">The WeatherStage to get</param>
		/// <returns>Loc key for the current stage</returns>
		/// <remarks>
		/// This is needed as the developers have not updated their own method with some of the stages
		/// </remarks>
		public static string? GetWeatherStageLoc(WeatherStage stage)
		{
			return stage switch
			{
				WeatherStage.DenseFog           => "GAMEPLAY_WeatherHeavyFog",
				WeatherStage.LightSnow          => "GAMEPLAY_WeatherLightSnow",
				WeatherStage.HeavySnow          => "GAMEPLAY_WeatherHeavySnow",
				WeatherStage.PartlyCloudy       => "GAMEPLAY_PartlyCloudy",
				WeatherStage.Clear              => "GAMEPLAY_WeatherClear",
				WeatherStage.Cloudy             => "GAMEPLAY_Cloudy",
				WeatherStage.LightFog           => "GAMEPLAY_WeatherLightFog",
				WeatherStage.Blizzard           => "GAMEPLAY_WeatherBlizzard",
				WeatherStage.ClearAurora        => "GAMEPLAY_know_th_AuroraObservations1_Title",    // Aurora Borealis
				WeatherStage.ToxicFog           => "GAMEPLAY_AfflictionToxicFog",                   // Toxic Fog - only darkwalker challenge as of 2.22
				WeatherStage.ElectrostaticFog   => "GAMEPLAY_ElectrostaticFog",                     // Glimmer Fog
				WeatherStage.Undefined          => null,
				_ => null,
			};
		}

		/// <summary>
		/// Checks if the Aurora is fully active
		/// </summary>
		/// <param name="auroraManager">The current isntance of the AuroraManager. Typical usage is <see cref="GameManager.GetAuroraManager()"/> </param>
		/// <returns>True if the Aurorae alpha is above the required percent to be fully active</returns>
		/// <remarks>
		/// <para>NOTE: Some Aurora activated objects initialize before the Aurora is fully active</para>
		/// <para>There is no current method in the game for this that actually works.</para>
		/// </remarks>
		public static bool IsAuroraFullyActive(AuroraManager auroraManager)
		{
			if (auroraManager.GetNormalizedAlpha() >= auroraManager.m_FullyActiveValue) return true;
			return false;
		}
    }
}
