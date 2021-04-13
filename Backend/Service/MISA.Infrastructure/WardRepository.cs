using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Lớp kế thừa BaseRepository và tương tác với đối tượng phường/xã
    /// </summary>
    /// CreatedBy: 
    public class WardRepository:BaseRepository<Ward>, IWardRepository
    {
        public WardRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
