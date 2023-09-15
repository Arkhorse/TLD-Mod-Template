namespace TEMPLATE
{
    public class Settings : JsonModSettings
    {
        internal static Settings Instance { get; } = new();

        [Section("Spawn Rates")]

        [Name("Pilgram")]
        [Slider(0f, 100f, 101)]
        public float pilgramSpawnExpectation = 80f;

        [Name("Voyager")]
        [Slider(0f, 100f, 101)]
        public float voyagerSpawnExpectation = 70f;

        [Name("Stalker")]
        [Slider(0f, 100f, 101)]
        public float stalkerSpawnExpectation = 50f;

        [Name("Interloper")]
        [Slider(0f, 100f, 101)]
        public float interloperSpawnExpectation = 20f;

        [Name("Challenge")]
        [Description("NOT SUPPORTED")]
        [Slider(0f, 100f, 101)]
        public float challengeSpawnExpectation = 100f;

        [Name("Story")]
        [Description("NOT SUPPORTED")]
        [Slider(0f, 100f, 101)]
        public float storySpawnExpectation = 90f;

        // this is used to set things when user clicks confirm. If you dont need this ability, dont include this method
        protected override void OnConfirm()
        {
            base.OnConfirm();

            //CHANGEME
            TEMPLATE.Spawner.SetProbability(Pilgram, Instance.pilgramSpawnExpectation);
            TEMPLATE.Spawner.SetProbability(Voyager, Instance.voyagerSpawnExpectation);
            TEMPLATE.Spawner.SetProbability(Stalker, Instance.stalkerSpawnExpectation);
            TEMPLATE.Spawner.SetProbability(Interloper, Instance.interloperSpawnExpectation);
            TEMPLATE.Spawner.SetProbability(Challenge, Instance.challengeSpawnExpectation);
            TEMPLATE.Spawner.SetProbability(Story, Instance.storySpawnExpectation);
        }

        // this is called whenever there is a change. Ensure it contains the null bits that the base method has
        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            base.OnChange(field, oldValue, newValue);
        }

        // This is used to load the settings
        internal static void OnLoad()
        {
            Instance.AddToModSettings(BuildInfo.GUIName);
            Instance.RefreshGUI();
        }
    }
}