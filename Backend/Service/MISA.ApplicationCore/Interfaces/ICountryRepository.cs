using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface của Country kế thừa IBaseRepository và có các phương thức riêng của quốc gia.
    /// CreatedBy: 
    /// </summary>
    public interface ICountryRepository:IBaseRepository<Country>
    {
    }
}
