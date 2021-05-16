using Microsoft.AspNetCore.Mvc;
using System;
using ForumProject.Biz.Domain;
using Microsoft.Extensions.Logging;
using ForumProject.Biz.Interfaces.Services;
using ForumProject.Dal.Context.Dto;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace ForumProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessageController> _logger;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, ILogger<MessageController> logger, IMapper mapper)
        {
            _messageService = messageService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _messageService.DeleteById(id);
                return StatusCode(200);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Add(MessageCreationDto obj)
        {
            try
            {
                await _messageService.Add(_mapper.Map<MessageDomain>(obj));
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(MessageDomain obj)
        {
            try
            {
                await _messageService.Update(obj);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDomain>> GetById(Guid id)
        {
            try
            {
                var message = await _messageService.GetById(id);
                return Ok(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDomain>>> GetAll()
        {
            try
            {
                var list = await _messageService.GetAll();
                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}
