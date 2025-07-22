// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 14:40"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class AnswerVariantRepository : IRepository<AnswerVariantModel>
{
    private readonly ApplicationContext context;

    /// <summary>
    ///   Инициализирует экземпляр класса <see cref = "AnalysisResultRepository" />
    /// </summary>
    public AnswerVariantRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<AnswerVariantModel> GetAll()
    {
        return this.context.AnswerVariants.ToList();
    }

    public AnswerVariantModel GetEntityById(int id)
    {
        return this.context.AnswerVariants.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(AnswerVariantModel entity)
    {
        this.context.AnswerVariants.Add(entity);
        this.context.SaveChanges();
    }
}