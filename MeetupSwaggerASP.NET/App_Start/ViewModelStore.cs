using MeetupSwaggerASP.NET.Models;
using System;
using System.Collections.Generic;

namespace MeetupSwaggerASP.NET.App_Start
{
    public class ViewModelStore
    {
        public static List<Country> Countries { get; set; }
        public static List<Location> Locations { get; set; }
        public static List<Office> Offices { get; set; }
        public static List<Person> People { get; set; }

        public static void InitializeStore()
        {
            var country1 = new Country { Id = 1, Name = "France" };
            var country2 = new Country { Id = 2, Name = "USA" };
            var country3 = new Country { Id = 3, Name = "China" };

            var location1 = new Location { Id = 1, DisplayName = "Paris by night", City = "Paris", AddressLine1 = "12 rue des étoiles", ZipCode = "75008", Country = country1 };
            var location2 = new Location { Id = 2, DisplayName = "NY", City = "NewYork", AddressLine1 = "block 5", ZipCode = "123 M", Country = country2 };
            var location3 = new Location { Id = 3, DisplayName = "Space X Headquarters", City = "Hawthorne", AddressLine1 = "Rocket Rd", ZipCode = "CA 90250", Country = country2 };

            var office1 = new Office { Id = 1, Name = "Paris - Busieness", Address = location1 };
            var office2 = new Office { Id = 2, Name = "Paris - IT", Address = location1 };
            var office3 = new Office { Id = 3, Name = "NY", Address = location2 };
            var office4 = new Office { Id = 3, Name = "Space X", Address = location3 };

            var per1 = new Person { Id = 1, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office1, Firstname = "Thomas", Lastname = "Carter", Offices = new List<Office>() { office1, office4 } };
            var per2 = new Person { Id = 2, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office2, Firstname = "Luck", Lastname = "Skywalker", Offices = new List<Office>() { office2 } };
            var per3 = new Person { Id = 3, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office3, Firstname = "Ben", Lastname = "Kenobi", Offices = new List<Office>() { office3, office4 } };
            var per4 = new Person { Id = 4, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office4, Firstname = "Han", Lastname = "Solo", Offices = new List<Office>() { office4 } };
            var per5 = new Person { Id = 5, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office4, Firstname = "Leia", Lastname = "Organa", Offices = new List<Office>() { office4 } };
            var per6 = new Person { Id = 6, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office4, Firstname = "Chewbacca", Lastname = "", Offices = new List<Office>() { office1, office4 } };
            var per7 = new Person { Id = 7, ExternalId = Guid.NewGuid().ToString(), DefaultOffice = office1, Firstname = "Yoda", Lastname = "", Offices = new List<Office>() { office1, office4 } };

            ViewModelStore.Countries = new List<Country>() { country1, country2, country3 };
            ViewModelStore.Locations = new List<Location>() { location1, location2, location3 };
            ViewModelStore.Offices = new List<Office>() { office1, office2, office3, office4 };
            ViewModelStore.People = new List<Person>() { per1, per2, per3, per4, per5, per6, per7 };
        }
    }
}