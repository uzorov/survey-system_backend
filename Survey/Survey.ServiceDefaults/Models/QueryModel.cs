// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 13:35"</date>
// </file>

namespace Survey.ServiceDefaults.Models
{
    using System;

    /// <summary>
    ///     Модель запроса
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Текст запроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Пользователь
        /// </summary>
        public ContactModel Contact { get; set; }

        /// <summary>
        ///     Время запроса
        /// </summary>
        public DateTime QueryDateTime { get; set; }

        /// <summary>
        ///     Результат анализа
        /// </summary>
        public AnalysisResultModel AnalysisResult { get; set; }

        public int AnalysisResultModelId { get; set; }
    }
}