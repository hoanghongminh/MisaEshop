using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.eShop.Web.Api
{
    /// <summary>
    /// Lớp kế thừa BaseController và sử lý các phương thức riêng của phường/xã
    /// </summary>
    /// CreatedBy: hhminh(13/4/2021)
    public class WardsController : BaseController<Ward>
    {
        IWardService _wardService;
        public WardsController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;
        }
    }
}
