// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
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

    public double Value { get; set; }

    public AnalysisResultModel AnalysisResult { get; set; }

    public DateTime MetricDateTime { get; set; }
}