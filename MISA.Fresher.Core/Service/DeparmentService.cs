using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interfaces.Repository;
using MISA.Fresher.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Service
{
    public class DeparmentService:BaseService<Department>, IDepartmentService
    {
        public DeparmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            
        }
    }
}
