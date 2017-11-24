using Invenio.Data.Models;
using System;
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

        [Required]
        public CustomerUser Customer { get; set; }
    }
}
