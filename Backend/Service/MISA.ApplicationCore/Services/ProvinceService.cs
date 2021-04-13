using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// LỚp kế thừa BaseService và thực thi Interface IProvinceService riêng của đối tượng tỉnh/thành phố.
    /// </summary>
    /// CreatedBy: 
    public class ProvinceService:BaseService<Province>, IProvinceService
    {
        #region DECLARE
        IProvinceRepository _provinceRepository;
        #endregion

        #region CONSTRUCTOR
        public ProvinceService(IBaseRepository<Province> baseRepository, IProvinceRepository provinceRepository):base(baseRepository)
        {
            _provinceRepository = provinceRepository;
        }
        #endregion
    }
}
