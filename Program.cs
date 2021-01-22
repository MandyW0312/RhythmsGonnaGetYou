using System;
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
                    // Ask the user if they would like to add a New Band, add a New Album for a band, or add a New Song to an album (Possible Menu Options)
                    // Read the answer and set to a variable
                    // IF (Band)
                    // Ask the user what is the Band’s Name
                    // Read the answer and set it to a variable
                    // Ask the user what is the Band’s Country Of Origin
                    // Read the answer and set it to a variable
                    // Ask the user how many Members are in the Band
                    // Read the answer and set it to a variable (int.Parse)
                    // Ask the user for the Band’s Website
                    // Read the answer and set it to a variable
                    // Ask the user for the Band’s Style of Music
                    // Read the answer and set it to a variable
                    // Ask the user if the Band is currently signed to the Record Company (true or false)
                    // Read the answer and set it to a variable
                    // Ask the user what is the Band’s Contact Name
                    // Read the answer and set it to a variable
                    // Ask the user what is the Band’s Contact Phone Number
                    // Read the answer and set it to a variable (int.Parse)

                    //     		Make a new instance of a band (using the answers)
                    //     			var newBand = new Band {
                    //     			Name=
                    //     			CountryOfOrigin=
                    //     			NumberOfMembers=
                    //     			Website=
                    //     			Style=
                    //     			IsSigned=
                    //     			ContactName=
                    //     			ContactPhoneNumber=    }

                    //     		Add the Band to the table of Bands
                    //     			context.Bands.Add(newBand);
                    //     			context.SaveChanges();

                    //     	IF (Album)
                    //     		Ask the user which Band they want to add the Album to
                    //     		Read the answer and set it to a variable (bandNameChosen)
                    //     		var band = context.Bands.First(band => band.Name == “bandNameChosen”);

                    //     		Ask the user what is the Title of the Album
                    //     		Read the answer and set it to a variable
                    //     		Ask the user if the Album is Explicit (true or false)
                    //     		Read the answer and set it to a variable
                    //     		Ask the user for the Album’s Release Date
                    //     		Read the answer and set it to a variable

                    //     		Make a new instance of an Album (using the answers)
                    //     			var newAlbum = new Album {
                    //     			Title=
                    //     			IsExplicit=
                    //     			ReleaseDate=
                    //     			BandId= band.Id    }

                    //     		Add the Album to the table of Albums
                    //     			context.Albums.Add(newAlbum);
                    //     			context.SaveChanges();

                    //     	IF (Song)
                    //     		Ask the user which Album they want to add the Song to
                    //     		Read the answer and set it to a variable (albumChosen)
                    //     		var album = context.Albums.First(album => album.Title == “albumChosen”);

                    //     		Ask the user what is the Title of the Song
                    //     		Read the answer and set it to a variable
                    //     		Ask the user how long the Song is
                    //     		Read the answer and set it to a variable
                    //     		Ask the user what Track Number is the Song on the Album
                    //     		Read the answer and set it to a variable (int.Parse)

                    //     			IF (answer is already taken)
                    //     				Don’t add the Song to the Album
                    //     			IF (answer is not taken)
                    //     				Make a new instance of an Album (using the answers)
                    //     					var newAlbum = new Album {
                    //     					Title=
                    //     					Duration=
                    //     					TrackNumber=
                    //     					AlbumId= album.Id    }

                    //     				Add the Song to the table of Songs
                    //     					context.Songs.Add(newSong);
                    //     					context.SaveChanges();
                }
                if (choice == "VIEW")
                {
                    // Ask the user if they want to view all the Bands, view all the Albums, or view Albums by a Specific Band (Possible Menu Options)
                    // Read the answer and set to a variable
                    // IF (Bands)
                    // foreach(var band in context.Bands)
                    // Print out all the Bands

                    //     	IF (Albums)
                    //     		var albumsInOrder = albums.OrderBy(album => album.ReleaseDate);
                    //     		foreach (var album in albumsInOrder)
                    //     			Print out all the Albums

                    //     	IF (Specific)
                    //     		Ask the user which Band they want to look up
                    //     		Read the answer and set it to a variable
                    //     		foreach (var album in context.Albums.Include(bands => band.Name == “answer”)
                    //     			Print out the albums for a Specific Band
                }
                if (choice == "CONTRACT CHANGE")
                {
                    Console.WriteLine();
                    Console.Write("Would you like to Release a Band from their Contract (Release) or Resign a Band (Resign)? ");
                    var answer = Console.ReadLine().ToUpper().Trim();
                    if (answer == "RELEASE")
                    {
                        Console.WriteLine();
                        Console.Write("What Band would you like to Release from their Contract? ");
                        var releasedBand = Console.ReadLine();
                        var existingBand = context.Bands.FirstOrDefault(band => band.Name == releasedBand);
                        if (existingBand == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"We couldn't find the Band {releasedBand} in our system, so we are unable to complete your request.");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ending our Contract with {releasedBand}");
                            existingBand.IsSigned = false;
                            context.SaveChanges();
                        }
                    }
                    if (answer == "RESIGN")
                    {
                        Console.WriteLine();
                        Console.Write("What Band would you like to Resign to their Contract? ");
                        var resignedBand = Console.ReadLine();
                        var existingBand = context.Bands.FirstOrDefault(band => band.Name == resignedBand);
                        if (existingBand == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"We couldn't find the Band {resignedBand} in our system, so we are unable to complete your request.");
                        }
                        else
                        {
                            Console.WriteLine();
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
                        Console.WriteLine();
                        Console.WriteLine($"{band.Name} is Currently Signed");
                    }
                    var bandsNotSigned = context.Bands.Where(band => band.IsSigned == false);
                    foreach (var band in bandsNotSigned)
                    {
                        Console.WriteLine();
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
