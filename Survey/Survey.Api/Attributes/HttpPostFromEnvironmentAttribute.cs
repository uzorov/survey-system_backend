// <file>
//     <project="mnpk_2025">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 11:48"</date>
// </file>

namespace Survey.Api.Attributes
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Класс атрибута, который:
    ///     1. Определяет http-метод POST
    ///     2. Извлекает шаблон маршрута к POST-методу из переменной окружения
    /// </summary>
    public class HttpPostFromEnvironmentAttribute : HttpPostAttribute
    {
        /// <summary>
        ///     Инициализирует экземпляр класса <see cref="HttpPostFromEnvironmentAttribute" />
        /// </summary>
        /// <param name="variableName">Наименование переменной окружения, значение которой должно быть использовано в качестве шаблона маршрута к POST-методу MVC-контроллера</param>
        /// <param name="defaultTemplate">Значение маршрута по умолчанию. Используется в случае, если переменная окружения "variableName" не задана</param>
        public HttpPostFromEnvironmentAttribute(string variableName, string defaultTemplate) : base(Environment.GetEnvironmentVariable(variableName) ?? defaultTemplate) { }
    }
}