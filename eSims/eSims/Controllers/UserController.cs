﻿using eSims.Models;
using eSims.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eSims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{username}", Name = "GetUser")]
        public ActionResult<User> Get(string username)
        {
            var user = _userService.Get(username);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            if (_userService.Create(user) == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }
            
    }
}
