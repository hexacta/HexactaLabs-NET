using HexactaLabs_MVC.Business.Genres;
using HexactaLabs_MVC.Business.Movies;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HexactaLabs_MVC.Persistence.Common
{
    public class DBInitializer<T> : CreateDatabaseIfNotExists<T> where T : MoviesContext
    {
        protected override void Seed(T context)
        {
            var defaultGenres = this.AddGenres(context);

            this.AddMovies(context, defaultGenres);

            base.Seed(context);
        }       


        private List<Genre> AddGenres(T context)
        {
            var defaultGenres = new List<Genre>();

            defaultGenres.Add(new Genre() { Name = "Drama" });
            defaultGenres.Add(new Genre() { Name = "Sci-Fi" });
            defaultGenres.Add(new Genre() { Name = "Thriller" });
            defaultGenres.Add(new Genre() { Name = "Action" });
            defaultGenres.Add(new Genre() { Name = "Sport" });
            defaultGenres.Add(new Genre() { Name = "Animation" });
            defaultGenres.Add(new Genre() { Name = "Adventure" });
            defaultGenres.Add(new Genre() { Name = "Crime" });
            defaultGenres.Add(new Genre() { Name = "Fantasy" });
            defaultGenres.Add(new Genre() { Name = "Comedy" });

            defaultGenres.ForEach(g => context.Genres.Add(g));

            return defaultGenres;
        }

        private void AddMovies(T context, List<Genre> defaultGenres)
        {
            var defaultMovies = new List<Movie>();

            var movie = new Movie() { Name = "The Lord of the Rings: The Return of the King", ReleaseDate = new DateTime(2003, 12, 17), Plot = "Gandalf and Aragorn lead the World of Men against Saurons army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjE4MjA1NTAyMV5BMl5BanBnXkFtZTcwNzM1NDQyMQ@@._V1_SX214_.jpg", Runtime = 201 };
            movie.Genres.Add(defaultGenres[0]);
            movie.Genres.Add(defaultGenres[8]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "Hitch", ReleaseDate = new DateTime(2005, 2, 11), Plot = "While helping his latest client woo the fine lady of his dreams, a professional \"date doctor\" finds that his game doesn't quite work on the gossip columnist with whom he's smitten.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BNzYyNzM2NzM2NF5BMl5BanBnXkFtZTcwNjg5NTQzMw@@._V1_SX214_.jpg", Runtime = 118 };
            movie.Genres.Add(defaultGenres[2]);
            movie.Genres.Add(defaultGenres[3]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "Star Wars: Episode V - The Empire Strikes Back", ReleaseDate = new DateTime(1980, 5, 21), Plot = "After the rebels have been brutally overpowered by the Empire on their newly-established base, Luke Skywalker takes advanced Jedi training with Yoda, while his friends are constantly being pursued by Vader as part of his plan to capture Luke.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjE2MzQwMTgxN15BMl5BanBnXkFtZTcwMDQzNjk2OQ@@._V1_SY317_CR0,0,214,317_.jpg", Runtime = 124 };
            movie.Genres.Add(defaultGenres[1]);
            movie.Genres.Add(defaultGenres[8]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "Grown Ups", ReleaseDate = new DateTime(2010, 6, 25), Plot = "After their high school basketball coach passes away, five good friends and former teammates reunite for a Fourth of July holiday weekend.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMjA0ODYwNzU5Nl5BMl5BanBnXkFtZTcwNTI1MTgxMw@@._V1_SX214_.jpg", Runtime = 102 };
            movie.Genres.Add(defaultGenres[4]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "The Hobbit: An Unexpected Journey", ReleaseDate = new DateTime(2012, 12, 14), Plot = "A younger and more reluctant Hobbit, Bilbo Baggins, sets out on an \"unexpected journey\" to the Lonely Mountain with a spirited group of Dwarves to reclaim their stolen mountain home from a dragon named Smaug.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_.jpg", Runtime = 169 };
            movie.Genres.Add(defaultGenres[6]);
            movie.Genres.Add(defaultGenres[8]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "Fast & Furious 6", ReleaseDate = new DateTime(2013, 5, 24), Plot = "Agent Luke Hobbs enlists Dominic Toretto and his team to bring down former Special Ops soldier Owen Shaw, leader of a unit specializing in vehicular warfare.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTM3NTg2NDQzOF5BMl5BanBnXkFtZTcwNjc2NzQzOQ@@._V1_SX214_.jpg", Runtime = 130 };
            movie.Genres.Add(defaultGenres[0]);
            movie.Genres.Add(defaultGenres[3]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "Horrible Bosses", ReleaseDate = new DateTime(2011, 7, 8), Plot = "Three friends conspire to murder their awful bosses when they realize they are standing in the way of their happiness.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BNzYxNDI5Njc5NF5BMl5BanBnXkFtZTcwMDUxODE1NQ@@._V1_SY317_CR0,0,214,317_.jpg", Runtime = 98 };
            movie.Genres.Add(defaultGenres[2]);
            movie.Genres.Add(defaultGenres[7]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "The Shining", ReleaseDate = new DateTime(1980, 12, 25), Plot = "algo", CoverLink = "http://aaa.com", Runtime = 146 };
            movie.Genres.Add(defaultGenres[6]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "SuperCampeones", ReleaseDate = new DateTime(1993, 12, 12), Plot = "La historia de Oliver", CoverLink = "www.supercampeones.com", Runtime = 130 };
            movie.Genres.Add(defaultGenres[5]);
            defaultMovies.Add(movie);

            movie = new Movie() { Name = "The Lord of the Rings: The Two Towers", ReleaseDate = new DateTime(2002, 12, 18), Plot = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Saurons new ally, Saruman, and his hordes of Isengard.", CoverLink = "http://ia.media-imdb.com/images/M/MV5BMTAyNDU0NjY4NTheQTJeQWpwZ15BbWU2MDk4MTY2Nw@@._V1_SY317_CR1,0,214,317_.jpg", Runtime = 179 };
            defaultMovies.Add(movie);

            defaultMovies.ForEach(m => context.Movies.Add(m));
        }
    }
}