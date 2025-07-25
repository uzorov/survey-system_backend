// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"22/07/2025 11:40"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

using Survey.ServiceDefaults.Models;

public class FreeFormResponseDto
{
    public string Message { get; set; }
    public ContactModel Contact { get; set; }
}