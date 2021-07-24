using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Infracstructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region Field
        public IDbConnection _dbConnection;
        string _connectString;
        IConfiguration _configuration;
        DynamicParameters _dynamicParameters;
        string _className;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new MySqlConnection(_connectString);
            _dynamicParameters = new DynamicParameters();
            _className = typeof(T).Name;
        }
        #endregion

        #region Methods
        public IEnumerable<T> GetAll()
        {
            return _dbConnection.Query<T>($"Proc_Get{_className}s", commandType: CommandType.StoredProcedure);
        }

        public T GetById(Guid entityId)
        {
            _dynamicParameters.Add($"@m_{_className}Id", entityId);
            return _dbConnection.QueryFirstOrDefault<T>($"Proc_Get{_className}ById", _dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int Insert(T entity)
        {
            MappingParameterValue(entity);
            return _dbConnection.Execute($"Proc_Insert{_className}", _dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int Update(Guid entityId, T entity)
        {
            entity.GetType().GetProperty($"{_className}Id").SetValue(entity, entityId);
            MappingParameterValue(entity);
            return _dbConnection.Execute($"Proc_Update{_className}", _dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        public int Delete(Guid entityId)
        {
            _dynamicParameters.Add($"@m_{_className}Id", entityId);
            return _dbConnection.Execute($"Proc_Delete{_className}", _dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Thực hiện gán giá trị cho các tham số đầu vào của store với các property
        /// </summary>
        /// <param name="entity">Đối tượng sẽ thêm mới vào</param>
        /// CreatedBy : NGDuong (20/07/2021)
        void MappingParameterValue(T entity)
        {
            // Lấy ra các property của đối tượng
            var properties = typeof(T).GetProperties();
            // Duyệt từng property
            foreach (var property in properties)
            {
                // Lây value của property
                var propertyValue = property.GetValue(entity);
                // Lấy ra tên của property
                var propertyName = property.Name;
                _dynamicParameters.Add($"@m_{propertyName}", propertyValue);
            }

        }
        #endregion


    }
}
