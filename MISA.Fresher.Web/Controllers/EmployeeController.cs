using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Enum;
using MISA.Fresher.Core.Interfaces.Repository;
using MISA.Fresher.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Web.Controllers
{
    /// <summary>
    /// Api nhân viên
    /// Createdby: NGDuong(13/07/2021)
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Field
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        #endregion

        #region Constructor 
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeService, employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        #endregion

        #region Methods
        [HttpPut("{employeeId}")]
        public override IActionResult Update(Guid employeeId, Employee employee)
        {
            employee.EntityState = EntityState.Update;
            return base.Update(employeeId, employee);
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>
        /// Mã nhân viên mới có dạng NV-{...}
        /// Createdby: NGDuong(13/07/2021)
        /// </returns>
        [HttpGet("NewCode")]
        public IActionResult getBiggestEmployeeCode()
        {    
            var newEmployeeCode = _employeeService.GenNewEmployeeCode();
            if (newEmployeeCode != null)
            {
                return Ok(newEmployeeCode);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo filter
        /// </summary>
        /// <param name="pageInt">page hiện tại</param>
        /// <param name="pageSize">số bản ghi trên page</param>
        /// <param name="filterString">điều kiện filter</param>
        /// <returns>
        /// Danh sách nhân viên
        /// Createdby: NGDuong(13/07/2021)
        /// </returns>
        [HttpGet("Filter")]
        public IActionResult GetByPagination(int pageInt, int pageSize, string filterString = null)
        {
            var employees = _employeeRepository.GetByPaginationFilter(pageInt, pageSize, filterString);
            var totalItem = _employeeRepository.GetTotalByFilter(filterString);
            if (employees.Count() > 0)
            {
                var response = new
                {
                    total = totalItem,
                    data = employees
                };
                return Ok(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Xuất khẩu dữ liệu ra file Excel
        /// </summary>
        /// <returns>
        /// File Excel chưa dữ liệu xuất khẩu
        /// Createdby: NGDuong(13/07/2021)
        /// </returns>
        [HttpGet("Export")]
        public IActionResult Export()
        {
            var stream = _employeeService.ExportExcel();
            string fileName = $"Danh sach nhan vien {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        #endregion

    }
}
