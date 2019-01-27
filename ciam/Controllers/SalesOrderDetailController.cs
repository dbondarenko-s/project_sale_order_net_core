using System;
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
    public class SalesOrderDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesOrderDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> _AddOrEditPartial(int salesOrderId, int? id)
        {
            if(id != null)
            {
                var model = await _unitOfWork.SalesOrderDetails.GetAll().Where(x => x.Id == id)
                                                                        .Include(x => x.Product)
                                                                        .ProjectTo<SalesOrderDetailViewModel>(_mapper.ConfigurationProvider)
                                                                        .AsNoTracking()
                                                                        .SingleOrDefaultAsync();

                return PartialView(model);
            }

            return PartialView(new SalesOrderDetailViewModel() { SalesOrderId = salesOrderId, ModifyDate = DateTime.Now });
        }

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = await _unitOfWork.SalesOrderDetails.GetAll()
                                                          .Where(x=>x.SalesOrderId == id)
                                                          .Include(x=>x.Product)
                                                          .AsNoTracking()
                                                          .ProjectTo<SalesOrderDetailViewModel>(_mapper.ConfigurationProvider)
                                                          .ToDataSourceResultAsync(request);

            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrEdit(SalesOrderDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Errors() });
            }

            model.ModifyDate = DateTime.Now;

            if(model.Id == null)
            {
                _unitOfWork.SalesOrderDetails.Create(_mapper.Map<SalesOrderDetail>(model));
            }
            else
            {
                _unitOfWork.SalesOrderDetails.Update(_mapper.Map<SalesOrderDetail>(model));
            }

            await _unitOfWork.SaveChangesAsync();

            return Json(new { status = true });
        }
    }
}