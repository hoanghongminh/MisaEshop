using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng tỉnh/thành phố
    /// CreatedBy: 
    /// </summary>
    public class Province:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: 
        /// </summary>
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// CreatedBy:
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// Mã nhóm quốc gia
        /// CreatedBy: 
        /// </summary>
        public Guid? CountryId { get; set; }
        #endregion
    }
}
