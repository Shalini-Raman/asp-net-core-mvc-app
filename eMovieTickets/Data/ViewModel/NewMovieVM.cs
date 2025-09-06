using eMovieTickets.Data;
using eMovieTickets.Data.Base;
using eMovieTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public NewMovieVM()
        {
            ActorIds = new List<int>();
        }
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage="Name is required")]
       
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]

        public MovieCategory MovieCategory { get; set; }

        //relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public List<int> ActorIds { get; set; }

        //Cinema
        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie Cinema is required")]
        public int CinemaID { get; set; }


        //Producer
        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie Producer is required")]
        public int ProducerID { get; set; }
       
    }
}
