using MISA.Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Service
{
    /// <summary>
    /// Inteface thực hiện thao tác lớp service của Nhân viên
    /// </summary>
    /// CreatedBy: NGDuong (18/08/2021)
    public interface IEmployeeService:IBaseService<Employee>
    {
        /// <summary>
        /// xuất khẩu dữ liệu ra fileExcel
        /// </summary>
        /// <returns>
        /// File excel chứa dữ liệu xuất khẩu
        /// </returns>
        /// CreatedByL NGDuong (18/08/2021)
        Stream ExportExcel();
        /// <summary>
        /// Sinh mới mã nhân viên
        /// </summary>
        /// <returns>Mã nhân viên được thêm mới</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        public String GenNewEmployeeCode();
    }
}
