using DatabaseFirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Table1Controller : ControllerBase
    {
        private readonly MyDataBaseApproachContext _context;

        public Table1Controller(MyDataBaseApproachContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddTableData(Table1 data)
        {
            _context.Table1.Add(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

    }
}