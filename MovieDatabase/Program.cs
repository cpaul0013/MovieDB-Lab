using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MovieDBContext context = new MovieDBContext();
            bool runProgram = true;
            while (runProgram)
            {
                //CreateDB();
                DisplayMovies();
                TitleorGenre();
                runProgram = getContinue();
            }
        }

        public static void CreateDB()
        {
            using (MovieDBContext context = new MovieDBContext())
            {
               
                Movie movie1 = new Movie
                {
                    Title = "Up",
                    Genre = "Animated",
                    Runtime = 98
                };

                Movie movie2 = new Movie
                {
                    Title = "Soul",
                    Genre = "Animated",
                    Runtime = 125
                };

                Movie movie3 = new Movie
                {
                    Title = "The Good Dinosaur",
                    Genre = "Animated",
                    Runtime = 100
                };

                Movie movie4 = new Movie
                {
                    Title = "Halloween",
                    Genre = "Horror",
                    Runtime = 120
                };

                Movie movie5 = new Movie
                {
                    Title = "The Exorcist",
                    Genre = "Horror",
                    Runtime = 117
                };

                Movie movie6 = new Movie
                {
                    Title = "The Blob",
                    Genre = "Horror",
                    Runtime = 100
                };

                Movie movie7 = new Movie
                {
                    Title = "Harry Potter",
                    Genre = "Fantasy",
                    Runtime = 98
                };

                Movie movie8 = new Movie
                {
                    Title = "The Fellowship of the Ring",
                    Genre = "Fantasy",
                    Runtime = 125
                };

                Movie movie9 = new Movie
                {
                    Title = "Dune",
                    Genre = "Fantasy",
                    Runtime = 134
                };

                Movie movie10 = new Movie
                {
                    Title = "Dune",
                    Genre = "Fantasy",
                    Runtime = 134
                };
                
                context.Movies.Add(movie1);
                context.Movies.Add(movie2);
                context.Movies.Add(movie3);
                context.Movies.Add(movie4);
                context.Movies.Add(movie5);
                context.Movies.Add(movie6);
                context.Movies.Add(movie7);
                context.Movies.Add(movie8);
                context.Movies.Add(movie9);
                context.Movies.Add(movie10);
                context.SaveChanges();

            }

        }

        public static void SelectByGenre()
        {   while (true)
            {
                MovieDBContext context = new MovieDBContext();
                Console.WriteLine("Please enter a genre: Horror / Fantasy / Animated");
                string response = Console.ReadLine();
                List<Movie> ByGenre = context.Movies.Where(Movie => Movie.Genre == response).ToList();
                if (ByGenre.Count() > 0)
                {
                    foreach (Movie m in ByGenre)
                    {
                        Console.WriteLine($"Title: {m.Title} \n Genres: {m.Genre} \n Run Times: {m.Runtime} Minutes \n");

                    }
                    break;
                }

                else
                {
                    Console.WriteLine("That was not a valid input. Please check your input");

                }
            }
        }

        public static void SelectTitle()
        {   while (true)
            {
                MovieDBContext context = new MovieDBContext();
                Console.WriteLine("Please enter a movie title: ");
                string response = Console.ReadLine();
                List<Movie> ByTitle = context.Movies.Where(Movie => Movie.Title == response).ToList();
                if (ByTitle.Count > 0)
                {
                    foreach (Movie m in ByTitle)
                    {
                        Console.WriteLine($" Title: {m.Title}\n Genre: {m.Genre}\n Run Time: {m.Runtime} Minutes");
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("That was not a valid input. Please check your input");

                }
            }
        }

        public static void DisplayMovies()
        {
            MovieDBContext context = new MovieDBContext();
            foreach(Movie m in context.Movies.ToList())
            {

                Console.WriteLine($"{m.Title}, {m.Genre}, {m.Runtime} Minutes \n");


            }

        }

        public static void TitleorGenre()
        {
            bool validInput = false;
                while(!validInput)
            {
                Console.WriteLine("Would you like to search by genre or title? ");
                string response = Console.ReadLine().ToLower().Trim();
                if(response == "genre")
                {

                    SelectByGenre();
                    break;


                }

                else if(response == "title")
                {

                    SelectTitle();
                    break;
                }

                else
                {

                    Console.WriteLine("That was not a valid input. Please select genre or title,");
                }


            }
        }


        public static bool getContinue()
        {
            bool result = true;

            while (true)
            {
                Console.WriteLine("Would you like to keep running the program? y/n");
                string choice = Console.ReadLine().ToLower().Trim();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    break;
                }
                else if (choice == "n" || choice == "no")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid choice.");
                }
            }

            return result;
        }


    }
}
