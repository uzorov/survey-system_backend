// <file>
//     <project="Question.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 12:46"</date>
// </file>

namespace Survey.ServiceDefaults.Models
{
    /// <summary>
    ///     Класс модели варианта ответа
    /// </summary>
    public class AnswerVariantModel
    {
        /// <summary>
        ///     Идентификатор варианта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Анкета
        /// </summary>
        public QuestionModel Question { get; set; }

        /// <summary>
        ///     Вариант ответа
        /// </summary>
        public string AnswerVariant { get; set; }
    }
}