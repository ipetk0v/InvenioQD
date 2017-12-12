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
        public string OrderName { get; set; }

        [Required]
        public string OderNumber { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int CountToFinishOrder { get; set; }

        [Required]
        public DateTime StartOrder { get; set; }
    }
}
