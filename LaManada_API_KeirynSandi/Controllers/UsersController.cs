using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaManada_API_KeirynSandi.Models;
using LaManada_API_KeirynSandi.ModelsDTO;

namespace LaManada_API_KeirynSandi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LaManadaContext _context;

        public UsersController(LaManadaContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("GetUserInfoByEmail")]
        //Esta version de get muestra la informacion del usuario
        //según su correo,y será usada para cargar la información del ususario
        //justo despues de la validación del login en la app,
        //con esto crearemos un usuario global
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserInfoByEmail(string pEmail)
        {
            var query = (from u in _context.Users
                         join ur in _context.UserRoles    
                         on u.UserRoleId equals ur.UserRoleId
                         where u.Email == pEmail
                         select new
                         {
                            id = u.UsersId,
                            correo = u.Email,
                            nombre = u.FirstName,
                            telefono = u.PhoneNumber,
                            rolid = u.UserRoleId,
                            descripcion = ur.UserRoleId
                         }
                         ).ToList();

            List<UsuarioDTO> list = new List<UsuarioDTO>();

            foreach (var item in list)
            {
                UsuarioDTO nuevoUsuario = new UsuarioDTO()
                {
                    UsersId = item.UsersId,
                    Correo = item.Correo,
                    Nombre = item.Nombre,
                    Telefono = item.Telefono,
                    RolID = item.RolID,
                    RolDescripcion=item.RolDescripcion,
                };
                list.Add(nuevoUsuario);
            }

            if (list == null) { return NotFound(); }

            return list;

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UsersId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UsersId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }
    }
}
