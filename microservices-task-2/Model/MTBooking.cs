using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace microservices_task_2.Model
{
    public class MTBooking
    {
        [Key]
        public int MTBooking_ID { get; set; }

        public string Display_ID { get; set; }

        public string Creator { get; set; }

        public DateTime? Creation_Time { get; set; }

        public DateTime? Edit_Time { get; set; }

        public string Status { get; set; }

        [Required]
        public DateTime? BookingDate { get; set; }

        [Required]
        public DateTime? BookingTime { get; set; }

        [Required]
        public string loginUser { get; set; }

        [Required]
        public int? NumberofTickets { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public string Currency { get; set; }

    }
}
