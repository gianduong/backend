using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Attributes
{
    /// <summary>
    /// Attribute lỗi
    /// </summary>
    /// CreatedBy: NGDuong (20/07/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        #region filed
        /// <summary>
        /// Thông tin lỗi
        /// </summary>
        /// CreatedBy: NGDuong (17/07/2021)
        public string _msgError = string.Empty;
        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// CreatedBy: NGDuong (17/07/2021)
        public string _fieldError = string.Empty;
        #endregion

        #region Constructure
        public Required(string msgError, string fieldError)
        {
            _msgError = msgError;
            _fieldError = fieldError;
        }
        #endregion
    }
    /// <summary>
    /// Kiểm tra độ dài của thuộc tính
    /// </summary>
    /// CreatedBy: NGDuong (20/07/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxSize: Attribute
    {
        public int size;
        public string msgError;

        public MaxSize(int size, string msg)
        {
            this.size = size;
            this.msgError = msg;
        }
    }
}
