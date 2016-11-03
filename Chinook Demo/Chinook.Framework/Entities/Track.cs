    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Chinook.Framework.Entities
{
    [Table("Tracks")] // Identifies which DB table this class maps to
    public partial class Track
    {
        [Key] // Identifies that this property maps as a Primary Key in DB
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Name is a required field.")] // This property cannot have a null value
        [StringLength(200, ErrorMessage = "Name is too long. Max length is 200 characters.")] // This property has a max string length of 200 characters
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Album is invalid.")] // This property's value must fit in the range of the min/max values
        public int? AlbumId { get; set; }

        [Range(1, int.MaxValue)]
        public int MediaTypeId { get; set; }

        [Range(1, int.MaxValue)]
        public int? GenreId { get; set; }

        [StringLength(220, MinimumLength = 3)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        public virtual MediaType MediaType { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
