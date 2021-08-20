using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Core.Interfaces.Repository;
using MISA.Fresher.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Web.Controllers
{
    /// <summary>
    /// API phục vụ các chức năng cơ bản
    /// </summary>
    /// <typeparam name="T">Đối tượng xử lý</typeparam>
    /// CreatedBy: NGDuong (18/08/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Fields
        IBaseService<T> _baseServices;
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<T> baseservice, IBaseRepository<T> baseRepository)
        {
            _baseServices = baseservice;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách bản ghi
        /// </summary>
        /// <returns>
        /// Danh sách tất cả bản ghi
        /// </returns>
        /// CreatedBy: NGDuong(18/08/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            return NoContent();
        }
        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID bản ghi</param>
        /// <returns>
        /// 200 - trả về bản ghi
        /// 400 - Bad request
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            if (entity != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi được thêm mới </param>
        /// <returns>
        /// 200 - thêm thành công
        /// 400 - Bad request
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpPost]
        public IActionResult Insert(T entity)
        {

            var rowEffects = _baseServices.Insert(entity);
            if (rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entityId">ID bản ghi cần cập nhật</param>
        /// <param name="entity">Bản ghi cập nhật</param>
        /// <returns>
        /// 200 - cập nhật thành công
        /// 400 - bad request
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpPut("{entityId}")]
        public virtual IActionResult Update(Guid entityId, T entity)
        {
            //customer.EntityState = EntityState.Update;
            var rowEffects = _baseServices.Update(entityId, entity);
            if (rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xóa</param>
        /// <returns>
        /// 200 - Xóa thành công
        /// 400 - Bad request
        /// </returns>
        /// CreatedBy: NGDuong(18/08/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowEffects = _baseRepository.Delete(entityId);
            if (rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        #endregion

    }
}

