// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 14:32"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class CompanyRepository : IRepository<CompanyModel>
{
    private readonly ApplicationContext context;
    public CompanyRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<CompanyModel> GetAll()
    {
        return this.context.Companies.ToList();
    }

    public CompanyModel GetEntityById(int id)
    {
        return this.context.Companies.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(CompanyModel entity)
    {
        this.context.Companies.Add(entity);
        this.context.SaveChanges();
    }

}