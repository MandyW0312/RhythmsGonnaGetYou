Problem:

- Model and Create a Database (RecordCompany)

- Starting a record label company and we have a place to store our Bands, Albums, and eventually Songs

- Create a console app that stores the info into a Database

C R U D

- Create: Create Albums, Songs, & Bands
- Read: View the Bands, Albums, and Albums of Specific Bands
- Update: Resign a Band, Release a Band from Contract
- Delete: Not Really Deleting any info from the Database

Examples:

- Our Record Company Releases ABBA from its Record Contract.

- Our Record Company decides that it made a wants to Resign Fleetwood Mac to a Record Contract.

- We want to add the Band, KISS to our Record Company.

- We want to add the Album ‘ ‘, to the Band Night Ranger.

- We want to add the Song ‘ ‘, to the New Night Ranger Album.

- We want to View all the Albums for Night Ranger.

Data Structure:

Bands (Table):
Id (SERIAL)
Name (TEXT)
CountryOfOrigin (TEXT)
NumberOfMembers (INT)
Website (TEXT)
Style (TEXT)
IsSigned (BOOL)
ContactName (TEXT)
ContactPhoneNumber (INT)

Albums (Table):
Id (SERIAL)
Title (TEXT)
IsExplicit (BOOL)
ReleaseDate (DATE)
BandID (INTEGER REFERENCES “Bands” (“Id”))

Songs (Table):
Id (SERIAL)
TrackNumber (INT)
Title (TEXT)
Duration (TIME)
AlbumId (INTEGER REFERENCES “Albums” (“Id”))

Create a Class for Band with the above properties
Create a Class for Album with the above properties
Create a Class for Song with the above properties
Create a Class for Context

Algorithm:

In SQL:
Create a Database (RecordCompany)
Create a table called “Bands”
Insert some Bands into the “Bands” table
Create a table called “Albums”
Insert some Albums into the “Albums” table
Create a table called “Songs”
Insert some Songs into the “Songs” table

In VSCode:
Create a Class for Band with the above properties
Create a Class for Album with the above properties
Create a Class for Song with the above properties
Create a Class for Context

Welcome to the App

Var context = new RecordCompanyContext();

While the user has not chosen to quit (Bool = false)
Display Menu Options:
Add
View
Contract Change
Current Clients
Quit

Ask the user which they would like to choose
Read the answer and set to a variable

IF (Add)
Ask the user if they would like to add a New Band, add a New Album for a band, or add a New Song to an album (Possible Menu Options)
Read the answer and set to a variable
IF (Band)
Ask the user what is the Band’s Name
Read the answer and set it to a variable
Ask the user what is the Band’s Country Of Origin
Read the answer and set it to a variable
Ask the user how many Members are in the Band
Read the answer and set it to a variable (int.Parse)
Ask the user for the Band’s Website
Read the answer and set it to a variable
Ask the user for the Band’s Style of Music
Read the answer and set it to a variable
Ask the user if the Band is currently signed to the Record Company (true or false)
Read the answer and set it to a variable
Ask the user what is the Band’s Contact Name
Read the answer and set it to a variable
Ask the user what is the Band’s Contact Phone Number
Read the answer and set it to a variable (int.Parse)

    		Make a new instance of a band (using the answers)
    			var newBand = new Band {
    			Name=
    			CountryOfOrigin=
    			NumberOfMembers=
    			Website=
    			Style=
    			IsSigned=
    			ContactName=
    			ContactPhoneNumber=    }

    		Add the Band to the table of Bands
    			context.Bands.Add(newBand);
    			context.SaveChanges();

    	IF (Album)
    		Ask the user which Band they want to add the Album to
    		Read the answer and set it to a variable (bandNameChosen)
    		var band = context.Bands.First(band => band.Name == “bandNameChosen”);

    		Ask the user what is the Title of the Album
    		Read the answer and set it to a variable
    		Ask the user if the Album is Explicit (true or false)
    		Read the answer and set it to a variable
    		Ask the user for the Album’s Release Date
    		Read the answer and set it to a variable

    		Make a new instance of an Album (using the answers)
    			var newAlbum = new Album {
    			Title=
    			IsExplicit=
    			ReleaseDate=
    			BandId= band.Id    }

    		Add the Album to the table of Albums
    			context.Albums.Add(newAlbum);
    			context.SaveChanges();

    	IF (Song)
    		Ask the user which Album they want to add the Song to
    		Read the answer and set it to a variable (albumChosen)
    		var album = context.Albums.First(album => album.Title == “albumChosen”);

    		Ask the user what is the Title of the Song
    		Read the answer and set it to a variable
    		Ask the user how long the Song is
    		Read the answer and set it to a variable
    		Ask the user what Track Number is the Song on the Album
    		Read the answer and set it to a variable (int.Parse)

    			IF (answer is already taken)
    				Don’t add the Song to the Album
    			IF (answer is not taken)
    				Make a new instance of an Album (using the answers)
    					var newAlbum = new Album {
    					Title=
    					Duration=
    					TrackNumber=
    					AlbumId= album.Id    }

    				Add the Song to the table of Songs
    					context.Songs.Add(newSong);
    					context.SaveChanges();

IF (View)
Ask the user if they want to view all the Bands, view all the Albums, or view Albums by a Specific Band (Possible Menu Options)
Read the answer and set to a variable
IF (Bands)
foreach(var band in context.Bands)
Print out all the Bands

    	IF (Albums)
    		var albumsInOrder = albums.OrderBy(album => album.ReleaseDate);
    		foreach (var album in albumsInOrder)
    			Print out all the Albums

    	IF (Specific)
    		Ask the user which Band they want to look up
    		Read the answer and set it to a variable
    		foreach (var album in context.Albums.Include(bands => band.Name == “answer”)
    			Print out the albums for a Specific Band

IF (Contract Change)
Ask the user if they want to Release a Band from their Contract or Resign a Band
Read the answer and set it to a variable
IF (Release)
Ask the user what Band do they want to Release from their Contract
Read the answer and set it to a variable
var existingBand = context.Bands.FirstOrDefault(band => band.Name == “answer”);
IF (existingBand == null)
Print out couldn’t find the band
ELSE
Print out Ending the Contract with (answer)
existingBand.IsSigned = false;
context.SaveChanges();

    	IF (Resign)
    		Ask the user what Band do they want to Resign to the Company
    		Read the answer and set it to a variable

    		var existingBand = context.Bands.FirstOrDefault(band => band.Name == “answer”);
    			IF (existingBand == null)
    				Print out couldn’t find the band
    			ELSE
    				Print out Resigning the Contract with (answer)
    				existingBand.IsSigned = true;
    				context.SaveChanges();

IF (Current Clients)
var bandsSigned = bands.Where(band => band.IsSigned == true);
foreach (var band in bandsSigned)
Print out all the currently signed bands
var bandsNotSigned = bands.Where(band => band.IsSigned == false);
foreach (var band in bandsNotSigned)
Print out all the bands not currently signed

IF (Quit)
set Bool = true;

Say GoodBye
