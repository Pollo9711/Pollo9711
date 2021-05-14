using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Api.ViewModels;
using ForumProject.Biz.Domain;
using Microsoft.Extensions.Logging;
using ForumProject.Biz.Interfaces.Services;

namespace ForumProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMessageService messageService, ILogger<MessageController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _messageService.DeleteById(id);
                return Ok();

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }

        }

        [HttpPost]
        public ActionResult Add(MessageDto obj)
        {
            try
            {
                var message = new MessageDomain
                {
                    Id = Guid.NewGuid(),
                    Text = obj.Text,
                    IsReported = false,
                    MessagePoint = 0,
                    PublishTime = DateTime.Now,
                    PostId =obj.Post,
                    UserId = obj.User
                };
                _messageService.Add(message);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        public ActionResult Update(MessageDomain obj)
        {
            try
            {
                _messageService.Update(obj);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                var message = _messageService.GetById(id);
                return Ok(new MessageDto(message));
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
                var list = _messageService.GetAll();
                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }
    }
}
