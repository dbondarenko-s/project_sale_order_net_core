using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ciam.AutoMapper;
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
    public class SalesStatusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesStatusController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<JsonResult> CreateOrEdit(SalesStatusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, errors = ModelState.Errors() });
            }

            _unitOfWork.SalesStatuses.Create(_mapper.Map<SalesStatus>(model));

            await _unitOfWork.SaveChangesAsync();

            return Json(new { status = true });
        }

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _unitOfWork.SalesStatuses.GetAll().AsNoTracking().ProjectTo<SalesStatusViewModel>(_mapper.ConfigurationProvider).ToDataSourceResultAsync(request);

            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetStatusList()
        {
            var list = await _unitOfWork.SalesStatuses.GetAll().ProjectTo<SalesStatusViewModel>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();

            return Json(list);
        }
    }
}