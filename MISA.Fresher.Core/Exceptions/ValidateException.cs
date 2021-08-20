using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Exceptions
{
    /// <summary>
    /// Xử lý ngoại lệ validate
    /// </summary>
    /// CreatedBy: NGDuong (18/08/2021)
    public class ValidateException : Exception
    {
        /// <summary>
        /// Hàm validate ngoại lệ cho dữ liệu lỗi
        /// </summary>
        /// <param name="msg">Thông điệp ngoại lệ</param>
        /// <param name="Data">Dữ liệu lỗi</param>
        public ValidateException(string msg, object Data) : base(msg)
        {
            var objectReturn = new
            {
                Msg = msg,
                FieldNotValid = Data
            };
            this.Data.Add("detail", objectReturn);
        }
    }
}
