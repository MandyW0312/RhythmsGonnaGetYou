using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static string PromptForStringUpper(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper().Trim();
            return userInput;
        }
        static string PromptForStringRegular(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            var userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        static bool PromptForBool(string prompt)
        {
            Console.Write(prompt);
            var userInput = bool.Parse(Console.ReadLine());
            return userInput;
        }
        static void BannerMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            BannerMessage("Welcome to The Rhythms Gonna Get You Record Company");

            var context = new RecordCompanyContext();


            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine();
                Console.WriteLine("Add");
                Console.WriteLine("View");
                Console.WriteLine("Contract Change");
                Console.WriteLine("Current Clients");
                Console.WriteLine("Quit");
                Console.WriteLine();

                var choice = PromptForStringUpper("Which Option would you like to choose? ");

                if (choice == "ADD")
                {
                    Console.WriteLine();
                    Console.WriteLine("Menu Options:");
                    Console.WriteLine();
                    Console.WriteLine("Add a New Band (Band)");
                    Console.WriteLine("Add a New Album for a Band (Album)");
                    Console.WriteLine("Add a New Song to an Album (Song)");
                    Console.WriteLine("Add a New Bans Member to a Band (Member)");
                    Console.WriteLine();
                    var answer = PromptForStringUpper("Which Option would you like to choose? ");

                    if (answer == "BAND")
                    {
                        var newName = PromptForStringRegular("What is the Name of the Band? ");
                        var newCountryOfOrigin = PromptForStringRegular("What is the Band's Country Of Origin? ");
                        var newNumberOfMembers = PromptForInteger("How many Members are in the Band? ");
                        var newWebsite = PromptForStringRegular("What is the Band's Website URL? ");
                        var newStyle = PromptForStringRegular("What is the Band's Style of Music? ");
                        var newIsSigned = PromptForBool("Is the Band currently Signed to the Record Company (true or false)? ");
                        var newContactName = PromptForStringRegular("What is the Band's Contact Name? ");
                        Console.Write("What is the Band's Contact Phone Number ");
                        var newContactPhoneNumber = long.Parse(Console.ReadLine());

                        var newBand = new Band
                        {
                            Name = newName,
                            CountryOfOrigin = newCountryOfOrigin,
                            NumberOfMembers = newNumberOfMembers,
                            Website = newWebsite,
                            Style = newStyle,
                            IsSigned = newIsSigned,
                            ContactName = newContactName,
                            ContactPhoneNumber = newContactPhoneNumber
                        };
                        context.Bands.Add(newBand);
                        context.SaveChanges();
                        Console.WriteLine($"The Band {newName} was Added!");
                    }
                    if (answer == "ALBUM")
                    {
                        var bandNameChosen = PromptForStringRegular("Which Band do you want to Add an Album to? ");
                        var band = context.Bands.FirstOrDefault(band => band.Name == bandNameChosen);

                        var newAlbumTitle = PromptForStringRegular("What is the Title of the Album? ");
                        var newIsExplicit = PromptForBool("Is the Album Explicit (true or false)? ");
                        Console.Write("What is the Album's Release Date (Please have it in this format YYYY-MM-DD)? ");
                        var newReleaseDate = DateTime.Parse(Console.ReadLine());

                        var newAlbum = new Album
                        {
                            Title = newAlbumTitle,
                            IsExplicit = newIsExplicit,
                            ReleaseDate = newReleaseDate,
                            BandId = band.Id
                        };
                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                        Console.WriteLine($"The Album {newAlbumTitle} was added!");
                    }
                    if (answer == "SONG")
                    {
                        var albumChosen = PromptForStringRegular("Which Album do you want to Add a Song to? ");
                        var album = context.Albums.FirstOrDefault(album => album.Title == albumChosen);

                        var newSongTitle = PromptForStringRegular("What is the Title of the Song? ");
                        var newDuration = PromptForInteger("How long is the Song (in seconds)? ");
                        var newTrackNumber = PromptForInteger("What Track Number is the Song on the Album? ");

                        var checkingTrackNumber = context.Songs.FirstOrDefault(song => song.AlbumId == album.Id && song.TrackNumber == newTrackNumber);
                        if (checkingTrackNumber != null)
                        {
                            Console.WriteLine("This Track Number is taken, please try again!");
                        }
                        else
                        {
                            var newSong = new Song
                            {
                                Title = newSongTitle,
                                Duration = newDuration,
                                TrackNumber = newTrackNumber,
                                AlbumId = album.Id
                            };
                            context.Songs.Add(newSong);
                            context.SaveChanges();
                            Console.WriteLine($"The Song {newSongTitle} was added!");
                        }
                    }
                    if (answer == "MEMBER")
                    {
                        var bandNameChosen = PromptForStringRegular("Which Band do you want to Add a Member to? ");
                        var band = context.Bands.FirstOrDefault(band => band.Name == bandNameChosen);
                        var newFullName = PromptForStringRegular("What is the Band Member's Name? ");
                        Console.Write("What is the Band Member's Birthday (YYYY-MM-DD)? ");
                        var newBirthday = DateTime.Parse(Console.ReadLine());
                        var newBandPosition = PromptForStringRegular("What's is the Band Member's Position in the Band? ");

                        var newMusician = new Musician
                        {
                            FullName = newFullName,
                            Birthday = newBirthday
                        };
                        context.Musicians.Add(newMusician);
                        context.SaveChanges();
                        Console.WriteLine($"The Band Member {newFullName} has been added to the Band {bandNameChosen} in our system.");

                        var musician = context.Musicians.FirstOrDefault(musician => musician.FullName == newFullName);

                        var newPosition = new Position
                        {
                            BandId = band.Id,
                            MusicianId = musician.Id,
                            BandPosition = newBandPosition
                        };
                        context.Positions.Add(newPosition);
                        context.SaveChanges();
                    }
                }
                if (choice == "VIEW")
                {
                    Console.WriteLine();
                    Console.WriteLine("Menu Options:");
                    Console.WriteLine();
                    Console.WriteLine("View All the Bands (Bands)");
                    Console.WriteLine("View All the Albums (Albums)");
                    Console.WriteLine("View All the Albums of a Specific Band (Specific)");
                    Console.WriteLine("View All Albums in a Genre (Genre)");
                    Console.WriteLine("View All Members of a Band (Members)");
                    Console.WriteLine();
                    var answer = PromptForStringUpper("Which Option would you like to choose? ");
                    if (answer == "BANDS")
                    {
                        foreach (var band in context.Bands)
                        {
                            Console.WriteLine($"{band.Name}");
                        }
                    }
                    if (answer == "ALBUMS")
                    {
                        var albumsInOrder = context.Albums.OrderBy(album => album.ReleaseDate);
                        foreach (var album in albumsInOrder)
                        {
                            Console.WriteLine($"{album.Title}");
                        }
                    }
                    if (answer == "SPECIFIC")
                    {
                        var specificBand = PromptForStringRegular("Which Band would like to look up Albums for? ");
                        foreach (var album in context.Albums.Where(band => band.TheAssociatedBand.Name == specificBand))
                        {
                            Console.WriteLine($"The Albums for {specificBand} are {album.Title}");
                        }
                    }
                    if (answer == "GENRE")
                    {
                        foreach (var album in context.Albums.Include(album => album.TheAssociatedBand))
                        {
                            Console.WriteLine($"We have this Album: {album.Title} in the Genre { album.TheAssociatedBand.Style}");
                        }
                    }
                    if (answer == "MEMBERS")
                    {
                        var specificBand = PromptForStringRegular("Which Band would like to look up Members for? ");
                        foreach (var position in context.Positions.Where(band => band.TheAssociatedBand.Name == specificBand).Include(position => position.TheAssociatedMusician))
                        {
                            Console.WriteLine($"The Band Member {position.TheAssociatedMusician.FullName} is the {position.BandPosition} of {specificBand}");
                        }
                    }
                }
                if (choice == "CONTRACT CHANGE")
                {
                    var answer = PromptForStringUpper("Would you like to Release a Band from their Contract (Release) or Resign a Band (Resign)? ");
                    if (answer == "RELEASE")
                    {
                        var releasedBand = PromptForStringRegular("What Band would you like to Release from their Contract? ");
                        var existingBand = context.Bands.FirstOrDefault(band => band.Name == releasedBand);
                        if (existingBand == null)
                        {
                            Console.WriteLine($"We couldn't find the Band {releasedBand} in our system, so we are unable to complete your request.");
                        }
                        else
                        {
                            Console.WriteLine($"Ending our Contract with {releasedBand}");
                            existingBand.IsSigned = false;
                            context.SaveChanges();
                        }
                    }
                    if (answer == "RESIGN")
                    {
                        var resignedBand = PromptForStringRegular("What Band would you like to Resign to their Contract? ");
                        var existingBand = context.Bands.FirstOrDefault(band => band.Name == resignedBand);
                        if (existingBand == null)
                        {
                            Console.WriteLine($"We couldn't find the Band {resignedBand} in our system, so we are unable to complete your request.");
                        }
                        else
                        {
                            Console.WriteLine($"Resigning our Contract with {resignedBand}");
                            existingBand.IsSigned = true;
                            context.SaveChanges();
                        }
                    }
                }
                if (choice == "CURRENT CLIENTS")
                {
                    var bandsSigned = context.Bands.Where(band => band.IsSigned == true);
                    foreach (var band in bandsSigned)
                    {
                        Console.WriteLine($"{band.Name} is Currently Signed");
                    }
                    var bandsNotSigned = context.Bands.Where(band => band.IsSigned == false);
                    foreach (var band in bandsNotSigned)
                    {
                        Console.WriteLine($"{band.Name} is Not Currently Signed");
                    }
                }
                if (choice == "QUIT")
                {
                    userHasChosenToQuit = true;
                }
            }
            BannerMessage("Thank you for visiting The Rhythms Gonna Get You Record Company");
        }
    }
}
