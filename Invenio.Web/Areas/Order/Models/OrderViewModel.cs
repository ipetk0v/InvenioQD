using Invenio.Web.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Areas.Order.Models
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(DataAnnotationsAttributesHelper.OrderNameMaxLength)]
        [Display(Name = "Order name")]
        public string OrderName { get; set; }

        [Required]
        [MaxLength(DataAnnotationsAttributesHelper.OrderNumberMaxLength)]
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
