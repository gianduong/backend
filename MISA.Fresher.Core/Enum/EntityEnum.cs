using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Enum
{

    /// <summary>
    /// Trạng thái của object
    /// </summary>
    /// CreatedBy : NGDuong (18/08/2021)
    public enum EntityState
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        Add = 1,
        /// <summary>
        /// Sửa
        /// </summary>
        Update = 2,
        /// <summary>
        /// Xóa
        /// </summary>
        Delete = 3,
    }
    /// <summary>
    /// Giới tính
    /// </summary>
    /// CreatedBy : NGDuong (18/08/2021)
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,
        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }
}

