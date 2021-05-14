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
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _postService.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public ActionResult Add(PostDto obj)
        {
            try
            {
                var post = new PostDomain
                {
                    Id = Guid.NewGuid(),
                    Category = obj.Category,
                    Description = obj.Description,
                    IsClosed = false,
                    Title = obj.Title,
                    PostPoint = 0,
                    PublishTime = DateTime.Now,
                    Messages = null
                };

                _postService.Add(post);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        public ActionResult Update(PostDomain obj)
        {
            try
            {
                _postService.Update(obj);
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
                var post = _postService.GetById(id);

                return Ok(new PostDto(post));
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
                var list = _postService.GetAll();
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
