using System.Text.Json.Serialization;

namespace TEMPLATE.JSON.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJsonFile
    {
        /// <summary></summary>
        /// <value></value>
        [JsonIgnore]
        string Path { get; }

        /// <summary></summary>
        /// <value></value>
        [JsonIgnore]
        JsonConverter[] AlwaysIncludedJsonConverters { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createFileIfNotExist"></param>
        void Load(bool createFileIfNotExist = true);

        /// <summary>
        /// 
        /// </summary>
        void Save();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createFileIfNotExist"></param>
        /// <param name="jsonConverters"></param>
        void LoadWithConverters(bool createFileIfNotExist = true, params JsonConverter[] jsonConverters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonConverters"></param>
        void SaveWithConverters(params JsonConverter[] jsonConverters);
    }
}