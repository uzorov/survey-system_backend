// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 14:41"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Dtos;
using Survey.ServiceDefaults.Models;

public class QuestionRepository : IRepository<QuestionModel>
{
    private readonly ApplicationContext context;
    public QuestionRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<QuestionModel> GetAll()
    {
        return this.context.Questions.ToList();
    }

    public QuestionModel GetEntityById(int id)
    {
        return this.context.Questions.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(QuestionModel entity)
    {
        this.context.Questions.Add(entity);
        this.context.SaveChanges();
    }
}