using FoodAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repositories
{
    public interface taskAdminRepository
    {
        Task<IEnumerable<AdminUser>> Get();
        Task<AdminUser> Get(int id);
        Task<AdminUser> Create(AdminUser admin);
        Task Update(AdminUser admin);
        Task Delete(int id);
    }
}
