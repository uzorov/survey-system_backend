// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 13:28"</date>
// </file>

namespace Survey.ServiceDefaults.Models;

using System;

/// <summary>
///     Класс модели пользователя
/// </summary>
public class UserModel
{
    /// <summary>
    ///     Идентификатор   
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Имя пользователя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Эл. почта пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Дата создания пользователя
    /// </summary>
    public DateTime Created { get; set; }
}