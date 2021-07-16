using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Exceptions;
using MISA.Fresher.Core.Interfaces.Repository;
using MISA.Fresher.Core.Interfaces.Service;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Service
{
    public class EmployeeService:BaseService<Employee>, IEmployeeService
    {

        #region Field
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        
        #endregion

        #region Methods
        protected override void Validate(Employee employee)
        {
            base.Validate(employee);
            var isDuplicateCode = false;
           
            // Kiểm tra trùng mã 
            if (employee.EntityState == Enum.EntityState.Add)
            {
                isDuplicateCode = _employeeRepository.CheckEmployeeCodeExits(employee.EmployeeCode);
            }
            else
            {
                isDuplicateCode = _employeeRepository.CheckEmployeeCodeExits(employee.EmployeeCode, employee.EmployeeId);
            }
            if (isDuplicateCode)
            {
                throw new ValidateException(string.Format(Properties.Resources.Error_Employee_Code_Exits, employee.EmployeeCode) , employee.GetType().GetProperty(Properties.Resources.EmployeeCode).Name);
            }
           
        }

        public Stream ExportExcel()
        {
            // lấy về danh sách nhân viên từ DB
            var result = _employeeRepository.GetAll();
            var listEmployees = result.ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage(stream);
            // Thêm một workSheet
            var workSheet = package.Workbook.Worksheets.Add(Properties.Resources.excel_ListNhanVien);

            using (var range = workSheet.Cells[Properties.Resources.excel_TitlelRollColl])
            {
                range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                range.Value = Properties.Resources.excel_ListNhanVien;
                range.Merge = true;
            }
            // todo: Đang làm 
            // Thêm tiêu đề
            workSheet.Cells[3, 1].Value = Properties.Resources.excel_STT;
            workSheet.Cells[3, 2].Value = Properties.Resources.excel_Code;
            workSheet.Cells[3, 3].Value = Properties.Resources.excel_Name;
            workSheet.Cells[3, 4].Value = Properties.Resources.excel_Gender;
            workSheet.Cells[3, 5].Value = Properties.Resources.excel_Dob;
            workSheet.Cells[3, 6].Value = Properties.Resources.excel_Position;
            workSheet.Cells[3, 7].Value = Properties.Resources.excel_DonVi;
            workSheet.Cells[3, 8].Value = Properties.Resources.excel_AccountNumber;
            workSheet.Cells[3, 9].Value = Properties.Resources.excel_Bank;

            // đặt độ rộng cho row
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 25;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 20;
            workSheet.Column(6).Width = 20;
            workSheet.Column(7).Width = 20;
            workSheet.Column(8).Width = 10;
            workSheet.Column(9).Width = 15;
            // Gán dữ liệu
            int i = 0;
            foreach (var employee in listEmployees)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = employee.EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = employee.FullName;
                workSheet.Cells[i + 4, 4].Value = employee.GenderName;
                workSheet.Cells[i + 4, 5].Value = employee.DateOfBirth?.ToString(Properties.Resources.dateStyle);
                workSheet.Cells[i + 4, 6].Value = employee.PositionName;
                workSheet.Cells[i + 4, 7].Value = employee.DeparmentName;
                workSheet.Cells[i + 4, 8].Value = employee.BankAccount;
                workSheet.Cells[i + 4, 9].Value = employee.BankName;
                i++;
            }
            package.Save();
            stream.Position = 0;
            return package.Stream;
        }

        public String GenNewEmployeeCode()
        {
            // Sinh code mới bằng cách lấy mã lớn nhất rồi tăng phần số lên 1
            String NewCode = "";
            var Employeecode = _employeeRepository.GenEmployeeCode();
            if (Employeecode is String)
            {
                if (Employeecode != "")
                {
                    String[] split = Employeecode.Split("-");
                    try
                    {
                        int newCode = Int32.Parse(split[1]) + 1;
                        NewCode = split[0] + "-" + newCode;
                    }
                    catch
                    {
                        throw new Exception(Properties.Resources.Error_Exception);
                    }
                }
            }
            return NewCode;
        }
        #endregion
    }
}
