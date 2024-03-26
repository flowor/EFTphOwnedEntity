namespace EFTphOwnedEntity.Model
{
    public class Cat : Animal
    {
        public required override Part Head { get; set; }
        public required override Part Torso { get; set; }
        public required override Part Legs { get; set; }
    }

    public class CatPart : Part
    {
        public required override AuctionDetail Current { get; set; }
        public required override AuctionDetail Prior { get; set; }
    }

    public class CatAuctionDetail : AuctionDetail { }
}
