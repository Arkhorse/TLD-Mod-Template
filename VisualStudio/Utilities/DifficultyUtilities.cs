
namespace TEMPLATE.Utilities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class DifficultyUtilities
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// 
		/// </summary>
		public static Dictionary<Mode, Levels> DifficultyLibrary { get; } = new()
		{
			{ Mode.StoryMode, Levels.None },
			{ Mode.Sandbox, Levels.Pilgrim }
		};

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static int GetCurrentMode()
		{
			return ExperienceModeManager.GetCurrentExperienceModeType() switch
			{
				ExperienceModeType.Pilgrim					=> 3,
				ExperienceModeType.Voyageur					=> 3,
				ExperienceModeType.Stalker					=> 3,
				ExperienceModeType.Interloper				=> 3,
				ExperienceModeType.Custom					=> 3,

				ExperienceModeType.Story					=> 1,
				ExperienceModeType.StoryFresh				=> 1,
				ExperienceModeType.StoryHardened			=> 1,

				ExperienceModeType.ChallengeRescue			=> 2,
				ExperienceModeType.ChallengeHunted			=> 2,
				ExperienceModeType.ChallengeWhiteout		=> 2,
				ExperienceModeType.ChallengeNomad			=> 2,
				ExperienceModeType.ChallengeHuntedPart2		=> 2,
				ExperienceModeType.FourDaysOfNight			=> 2,
				ExperienceModeType.ChallengeArchivist		=> 2,
				ExperienceModeType.ChallengeDeadManWalking	=> 2,
				ExperienceModeType.EventWintersEmbrace		=> 2,
				ExperienceModeType.ChallengeNowhereToHide	=> 2,

				ExperienceModeType.NUM_MODES				=> 0,
				_											=> 0,
			};
		}
	}
}
