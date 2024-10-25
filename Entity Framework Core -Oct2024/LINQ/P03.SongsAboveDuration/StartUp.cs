namespace MusicHub
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                        .Select(s => new
                        {
                            s.Name,
                            Performers = s.SongPerformers
                                            .Select(sp => new
                                            {
                                                sp.Performer.FirstName,
                                                sp.Performer.LastName
                                            })
                                            .OrderBy(sp => sp.FirstName)
                                            .ToList(),
                            WriterName = s.Writer.Name,
                            ProducerName = s.Album.Producer.Name,
                            s.Duration
                        })
                        .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                        .OrderBy(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList();

            StringBuilder result = new();

            int songNumber = 0;

            foreach (var song in songs)
            {
                songNumber++;

                result.AppendLine($"-Song #{songNumber}");
                result.AppendLine($"---SongName: {song.Name}");
                result.AppendLine($"---Writer: {song.WriterName}");

                if (song.Performers.Count > 0)
                {
                    foreach (var performer in song.Performers)
                    {
                        result.AppendLine($"---Performer: {performer.FirstName} {performer.LastName}");
                    }
                }

                result.AppendLine($"---AlbumProducer: {song.ProducerName}");
                result.AppendLine($"---Duration: {song.Duration}");
            }

            return result.ToString().Trim();
        }
    }
}
