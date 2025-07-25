// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"22/07/2025 8:51"</date>
// </file>

namespace Survey.Api.Services;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;
using Survey.ServiceDefaults.Constants;
using Survey.ServiceDefaults.Dtos;

public class AiAgentService : IAiAgentService
{

    private readonly HttpClient httpClient;
    private readonly IJsonSerializer jsonSerializer;

    public AiAgentService(HttpClient httpClient, IJsonSerializer jsonSerializer)
    {
        this.httpClient = httpClient;
        this.jsonSerializer = jsonSerializer;
    }

    /// <summary>
    ///     Обрабатывает заявку
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public AiAgentAnalysisResultDto AnalyzeSurvey(string message)
    {
        var _agentRequestDto = new AgentRequestDto()
        {
            Text = message
        };

        var _jsonFormattedAgentRequest = this.jsonSerializer.Serialize(_agentRequestDto);

        var _httpContent = new StringContent(_jsonFormattedAgentRequest);
        _httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var _response = this.httpClient.PostAsync(Addresses.REST_API_AI_AGENT_ANALYZE_FULL_ADDRESS, _httpContent).Result;

        if (!_response.IsSuccessStatusCode)
        {
            throw new Exception($"Ошибка при выполнении запроса к ИИ агенту. Код ответа: {_response.StatusCode}, Тело ответа: {_response.Content.ReadAsStringAsync().Result}");
        }

        var _responseContent = _response.Content.ReadAsStringAsync().Result;

        var _agentResponseDto = this.jsonSerializer.Deserialize<AiAgentAnalysisResultDto>(_responseContent);

        return _agentResponseDto;
    }

    /// <summary>
    ///     Обрабатывает заявку
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public string AnalyzeParameter(string parameter,string message)
    {
        var _agentRequestDto = new AgentRequestDto()
        {
            Text = message
        };

        var _jsonFormattedAgentRequest = this.jsonSerializer.Serialize(_agentRequestDto);

        var _httpContent = new StringContent(_jsonFormattedAgentRequest);
        _httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var _address = Addresses.REST_API_AI_AGENT_ANALYZE_PARAMETER_ADDRESS + parameter;

        var _response = this.httpClient.PostAsync(_address, _httpContent).Result;

        var _contentString = _response.Content.ReadAsStringAsync().Result;

        var _analysisResult = this.jsonSerializer.Deserialize<AiAgentAnalysisResultDto>(_contentString);

        if (parameter == ResponseKeys.TYPE_OF_PIPE)
        {
            return _analysisResult.TypeOfPype;
        }
        if (parameter == ResponseKeys.DIAMETER_OF_PIPE)
        {
            return _analysisResult.DiameterOfPipe;
        }
        if (parameter == ResponseKeys.VOLUME_TONS)
        {
            return _analysisResult.VolumeTons;
        }
        if (parameter == ResponseKeys.TIMELINE)
        {
            return _analysisResult.Timeline;
        }
        if (parameter == ResponseKeys.PIPE_WALL_THICKNESS)
        {
            return _analysisResult.PipeWallThickness;
        }
        if (parameter == ResponseKeys.INTEREST_LEVEL)
        {
            return _analysisResult.InterestLevel;
        }

        return null;
    }
}