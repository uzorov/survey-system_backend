// <file>
//     <project="Survey.Api">
//     <author>"Кольчиков Евгений Олегович"</author>
//     <date>"21/07/2025 14:40"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class MetricRepository : IRepository<MetricModel>
{
    private readonly ApplicationContext context;
    public MetricRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<MetricModel> GetAll()
    {
        return this.context.Metrics.ToList();
    }

    public MetricModel GetEntityById(int id)
    {
        return this.context.Metrics.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(MetricModel entity)
    {
        this.context.Metrics.Add(entity);
        this.context.SaveChanges();
    }
}