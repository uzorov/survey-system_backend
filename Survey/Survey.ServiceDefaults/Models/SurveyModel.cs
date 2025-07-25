// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 12:50"</date>
// </file>

namespace Survey.ServiceDefaults.Models;

/// <summary>
///     Класс модели опроса
/// </summary>
public class SurveyModel
{
    public int Id { get; set; }

    /// <summary>
    ///     Вопрос опроса
    /// </summary>
    public QuestionModel Question { get; set; }

    /// <summary>
    ///     Варианты ответов
    /// </summary>
    public AnswerVariantModel AnswerVariant { get; set; }
}