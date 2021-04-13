using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng quốc gia
    /// CreatedBy: hhminh(13/4/2021)
    /// </summary>
    public class Country:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Tên quốc gia
        /// CreatedBy:hhminh(13/4/2021)
        /// </summary>
        public string CountryName { get; set; }
        #endregion
    }
}
