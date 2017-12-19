using Invenio.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.OrderViewModels
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Order name")]
        public string OrderName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Order number")]
        public string OrderNumber { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        [Display(Name = "Count to finish order")]
        public int CountToFinishOrder { get; set; }

        [Required]
        [Display(Name = "Start date")]
        public DateTime StartOrder { get; set; }
    }
}
