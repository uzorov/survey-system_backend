// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 14:43"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using System.Linq;
using Survey.EntityFramework.Contexts;
using Survey.ServiceDefaults.Models;

public class UserRepository : IRepository<ContactModel>
{
    private readonly ApplicationContext context;
    public UserRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public List<ContactModel> GetAll()
    {
        return this.context.Users.ToList();
    }

    public ContactModel GetEntityById(int id)
    {
        return this.context.Users.FirstOrDefault(x => x.Id == id);
    }

    public void AddEntity(ContactModel entity)
    {
        this.context.Users.Add(entity);
        this.context.SaveChanges();
    }

}