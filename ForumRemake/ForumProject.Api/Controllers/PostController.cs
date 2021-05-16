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
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostController> _logger;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, ILogger<PostController> logger, IMapper mapper)
        {
            _postService = postService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _postService.DeleteById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(PostCreationDto obj)
        {
            try
            {
                await _postService.Add(_mapper.Map<PostDomain>(obj));
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(PostDomain obj)
        {
            try
            {
                await _postService.Update(obj);
                return StatusCode(200);
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
                var post = await _postService.GetById(id);

                return Ok(post);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("search/title/{title}")]
        public async Task<ActionResult<List<PostDomain>>> GetByTitle(string title)
        {
            try
            {
                var post = await _postService.GetByTitle(title);
                return Ok(post);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("search/category/{category}")]
        public async Task<ActionResult<List<PostDomain>>> GetByCategory(string category)
        {
            try
            {
                var post = await _postService.GetByCategory(category);
                return Ok(post);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDomain>>> GetAll()
        {
            try
            {
                var list = await _postService.GetAll();
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
