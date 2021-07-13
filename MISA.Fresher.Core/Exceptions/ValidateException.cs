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
    /// CreatedBy: NGDuong (17/07/2021)
    public class ValidateException : Exception
    {

        public ValidateException(string msg, object Data) : base(msg)
        {
            var objecReturn = new
            {
                Msg = msg,
                FieldNotValid = Data
            };
            this.Data.Add("detail", objecReturn);
        }
    }
}
