namespace Problem_4___Movie_Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieTime
    {
        public static void Main()
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();

            string line = Console.ReadLine();

            var movies = new Dictionary<string, Dictionary<string, TimeSpan>>();

            while (line != "POPCORN!")
            {
                string[] info = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string filmName = info[0];
                string filmGenre = info[1];
                TimeSpan filmDuration = TimeSpan.Parse(info[2]);

                if (!movies.ContainsKey(filmGenre))
                {
                    movies.Add(filmGenre, new Dictionary<string, TimeSpan>());
                }

                movies[filmGenre].Add(filmName, filmDuration);


                line = Console.ReadLine();
            }

            TimeSpan playlistDuration = TimeSpan.Zero;

            foreach (var key in movies.Keys)
            {
                foreach (var innerKey in movies[key].Keys)
                {
                    playlistDuration += movies[key][innerKey];
                }
            }

            if (duration.Equals("Short"))
            {

                foreach (var movie in movies[genre].OrderBy(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine(movie.Key);
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {playlistDuration}");
                        break;
                    }
                }
            }
            else
            {
                
                foreach (var movie in movies[genre].OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine(movie.Key);
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {playlistDuration}");
                        break;
                    }
                }
            }
        }
    }
}
