﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class BudgetCategory : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
    }
}