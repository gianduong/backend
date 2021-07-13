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
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController :BaseEntityController<Department>
    {
        public DepartmentController(IDepartmentService departmentService, IDepartmentRepository departmentRepository) : base(departmentService, departmentRepository)
        {

        }
    }
}
