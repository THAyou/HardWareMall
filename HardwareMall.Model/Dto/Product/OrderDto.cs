using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Model
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public string processstatus { get; set; }

        public string Amount { get; set; }

        public string ClientName { get; set; }

        public string ContactDetails { get; set; }

        public string Remark { get; set; }

        public string Email { get; set; }

        public DateTime? ProcessTime { get; set; }

        public string ProcessRemark { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
