using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.ProductDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult ProductCreate(CreateProductDto createProductDto)
        {
            var value = new Product()
            {
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                ProductPrice = createProductDto.ProductPrice,
                ProductImage = createProductDto.ProductImage,
                ProductStatus = createProductDto.ProductStatus,
                CategoryId = createProductDto.CategoryId
            };
            _productService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult ProductGet(int id)
        {
            var value = _productService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
        {
            var value = new Product()
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                ProductDescription = updateProductDto.ProductDescription,
                ProductPrice = updateProductDto.ProductPrice,
                ProductImage = updateProductDto.ProductImage,
                ProductStatus = updateProductDto.ProductStatus,
                CategoryId = updateProductDto.CategoryId
            };
            _productService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            var value = _productService.GetById(id);
            _productService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetProductsWithCategory")]
        public IActionResult GetProductsWithCategory()
        {
            var products = _productService.GetProductsWithCategory(); // 1.adım: Product, Include ile Category'i de aldı ve geldi
            var values = _mapper.Map<List<ResultProductWithCategoryDto>>(products); // 2.adım: Product Dto ile Mapl'lendi
            for (int i = 0; i < values.Count(); i++)
            { // 3.adım: Dto içindeki CategoryName property'sine, Product içindeki Category.CategoryName bilgisi gönderildi.
                values[i].CategoryName = products[i].Category.CategoryName;
            }

            return Ok(values);
        }

        [HttpGet("GetProductsWithCategoryStatusTrue")]
        public IActionResult GetProductsWithCategoryStatusTrue()
        {
            var products = _productService.GetProductsWithCategoryStatusTrue();

            var values = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            for (int i = 0; i < values.Count(); i++)
            {
                values[i].CategoryName = products[i].Category.CategoryName;
            }

            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var result = _productService.ProductCount();
            return Ok(result);
        }
    }
}