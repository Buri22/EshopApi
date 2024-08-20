using Microsoft.AspNetCore.Mvc;
using EshopApi.Application.Services;
using EshopApi.Domain.Entities;
using EshopApi.Presentation.Models;
using EshopApi.Presentation.Models.DTOs;
using AutoMapper;
using EshopApi.Presentation.Mapping;

namespace EshopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IMapper _mapper = MappingConfig.CreateMapper();

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetPaginatedProducts([FromQuery] PaginationRequest paginationRequest)
        {
            var products = productService.GetPaginatedProducts(paginationRequest.Page, paginationRequest.PageSize);
            var totalCount = productService.GetEntityCount();
            var paginationResponse = new PaginationResponse<Product>(products, totalCount, paginationRequest.Page, paginationRequest.PageSize);

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();

            var product = productService.AddProduct(_mapper.Map<Product>(productDTO));
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null || id != productDTO.Id) return BadRequest();

            var product = productService.UpdateProduct(_mapper.Map<Product>(productDTO));
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            productService.DeleteProduct(id);
            return NoContent();
        }
    }
}