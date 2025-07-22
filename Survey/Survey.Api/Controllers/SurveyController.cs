namespace Survey.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Survey.Api.Repositories;
    using Survey.Api.Services;
    using Survey.ServiceDefaults.Constants;
    using Survey.ServiceDefaults.Dtos;
    using Survey.ServiceDefaults.Enums;
    using Survey.ServiceDefaults.Models;
    using JsonSerializer = System.Text.Json.JsonSerializer;

    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyRepository surveyRepository;
        private readonly IRepository<AnalysisResultModel> analysisResultRepository;
        private readonly IJsonSerializer jsonSerializer;
        private readonly IAiAgentService aiAgentService;

        /// <summary>
        ///   Инициализирует экземпляр класса <see cref = "SurveyController" />
        /// </summary>
        public SurveyController(ISurveyRepository surveyRepository, IJsonSerializer jsonSerializer, IRepository<AnalysisResultModel> analysisResultRepository, IAiAgentService aiAgentService)
        {
            this.surveyRepository = surveyRepository;
            this.jsonSerializer = jsonSerializer;
            this.analysisResultRepository = analysisResultRepository;
            this.aiAgentService = aiAgentService;
        }

        [HttpPost("/api/survey/submit")]
        public IActionResult SubmitSurvey([FromBody] JsonElement jsonContent)
        {
            try
            {
                var _completedSurvey = this.jsonSerializer.Deserialize<CompletedSurveyDto>(jsonContent.GetRawText());

                var _analysisResult = new AnalysisResultModel();
                _analysisResult.AnalysisDateTime = DateTime.UtcNow;

                this.FillAnalysisResultFields(_completedSurvey.Responses, _analysisResult);

                _analysisResult.Contact = _completedSurvey.Contact;

                this.analysisResultRepository.AddEntity(_analysisResult);

                var _response = new ResponseDto()
                {
                    Success = true,
                    Message = "Ответы успешно отправлены"
                };

                var _serializedResponse = this.jsonSerializer.Serialize(_response);

                return this.Ok(_serializedResponse);
            }
            catch (Exception _exception)
            {
                var _response = new ResponseDto()
                {
                    Success = false,
                    Message = _exception.Message
                };

                var _serializedResponse = this.jsonSerializer.Serialize(_response);

                return this.StatusCode(500, _serializedResponse);
            }
        }

        [HttpPost("/api/survey/freeform")]
        public IActionResult PostFreeForm([FromBody] JsonElement jsonEventContent)
        {
            try 
            {
                var _freeFormDto = this.jsonSerializer.Deserialize<FreeFormResponseDto>(jsonEventContent.GetRawText());

                var _analysisResult = new AnalysisResultModel();

                var _agentAnalysisResult = this.aiAgentService.AnalyzeSurvey(_freeFormDto.Message);

                _analysisResult.TypeOfPipe = _agentAnalysisResult.TypeOfPype ?? string.Empty;
                _analysisResult.DiameterOfPipe = _agentAnalysisResult.DiameterOfPipe ?? string.Empty;
                _analysisResult.PipeWallThickness = _agentAnalysisResult.PipeWallThickness ?? string.Empty;
                _analysisResult.Timeline = _agentAnalysisResult.Timeline ?? string.Empty;
                _analysisResult.VolumeTons = _agentAnalysisResult.VolumeTons ?? string.Empty;
                _analysisResult.InterestLevel = _agentAnalysisResult.InterestLevel ?? string.Empty;
                _analysisResult.Text = $"Message: {_freeFormDto.Message}{Environment.NewLine}";
                _analysisResult.Contact = _freeFormDto.Contact;

                this.analysisResultRepository.AddEntity(_analysisResult);

                var _response = new ResponseDto()
                {
                    Success = true,
                    Message = "Сообщение успешно отправлено"
                };

                var _serializedResponse = this.jsonSerializer.Serialize(_response);

                return this.Ok(_serializedResponse);
            }
            catch (Exception _exception)
            {
                var _response = new ResponseDto()
                {
                    Success = false,
                    Message = _exception.Message
                };

                var _serializedResponse = this.jsonSerializer.Serialize(_response);

                return this.StatusCode(500, _serializedResponse);
            }
        }

        [HttpGet("/api/survey")]
        public IActionResult GetSurveys()
        {
            var _surveyDto = new SurveyDto()
            {
                Questions = this.surveyRepository.GetSurveyQuestions()
            };

            var _jsonFormattedSurvey = this.jsonSerializer.Serialize(_surveyDto);

            return this.Ok(_jsonFormattedSurvey);
        }

        private void FillAnalysisResultFields(List<SurveyResponseDto> responses, AnalysisResultModel analysisResult)
        {
            var _timeline = string.Empty;
            var _volumeTons = string.Empty;

            foreach (var _response in responses)
            {
                if (_response.Id == ResponseKeys.TYPE_OF_PIPE)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.TYPE_OF_PIPE, _response.Answer);
                        analysisResult.TypeOfPipe = _analyzedValue;

                        analysisResult.Text += $"{_response.Answer};";

                        continue;
                    }

                    analysisResult.TypeOfPipe = _response.Answer;
                }
                else if (_response.Id == ResponseKeys.DIAMETER_OF_PIPE)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.DIAMETER_OF_PIPE, _response.Answer);
                        analysisResult.DiameterOfPipe = _analyzedValue;

                        analysisResult.Text += $"{_response.Answer};";

                        continue;
                    }

                    analysisResult.DiameterOfPipe = _response.Answer;
                }
                else if (_response.Id == ResponseKeys.PIPE_WALL_THICKNESS)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.PIPE_WALL_THICKNESS, _response.Answer);
                        analysisResult.PipeWallThickness = _analyzedValue;

                        analysisResult.Text += $"{_response.Answer};";


                        continue;
                    }

                    analysisResult.PipeWallThickness = _response.Answer;
                }
                else if (_response.Id == ResponseKeys.TIMELINE)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.TIMELINE, _response.Answer);
                        analysisResult.Timeline = _analyzedValue;

                        _timeline = _analyzedValue;
                        analysisResult.Text += $"{_response.Answer};";

                        continue;
                    }

                    analysisResult.Timeline = _response.Answer;
                    _timeline = _response.Answer;
                }
                else if (_response.Id == ResponseKeys.VOLUME_TONS)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.VOLUME_TONS, _response.Answer);
                        analysisResult.VolumeTons = _analyzedValue;

                        _volumeTons = _analyzedValue;
                        analysisResult.Text += $"{_response.Answer};";

                        continue;
                    }

                    _volumeTons = _response.Answer;
                    analysisResult.VolumeTons = _response.Answer;
                }
                else if (_response.Id == ResponseKeys.INTEREST_LEVEL)
                {
                    if (_response.IsOther)
                    {
                        var _analyzedValue = this.aiAgentService.AnalyzeParameter(ResponseKeys.INTEREST_LEVEL, _response.Answer);
                        analysisResult.InterestLevel = _analyzedValue;

                        continue;
                    }

                    analysisResult.InterestLevel = this.CalculateInterestLevel(_timeline, _volumeTons);
                }
            }
        }

        private string CalculateInterestLevel(string timeline, string volumeTons)
        {
            if (timeline == "До месяца" && volumeTons == "До 100 т.")
            {
                return InterestLevel.Hot.ToString();
            }
            if (timeline == "Более месяца" && volumeTons == "До 100 т.")
            {
                return InterestLevel.Warm.ToString();
            }
            if (timeline == "До месяца" && volumeTons == "От 100 т.")
            {
                return InterestLevel.Warm.ToString();
            }
            if (timeline == "Более месяца" && volumeTons == "От 100 т.")
            {
                return InterestLevel.Cold.ToString();
            }

            return null;
        }
    }
}
