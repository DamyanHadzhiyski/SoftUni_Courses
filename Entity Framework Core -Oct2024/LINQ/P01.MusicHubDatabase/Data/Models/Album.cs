﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price
        {
            get { return Price; }
            set { Songs.Sum(s => s.Price); }
        }

        public int? ProducerId { get; set; }
        [ForeignKey(nameof(ProducerId))]
        public Producer? Producer { get; set; }

        public virtual ICollection<Song>? Songs { get; set; }
    }
}
