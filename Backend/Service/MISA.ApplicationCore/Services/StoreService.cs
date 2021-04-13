using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// LỚp kế thừa BaseService và thực thi Interface IStoreService riêng của đối tượng cửa hàng
    /// </summary>
    /// CreatedBy:
    public class StoreService:BaseService<Store>, IStoreService
    {
        #region DECLARE
        IStoreRepository _storeRepository;
        #endregion

        #region CONSTRUCTOR
        public StoreService(IStoreRepository storeRepository, IBaseRepository<Store> baseRepository) : base(baseRepository)
        {
            _storeRepository = storeRepository;        
        }

        public int GetCountData<Store>()
        {
            return _storeRepository.GetCountData<Store>();
        }

        public ServiceResult GetDataByIndexAndOffset<Store>(int positionStart, int offset)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _storeRepository.GetDataByIndexAndOffset<Store>(positionStart, offset);
            return serviceResult;
        }

        public List<Store> GetFilter(string StoreCode, string StoreName, string Address, string PhoneNumber, int Status)
        {
            return _storeRepository.GetFilter(StoreCode, StoreName, Address, PhoneNumber, Status);
        }

        public IEnumerable<Store> GetProvinceWithCountry(Guid Id)
        {
            return _storeRepository.GetProvinceWithCountry(Id);
        }
        #endregion
    }
}
