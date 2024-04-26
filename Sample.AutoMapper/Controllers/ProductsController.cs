using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.AutoMapper.Data;
using Sample.AutoMapper.Dtos;
using Sample.AutoMapper.Entities;

namespace Sample.AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AutoMapperSampleContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AutoMapperSampleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ProductDto> GetProduct()
        {
            _context.Add(new Product()
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Price = 102.32,
            });

            var dto = new ProductDto()
            {
                ProductName = "Name2",
                ProductDescription = "Des2",
                Price = 23.12,
                ProductId = 2
            };

            _context.Products.Add(_mapper.Map<Product>(dto));

             _context.SaveChangesAsync();

            return _context.Products/*.Where(c => c.Id == 1)*/
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
