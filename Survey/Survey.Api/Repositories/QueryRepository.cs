// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 14:41"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class QueryRepository : IRepository<QueryModel>
{
    private readonly ApplicationContext context;
    public QueryRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<QueryModel> GetAll()
    {
        return this.context.Queries.ToList();
    }

    public QueryModel GetEntityById(int id)
    {
        return this.context.Queries.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(QueryModel entity)
    {
        this.context.Queries.Add(entity);
        this.context.SaveChanges();
    }

}