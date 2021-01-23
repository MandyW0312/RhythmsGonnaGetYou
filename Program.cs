using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
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

                Console.Write("Which Option would you like to choose? ");
                var choice = Console.ReadLine().ToUpper().Trim();


                if (choice == "ADD")
                {
                    Console.WriteLine();
                    Console.WriteLine("Menu Options:");
                    Console.WriteLine();
                    Console.WriteLine("Add a New Band (Band)");
                    Console.WriteLine("Add a New Album for a Band (Album)");
                    Console.WriteLine("Add a New Song to an Album (Song)");
                    Console.WriteLine();
                    Console.Write("Which Option would you like to choose? ");

                    var answer = Console.ReadLine().ToUpper().Trim();
                    if (answer == "BAND")
                    {
                        Console.Write("What is the Name of the Band? ");
                        var newName = Console.ReadLine();
                        Console.Write("What is the Band's Country Of Origin? ");
                        var newCountryOfOrigin = Console.ReadLine();
                        Console.Write("How many Members are in the Band? ");
                        var newNumberOfMembers = int.Parse(Console.ReadLine());
                        Console.Write("What is the Band's Website URL? ");
                        var newWebsite = Console.ReadLine();
                        Console.Write("What is the Band's Style of Music? ");
                        var newStyle = Console.ReadLine();
                        Console.Write("Is the Band currently Signed to the Record Company (true or false)? ");
                        var newIsSigned = bool.Parse(Console.ReadLine());
                        Console.Write("What is the Band's Contact Name? ");
                        var newContactName = Console.ReadLine();
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
                        Console.Write("Which Band do you want to Add an Album to? ");
                        var bandNameChosen = Console.ReadLine();
                        var band = context.Bands.First(band => band.Name == bandNameChosen);

                        Console.Write("What is the Title of the Album? ");
                        var newAlbumTitle = Console.ReadLine();
                        Console.Write("Is the Album Explicit (true or false)? ");
                        var newIsExplicit = bool.Parse(Console.ReadLine());
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
                    }
                    if (answer == "SONG")
                    {
                        Console.Write("Which Album do you want to Add a Song to? ");
                        var albumChosen = Console.ReadLine();
                        var album = context.Albums.First(album => album.Title == albumChosen);

                        Console.Write("What is the Title of the Song? ");
                        var newSongTitle = Console.ReadLine();
                        Console.Write("How long is the Song (in seconds)? ");
                        var newDuration = int.Parse(Console.ReadLine());
                        Console.Write("What Track Number is the Song on the Album? ");
                        var newTrackNumber = int.Parse(Console.ReadLine());

                        var existingSongWithSameTrackAndAlbum = context.Songs.FirstOrDefault(song => song.AlbumId == album.Id && song.TrackNumber == newTrackNumber);
                        if (existingSongWithSameTrackAndAlbum != null)
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
                        }
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
                    Console.WriteLine();
                    Console.Write("Which Option would you like to choose? ");
                    var answer = Console.ReadLine().ToUpper().Trim();
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
                        Console.Write("Which Band would like to look up Albums for? ");
                        var specificBand = Console.ReadLine();
                        foreach (var album in context.Albums.Where(band => band.TheBandAssociatedtotheAlbumObject.Name == specificBand))
                        {
                            Console.WriteLine($"The Albums for {specificBand} is {album.Title}");
                        }
                    }
                }
                if (choice == "CONTRACT CHANGE")
                {
                    Console.Write("Would you like to Release a Band from their Contract (Release) or Resign a Band (Resign)? ");
                    var answer = Console.ReadLine().ToUpper().Trim();
                    if (answer == "RELEASE")
                    {
                        Console.Write("What Band would you like to Release from their Contract? ");
                        var releasedBand = Console.ReadLine();
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
                        Console.Write("What Band would you like to Resign to their Contract? ");
                        var resignedBand = Console.ReadLine();
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
