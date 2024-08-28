
[HarmonyPatch(typeof(ClassName), nameof(ClassName.MethodName), new Type[] { typeof(GearItem), typeof(float), typeof(int), typeof(GearItem) })]
public static class ClassName_MethodName
{
    public static bool Prefix(ClassName __instance)
    {

    }
    public static void Postfix(ClassName __instance)
    {

    }
}
[HarmonyPatch(typeof(ClassName), nameof(ClassName.MethodName), new Type[] { typeof(GearItem), typeof(float), typeof(int), typeof(GearItem) })]
public static class ClassName_MethodName
{
    [HarmonyPrefix]
    public static bool Before(ClassName __instance)
    {

    }
    [HarmonyPostfix]
    public static void After(ClassName __instance)
    {

    }
}
[HarmonyPatch(typeof(ClassName))]
[HarmonyPatch(nameof(ClassName.MethodName))]
[HarmonyPatch([typeof(GearItem), typeof(float), typeof(int), typeof(GearItem)], [ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Ref])]
public static class ClassName_MethodName
{
    [HarmonyPrefix]
    public static bool Before(ClassName __instance)
    {

    }
    [HarmonyPostfix]
    public static void After(ClassName __instance)
    {

    }
}