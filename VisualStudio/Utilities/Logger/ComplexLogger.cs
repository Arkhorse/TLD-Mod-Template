// ---------------------------------------------
// ComplexLogger - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------
using Microsoft.Extensions.Logging;
using TEMPLATE.Utilities.Enums; // CHANGE: TEMPLATE

namespace TEMPLATE.Utilities.Logger
{
	/// <summary>
	/// Simple enum to handle the different types of logging
	/// </summary>
	/// <remarks>
	/// <para>Normal, General use. This is used by default</para>
	/// <para>Separator, if you want to print a separator</para>
	/// <para>IntraSeparator, if you want to print a header</para>
	/// </remarks>
	public enum LoggingSubType { Normal, Separator, IntraSeparator }

	public class ComplexLogger
	{
		public ComplexLogger()
		{
			AddLevel(FlaggedLoggingLevel.None);
			AddLevel(FlaggedLoggingLevel.Exception);
		}

		/// <summary>
		/// The current logging level. Levels are bitwise added or removed.
		/// </summary>
		public FlaggedLoggingLevel CurrentLevel { get; private set; } = new();

		/// <summary>
		/// Add a flag to the existing list
		/// </summary>
		/// <param name="level">The level to add</param>
		public void AddLevel(FlaggedLoggingLevel level)
		{
			if (CurrentLevel.HasFlag(level))
			{
				Log(FlaggedLoggingLevel.Debug, $"Attempting to add already existing level: {level}");
				return;
			}

			CurrentLevel |= level;

			Log(FlaggedLoggingLevel.Debug, $"Added flag {level}");
		}

		/// <summary>
		/// Remove a flag from the list
		/// </summary>
		/// <param name="level">Level to remove</param>
		/// <remarks>Attempting to remove "<see cref="FlaggedLoggingLevel.None"/>" or "<see cref="FlaggedLoggingLevel.Exception"/>" is not supported</remarks>
		public bool RemoveLevel(FlaggedLoggingLevel level)
		{
			if (level == FlaggedLoggingLevel.None)
			{
				Log(FlaggedLoggingLevel.Debug, "Attempting to remove \"FlaggedLoggingLevel.None\" is not supported");
				return false;
			}
			else if (level == FlaggedLoggingLevel.Exception)
			{
				Log(FlaggedLoggingLevel.Debug, "Attempting to remove \"FlaggedLoggingLevel.Exception\" is not supported");
				return false;
			}

			CurrentLevel &= ~level;

			Log(FlaggedLoggingLevel.Debug, $"Removed flag {level}");
			return true;
		}

		/// <summary>
		/// Print a log if the current level matches the level given.
		/// </summary>
		/// <param name="level">The level of this message (NOT the existing the level)</param>
		/// <param name="message">Formatted string to use in this log</param>
		/// <param name="LogSubType">Used to write separators only when the logging level matches the current flags</param>
		/// <param name="exception">The exception, if applicable, to display</param>
		/// <param name="parameters">Any additional params</param>
		/// <remarks>
		/// <para>Use <see cref="WriteSeperator(object[])"/> or <see cref="WriteIntraSeparator(string, object[])"/> for seperators without using the flagged level</para>
		/// <para>There is also <see cref="WriteStarter"/> if you require a prebuild startup message to display regardless of user settings (DONT DO THIS)</para>
		/// </remarks>
		public void Log(FlaggedLoggingLevel level, string message, LoggingSubType LogSubType = LoggingSubType.Normal, Exception? exception = null, params object[] parameters)
		{
			Log(FlaggedLoggingLevel.Debug, $"Log was triggered, current flags: {CurrentLevel}. Called flag: {level}");

			if (LogSubType != LoggingSubType.Normal)
			{
				if (LogSubType == LoggingSubType.Separator)
				{
					WriteSeperator(level);
					return;
				}
				else if (LogSubType == LoggingSubType.IntraSeparator)
				{
					WriteIntraSeparator(level, message);
					return;
				}
			}

			if (CurrentLevel.HasFlag(level))
			{
				switch (level)
				{
					case FlaggedLoggingLevel.Trace:
						Write($"[TRACE] {message}", parameters);
						break;
					case FlaggedLoggingLevel.Debug:
						Write($"[DEBUG] {message}", parameters);
						break;
					case FlaggedLoggingLevel.Verbose:
						Write($"[INFO] {message}", parameters);
						break;
					case FlaggedLoggingLevel.Warning:
						Write($"[WARNING] {message}", Color.red, parameters);
						break;
					case FlaggedLoggingLevel.Error:
						Write($"[ERROR] {message}", Color.red, parameters);
						break;
					case FlaggedLoggingLevel.Critical:
						Write($"[CRITICAL] {message}", Color.red, FontStyle.Bold, parameters);
						break;
					case FlaggedLoggingLevel.Exception:
						WriteException(message, exception, parameters);
						break;
					default:
						break;
				}
				return;
			}
			return;
		}

