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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ciam.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesOrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("AddOrEdit", new SalesOrderViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _unitOfWork.SalesOrders.GetAll().Where(x => x.Id == id)
                                                     .AsNoTracking()
                                                     .Include(x => x.SalesOrderDetails)
                                                     .ProjectTo<SalesOrderViewModel>(_mapper.ConfigurationProvider)
                                                     .FirstOrDefaultAsync();

            return View("AddOrEdit", model);
        }

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _unitOfWork.SalesOrders.GetAll()
                                                    .Include(x=>x.Customer)
                                                    .Include(x=>x.SalesStatus)
                                                    .Include(x=>x.SalesOrderDetails)
                                                    .AsNoTracking()
                                                    .ProjectTo<SalesOrderViewModel>(_mapper.ConfigurationProvider)
                                                    .ToDataSourceResultAsync(request);

            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(SalesOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddOrEdit", model);
            }

            var entity = _mapper.Map<SalesOrder>(model);

            if (model.Id != null)
            {
                _unitOfWork.SalesOrders.Update(entity);
            }   
            else
                _unitOfWork.SalesOrders.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction("Edit","SalesOrder", new { area = "", id = entity.Id});
        }
    }
}