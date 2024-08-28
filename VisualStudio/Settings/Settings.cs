namespace TEMPLATE
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class Settings : JsonModSettings
	{
		internal static Settings Instance { get; } = new();

		#region  Spawner
		[Section("Spawn Rates")]

		[Name("Pilgrim")]
		[Slider(0f, 100f, 401)]
		public float pilgrimSpawnExpectation = 80f;

		[Name("Voyager")]
		[Slider(0f, 100f, 401)]
		public float voyagerSpawnExpectation = 70f;

		[Name("Stalker")]
		[Slider(0f, 100f, 401)]
		public float stalkerSpawnExpectation = 50f;

		[Name("Interloper")]
		[Slider(0f, 100f, 401)]
		public float interloperSpawnExpectation = 20f;

		[Name("Challenge")]
		[Description("NOT SUPPORTED")]
		[Slider(0f, 100f, 401)]
		public float challengeSpawnExpectation = 100f;

		[Name("Story")]
		[Description("NOT SUPPORTED")]
		[Slider(0f, 100f, 401)]
		public float storySpawnExpectation = 90f;
		#endregion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

		// this is used to set things when user clicks confirm. If you dont need this ability, dont include this method
		/// <inheritdoc/>
		protected override void OnConfirm()
		{
			base.OnConfirm();
			// Delete this if your not using GearSpawner
			Spawn.SetSpawner();
		}

		// this is called whenever there is a change. Ensure it contains the null bits that the base method has
		/// <inheritdoc/>
		protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
		{
			base.OnChange(field, oldValue, newValue);
		}

		// MUST be static
		// This is used to load the settings
		internal static void OnLoad()
		{
			Instance.AddToModSettings(BuildInfo.GUIName);
			Instance.RefreshGUI();
			// Delete this if your not using GearSpawner
			Spawn.SetSpawner();
		}
	}
}
