using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interfaces.Repository;
using MISA.Fresher.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Web.Controllers
{
    /// <summary>
    /// Api thực hiện tác vụ của phòng ban
    /// </summary>
    /// CreatedBy: NGDuong (18/08/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController :BaseEntityController<Department>
    {
        #region Constructure
        public DepartmentController(IDepartmentService departmentService, IDepartmentRepository departmentRepository) : base(departmentService, departmentRepository)
        {
        }
        #endregion
    }
}
