﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Account;

namespace MyCrm.Domain.Entities.Predict
{
    public class PredictMarketer
    {
        [Key]
        public long Id { get; set; }
        public long MarketerId { get; set; }
        public Marketer   Marketer { get; set; }
    }
}