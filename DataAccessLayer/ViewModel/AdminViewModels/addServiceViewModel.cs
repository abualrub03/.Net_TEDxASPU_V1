using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ViewModel.AdminViewModels
{
    public class addServiceViewModel  
    {
        [StringLength(maximumLength: 15, MinimumLength = 5)]
        public string? Name { get; set; }
        [StringLength(maximumLength: 15, MinimumLength = 5)]
        public string? Details { get; set; }

    }
}
