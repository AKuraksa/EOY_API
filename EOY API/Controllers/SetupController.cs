﻿using EOY_API.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly EoyDbContext _context;

        public SetupController(EoyDbContext context)
        {
            _context = context;
        }


        [HttpPost("create")]
        public ActionResult<string> CreateDatabaseAndTables()
        {
            try
            {

                _context.Database.EnsureCreated();



                return Ok("Databáze");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Chyba při vytváření databáze a tabulek: {ex.Message}");
            }




        }
    }
}