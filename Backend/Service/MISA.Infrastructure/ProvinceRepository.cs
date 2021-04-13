using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Lớp kế thừa BaseRepository và tương tác với đối tượng tỉnh/thành phố
    /// </summary>
    /// CreatedBy: 
    public class ProvinceRepository:BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(IConfiguration configuration):base(configuration)
        {

        }
    }
}
