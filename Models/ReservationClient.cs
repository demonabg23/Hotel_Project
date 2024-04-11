using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Project_Marti_i_Stanko.Models
{
    public class ReservationClient
    {
        [Key]
        public int Id { get; set; }//need this to avoid error
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
