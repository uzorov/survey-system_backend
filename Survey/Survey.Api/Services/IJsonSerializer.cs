// <file>
//     <project="Sinara.CloudBus.Clients">
//     <author>"MeyaDA"</author>
//     <date>"14/01/2024 15:16"</date>
// </file>

namespace Survey.Api.Services;

/// <summary>
///     Интерейс Json-сериализатора
/// </summary>
public interface IJsonSerializer
{
    /// <summary>
    ///     Выполняет десериализацию json-содержимого в объект
    /// </summary>
    /// <typeparam name="TObject">Тип объекта</typeparam>
    /// <param name="json">Сериализованные данные объекта в формате json</param>
    /// <returns>Десериализованный объект</returns>
    TObject Deserialize<TObject>(string json);

    /// <summary>
    ///     Выполняет сериализацию указанного объекта в формат json
    /// </summary>
    /// <typeparam name="TObject">Тип объекта для сериализации</typeparam>
    /// <param name="objectToSerialize">Экземпляр объекта для сериализации</param>
    /// <returns>Сериализованный данные объекта в формате json</returns>
    string Serialize<TObject>(TObject objectToSerialize);
}