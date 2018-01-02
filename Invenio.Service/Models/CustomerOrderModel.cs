﻿using System;

namespace Invenio.Service.Models
{
    public class CustomerOrderModel
    {         
        public string OrderId { get; set; }

        public string CustomerUserId { get; set; }

        public string CustomerUserName { get; set; }

        public string Name { get; set; }

        public string OrderNumber { get; set; }

        public int CountToFinishOrder { get; set; }

        public DateTime StartOrder { get; set; }

        public DateTime FinishOrder { get; set; }

        public bool Status { get; set; }
    }
}
