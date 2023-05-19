using ModSettings;

namespace TEMPLATE
{
    internal class Settings : JsonModSettings
    {
        internal static readonly Settings _settings = new();

        #region Settings
        // Setup your settings here
        [Section("Section")] // this is a section attrib. Anything inside of it will be collapsable within this section and will also be indented. Always in caps
        [Name("Name")] // this is a name for a setting. Always in caps
        [Description("Description")] // this is the description for the above setting. Shown when hovering on the right side
        public bool name = true; // these should always be public and not static (otherwise you will need to move some code)

        #endregion

        // this is used to set things when user clicks confirm. If you dont need this ability, dont include this method
        protected override void OnConfirm()
        {
            
        }

        // this is called whenever there is a change. Ensure it contains the null bits that the base method has
        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            if ( field.Name == nameof(name) )
            {
                RefreshFields();
            }
        }

        // use this as a shortcut to enable/disable and fields on change
        internal void RefreshFields()
        {
            SetFieldVisible(nameof(name), true);
        }
        
        // This is used to load the settings
        internal static void OnLoad()
        {
            _settings.AddToModSettings($"{BuildInfo.Name}");
        }
    }
}