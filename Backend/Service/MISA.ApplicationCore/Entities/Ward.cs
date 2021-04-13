using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng phường/xã
    /// CreatedBy: hhminh(13/4/2021)
    /// </summary>
    public class Ward:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public Guid WardId { get; set; }

        /// <summary>
        /// Tên phường/xã
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public string WardName { get; set; }
        /// <summary>
        /// Mã quận/huyện
        /// CreatedBy:hhminh(13/4/2021)
        /// </summary>
        public Guid? DistrictId { get; set; }
        #endregion
    }
}
