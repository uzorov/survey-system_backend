// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 14:39"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class AnalysisResultRepository : IRepository<AnalysisResultModel>
{
    private readonly ApplicationContext context;

    /// <summary>
    ///   Инициализирует экземпляр класса <see cref = "AnalysisResultRepository" />
    /// </summary>
    public AnalysisResultRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<AnalysisResultModel> GetAll()
    {
        return this.context.AnalysisResults.Include(x => x.Contact).ToList();
    }

    public AnalysisResultModel GetEntityById(int id)
    {

        return this.context.AnalysisResults.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(AnalysisResultModel entity)
    {
        this.context.AnalysisResults.Add(entity);
        this.context.SaveChanges();
    }
}