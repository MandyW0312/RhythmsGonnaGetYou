using System;
using System.Linq;

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
            // Welcome to the App
            BannerMessage("Welcome to The Rhythms Gonna Get You Record Company");

            var context = new RecordCompanyContext();

            // While the user has not chosen to quit (Bool = false)
            var userHasChosenToQuit = false;
            while (userHasChosenToQuit == false)
            {
                // Display Menu Options:
                Console.WriteLine("Menu Options:");
                Console.WriteLine();
                // Add
                Console.WriteLine("Add");
                // View
                Console.WriteLine("View");
                // Contract Change
                Console.WriteLine("Contract Change");
                // Current Clients
                Console.WriteLine("Current Clients");
                // Quit
                Console.WriteLine("Quit");
                Console.WriteLine();

                // Ask the user which they would like to choose
                Console.Write("Which Option would you like to choose? ");
                // Read the answer and set to a variable
                var choice = Console.ReadLine().ToUpper().Trim();

                // IF (Add)
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
                // IF (View)
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
                // IF (Contract Change)
                if (choice == "CONTRACT CHANGE")
                {
                    // Ask the user if they want to Release a Band from their Contract or Resign a Band
                    // Read the answer and set it to a variable
                    // IF (Release)
                    // Ask the user what Band do they want to Release from their Contract
                    // Read the answer and set it to a variable
                    // var existingBand = context.Bands.FirstOrDefault(band => band.Name == “answer”);
                    // IF (existingBand == null)
                    // Print out couldn’t find the band
                    // ELSE
                    // Print out Ending the Contract with (answer)
                    // existingBand.IsSigned = false;
                    // context.SaveChanges();

                    //     	IF (Resign)
                    //     		Ask the user what Band do they want to Resign to the Company
                    //     		Read the answer and set it to a variable

                    //     		var existingBand = context.Bands.FirstOrDefault(band => band.Name == “answer”);
                    //     			IF (existingBand == null)
                    //     				Print out couldn’t find the band
                    //     			ELSE
                    //     				Print out Ending the Contract with (answer)
                    //     				existingBand.IsSigned = true;
                    //     				context.SaveChanges();
                }
                // IF (Current Clients)
                if (choice == "Current Clients")
                {
                    // var bandsSigned = bands.Where(band => band.IsSigned == true);
                    // foreach (var band in bandsSigned)
                    // Print out all the currently signed bands
                    // var bandsNotSigned = bands.Where(band => band.IsSigned == false);
                    // foreach (var band in bandsNotSigned)
                    // Print out all the bands not currently signed
                }
                // IF (Quit)
                if (choice == "QUIT")
                {
                    // set Bool = true;
                    userHasChosenToQuit = true;
                }
            }
            // Say GoodBye
            BannerMessage("Thank you for visiting The Rhythms Gonna Get You Record Company");
        }
    }
}
