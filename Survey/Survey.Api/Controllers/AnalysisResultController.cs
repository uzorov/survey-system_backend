using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.ServiceDefaults.Dtos;
using System.Linq;

namespace Survey.Api.Controllers
{
    using Survey.Api.Repositories;
    using Survey.Api.Services;
    using Survey.ServiceDefaults.Models;

    [ApiController]
    public class AnalysisResultController : ControllerBase
    {
        private readonly IRepository<AnalysisResultModel> analysisResultRepository;
        private readonly IJsonSerializer jsonSerializer;

        public AnalysisResultController(IRepository<AnalysisResultModel> analysisResultRepository, IJsonSerializer jsonSerializer)
        {
            this.analysisResultRepository = analysisResultRepository;
            this.jsonSerializer = jsonSerializer;
        }

        [HttpGet("/api/analysis")]
        public IActionResult GetAnalysisResults()
        {
            var _analysisResults = analysisResultRepository.GetAll();

            var _result = _analysisResults.Select(x => new {
                x.Id,
                TypeOfPipe = string.IsNullOrEmpty(x.TypeOfPipe) ? x.TypeOfPipe : char.ToUpper(x.TypeOfPipe[0]) + x.TypeOfPipe.Substring(1),
                x.DiameterOfPipe,
                x.PipeWallThickness,
                x.VolumeTons,
                x.Timeline,
                InterestLevel = x.InterestLevel?.ToLower() switch
                {
                    "hot" => "Горячий",
                    "warm" => "Тёплый",
                    "cold" => "Холодный",
                    _ => x.InterestLevel
                },
                x.Text,
                x.Query,
                x.Contact
            });

            var _jsonFormattedAnalysis = this.jsonSerializer.Serialize(_result);

            return this.Ok(_jsonFormattedAnalysis);
        }
    }
}
