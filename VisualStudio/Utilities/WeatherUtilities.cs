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
	public static class WeatherUtilities
    {
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

		public static bool IsAuroraFullyActive(AuroraManager auroraManager)
		{
			if (auroraManager.GetNormalizedAlpha() >= auroraManager.m_FullyActiveValue) return true;
			return false;
		}
    }
}
