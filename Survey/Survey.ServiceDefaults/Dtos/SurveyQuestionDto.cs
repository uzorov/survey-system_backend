// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 22:12"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

public class SurveyQuestionDto
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string[] Answers { get; set; }
    public bool AllowOther { get; set; }
}