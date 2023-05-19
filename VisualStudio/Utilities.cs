namespace TEMPLATE
{
    internal class Utilities
    {
        // This is used to load prefab info of a GearItem
        // NOTE: This is a volitile method. Ensure it is always up to date as otherwise it can break anything tied to GearItem
        public static GearItem GetGearItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<GearItem>();
        // This is used to load prefab info of a ToolsItem
        // NOTE: This is a volitile method. Ensure it is always up to date as otherwise it can break anything tied to GearItem
        public static ToolsItem GetToolItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<ToolsItem>();
    }
}