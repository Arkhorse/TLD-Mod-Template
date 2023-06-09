namespace TEMPLATE
{
    public class Logger
    {
        internal static void Log(string message, params object[] parameters)            => MelonLogger.Msg($"{message}", parameters);
        internal static void LogWarning(string message, params object[] parameters)     => MelonLogger.Warning($"{message}", parameters);
        internal static void LogError(string message, params object[] parameters)       => MelonLogger.Error($"{message}", parameters);
        internal static void LogSeperator(params object[] parameters)                   => MelonLogger.Msg("==============================================================================", parameters);
    }
}