﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize(Roles = "Cashier")] // Cashier,Admin -> for multi role
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<ProductModel> Get ()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }
    }
}