		/// <summary>
		/// The base log method
		/// </summary>
		/// <param name="message">The formated string to add as the message</param>
		/// <param name="parameters">Any additional params</param>
		private void Write(string message, params object[] parameters)
		{
			// sadly I cant find a way to dynamically set the singleton. The LoggerInstance is not accessable via this class
			Melon<Main>.Logger.Msg(message, parameters); // CHANGE: Main
		}

		/// <summary>
		/// Logs a prebuilt startup message
		/// </summary>
		/// <remarks>Requires use of a <see cref="BuildInfo"/> class with a property named <see cref="BuildInfo.Version"/></remarks>
		public void WriteStarter()
		{
			Write($"Mod loaded with v{BuildInfo.Version}");
		}

		/// <summary>
		/// Prints a seperator
		/// </summary>
		/// <param name="parameters">Any additional params</param>
		public void WriteSeperator(params object[] parameters)
		{
			Write("==============================================================================", parameters);
		}

		/// <summary>
		/// Prints a seperator
		/// </summary>
		/// <param name="parameters">Any additional params</param>
		/// <param name="level">The level of this message (NOT the existing the level)</param>
		public void WriteSeperator(FlaggedLoggingLevel level, params object[] parameters)
		{
			if (CurrentLevel.HasFlag(level)) WriteSeperator(parameters);
		}

		/// <summary>
		/// Logs an "Intra Seperator", allowing you to print headers
		/// </summary>
		/// <param name="message">The header name. Should be short</param>
		/// <param name="parameters">Any additional params</param>
		public void WriteIntraSeparator(string message, params object[] parameters)
		{
			Write($"=========================   {message}   =========================", parameters);
		}

		/// <summary>
		/// Logs an "Intra Seperator", allowing you to print headers
		/// </summary>
		/// <param name="message">The header name. Should be short</param>
		/// <param name="level">The level of this message (NOT the existing the level)</param>
		/// <param name="parameters">Any additional params</param>
		public void WriteIntraSeparator(FlaggedLoggingLevel level, string message, params object[] parameters)
		{
			if (CurrentLevel.HasFlag(level)) WriteIntraSeparator(message, parameters);
		}

		/// <summary>
		/// Prints a log with <c>[EXCEPTION]</c> at the start.
		/// </summary>
		/// <param name="message">The formated string to add as the message. Displayed before the exception</param>
		/// <param name="exception">The exception thrown</param>
		/// <param name="parameters">Any additional params</param>
		/// <remarks>
		/// <para>This is done as building the exception otherwise can be tedious</para>
		/// </remarks>
		private void WriteException(string message, Exception? exception, params object[] parameters)
		{
			StringBuilder sb = new();

			sb.Append("[EXCEPTION]");
			sb.Append(message);

			if (exception != null) sb.AppendLine(exception.Message);
			else sb.AppendLine("Exception was null");

			Write(sb.ToString(), Color.red, FontStyle.Bold, parameters);
		}
	}
}