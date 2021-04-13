using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Lớp kế thừa BaseRepository và tương tác với đối tượng cửa hàng
    /// </summary>
    /// CreatedBy:hhminh(13/4/2021)
    public class StoreRepository:BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public int GetCountData<Store>()
        {
            var procName = $"Proc_GetCountStores";
            var res = _dbConnection.Query<int>(procName, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public IEnumerable<Store> GetDataByIndexAndOffset<Store>(int positionStart, int offset)
        {
            var procName = $"Proc_GetStoreByIndexOffset";
            var res = _dbConnection.Query<Store>(procName, new { positionStart = positionStart, offSet = offset }, commandType: CommandType.StoredProcedure);
            return res;
        }

        public List<Store> GetFilter(string StoreCode, string StoreName, string Address, string PhoneNumber, int Status)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StoreCode", StoreCode, DbType.String);
            parameters.Add("@StoreName", StoreName, DbType.String);
            parameters.Add("@Address", Address, DbType.String);
            parameters.Add("@PhoneNumber", PhoneNumber, DbType.String);
            parameters.Add("@Status", Status, DbType.Int32);
            var fees = _dbConnection.Query<Store>("Proc_GetStoreFilter", parameters, commandType: CommandType.StoredProcedure).ToList();
            return fees;
        }

        public IEnumerable<Store> GetProvinceWithCountry(Guid Id)
        {
            string procName = $"Proc_GetProvinceWithCountry";
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", Id.ToString());
            var res = _dbConnection.Query<Store>(procName,parameters,commandType:CommandType.StoredProcedure);
            return res;
        }
    }
}
