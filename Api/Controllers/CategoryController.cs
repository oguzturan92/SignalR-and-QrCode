using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.CategoryDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
        {
            var value = new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = createCategoryDto.CategoryStatus
            };
            _categoryService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var value = _categoryService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            var value = new Category()
            {
                CategoryId = updateCategoryDto.CategoryId,
                CategoryName = updateCategoryDto.CategoryName,
                CategoryStatus = updateCategoryDto.CategoryStatus
            };
            _categoryService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryService.GetById(id);
            _categoryService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var result = _categoryService.CategoryCount();
            return Ok(result);
        }

        [HttpGet("GetCategoriesAndProducts")]
        public IActionResult GetCategoriesAndProducts()
        {
            var categoriesAndProducts = _categoryService.GetCategoriesAndProducts();

            var resultCategoryAndProductsDto = categoriesAndProducts.Select(i => new ResultCategoryAndProductsDto
            {
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryName,
                CategoryStatus = i.CategoryStatus,
                Products = i.Products.Select(a => new ResultCategoryAndProductsDto.Product
                {
                    ProductId = a.ProductId,
                    ProductName = a.ProductName,
                    ProductDescription = a.ProductDescription,
                    ProductImage = a.ProductImage,
                    ProductPrice = a.ProductPrice,
                    ProductStatus = a.ProductStatus,
                    CategoryId = a.CategoryId
                }).ToList()
            }).ToList();

            var values = _mapper.Map<List<ResultCategoryAndProductsDto>>(resultCategoryAndProductsDto);

            return Ok(values);
        }
    }
}