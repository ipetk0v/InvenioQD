using Invenio.Data.Models;
using Invenio.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invenio.Web.Models.OrderViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string OderNumber { get; set; }

        [Required]
        public int CountToFinishOrder { get; set; }

        [Required]
        public DateTime StartOrder { get; set; }
    }
}
