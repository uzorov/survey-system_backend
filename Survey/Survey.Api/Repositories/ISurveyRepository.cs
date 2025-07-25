// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 22:32"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using Survey.ServiceDefaults.Dtos;
using Survey.ServiceDefaults.Models;

public interface ISurveyRepository : IRepository<SurveyModel>
{
    List<SurveyQuestionDto> GetSurveyQuestions();
}