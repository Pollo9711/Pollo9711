using Microsoft.AspNetCore.Mvc;
using System;
using ForumProject.Biz.Domain;
using ForumProject.Biz.Interfaces.Services;
using Microsoft.Extensions.Logging;
using ForumProject.Dal.Context.Dto;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace ForumProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService service, ILogger<UserController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserDomain obj)
        {
            try
            {
                await _service.Update(obj);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserCreationDto obj)
        {
            try
            {
                await _service.Add(_mapper.Map<UserDomain>(obj));
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDomain>>> GetAll()
        {
            try
            {
                var list = await _service.GetAll();
                return Ok(list);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDomain>> GetById(Guid id)
        {
            try
            {
                var user = await _service.GetById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDomain>> Login(string username, string password)
        {
            try
            {
                var toCheck = await _service.Login(username, password);
                if (toCheck is null)
                    return StatusCode(403);
                return Ok(toCheck);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}
