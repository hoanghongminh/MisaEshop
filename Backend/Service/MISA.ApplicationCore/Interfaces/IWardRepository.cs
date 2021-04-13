using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface kế thừa IBaseRepository có các phương thức riêng của phường/xã
    /// CreatedBy: hhminh(13/4/2021)
    /// </summary>
    public interface IWardRepository:IBaseRepository<Ward>
    {
    }
}
