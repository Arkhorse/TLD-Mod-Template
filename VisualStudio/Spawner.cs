// ---------------------------------------------
// Spawner - by The Illusion
// ---------------------------------------------
// Reuse Rights 
// ---------------------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace TEMPLATE
{
    /// <summary>
    /// 
    /// </summary>
    public class Spawn
    {
        /// <summary>
        /// 
        /// </summary>
        public static void SetupSpawner()
        {
            // initial setup of the spawner values
            Spawner spawner = new(
                Settings.Instance.pilgrimSpawnExpectation,
                Settings.Instance.voyagerSpawnExpectation,
                Settings.Instance.stalkerSpawnExpectation,
                Settings.Instance.interloperSpawnExpectation,
                Settings.Instance.challengeSpawnExpectation,
                Settings.Instance.storySpawnExpectation
            );
            spawner.Add();
        }

        /// <summary>
        /// 
        /// </summary>
		public static void SetSpawner()
		{
			//CHANGEME
			Spawner.SetProbability(Settings.Instance.pilgrimSpawnExpectation,        DifficultyLevel.Pilgram);
			Spawner.SetProbability(Settings.Instance.voyagerSpawnExpectation,        DifficultyLevel.Voyager);
			Spawner.SetProbability(Settings.Instance.stalkerSpawnExpectation,        DifficultyLevel.Stalker);
			Spawner.SetProbability(Settings.Instance.interloperSpawnExpectation,     DifficultyLevel.Interloper);
			Spawner.SetProbability(Settings.Instance.challengeSpawnExpectation,      DifficultyLevel.Challenge);
			Spawner.SetProbability(Settings.Instance.storySpawnExpectation,          DifficultyLevel.Storymode);
		}
    }

    internal class Spawner
    {
        private static float Pilgrim       { get; set; }
        private static float Voyager       { get; set; }
        private static float Stalker       { get; set; }
        private static float Interloper    { get; set; }
        private static float Challenge     { get; set; }
        private static float Story         { get; set; }

        public Spawner(float pilgrim, float voyager, float stalker, float interloper, float challenge, float story)
        {
            Pilgrim        = pilgrim;
            Voyager        = voyager;
            Stalker        = stalker;
            Interloper     = interloper;
            Challenge      = challenge;
            Story          = story;
        }

        internal void Add()
        {
            SpawnTagManager.AddFunction(BuildInfo.Name, GetProbability);
        }

        private static float GetProbability(DifficultyLevel diff, FirearmAvailability firearms, GearSpawnInfo info)
        {
            return diff switch
            {
                DifficultyLevel.Pilgram         => Pilgrim,
                DifficultyLevel.Voyager         => Voyager,
                DifficultyLevel.Stalker         => Stalker,
                DifficultyLevel.Interloper      => Interloper,
                DifficultyLevel.Challenge       => Challenge,
                DifficultyLevel.Storymode       => Story,
                _ => 0f
            };
        }

        internal static void SetProbability(float probability, DifficultyLevel mode)
        {
            switch (mode)
            {
                case DifficultyLevel.Pilgram:
                    Pilgrim = probability;
                    break;
                case DifficultyLevel.Voyager:
                    Voyager = probability;
                    break;
                case DifficultyLevel.Stalker:
                    Stalker = probability;
                    break;
                case DifficultyLevel.Interloper:
                    Interloper = probability;
                    break;
                case DifficultyLevel.Challenge:
                    Challenge = probability;
                    break;
                case DifficultyLevel.Storymode:
                    Story = probability;
                    break;
            }
        }
    }
}
