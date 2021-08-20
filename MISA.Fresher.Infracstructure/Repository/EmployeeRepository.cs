using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MySqlConnector;

namespace MISA.Fresher.Infracstructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Field
        DynamicParameters _dynamicParameters;


        #endregion
        #region Constructor
        public EmployeeRepository( IConfiguration configuration) : base(configuration)
        {
            _dynamicParameters = new DynamicParameters();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Kiểm tra mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">ID của nhân viên</param>
        /// <returns>
        /// true - mã đã tồn tại
        /// false - mã chưa tồn tại
        /// </returns>
        /// CreatedBy : NGDuong (18/08/2021)
        public bool CheckEmployeeCodeExits(string employeeCode, Guid? employeeId)
        {
            using(_dbConnection = new MySqlConnection(_connectString))
            {
                _dynamicParameters.Add(Properties.Resources.dy_code, employeeCode);
                _dynamicParameters.Add(Properties.Resources.dy_id, employeeId);
                var isExit = _dbConnection.ExecuteScalar<bool>(Properties.Resources.proc_CheckCodeExist, _dynamicParameters, commandType: CommandType.StoredProcedure);
                return isExit;
            }
            
        }

        public IEnumerable<Employee> GetByPaginationFilter(int pageInt, int pageSize, string filterString)
        {
            using (_dbConnection = new MySqlConnection(_connectString))
            {
                var storeName = Properties.Resources.Proc_GetEmployee_Pagination_Filter;
                _dynamicParameters.Add(Properties.Resources.dy_size, pageSize);
                _dynamicParameters.Add(Properties.Resources.dy_int, pageInt);
                _dynamicParameters.Add(Properties.Resources.dy_fitler, filterString);
                return _dbConnection.Query<Employee>(storeName, _dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetTotalByFilter(string filterString)
        {
            using (_dbConnection = new MySqlConnection(_connectString))
            {
                var storeName = Properties.Resources.Proc_GetTotal;
                _dynamicParameters.Add(Properties.Resources.dy_fitler, filterString);
                return _dbConnection.ExecuteScalar<int>(storeName, _dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string GenEmployeeCode()
        {
            using (_dbConnection = new MySqlConnection(_connectString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = Properties.Resources.Proc_GetEmployeeCode;
                var res = _dbConnection.QueryFirstOrDefault<String>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
