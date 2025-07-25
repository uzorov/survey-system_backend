// <file>
//     <project="QuestionModel.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 12:14"</date>
// </file>

namespace Survey.ServiceDefaults.Models
{
    /// <summary>
    ///     Класс модели вопроса анкеты
    /// </summary>
    public class QuestionModel 
    {
        /// <summary>
        ///     Идентификатор анкеты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Текст вопроса анкеты
        /// </summary>
        public string Question { get; set; }

        public bool IsAllowOtherAnswer { get; set; }
    }
}