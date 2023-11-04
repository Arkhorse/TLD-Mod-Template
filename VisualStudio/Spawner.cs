// ---------------------------------------------
// Spawner - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace TEMPLATE
{
    internal class Spawner
    {
        private static float Pilgram       { get; set; }
        private static float Voyager       { get; set; }
        private static float Stalker       { get; set; }
        private static float Interloper    { get; set; }
        private static float Challenge     { get; set; }
        private static float Story         { get; set; }

        public Spawner(float pilgram, float voyager, float stalker, float interloper, float challenge, float story)
        {
            Pilgram        = Pilgram;
            Voyager        = Voyager;
            Stalker        = Stalker;
            Interloper     = Interloper;
            Challenge      = Challenge;
            Story          = Story;
        }

        internal void Add()
        {
            SpawnTagManager.AddFunction(BuildInfo.Name, GetProbability);
        }

        private static float GetProbability(DifficultyLevel diff, FirearmAvailability firearms, GearSpawnInfo info)
        {
            return diff switch
            {
                DifficultyLevel.Pilgram         => Pilgram,
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
                    Pilgram = probability;
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