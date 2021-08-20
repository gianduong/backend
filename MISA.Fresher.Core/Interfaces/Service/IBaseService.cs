using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Service
{
    /// <summary>
    /// Interface thực hiện các thao tác lớp service
    /// </summary>
    /// <typeparam name="T">Đối tượng</typeparam>
    /// CreatedBy: NGDuong (18/08/2021)
    public interface IBaseService<T>
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin đối tượng thêm mới</param>
        /// <returns>1 bản ghi được thêm vào database</returns>
        /// Created: NGDuong (18/08/2021)
        int Insert(T entity);
        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entityId">ID đối tượng sửa</param>
        /// <param name="entity">Thông tin đối tượng thêm mới</param>
        /// <returns>1 bản ghi được chỉnh sửa trong database</returns>
        /// Created: NGDuong (18/08/2021)
        int Update(Guid entityId, T entity);
        
    }
}
