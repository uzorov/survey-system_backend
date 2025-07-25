// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 14:42"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Dtos;
using Survey.ServiceDefaults.Models;

public class SurveyRepository : ISurveyRepository
{
    private readonly ApplicationContext context;
    public SurveyRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<SurveyModel> GetAll()
    {
        return this.context.Surveys.ToList();
    }

    public SurveyModel GetEntityById(int id)
    {
        return this.context.Surveys.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(SurveyModel entity)
    {
        this.context.Surveys.Add(entity);
        this.context.SaveChanges();
    }

    public List<SurveyQuestionDto> GetSurveyQuestions()
    {
        var _questions = context.Questions
                                .Select(q => new SurveyQuestionDto()
                                {
                                    Id = q.Id.ToString(),
                                    Text = q.Question,
                                    Answers = context.AnswerVariants
                                                     .Where(a => a.Question.Id == q.Id)
                                                     .Select(a => a.AnswerVariant)
                                                     .ToArray(),
                                    AllowOther = q.IsAllowOtherAnswer
                                })
                                .ToList();

        return _questions;
    }
}