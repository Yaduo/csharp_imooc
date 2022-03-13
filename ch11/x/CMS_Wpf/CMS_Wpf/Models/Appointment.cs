using System;
using System.Collections.Generic;

#nullable disable

namespace CMS_Wpf.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
