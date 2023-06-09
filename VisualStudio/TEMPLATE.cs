namespace TEMPLATE
{
    internal class TEMPLATE : MelonMod
    {
        // This is used to init the mod. If you have no settings or other dependent mods, this method is not needed
        public override void OnInitializeMelon()
        {
            Settings.OnLoad(); // used to load settings, if you have it defined
            // This is enclosed in a build conditional. This means if the build is a DEBUG build, this code will be part of the mod. Otherwise it will not
#if DEBUG
            Log($"Mod has loaded with version: {BuildInfo.Version}");
#endif
        }
    }
}