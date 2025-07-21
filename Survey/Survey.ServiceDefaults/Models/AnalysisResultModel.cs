// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 12:59"</date>
// </file>

namespace Survey.ServiceDefaults.Models;

using System;

/// <summary>
///     Класс модели результата анализа
/// </summary>
public class AnalysisResultModel
{
    /// <summary>
    ///     Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Тип трубы
    /// </summary>
    public string PipeType { get; set; }

    /// <summary>
    ///     Объем в тоннах
    /// </summary>
    public string Tons { get; set; }

    /// <summary>
    ///     Регион
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    ///     Срок
    /// </summary>
    public DateTime Deadline { get; set; }

    /// <summary>
    ///     Уровень интереса
    /// </summary>
    public string InterestLevel { get; set; }

    /// <summary>
    ///     Исходный запрос
    /// </summary>
    public QueryModel Query { get; set; }

    /// <summary>
    ///     Время анализа
    /// </summary>
    public DateTime AnalysisDateTime { get; set; }
}