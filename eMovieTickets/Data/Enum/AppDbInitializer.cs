using eMovieTickets.Models;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace eMovieTickets.Data.Enum
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                context.Database.EnsureCreated();

                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(
                        new Cinema { Name = "Cinema1", Logo = "https://img.freepik.com/premium-vector/movie-cinema-premiere-background_41737-251.jpg", Description = "This is the description of the first cinema " },
                        new Cinema { Name = "Cinema2", Logo = "https://img.freepik.com/premium-vector/movie-cinema-premiere-background_41737-251.jpg", Description = "This is the description of the second cinema " },
                        new Cinema { Name = "Cinema3", Logo = "https://img.freepik.com/premium-vector/movie-cinema-premiere-background_41737-251.jpg", Description = "This is the description of the third cinema " },
                        new Cinema { Name = "Cinema4", Logo = "https://img.freepik.com/premium-vector/movie-cinema-premiere-background_41737-251.jpg", Description = "This is the description of the fourth cinema " }
                        );
                    context.SaveChanges();
                }
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(


                        new Producer { FullName = "Producer1", Bio = "This is the bio of the first producer", ProfilePictureURL = "https://tse4.mm.bing.net/th/id/OIP.2P_KnLCHFH-L_8kn8-JbfAHaEK?pid=Api&P=0&h=220" },
                        new Producer { FullName = "Producer2", Bio = "This is the bio of the second producer", ProfilePictureURL = "https://tse4.mm.bing.net/th/id/OIP.2P_KnLCHFH-L_8kn8-JbfAHaEK?pid=Api&P=0&h=220" },
                        new Producer { FullName = "Producer3", Bio = "This is the bio of the third producer", ProfilePictureURL = "https://tse4.mm.bing.net/th/id/OIP.2P_KnLCHFH-L_8kn8-JbfAHaEK?pid=Api&P=0&h=220" },
                        new Producer { FullName = "Producer4", Bio = "This is the bio of the fourth producer", ProfilePictureURL = "https://tse4.mm.bing.net/th/id/OIP.2P_KnLCHFH-L_8kn8-JbfAHaEK?pid=Api&P=0&h=220" },
                        new Producer { FullName = "Producer5", Bio = "This is the bio of the fifth producer", ProfilePictureURL = "https://tse4.mm.bing.net/th/id/OIP.2P_KnLCHFH-L_8kn8-JbfAHaEK?pid=Api&P=0&h=220" }
                    );
                    context.SaveChanges();
                }
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(
                        new Actor { FullName = "Actor1", Bio = "This is the bio of the first actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" },
                        new Actor { FullName = "Actor2", Bio = "This is the bio of the second actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" },
                        new Actor { FullName = "Actor3", Bio = "This is the bio of the third actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" },
                        new Actor { FullName = "Actor4", Bio = "This is the bio of the fourth actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" },
                        new Actor { FullName = "Actor5", Bio = "This is the bio of the fifth actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" },
                        new Actor { FullName = "Actor6", Bio = "This is the bio of the sixth actor", ProfilePictureURL = "https://ik.imagekit.io/j83rchiauw/A_List_Star/vijay-biography.jpg" }

                        );
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie { Name = "Movie1", Description = "This is the description of the first movie", Price = 10.99, ImageURL = "https://tse1.mm.bing.net/th/id/OIP.tgDjfEJ1-RFnL4LqmafzWwHaEK?pid=Api&P=0&h=220", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), CinemaID = 1,ProducerID=6,MovieCategory=MovieCategory.Action },
                        new Movie { Name = "Movie2", Description = "This is the description of the second movie", Price = 12.99, ImageURL = "https://tse1.mm.bing.net/th/id/OIP.tgDjfEJ1-RFnL4LqmafzWwHaEK?pid=Api&P=0&h=220", StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(14), CinemaID = 2, ProducerID = 7, MovieCategory = MovieCategory.Comedy },
                        new Movie { Name = "Movie3", Description = "This is the description of the third movie", Price = 8.99, ImageURL = "https://tse1.mm.bing.net/th/id/OIP.tgDjfEJ1-RFnL4LqmafzWwHaEK?pid=Api&P=0&h=220", StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(15), CinemaID = 3, ProducerID = 8, MovieCategory = MovieCategory.Drama },
                        new Movie { Name = "Movie4", Description = "This is the description of the fourth movie", Price = 15.99, ImageURL = "https://tse1.mm.bing.net/th/id/OIP.tgDjfEJ1-RFnL4LqmafzWwHaEK?pid=Api&P=0&h=220", StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(20), CinemaID = 4, ProducerID = 9, MovieCategory = MovieCategory.Horror }
                        );
                    context.SaveChanges();
                }

                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(
                        new Actors_Movies { MovieId = 6, ActorId = 7 },
                        new Actors_Movies { MovieId = 7, ActorId = 8 },
                        new Actors_Movies { MovieId = 8, ActorId = 9 },
                        new Actors_Movies { MovieId = 9, ActorId = 10 },
                        new Actors_Movies { MovieId = 6, ActorId = 12 },
                        new Actors_Movies { MovieId = 7, ActorId = 7 },
                        new Actors_Movies { MovieId = 8, ActorId = 8 },
                        new Actors_Movies { MovieId = 9, ActorId = 7 },
                        new Actors_Movies { MovieId = 6, ActorId = 10 },
                        new Actors_Movies { MovieId = 7, ActorId = 11 },
                        new Actors_Movies { MovieId = 8, ActorId = 12 }
                    );
                    context.SaveChanges();
                }
                    //var ActorsToUpdate = context.Actors.ToList();
                    //foreach (var actor in ActorsToUpdate)
                    //{
                    //  actor.ProfilePictureURL = actor.ProfilePictureURL.Replace("images/", "~/images/");
                    //}
                    //context.SaveChanges();

                    //var MoviesToUpdate = context.Movies.ToList();
                    //foreach (var movies in MoviesToUpdate)
                    //{
                    //    movies.ImageURL = movies.ImageURL.Replace("images/", "~/images/");
                    //}
                    //context.SaveChanges();

                    //var ProducersToUpdate = context.Producers.ToList();
                    //foreach (var producer in ProducersToUpdate)
                    //{
                    //    producer.ProfilePictureURL = producer.ProfilePictureURL.Replace("images/", "~/images/");
                    //}
                    //context.SaveChanges();

                    //var CinemaToUpdate = context.Cinemas.ToList();
                    //foreach (var Cinema in CinemaToUpdate)
                    //{
                    //    Cinema.Logo = Cinema.Logo.Replace("images/", "~/images/");
                    //}
                    //context.SaveChanges();
                // Seed data if necessary
                // Example: context.Movies.Add(new Movie { Title = "Inception", Genre = "Sci-Fi" });
                // context.SaveChanges();
            }
        }
    }
}
