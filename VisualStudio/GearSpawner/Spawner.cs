namespace TEMPLATE
{
    internal class Spawner
    {
        private float Pilgram       { get; set; }
        private float Voyager       { get; set; }
        private float Stalker       { get; set; }
        private float Interloper    { get; set; }
        private float Challenge     { get; set; }
        private float Story         { get; set; }

        public Spawner(float Pilgram, float Voyager, float Stalker, float Interloper, float Challenge, float Story)
        {
            this.Pilgram        = Pilgram;
            this.Voyager        = Voyager;
            this.Stalker        = Stalker;
            this.Interloper     = Interloper;
            this.Challenge      = Challenge;
            this.Story          = Story;
        }

        internal void Add()
        {
            SpawnTagManager.AddFunction(BuildInfo.Name, GetProbability);
        }

        private float GetProbability(DifficultyLevel diff, FirearmAvailability firearms, GearSpawnInfo info)
        {
            return difficultyLevel switch
            {
                DifficultyLevel.Pilgram         => Pilgram,
                DifficultyLevel.Voyager         => Voyager,
                DifficultyLevel.Stalker         => Stalker,
                DifficultyLevel.Interloper      => Interloper,
                DifficultyLevel.Challenge       => Challenge,
                DifficultyLevel.Story           => Story,
                _ => 0f
            };
        }

        internal void SetProbability(float probability, string mode)
        {
            switch (mode)
            {
                case Pilgram:
                    Pilgram = probability;
                    break;
                case Voyager:
                    Voyager = probability;
                    break:
                case Stalker:
                    Stalker = probability;
                    break:
                case Interloper:
                    Interloper = probability;
                    break;
                case Challenge:
                    Challenge = probability;
                    break;
                case Story:
                    Story = probability;
                    break;
            }
        }
    }
}