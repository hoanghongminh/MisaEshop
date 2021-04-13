using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Lớp kế thừa BaseRepository và tương tác với đối tượng quận/ huyện
    /// </summary>
    /// CreatedBy: 
    public class DistrictRepository:BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(IConfiguration configuration):base(configuration)
        {

        }
    }
}
