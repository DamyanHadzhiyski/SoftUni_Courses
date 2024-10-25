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

            Console.WriteLine(ExportAlbumsInfo(context, 9)); 
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                            .Select(a => new
                            {
                                a.Name,
                                a.ReleaseDate,
                                a.ProducerId,
                                ProducerName = a.Producer.Name,
                                a.Songs,
                            })
                            .Where(a => a.ProducerId == producerId)
                            .ToList();

            var orderedAlbums = albums.OrderByDescending(a => a.Songs.Sum(s => s.Price)).ToList();

            StringBuilder result = new();

            foreach (var album in orderedAlbums)
            {
                result.AppendLine($"-AlbumName: {album.Name}");
                result.AppendLine("-ReleaseDate: " + album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                result.AppendLine($"-ProducerName: {album.ProducerName}");
                result.AppendLine($"-Songs:");

                int songNumber = 0;
                decimal totalAlbumPrice = 0;

                var sortedSongs = album.Songs.OrderByDescending(s => s.Name).ThenBy(s => s.Writer.Name).ToList();

                foreach (var song in sortedSongs)
                {
                    songNumber++;
                    totalAlbumPrice += song.Price;

                    result.AppendLine($"---#{songNumber}");
                    result.AppendLine($"---SongName: {song.Name}");
                    result.AppendLine($"---Price: {song.Price:F2}");
                    result.AppendLine($"---Writer: {song.Writer.Name}");
                }

                result.AppendLine($"-AlbumPrice: {totalAlbumPrice:f2}");
            }

            return result.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
