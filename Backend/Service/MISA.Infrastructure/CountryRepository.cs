using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Lớp kế thừa BaseRepository và tương tác với đối tượng quốc gia
    /// </summary>
    /// CreatedBy: hhminh(13/4/2021)
    public class CountryRepository:BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IConfiguration configuration):base(configuration)
        {

        }
    }
}
