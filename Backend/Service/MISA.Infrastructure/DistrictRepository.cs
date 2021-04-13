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
    /// CreatedBy: hhminh(13/4/2021)
    public class DistrictRepository:BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(IConfiguration configuration):base(configuration)
        {

        }
    }
}
