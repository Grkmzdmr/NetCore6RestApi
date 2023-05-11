using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;
using NLayer.Core;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IServices<Product> _services;
        private readonly IProductService productService;

        public ProductsController(IServices<Product> service,IMapper mapper,IProductService productService)
        {
            _services = service;
            _mapper = mapper;
            this.productService = productService;

        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await productService.GetProductsWithCategory());

        }








        [HttpGet]
        public async Task<IActionResult> All()
        {
             var products = await _services.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDTO<List<ProductDto>>.Success(200, productsDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _services.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var products = await _services.AddAsync(_mapper.Map<Product>(product));
            var productsDtos = _mapper.Map<ProductDto>(products);

            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(201, productsDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _services.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(204));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            var product = await _services.GetByIdAsync(id);


            if(product == null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentDto>.Fail(404, "B u idye sahip ürün bulunamadı"));
            }

            await _services.DeleteAsync(product);

            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(204));
        }


    }
}
