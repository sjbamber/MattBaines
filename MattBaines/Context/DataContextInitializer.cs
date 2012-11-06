using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;
using MattBaines.Data;
using Devtalk.EF.CodeFirst;


public class DataContextInitializer : DontDropDbJustCreateTablesIfModelChanged<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            DataAccess _db = new DataAccess();


            // Init Categories and Objects
            List<AdvertisingCreativeCategory> Categories = new List<AdvertisingCreativeCategory>();
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "BBH Shanghai",
                Colour = "#2222FF"
            });

            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "TBWA London",
                Colour = "#FF2222"
            });
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "Momentum Manchester",
                Colour = "#22FF22"
            });
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "Proactive Work",
                Colour = "#22FFFF"
            });

            foreach (var category in Categories)
            {
                _db.AddAdvertisingCreativeCategory(category);
            }

            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Work 1",
                Content = "<h1>Work 1</h1>",
                Category = Categories[0]
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Work 2",
                Content = "<h1>Work 2</h1>",
                Category = Categories[1]
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Work 3",
                Content = "<h1>Work 3</h1>",
                Category = Categories[2]
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Work 4",
                Content = "<h1>Work 4</h1>",
                Category = Categories[2]
            });

            _db.AddWorkILike(new WorkILike()
            {
                Type = "Articles",
                Title = "Fashion and Poetry and Never the Twain Shall Meet",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = "Fashionable writers certainly seem to be the exception rather than the rule. For every Oscar Wilde there are a thousand Philip Larkins. When the great novelist Gilda Radner was asked about her wardrobe she replied “I base my fashion sense on what doesn’t itch.” A sentiment that echoes through a literary world that holds fashion in mild contempt."
            });
            _db.AddWorkILike(new WorkILike()
            {
                Type = "Story Ideas",
                Title = "The Importance Of Pee",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = "Shaking his head, Pee lowered the volume on the cassette player and addressed his friends with the confidence of a man about to achieve things beyond the expectations of most of humanity “men, as you know, next week I will catch a flight to Tanzania with the express interest of tackling the largest mountain in Africa’s entirety. This is a story about one man's self importance, and the comedyflicts which arise because of it."
            });
            _db.AddWorkILike(new WorkILike()
            {
                Type = "Interviews",
                Title = "9 Questions: Hazel Davis",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = "Hazel Davis talks about life as a freelance writer. She gives tips on how to enhance your writing career, what inspires her most and what it's like being your own boss."
            });
            _db.AddWorkILike(new WorkILike()
            {
                Title = "Is Contador’s Disfigured Reputation, Irreparable?",
                Course = "MA Falmouth",
                Year = "2011",
                Summary = "In the media glare of the 21st century elite level Cycling and in particular doping has entered the spotlight like never before. This has led to more stringent doping tests and an increased penalty for even slight infringements. Particularly apt in light of Contador's two year ban, this article asks the question, can a cyclist recover from the ignominy that a doping allegation brings?"
            });

            // Init Users and Roles
            WebSecurity.Register("Demo", "123456", "demo@demo.com", true, "Demo", "Demo");
            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");
        }
    }