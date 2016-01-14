# Developer Notes #

Notes for developers about how OMM Server works and why



## Prerequisites for Developers ##

  * Microsoft Visual Studio 2010 (.NET Framework 3.5) - OMM Server
  * Microsoft Visual Studio 2010 (.NET Framework 4) - Windows Client
  * Fluent Nhibernate
  * SQL Server 2008 Express

## Key Differences from Anime2 ##

## AnimeGroup, Series and Episodes ##

### AnimeGroup ###

AnimeGroup is a simple mechanism which enables the user to group animes in whatever way they want (hierarchical)<br>
The typical usage would be to group animes which are related as defined on AniDB, and OMM Server will use this behaviour by default<br>

One difference of OMM Server versus MyAnime2, is that we now allow groups within groups. This is done via creating a new AnimeGroup record and populating the AnimeGroupParentID field<br>

A typical usage for this might look like the following<br><br>
Gundam <i>AnimeGroup</i>
<ul><li>Gundam 00 <i>AnimeGroup</i>
<ul><li>Mobile Suit Gundam 00 S1 <i>AnimeSeries</i>
</li><li>Mobile Suit Gundam 00 S2 <i>AnimeSeries</i>
</li></ul></li><li>Gundam SEED <i>AnimeGroup</i>
<ul><li>Gundam SEED <i>AnimeSeries</i>
</li><li>Gundam SEED Destiny <i>AnimeSeries</i>
</li><li>Gundam SEED Destiny Final Plus <i>AnimeSeries</i></li></ul></li></ul>

<h3>AnimeSeries</h3>

In MyAnime2 users had some flexibility in what they could do with AnimeSeries. However it is now just a wrapper around the AniDB_Anime record (this is how it was used 99% of the time anyway).<br><br>
The AniDB_ID field, which links to AniDB_Anime is now mandatory, and must be unique across all AnimeSeries records ie. two AnimeSeries records <b>cannot</b> have the same AnimeID (from AniDB).<br>
When implementing a new database provider this should be enforced at the database level.<br>
<br>
<h3>AnimeEpisode</h3>

This is a similar case to AnimeSeries and is just a wrapper around the AniDB_Episode record.<br>
Again the AniDB_EpisodeID field is now mandatory, and must be unique and enforced at the database level.<br>
Users can no longer create their own AnimeEpisode records manually, instead they must be imported from AniDB<br>
<br>
<h2>Handling of image downloads</h2>

Now that we are allowing multiple clients, downloading of images becomes important. The agreed strategy is for JMM Server to do all the downloading of images from the internet. The clients will then request the images from JMM Server<br>

JMM Server will download images in much the same way as the current MyAnime2 implementation<br>
Images are added to an internal queue to be downloaded. Images are saved to a temporary location first and then moved to the final location once the download is complete<br>

On the client side, when it needs an image it will request it from the server and then save it to a local cache. Subsequent reads will come from the local cache. If an image cannot be found on the server, JMM server should add it to the queue<br>

<h2>Handling of watched states</h2>

The basis of all watched states should originate from the VideoLocal record. This is required because we will allow the user to have a video file which doesn't have a corresponding AniDB_File record ie manually associated files<br>

Common usage scenarios:<br>

User marks an episode as watched.<br>
- Find all the VideoLocal Records and set watched as true<br>
- Find the AniDB_File records and set watched to true (including message to AniDB)<br>
- Mark episode as watched<br>

User plays a video file<br>
- Set watched as true on the VideoLocal record<br>
- Set watched as true on the AniDB_File record (including message to AniDB)<br>
- Mark episode as watched<br>

User marks a file as un-watched<br>
- Set watched as falseon the VideoLocal record<br>
- Set watched as false on the AniDB_File record (including message to AniDB)<br>
- Determine if episode should be set as un-watched. If at least one file is watched, the episode is watched<br>


Updating a file which is a double episode should update both episode records<br><br>
With episodes that are split across multiple files we need to keep those watched statuses held on the file record, so that we only set the episode watched once the last file has been viewed.<br>
This also gives us the chance to automatically play the next file<br>

<h2>VideoLocal</h2>

VideoLocal stores information about one video files<br>
For the sake of simplicity we are going to assume that user has only one copy of each file, and consequently make the Hash field on this table unique.<br>
<br>
<h3>Handling duplicate files</h3>

If the user does have more than one copy a specific file, we obviously need to handle this. So what would happen during the import? <br>

<i>Processing File 1</i><br>
<b>Step 1</b> - The import process picks up file 1<br>
<b>Step 2</b> - It searches the VideoLocal table by file path and network share<br>
<b>Step 3</b> - No record found, so populate basic details<br>
<b>Step 4</b> - Get the hash for the file<br>
<b>Step 5</b> - Check the VideoLocal table for any other records with the same hash<br>
<b>Step 5</b> - None found so save the VideoLocal record<br>
<b>Step 6</b> - Continue other operations<br>

<i>Processing File 2</i><br>
<b>Step 1</b> - The import process picks up file 2<br>
<b>Step 2</b> - It searches the VideoLocal table by file path and network share<br>
<b>Step 3</b> - No record found, so populate basic details<br>
<b>Step 4</b> - Get the hash for the file<br>
<b>Step 5</b> - Check the VideoLocal table for any other records with the same hash<br>
<b>Step 5</b> - Record for file 1 is found, so we delete that record<br>
<b>Step 6</b> - Continue other operations<br>

So the implication is that every time we run the import it is possible that the duplicate files will be re-processed. From the logs the user will be able to see this behaviour and hopefully remove one of the duplicate files<br>
If they don't it will still be fine, as the episode will still have one of the files associated with it.<br>

This behaviour is also needed to handle the situation where a user is moving files around. By deleting the old VideoLocal record we make sure we don't have duplicates. We can also leverage the CrossRef_File_Episode table, so that user does not need to re-hash their files in this scenario.<br>
<br>
<h2>CrossRef_File_Episode</h2>

Stores a reference between an ED2K Hash and an AniDB_Episode<br>
We store the <b>Hash</b> and the <b>FileSize</b>, because this is what enables us to make a call the AniDB UDP API using the FILE command<br><br>
We store the AnimeID so we can download all the episodes from HTTP API (ie the HTTP api call will return the anime details and all the episodes<br><br>
<b>Note 1</b> - It is not directly a link between an AniDB_File record and an AniDB_Episode record, because not all files will appear on AniDB. By just using the Hash, we can always link a users local file to an episode record on AniDB<br>
<b>Note 2</b> - A file can have one to many episodes, and an episode can have one to many files<br>
<b>Note 3</b> -  By storing this information when a user manually associates a file with an episode, we can recover the manual<br>
associations even when they move the files around<br>
<b>Note 4</b> - We can use a combination of the FileName/FileSize to determine the Hash for a file, this enables us to handle the<br>
moving of files to different locations without needing to re-hash the file again<br>
<b>Note 5</b> - Make sure that when a user re-hashes a file we remove the existing record from this table<br>

Uniqueness of this table is determined by the combination of Hash and AniDB Episode ID.<br>
<br>
<h2>Strategy for Importing Files</h2>