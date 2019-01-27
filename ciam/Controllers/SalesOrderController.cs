using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ciam.DAL.Interfaces;
using Ciam.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<JsonResult> GetData([DataSourceRequest] DataSourceRequest request)
        {
            var data = await _unitOfWork.SalesOrders.GetAll()
                                                    .Include(x=>x.Customer)
                                                    .Include(x=>x.SalesStatus)
                                                    .AsNoTracking()
                                                    .ProjectTo<SalesOrderViewModel>(_mapper.ConfigurationProvider)
                                                    .ToDataSourceResultAsync(request);

            return Json(data);
        }
    }
}