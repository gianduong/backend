using MISA.Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface thực hiện thao tác với nhân viên
    /// </summary>
    /// CreatedBy: NGDuong (18/08/2021)
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">ID của nhân viên</param>
        /// <returns>
        /// true - mã nhân viên đã tồn tại
        /// false - mã nhân viên chưa tồn tại
        /// </returns>
        /// CreatedBy: NGDuong(18/08/2021)
        bool CheckEmployeeCodeExits(string employeeCode, Guid? employeeId = null);


        /// <summary>
        /// Danh sách nhân viên qua filter
        /// </summary>
        /// <param name="pageInt">page hiện tại</param>
        /// <param name="pageSize">số bẩn ghi trên page</param>
        /// <param name="filterString">giá trị bộ lọc</param>
        /// <returns>
        /// Danh sách nhân viên 
        /// </returns>
        /// NGDuong (18/08/2021)
        IEnumerable<Employee> GetByPaginationFilter(int pageInt, int pageSize, string filterString);

        /// <summary>
        /// Lấy số lượng bản ghi hợp lệ
        /// </summary>
        /// <param name="filterString">chuỗi điều kiện</param>
        /// <returns>
        /// Số lượng bản ghi hợp lệ
        /// </returns>
        /// NGDuong (18/08/2021)
        int GetTotalByFilter(string filterString);
        /// <summary>
        /// Sinh ra mã nhân viên mới
        /// </summary>
        /// <returns>
        /// Mã nhân viên mới
        /// </returns>
        /// NGDuong (18/08/2021)
        public string GenEmployeeCode();

    }
}
