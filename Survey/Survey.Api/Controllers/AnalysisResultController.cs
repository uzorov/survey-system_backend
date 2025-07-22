using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.ServiceDefaults.Dtos;

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

            var _jsonFormattedAnalysis = this.jsonSerializer.Serialize(_analysisResults);

            return this.Ok(_jsonFormattedAnalysis);
        }
    }
}
