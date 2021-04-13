using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.eShop.Web.Api
{
    /// <summary>
    /// Lớp kế thừa BaseController và sử lý các phương thức riêng của cửa hàng
    /// </summary>
    /// CreatedBy: hhminh(13/4/2021)
    public class StoresController : BaseController<Store>
    {
        IStoreService _storeService;
        public StoresController(IStoreService storeService):base(storeService)
        {
            _storeService = storeService;
        }
        [HttpGet("CountryId")]
        public IActionResult GetProvinceWithCountry(Guid id)
        {
            var row = _storeService.GetProvinceWithCountry(id);
            if(row.Count() > 0)
            {
                return StatusCode(200, row);
            }
            else
            {
                return StatusCode(204, row);
            }
        }
        /// <summary>
        /// Lấy ra store theo các dữ kiệu truyền vào
        /// </summary>
        /// <param name="StoreCode">Mã cửa hàng</param>
        /// <param name="StoreName">Tên cửa hàng</param>
        /// <param name="Address">Địa chỉ</param>
        /// <param name="PhoneNumber">Số điện thoại</param>
        /// <param name="Status">Trạng thái hoạt động</param>
        /// CreatedBy: 
        /// <returns></returns>
        [HttpGet("Filter")]
        public IActionResult GetFilter([FromQuery] string StoreCode, [FromQuery] string StoreName, [FromQuery] string Address, [FromQuery] string PhoneNumber, [FromQuery] int Status)
        {
            var entities = _storeService.GetFilter(StoreCode, StoreName, Address, PhoneNumber, Status);
            return Ok(entities);
        }


        [HttpGet("paging")]
        public IActionResult GetDataByIndexAndOffset([FromQuery] int positionStart, [FromQuery] int offset)
        {
            var entities = _storeService.GetDataByIndexAndOffset<Store>(positionStart, offset);
            var data = entities.Data as List<Store>;
            if (data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return StatusCode(204, entities.Data);
            }
        }
        /// <summary>
        /// Lấy số lượng bản ghi
        /// </summary>
        /// <returns> số lượng bản ghi</returns>
        [HttpGet("numberData")]
        public int GetCountData()
        {
            var res = _storeService.GetCountData<Store>();
            return res;
        }


    }
}
