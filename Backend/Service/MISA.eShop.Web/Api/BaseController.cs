using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MISA.eShop.Web.Api
{
    /// <summary>
    /// Sử lý các yêu cầu từ Client
    /// CreatedBy: hhminh(13/4/2021)
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        //#region DECLARE
        IBaseService<T> _baseService;
        //#endregion

        //#region CONSTRUCTOR
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        //#endregion



        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// CreatedBy: hhminh(13/4/2021)
        /// <returns>Danh sách</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetTs();
            return Ok(entities);
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo khóa chính
        /// </summary>
        /// <param name="id">Khóa chính của đối tượng</param>
        /// CreatedBy:hhminh(13/4/2021)
        /// <returns>Đối tượng</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseService.GetTById(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return StatusCode(204);
            }
        }

        /// <summary>
        /// Thêm đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// CreatedBy: hhminh(13/4/2021)
        /// <returns>Đối tượng mà service trả về</returns>
        [HttpPost]
        public IActionResult Post(T entity)
        {
            var serviceResult = _baseService.Add(entity);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.IsValid)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }
        }   

        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// CreatedBy: hhminh(13/4/2021)
        /// <returns>Đối tượng mà service trả về</returns>
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.IsValid)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }
        }

        /// <summary>
        /// Xóa đối tượng theo khóa chính
        /// </summary>
        /// <param name="id">Khóa chính của đối tượng</param>
        /// CreatedBy:hhminh(13/4/2021)
        /// <returns>Đối tượng mà service trả về</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var serviceResult = _baseService.Delete(id);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.IsValid)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }
        }
    }
}
