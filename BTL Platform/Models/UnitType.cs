﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class UnitType
    {
        public long UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(Unit))]
        public long UnitId { get; set; }
        public virtual Unit? Unit { get; set; }

    }
}