// <file>
//     <project="Sinara.CloudBus.Client">
//     <author>"MeyaDA"</author>
//     <date>"28/12/2023 20:33"</date>
// </file>

namespace Survey.Api.Services
{
    using System.Text.Encodings.Web;
    using System.Text.Json;

    /// <summary>
    ///     Класс json-сериализатора, выполняющего сериализацию событий и команд в формат json
    /// </summary>
    public class JsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        /// <summary>
        ///     Инициализирует экземпляр класса <see cref="JsonSerializer" />
        /// </summary>
        public JsonSerializer()
        {
            this.jsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        /// <summary>
        ///     Выполняет десериализацию json-содержимого в объект
        /// </summary>
        /// <typeparam name="TObject">Тип объекта</typeparam>
        /// <param name="json">Сериализованные данные объекта в формате json</param>
        /// <returns>Десериализованный объект</returns>
        public TObject Deserialize<TObject>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<TObject>(json, this.jsonSerializerOptions);
        }

        /// <summary>
        ///     Выполняет сериализацию указанного объекта в формат json
        /// </summary>
        /// <typeparam name="TObject">Тип объекта для сериализации</typeparam>
        /// <param name="objectToSerialize">Экземпляр объекта для сериализации</param>
        /// <returns>Сериализованный данные объекта в формате json</returns>
        public string Serialize<TObject>(TObject objectToSerialize)
        {
            return System.Text.Json.JsonSerializer.Serialize(objectToSerialize, this.jsonSerializerOptions);
        }
    }
}