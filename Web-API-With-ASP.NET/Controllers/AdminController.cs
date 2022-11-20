using FoodAPI.Models;
using FoodAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly FoodContext _admincontext;

        public AdminController() => _admincontext = new FoodContext();

       

        [HttpGet]
        public async Task<IEnumerable<AdminUser>> GetAdmins()
        {
            return await _admincontext.Admin.ToListAsync();
        }

        [HttpGet("id")]
        
        public async Task<ActionResult<AdminUser>> GetAdmins(string id)
        {
            var admin = await _admincontext.Admin.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

       

        [HttpPost]
        
        public async Task<ActionResult<AdminUser>>PostAdmins([FromBody] AdminUser admin)
        {
            _admincontext.Admin.Add(admin);
          
            
                await _admincontext.SaveChangesAsync();
            
            
            

            return CreatedAtAction("GetAdmins", new { id = admin.adminname }, admin);

          

        }


        [HttpPut]
        public async Task<ActionResult> PutAdmins(string id, [FromBody] AdminUser admin)
        {
            if (id != admin.adminname)
            {
                return BadRequest();
            }

            _admincontext.Entry(admin).State = EntityState.Modified;

            
                await _admincontext.SaveChangesAsync();
            
           

            return NoContent();
        }
        [HttpPost("CheckUser")]
        public async Task<ActionResult<AdminUser>> CheckAdminUser(AdminUser admin)
        {
            //Console.WriteLine(adminUser);
            //await _context.AdminUsers.ToListAsync();
            var user = await _admincontext.Admin.FindAsync(admin.adminname);
            if (user == null)
            {
                return Ok("Kullanıcı Mevcut Değil");
            }
            if (user.adminpass == admin.adminpass)
            {
                return Ok("Giriş Başarılı");
            }
            else
            {
                return Ok("Şifre Hatalı");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (string id)
        {
            var adminUser = await _admincontext.Admin.FindAsync(id);
            if (adminUser == null)
            {
                return NotFound();
            }

            _admincontext.Admin.Remove(adminUser);
            await _admincontext.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminUserExists(string id)
        {
            return _admincontext.Admin.Any(e => e.adminname == id);
        }
    }

    internal class UnitOfWorkAttribute : Attribute
    {
        public bool IsDisabled;
    }
}

