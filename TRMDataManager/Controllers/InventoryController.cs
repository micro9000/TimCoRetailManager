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
    [Authorize]
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        [Authorize(Roles = "Manager,Admin")]
        public List<InventoryModel> Get ()
        {
            InventoryData data = new InventoryData();
            return data.GetInventory();
        }

        //[Authorize(Roles = "WarehouseWorker")] -> add this for and relationship for role | Admin,Manager is OR relationship
        [Authorize(Roles = "Admin")]
        public void Post (InventoryModel item)
        {
            InventoryData data = new InventoryData();
            data.SaveInventoryRecord(item);
        }
    }
}
