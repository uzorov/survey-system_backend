// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 23:52"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

using System.Collections.Generic;
using Survey.ServiceDefaults.Models;

public class CompletedSurveyDto
{
    public List<SurveyResponseDto> Responses { get; set; }
    public ContactModel Contact { get; set; }
}