// <file>
//     <project="Survey.ServiceDefaults">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"22/07/2025 11:47"</date>
// </file>

namespace Survey.ServiceDefaults.Dtos;

using System.Text.Json.Serialization;

public class AiAgentAnalysisResultDto
{
    [JsonPropertyName("type_of_pipe")]
    public string TypeOfPype { get; set; }

    [JsonPropertyName("diameter_of_pipe")]
    public string DiameterOfPipe { get; set; }

    [JsonPropertyName("pipe_wall_thickness")]
    public string PipeWallThickness { get; set; }

    [JsonPropertyName("volume_tons")]
    public string VolumeTons { get; set; }

    [JsonPropertyName("timeline")]
    public string Timeline { get; set; }

    [JsonPropertyName("interest_level")]
    public string InterestLevel { get; set; }
}

