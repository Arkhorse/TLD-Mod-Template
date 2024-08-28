using System.Text.Json.Serialization;
using System.Text.Json;

namespace TEMPLATE.Utilities.JSON
{
	/// <summary>
	/// Contains preset options to use in the class <see cref="JsonFile"/>
	/// </summary>
	public class JsonFileOptions
	{
		/// <summary>
		/// Gets the default set of options
		/// </summary>
		/// <returns></returns>
		public static JsonSerializerOptions GetDefaultOptions()
		{
			return new JsonSerializerOptions()
			{
				WriteIndented = true,   // pretty print
				IncludeFields = true,    // use [JsonInclude] on properties you want to include, otherwise it will not be
				ReadCommentHandling = JsonCommentHandling.Skip,
				PropertyNameCaseInsensitive = false,
				NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
				AllowTrailingCommas = true,
				UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement
			};
		}

		/// <summary>
		/// This allows for the writing of json objects in a compact manner. Basicaly without pretty print
		/// </summary>
		/// <returns></returns>
		public static JsonSerializerOptions GetCompactOptions()
		{
			return new JsonSerializerOptions()
			{
				WriteIndented = false,   // pretty print
				IncludeFields = true,    // use [JsonInclude] on properties you want to include, otherwise it will not be
				ReadCommentHandling = JsonCommentHandling.Skip,
				PropertyNameCaseInsensitive = false,
				NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
				AllowTrailingCommas = true,
				UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement
			};
		}

		/// <summary>
		/// This allows the reading of numbers in a string to be converted to a proper number
		/// </summary>
		/// <returns></returns>
		public static JsonSerializerOptions GetStringNumberOptions()
		{
			return new()
			{
				WriteIndented = true,   // pretty print
				IncludeFields = true,    // use [JsonInclude] on properties you want to include, otherwise it will not be
				ReadCommentHandling = JsonCommentHandling.Skip,
				PropertyNameCaseInsensitive = false,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				AllowTrailingCommas = true,
				UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement
			};
		}
	}
}
