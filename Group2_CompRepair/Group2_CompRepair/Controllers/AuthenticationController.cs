using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Group2_CompRepair.Data;
using Group2_CompRepair.Models;

namespace Group2_CompRepair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        private readonly Group2_ComprepairContext _context;
        public AuthenticationController(JwtAuthenticationManager jwtAuthenticationManager, Group2_ComprepairContext _context)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this._context = _context;
        }


        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [Authorize]
        [HttpGet("ComputerParts")]
        public async Task<ActionResult<IEnumerable<ComputerPart>>> GetComputerParts()
        {
            return await _context.ComputerParts.ToListAsync();
        }

        // GET: api/Customers
        [Authorize]
        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Employees
        [Authorize]
        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Orders
        [Authorize]
        [HttpGet("Orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Softwares
        [Authorize]
        [HttpGet("Softwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetSoftwares()
        {
            return await _context.Softwares.ToListAsync();
        }

        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}