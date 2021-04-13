using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Đối tượng để chứa các kết quả trả về từ Service
    /// CreatedBy: 
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Đối tượng chứa các thay đổi trong quá trình thực hiện nghiệp vụ hoặc các thông báo lỗi
        /// CreatedBy: 
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo
        /// CreatedBy:
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// Mã lỗi tự định nghĩa
        /// </summary>
        public MISACode MISACode { get; set; }
    }
}
