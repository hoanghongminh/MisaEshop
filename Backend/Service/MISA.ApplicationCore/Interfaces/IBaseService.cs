using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface chứa các phương thức tương tác trong quá trình sử lý nghiệp vụ
    /// </summary>
    /// CreatedBy:
    /// <typeparam name="T">Đối tượng</typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy danh sách entity
        /// </summary>
        /// CreatedBy: 
        /// <returns>danh sách entity</returns>
        IEnumerable<T> GetTs();

        /// <summary>
        /// Lấy entity theo id
        /// </summary>
        /// CreatedBy: 
        /// <param name="entityId">id entity</param>
        /// <returns>entity</returns>
        T GetTById(Guid entityId);

        /// <summary>
        /// Thêm mới entity
        /// </summary>
        /// CreatedBy: 
        /// <param name="entity">Đối tượng</param>
        /// <returns>Đối tượng chứa các dữ liệu trả về</returns>
        /// 
        ServiceResult Add(T entity);
        /// <summary>
        /// Cập nhật entity
        /// </summary>
        /// CreatedBy:
        /// <param name="entity">Đối tượng</param>
        /// <returns>Đối tượng chứa các dữ liệu trả về</returns>
        ServiceResult Update(T entity);
        /// <summary>
        /// Xóa bỏ entity
        /// </summary>
        /// CreatedBy: 
        /// <param name="entityId">mã đối tượng</param>
        /// <returns>Đối tượng chứa các dữ liệu trả về</returns>
        ServiceResult Delete(Guid entityId);
    }
}
