using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interfaces.Service
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin đối tượng thêm mới</param>
        /// <returns>1 bản ghi được thêm vào database</returns>
        /// Created: PQHIEU (11/06/2021)
        int Insert(T entity);
        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entityId">ID đối tượng sửa</param>
        /// <param name="entity">Thông tin đối tượng thêm mới</param>
        /// <returns>1 bản ghi được chỉnh sửa trong database</returns>
        /// Created: PQHIEU (11/06/2021)
        int Update(Guid entityId, T entity);
        
    }
}
