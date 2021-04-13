using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// LỚp kế thừa BaseService và thực thi Interface IDistrictService của đối tượng quận/ huyện
    /// </summary>
    /// CreatedBy: 
    public class DistrictService:BaseService<District>, IDistrictService
    {
        #region DECLARE
        IDistrictRepository _districtRepository;
        #endregion

        #region CONSTRUCTOR
        public DistrictService(IBaseRepository<District> baseRepository, IDistrictRepository districtRepository) : base(baseRepository)
        {
            _districtRepository = districtRepository;
        }
        #endregion
    }
}
