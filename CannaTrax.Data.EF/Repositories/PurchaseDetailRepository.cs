﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class PurchaseDetailRepository:IPurchaseDetailRepository
    {
        private readonly IEntityRepository<tblPurchaseDetail> _repo;
        public PurchaseDetailRepository(IEntityRepository<tblPurchaseDetail> repo)
        {
            _repo = repo;
        }
    }
}
