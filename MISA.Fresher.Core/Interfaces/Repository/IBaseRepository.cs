using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface chung
    /// </summary>
    /// <typeparam name="T">Đối tương</typeparam>
    /// CreatedBy: NGDuong (18/08/2021)
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy tất cả 
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của bản ghi</param>
        /// <returns>Bản ghi có ID</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        T GetById(Guid entityId);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi được thêm mới</param>
        /// <returns>Số lượng bản ghi được thêm mới</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        int Insert(T entity);
        /// <summary>
        /// Sửa bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của bản ghi cần sửa</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Số lượng bản ghi được sửa</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        int Update(Guid entityId, T entity);
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">ID bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi bị xóa</returns>
        /// CreatedBy: NGDuong (18/08/2021)
        int Delete(Guid entityId);

    }
}
