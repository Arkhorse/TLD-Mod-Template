namespace TEMPLATE
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            // initial setup of the spawner values
            Spawner spawner = new(
                Settings.Instance.pilgramSpawnExpectation,
                Settings.Instance.voyagerSpawnExpectation,
                Settings.Instance.stalkerSpawnExpectation,
                Settings.Instance.interloperSpawnExpectation,
                Settings.Instance.challengeSpawnExpectation,
                Settings.Instance.storySpawnExpectation
            );
            spawner.Add();
            Settings.OnLoad();
        }
    }
}
