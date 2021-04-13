using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface kế thừa IBaseRepository có các phương thức riêng của cửa hàng
    /// CreatedBy:hhminh(13/4/2021)
    /// </summary>
    public interface IStoreService:IBaseService<Store>
    {
        /// <summary>
        /// Lấy danh sách tỉnh thành theo quốc gia
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        /// <returns>Danh sách entity</returns>
        IEnumerable<Store> GetProvinceWithCountry(Guid Id);
        /// <summary>
        /// Tìm cửa hàng theo tham số truyền vào
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        /// <returns>Danh sách entity</returns>
        List<Store> GetFilter(string StoreCode, string StoreName, string Address, string PhoneNumber, int Status);

        /// <summary>
        /// Lấy danh sách cửa hàng theo tham số truyền vào
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        /// <typeparam name="Store">Đối tượng</typeparam>
        /// <param name="positionStart">Giá trị bắt đầu</param>
        /// <param name="offset">Số lượng</param>
        /// <returns>Danh sách</returns>
        ServiceResult GetDataByIndexAndOffset<Store>(int positionStart, int offset);
        /// <summary>
        /// Lấy tổng số bản ghi
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        /// <typeparam name="Store">Đối tượng</typeparam>
        /// <returns>Tổng số bản ghi</returns>
        int GetCountData<Store>();

    }
}