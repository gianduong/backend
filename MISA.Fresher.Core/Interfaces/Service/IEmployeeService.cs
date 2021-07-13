using MISA.Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Service
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        /// <summary>
        /// xuất khẩu dữ liệu ra fileExcel
        /// </summary>
        /// <returns>
        /// File excel chứa dữ liệu xuất khẩu
        /// </returns>
        Stream ExportExcel();
        /// <summary>
        /// Sinh mới mã nhân viên
        /// </summary>
        /// <returns></returns>
        public String GenNewEmployeeCode();
    }
}
