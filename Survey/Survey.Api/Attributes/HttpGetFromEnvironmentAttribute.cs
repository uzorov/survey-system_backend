// <file>
//     <project="mnpk_2025">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 11:49"</date>
// </file>

namespace Survey.Api.Attributes
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Класс атрибута, который:
    ///     1. Определяет http-метод GET
    ///     2. Извлекает шаблон маршрута к GET-методу из переменной окружения
    /// </summary>
    public class HttpGetFromEnvironmentAttribute : HttpGetAttribute
    {
        /// <summary>
        ///     Инициализирует экземпляр класса <see cref="HttpGetFromEnvironmentAttribute" />
        /// </summary>
        /// <param name="variableName">Наименование переменной окружения, значение которой должно быть использовано в качестве шаблона маршрута к GET-методу MVC-контроллера</param>
        /// <param name="defaultTemplate">Значение маршрута по умолчанию. Используется в случае, если переменная окружения "variableName" не задана</param>
        public HttpGetFromEnvironmentAttribute(string variableName, string defaultTemplate) : base(Environment.GetEnvironmentVariable(variableName) ?? defaultTemplate) { }
    }
}