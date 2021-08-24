using MISA.Fresher.Core.Attributes;
using MISA.Fresher.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Entities
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy : NGDuong (18/08/2021)
    public class Employee : BaseEntity
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 10)]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string FullName { get; set; }

        /// <summary>
        /// ID phòng ban
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public Guid DeparmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy : NGDuong(18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string DeparmentName { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public Gender? Gender { get; set; }

        /// <summary>
        /// Tên giới tính
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public string GenderName
        {
            get
            {
                return Gender switch
                {
                    Enum.Gender.Male => Properties.Resources.MALE,
                    Enum.Gender.Female => Properties.Resources.FEMALE,
                    Enum.Gender.Other => Properties.Resources.OTHER,
                    _ => Properties.Resources.OTHER
                };
            }
        }
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 13)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh nhân dân 
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp chứng minh nhân dân
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 255)]
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Chức vụ nhân viên
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 255)]
        public string PositionName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 255)]
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số cố định
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 50)]
        public string LandlinePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 20)]
        public string BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 255)]
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 255)]
        public string BankBranch { get; set; }

    }
}
