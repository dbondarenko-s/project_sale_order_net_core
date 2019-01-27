using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ciam.DAL.Entities;
using Ciam.DAL.Interfaces;
using Ciam.Extensions;
using Ciam.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ciam.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult _AddOrEditPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrEdit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Errors() });
            }

            _unitOfWork.Products.Create(_mapper.Map<Product>(model));

            await _unitOfWork.SaveChangesAsync();

            return Json(new { status = true });
        }

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _unitOfWork.Products.GetAll().AsNoTracking().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToDataSourceResultAsync(request);

            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductList()
        {
            var list = await _unitOfWork.Products.GetAll().Select(x=> new { x.Id, Name = x.Name + " (" + x.ListPrice.ToString() + ")" }).AsNoTracking().ToListAsync();

            return Json(list);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductPrice(int? id)
        {
            var price = await _unitOfWork.Products.GetAll().Where(x=>x.Id == id).Select(x => x.ListPrice).SingleOrDefaultAsync();

            return Json(new { status = true, price = id == null ? (decimal?)null : price });
        }
    }
}