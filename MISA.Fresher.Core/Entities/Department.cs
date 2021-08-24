using MISA.Fresher.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Entities
{
    /// <summary>
    /// Phòng ban
    /// </summary>
    /// CreatedBy : NGDuong (18/08/2021)
    public class Department:BaseEntity
    {
        /// <summary>
        /// ID phòng ban
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public Guid DeparmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string DeparmentName { get; set; }
    }
}
