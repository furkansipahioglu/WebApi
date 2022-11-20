using FoodAPI.Repositories;
using FoodAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repositories
{
    public class AdminRepository : taskAdminRepository
    {
        private readonly FoodContext _admincontext;

        public AdminRepository(FoodContext admincontext)
        {
            _admincontext = admincontext;
        }

        public async Task<AdminUser> Create(AdminUser admin)
        {
            _admincontext.Admin.Add(admin);
            await _admincontext.SaveChangesAsync();

            return admin;
        }

        

        public async Task Delete(int id)
        {
            var adminToDelete = await _admincontext.Admin.FindAsync(id);
            _admincontext.Admin.Remove(adminToDelete);
            await _admincontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdminUser>> Get()
        {
            return await _admincontext.Admin.ToListAsync();
        }

        public async Task<AdminUser> Get(int id)
        {
            return await _admincontext.Admin.FindAsync(id);
        }


        public async Task Update(AdminUser admin)
        {
            _admincontext.Entry(admin).State = EntityState.Modified;
            await _admincontext.SaveChangesAsync();
        }

       

        
    }
}
