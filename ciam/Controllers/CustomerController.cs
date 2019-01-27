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
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<JsonResult> CreateOrEdit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Errors() });
            }

            _unitOfWork.Customers.Create(_mapper.Map<Customer>(model));

            await _unitOfWork.SaveChangesAsync();

            return Json(new { status = true });
        }

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _unitOfWork.Customers.GetAll().AsNoTracking().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider).ToDataSourceResultAsync(request);

            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetCustomerList()
        {
            var list = await _unitOfWork.Customers.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();

            return Json(list);
        }
    }
}