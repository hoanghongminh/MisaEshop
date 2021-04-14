using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// LỚp kế thừa BaseService và thực thi Interface IWardService riêng của đối tượng phường/xã.
    /// </summary>
    /// CreatedBy:hhminh(14/4/2021)
    /// CreatedBy:hhminh(13/4/2021)
    public class WardService:BaseService<Ward>, IWardService
    {
        #region DECLARE
        IWardRepository _wardRepository;
        #endregion

        #region CONSTRUCTOR
        public WardService(IBaseRepository<Ward> baseRepository, IWardRepository wardRepository) : base(baseRepository)
        {
            _wardRepository = wardRepository;
        }
        #endregion
    }
}
