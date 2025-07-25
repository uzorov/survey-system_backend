// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 23:59"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

public class SurveyResponseDto
{
    public string Id { get; set; }
    public string Answer { get; set; }
    public bool IsOther { get; set; }
}