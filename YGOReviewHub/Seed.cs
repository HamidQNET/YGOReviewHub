using YGOReviewHub.Data;
using YGOReviewHub.Models;

namespace YGOReviewHub
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.YugiohCardOwners.Any())
            {
                var yugiohcardOwners = new List<YugiohCardOwner>()
                {
                    new YugiohCardOwner()
                    {
                        YugiohCard = new YugiohCard()
                        {
                            Name = "Blue eyes white dragon",
                            Level = 8,
                            YugiohCardTypes = new List<YugiohCardType>()
                            {
                                new YugiohCardType { Type = new Models.Type() { Name = "Monster", Category = "Light" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Dark Magician",Text = "Dark Magician is pretty good", Rating = 7,
                                Reviewer = new Reviewer(){ FirstName = "Ken", LastName = "Carson" } },
                                new Review { Title="Blue eyes white dragon",Text = "Blue eyes the OG", Rating = 9,
                                Reviewer = new Reviewer(){ FirstName = "Lil", LastName = "Uzi" } },
                                new Review { Title="Exodia The Forbidden One",Text = "You know it's gg", Rating = 10,
                                Reviewer = new Reviewer(){ FirstName = "Playboi", LastName = "Carti" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Playboi",
                            LastName = "Carti",
                            City = "New York",
                            Deck = new Deck()
                            {
                                Name = "Crimson King",
                                DeckType= "Dark/Fire"
                            }
                        }
                    },
                    new YugiohCardOwner()
                    {
                        YugiohCard = new YugiohCard()
                        {
                            Name = "Dark Magician",
                            Level = 7,
                            YugiohCardTypes = new List<YugiohCardType>()
                            {
                                new YugiohCardType { Type = new Models.Type() { Name = "Spellcaster/Normal", Category = "Dark" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Armed Dragon Thunder",Text = "Armed Dragon Thunder is OP", Rating = 8,
                                Reviewer = new Reviewer(){ FirstName = "Sponge", LastName = "Bob" } },
                                new Review { Title="Dark Magician Girl",Text = "Do I need to say more?", Rating = 10,
                                Reviewer = new Reviewer(){ FirstName = "Guts", LastName = "Berserk" } },
                                new Review { Title="Gaia The Fierce Knight ",Text = "A knight whose horse travels faster than the wind", Rating = 8,
                                Reviewer = new Reviewer(){ FirstName = "Griffith", LastName = "Femto" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Griffith",
                            LastName = "Femto",
                            City = "kingdom of Midland",
                            Deck = new Deck()
                            {
                                Name = "Wings of Darkness",
                                DeckType= "Light/Dark"
                            }
                        }
                    },
                    new YugiohCardOwner()
                    {
                        YugiohCard = new YugiohCard()
                        {
                            Name = "Polymerization",
                            Level = 1,
                            YugiohCardTypes = new List<YugiohCardType>()
                            {
                                new YugiohCardType { Type = new Models.Type() { Name = "Normal Spell", Category = "Spell" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Mirror Force",Text = "OP trap card", Rating = 9,
                                Reviewer = new Reviewer(){ FirstName = "John", LastName = "Doe" } },
                                new Review { Title="Dark Magic Curtain",Text = "Dark Magician's best friend", Rating = 6,
                                Reviewer = new Reviewer(){ FirstName = "Inspector", LastName = "Gadget" } },
                                new Review { Title="Pot of Greed",Text = "Forbidden card", Rating = 3,
                                Reviewer = new Reviewer(){ FirstName = "Star", LastName = "Boy" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Star",
                            LastName = "Boy",
                            City = "Amsterdam",
                            Deck = new Deck()
                            {
                                Name = "Dark World",
                                DeckType= "Dark"
                            }
                        }

                    }
                };
                dataContext.YugiohCardOwners.AddRange(yugiohcardOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
