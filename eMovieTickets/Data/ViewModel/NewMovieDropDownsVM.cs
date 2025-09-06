using eTickets.Models;
using System.Collections.Generic;

namespace eMovieTickets.Data.ViewModel
{
    public class NewMovieDropDownsVM
    {

        public NewMovieDropDownsVM()
        {
            producers = new List<Producer>();
            cinemas = new List<Cinema>();
            actors = new List<Actor>();
        }
        public List<Producer> producers { get; set; }
        public List<Cinema> cinemas { get; set; }

        public List<Actor> actors { get; set; }


    }
}
