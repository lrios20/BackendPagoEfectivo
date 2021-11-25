using System;
using System.Collections.Generic;

#nullable disable

namespace PagoEfectivoApi.Models
{
    public partial class codePromotion
    {
        public int id { get; set; }
        public string code { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public int? statusId { get; set; }
        public DateTime insertDate { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
