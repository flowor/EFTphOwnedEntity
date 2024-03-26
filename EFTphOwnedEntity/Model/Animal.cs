using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using static EFTphOwnedEntity.Enums;

namespace EFTphOwnedEntity.Model
{
    public abstract class Animal
    {
        public int AnimalId { get; set; }

        public AnimalType Type { get; set; }

        public required virtual Part Head { get; set; }
        public required virtual Part Torso { get; set; }
        public required virtual Part Legs { get; set; }

    }

    public class Part
    {
        public string? Comment { get; set; }
        public required virtual AuctionDetail Current { get; set; }
        public required virtual AuctionDetail Prior { get; set; }
    }

    public class AuctionDetail
    {
        [Column(TypeName = "decimal(29, 6)")]
        public decimal? Min { get; set; }
        [Column(TypeName = "decimal(29, 6)")]
        public decimal? Worst { get; set; }
        [Column(TypeName = "decimal(29, 6)")]
        public decimal? Best { get; set; }
    }
}
