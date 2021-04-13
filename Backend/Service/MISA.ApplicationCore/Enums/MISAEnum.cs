using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Enums
{
    /// <summary>
    /// MISACode để xác định  trạng thái của việc validate
    /// CreatedBy: 
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Dữ liệu chưa hợp lệ
        /// </summary>
        NotValid = 900,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Có lỗi xảy ra
        /// </summary>
        Exception = 500
    }
    /// <summary>
    /// Xác định trạng thái của object
    /// CreatedBy: 
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Trạng thái thêm mới
        /// </summary>
        AddNew = 1,
        /// <summary>
        /// Trạng thái sửa
        /// </summary>
        Update = 2,
        /// <summary>
        /// Trạng thái xóa
        /// </summary>
        Delete = 3,
    }
}
