using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Api.ViewModels;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ForumProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPut]
        public ActionResult Update(UserDomain obj)
        {
            try
            {
                _service.Update(obj);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public ActionResult Add(UserDto obj)
        {
            try
            {
                _logger.LogInformation("info", obj);
                var user = new UserDomain
                {
                    Id = Guid.NewGuid(),
                    Email = obj.Email,
                    Password = obj.Password,
                    Username = obj.Username,
                    BanTime = DateTime.MinValue,
                    Messages = null
                };
                _logger.LogInformation("info", user);
                _service.Add(user);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.DeleteById(id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var list = _service.GetAll();
                return Ok(list);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDomain> GetById(Guid id)
        {
            try
            {
                var user = _service.GetById(id);

                return Ok(new UserDto(user));

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }
    }
}
