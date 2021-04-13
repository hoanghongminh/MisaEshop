using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng quốc gia
    /// CreatedBy: 
    /// </summary>
    public class Country:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: 
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Tên quốc gia
        /// CreatedBy:
        /// </summary>
        public string CountryName { get; set; }
        #endregion
    }
}
