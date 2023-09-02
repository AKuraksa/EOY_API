﻿using EOY_API.db;
using EOY_API.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Windows.UI.Notifications;

namespace EOY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EoyDbContext _context;

        public LoginController(EoyDbContext context)
        {
            _context = context;

        }

        [HttpGet("/FindUser")]
        public IActionResult Get(string username, string password)
        {
            var listUsers = _context.Logins.Where(x=> x.Username == username 
            && x.Password == password ).ToList();


            return Ok(listUsers);
        }

        [HttpGet("/All_Data_FROM_Logins")]
        public IActionResult Get()
        {
            var listUsers = _context.Logins.ToList();


            return Ok(listUsers);
        }

        [HttpGet("/GetDataByLastName")]
        public IActionResult GetDataByLastName(string Lastname)
        {
            var User = _context.Logins
                .Where(x => x.LastName == Lastname)
                .ToList();


            return Ok("Deleted");
        }

        [HttpDelete("/DeleteByID")]
        public IActionResult DeleteById(Guid id)
        {
            var user = _context.Logins
                .FirstOrDefault(x => x.id == id);

            if (user == null)
            {
                return NotFound(); // Jeśli użytkownik nie istnieje, zwróć odpowiedź 404 Not Found.
            }

            _context.Logins.Remove(user); // Usuń użytkownika z bazy danych.
            _context.SaveChanges(); // Zapisz zmiany w bazie danych.

            return Ok(); // Zwróć odpowiedź 200 OK.
        }

        [HttpPost("create_login")]
        public IActionResult CreateLogin(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            bool admin)
        {
            var NewLogin = new Login
            {
                Username=username,
                Password=password,
                Email=email,
                FirstName=firstName,
                LastName= lastName,
                Permission = admin
                  


            };
            if (!string.IsNullOrEmpty(username)
                || !string.IsNullOrEmpty(password)
                || !string.IsNullOrEmpty(email)
                || !string.IsNullOrEmpty(firstName)
                || !string.IsNullOrEmpty(lastName))
            {
                _context.Logins.Add(NewLogin);
                return Ok(_context.SaveChanges());
            }                 
            else
            {
                return BadRequest("data missing");
            }
        }

        [HttpPatch("DataChange")]
        public IActionResult DataPATCH (
            string Search_Username,
            string password,
            string email,
            string firstName,
            string lastName)
        {

            var user = _context.Logins.FirstOrDefault(u => u.Username == Search_Username);

            if (user == null)
            {
                return NotFound(); 
            }

         
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = password;
            }
            if (!string.IsNullOrEmpty(email))
            {
                user.Email = email;
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                user.FirstName = firstName;
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                user.LastName = lastName;
            }

            _context.SaveChanges();

            return Ok("User data updated successfully");
        }

    }
}