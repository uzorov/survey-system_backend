// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 12:59"</date>
// </file>

namespace Survey.ServiceDefaults.Models;

using System;
using System.ComponentModel.DataAnnotations.Schema;

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
    [Column("type_of_pipe")]
    public string TypeOfPipe { get; set; }

    /// <summary>
    ///     Тип трубы
    /// </summary>
    [Column("diameter_of_pipe")]
    public string DiameterOfPipe { get; set; }

    /// <summary>
    ///     Тип трубы
    /// </summary>
    [Column("pipe_wall_thickness")]
    public string PipeWallThickness { get; set; }

    /// <summary>
    ///     Объем в тоннах
    /// </summary>
    [Column("volume_tons")]
    public string VolumeTons { get; set; }

    /// <summary>
    ///     Срок
    /// </summary>
    [Column("timeline")]
    public string Timeline { get; set; }

    /// <summary>
    ///     Уровень интереса
    /// </summary>
    [Column("interest_level")]
    public string InterestLevel { get; set; }

    [Column("text")]
    public string Text { get; set; }

    /// <summary>
    ///     Исходный запрос
    /// </summary>
    public QueryModel Query { get; set; }

    /// <summary>
    ///     Исходный запрос
    /// </summary>
    public ContactModel Contact { get; set; }

    /// <summary>
    ///     Время анализа
    /// </summary>
    public DateTime AnalysisDateTime { get; set; }
}