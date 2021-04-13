using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng quận/ huyện
    /// CreatedBy: 
    /// </summary>
    public class District:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: 
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// CreatedBy: 
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Mã tỉnh/thành phố
        /// CreatedBy: 
        /// </summary>
        public Guid? ProvinceId { get; set; }
        #endregion
    }
}
