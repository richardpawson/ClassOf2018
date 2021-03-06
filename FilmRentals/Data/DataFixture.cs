﻿using FilmRentals.Model;

namespace FilmRentals.Data
{

    public static class FilmRentalDataFixture
    {

        public static void CreateData(FilmRentalsDbContext dbContext)
        {

            CreateMember(dbContext, "Toby Lawrance", "26 The Street, Silverstone", 87, "TLawrance@stowe.co.uk");
            CreateMember(dbContext, "Olly Clarke", "26 The Street, Oxford", 18, "OllyC@aol.com");
            var u = CreateRating(dbContext, "U", 1);
            var pg = CreateRating(dbContext, "PG", 13);
            var r = CreateRating(dbContext, "R", 17);
            CreateFilm(dbContext, "Casino Royale", PriceCodes.NewRelease, pg);
            CreateFilm(dbContext, "Star Trek: Beyond", PriceCodes.Regular, pg);
            CreateFilm(dbContext, "Mary Poppins", PriceCodes.Childrens, u);
        }

        public static Member CreateMember(FilmRentalsDbContext context, string name, string address, int age, string email)
        {
            var member = new Member
            {
                Name = name,
                Address = address,
                Age = age,
                Email = email
            };
            if (context != null)
            {
                context.Members.Add(member);
            }
            return member;
        }

        public static Rating CreateRating(FilmRentalsDbContext context, string description, int age)
        {
            var rating = new Rating
            {
                Description = description,
                Age = age
            };
            if (context != null)
            {
                context.Ratings.Add(rating);
            }
            return rating;
        }
        public static Film CreateFilm(FilmRentalsDbContext context, string title, PriceCodes priceCode, Rating rating)
        {
            var film = new Film { Title = title, PriceCode = priceCode, Rating = rating };
            if (context != null)
            {
                context.Films.Add(film);
            }
            return film;
        }

        public static Rental CreateRental(FilmRentalsDbContext context, Member member, Film film, int daysRented)
        {
            var rental = new Rental { Film = film, Member = member, DaysRented = daysRented };
            if (context != null)
            {
                context.Rentals.Add(rental);
            }
            member.Rentals.Add(rental);
            return rental;
        }

    }
}
