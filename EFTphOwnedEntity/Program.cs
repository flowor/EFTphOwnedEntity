using EFTphOwnedEntity;
using EFTphOwnedEntity.Model;

using var db = new MyDbContext();

// Create
Console.WriteLine("Inserting a new Animal");

var animalDog = new Dog
{
    Type = Enums.AnimalType.Dog,
    Head = new DogPart
    {
        Comment = "Pretty large brain",
        Current = new DogAuctionDetail { Min = 1, Worst = -10, Best = 20 },
        Prior = new DogAuctionDetail { Min = 9, Worst = 8, Best = 7 },
    },
    Torso = new DogPart
    {
        Comment = "Long and lean",
        Current = new DogAuctionDetail { Min = 0, Worst = 1, Best = 2 },
        Prior = new DogAuctionDetail { Min = 2, Worst = 3, Best = 0 },
    },
    Legs = new DogPart
    {
        Comment = "Thick and meaty",
        Current = new DogAuctionDetail { Min = 2, Worst = -1, Best = 22 },
        Prior = new DogAuctionDetail { Min = 92, Worst = 82, Best = 72 },
    }
};

db.Add(animalDog);
db.SaveChanges();