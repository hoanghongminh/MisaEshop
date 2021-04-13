﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng quận/ huyện
    /// CreatedBy: hhminh(13/4/2021)
    /// </summary>
    public class District:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Mã tỉnh/thành phố
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        public Guid? ProvinceId { get; set; }
        #endregion
    }
}
