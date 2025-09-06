using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMovieTickets.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserId { get; set; }

        public List<orderItem> orderItems { get; set; }
    }
}
