﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Entities
{
    public class CategoryExport
    {
        public int CategoryExportId { get; set; }
        public decimal Value { get; set; }
        public Country? Country { get; set; }
        public Year? Year { get; set; }
        public Category? Category { get; set; }
    }
}