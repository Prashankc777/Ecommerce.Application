using AutoMapper;
using Ecommerce.Application.Profiles;
using Ecommerce.Data.DTOs;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/block")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockRepository _blockRepository;
        
        private readonly ILogger<BlockController> _logger;

        public BlockController(IBlockRepository blockRepository,  ILogger<BlockController> logger)
        {
            _blockRepository = blockRepository;
        
            _logger = logger;
        }

        [HttpPost , Route("insert")]
        public async Task<IActionResult> InsertBlock(BlockDto blockDto)
        {
            try
            {
                var insertedBlock = await _blockRepository.Insert(ObjectMapper.Mapper.Map<Block>(blockDto));
                return Ok($"The Block {insertedBlock.Name} has been added");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception while inserting block" , e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateBlock(BlockDto blockDto)
        {
            try
            {
                await _blockRepository.Update(ObjectMapper.Mapper.Map<Block>(blockDto));
                return Ok($"The Block  has been updated");


            }
            catch (Exception e)
            {
                _logger.LogError("Exception while updating block", e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("delete")]
        public async Task<IActionResult> DeleteBlock(BlockDto blockDto)
        {
            try
            {
                await _blockRepository.Delete(ObjectMapper.Mapper.Map<Block>(blockDto).Id);
                return Ok($"The Block  has been deleted");


            }
            catch (Exception e)
            {
                _logger.LogError("Exception while deleting block", e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("get-all")]
        public async Task<IActionResult> GetAllBlocks()
        {
            try
            {
                IEnumerable<BlockDto> blockDtos = ObjectMapper.Mapper.Map<IEnumerable<BlockDto>>(await _blockRepository.GetAll());
                return Ok(blockDtos);


            }
            catch (Exception e)
            {
                _logger.LogError("Exception while deleting block", e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                BlockDto blockDto = ObjectMapper.Mapper.Map<BlockDto>(await _blockRepository.GetById(id));
                return Ok(blockDto);

            }
            catch (Exception e)
            {
                _logger.LogError("Exception while deleting block", e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
