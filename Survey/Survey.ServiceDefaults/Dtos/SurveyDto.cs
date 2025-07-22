// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 22:12"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

using System.Collections.Generic;

public class SurveyDto
{
    public List<SurveyQuestionDto> Questions { get; set; }
}