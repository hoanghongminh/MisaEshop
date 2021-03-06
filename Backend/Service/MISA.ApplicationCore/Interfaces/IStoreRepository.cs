using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface kế thừa IBaseRepository có các phương thức riêng của cửa hàng
    /// CreatedBy: hhminh(13/4/2021)
    /// </summary>
    public interface IStoreRepository:IBaseRepository<Store>
    {
        /// <summary>
        /// Lấy danh sách tỉnh thành theo quốc gia
        /// CreatedBy: hhminh(13/4/2021)
        /// </summary>
        /// <returns>Danh sách entity</returns>
        IEnumerable<Store> GetProvinceWithCountry(Guid Id);
        /// <summary>
        /// Lấy cửa hàng theo tham số truyền vào
        /// CreatedBy:hhminh(13/4/2021)
        /// </summary>
        /// <returns>Danh sách entity</returns>
        List<Store> GetFilter(string StoreCode, string StoreName, string Address, string PhoneNumber, int Status);

        /// <summary>
        /// Lấy danh sách theo tham số truyền vào
        /// CreatedBy:hhminh(13/4/2021)
        /// </summary>
        /// <typeparam name="Store"></typeparam>
        /// <param name="positionStart"></param>
        /// <param name="offset"></param>
        /// <returns>Danh sách</returns>
        IEnumerable<Store> GetDataByIndexAndOffset<Store>(int positionStart, int offset);
        /// <summary>
        /// Lấy số lượng bản ghi trong db
        /// CreatedBy:hhminh(13/4/2021)
        /// </summary>
        /// <typeparam name="Store"></typeparam>
        /// <returns>Số lượng bản ghi trong db</returns>
        int GetCountData<Store>();
    }
}
