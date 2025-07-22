// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"22/07/2025 8:44"</date>
// </file>

namespace Survey.Api.Services;

using Survey.ServiceDefaults.Dtos;

/// <summary>
///     Сервис ИИ агента
/// </summary>
public interface IAiAgentService
{
    /// <summary>
    ///     Обрабатывает заявку
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public AiAgentAnalysisResultDto AnalyzeSurvey(string message);

    /// <summary>
    ///     Обрабатывает заявку
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public string AnalyzeParameter(string parameter, string message);
}