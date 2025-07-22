// <file>
//     <project="Survey.Api">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 14:26"</date>
// </file>

namespace Survey.Api.Repositories;

using System.Collections.Generic;
using Survey.ServiceDefaults.Models;

public interface IRepository<T> where T : class
{
    List<T> GetAll();

    T GetEntityById(int id);

    void AddEntity(T entity);
}