// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 13:44"</date>
// </file>

namespace Survey.ServiceDefaults.Models;

using System;

/// <summary>
///     Класс модели метрики
/// </summary>
public class MetricModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double ValueDouble { get; set; }

    public string ValueString { get; set; }

    public string ValueDateTime { get; set; }

    public AnalysisResultModel AnalysisResult { get; set; }

    public DateTime MetricDateTime { get; set; }
}