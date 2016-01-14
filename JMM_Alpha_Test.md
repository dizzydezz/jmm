# JMM Release Notes and Instructions #




http://jmmanager.wordpress.com/support/installation-and-setup-2/


## Change Log ##

### Version 3.4.1 ###

  * Proper Error handling on UI threads to prevent JMM Desktop crashing

### Version 3.3.32.5 ###

  * Fixed bug in Date Serialization (Broke Android version)
  * Updated SQLite libraries to .NET 4.5
  * Adding caching to group retrievals. (Group retrievals are blazing fast now).
  * Fixed About Requester bug

### Version 3.3.32.4 ###

  * SmartTV Support. (There is some limitation on embedded subtitles, please check https://forums.plex....samsung-client/ )
  * Updated back framework from 3.5 to 4.5. httplistener seems to be bandwidth limited on external ips, on 3.5.
  * Updated mediainfo.dll to the lastest version 0.7.67.0

### Version 3.3.32.3 (December 28 2013) ###

  * [Issue #473](https://code.google.com/p/jmm/issues/detail?id=#473).
  * Added support for Plex Media Server
  * Upgraded mediainfo.dll to latest version.
  * Added support to Plex Home Theater. (Direct Play, support for HEAD and OPTIONS verb in http, ip redirection)
  * Added Support for Http Range to File Streaming.

### Version 3.1.32 (June 3 2013) ###

  * [Issue #192](https://code.google.com/p/jmm/issues/detail?id=#192): Multiple tvdb links for series
  * [Issue #423](https://code.google.com/p/jmm/issues/detail?id=#423): JMM Desktop Nyaa torrent search is not working
  * Search in JMM Desktop now allows up to 100 results (instead of 40)
  * Search in JMM Desktop now allows a choice between searching by title only and by everything (title, category, tag)
  * [Issue #388](https://code.google.com/p/jmm/issues/detail?id=#388): Missing Episodes - Additional Filter - Currently Airing
  * Prevent ping command from being issued while JMM Server is still waiting on a response from AniDB udp api
  * Show visual indicator of AniDB udp communications activity on JMM Server window
  * Better handling for AniDB Errors  506 (Invalid Session) and 505 (illegal Input)
  * Better handling for AniDB Errors  600, 601, 602 and 604 - Pause for extended period when AniDB is not responding
  * [Issue #432](https://code.google.com/p/jmm/issues/detail?id=#432): Auto setting files to watched in latest MPC is no longer working
  * [Issue #418](https://code.google.com/p/jmm/issues/detail?id=#418): Rating star count on mouseover
  * Continue Watching (windows/widgets) In JMM Desktop and MyAnime3 is now based of a system created Group Filter which the user can customise.
  * [Issue #433](https://code.google.com/p/jmm/issues/detail?id=#433): Double episodes showing as missing in JMM Desktop
  * [Issue #434](https://code.google.com/p/jmm/issues/detail?id=#434): After hashing files some files don't exist
  * [Issue #437](https://code.google.com/p/jmm/issues/detail?id=#437): Support for MediaPortal 1.4 (convert ToggleButtons to CheckButtons)
  * Fix font heading issues in Titan skin in MyAnime3
  * Dropped support for Mustayaluca skin in MyAnime3
  * [Issue #438](https://code.google.com/p/jmm/issues/detail?id=#438): Issue with PlayCurrentThumb in MediaPortal

### Version 3.1.31 (Januray 29 2013) ###

  * Fix for JMM Server importer failing when trying to scan system folders

### Version 3.1.30 () ###

  * MyAnime3: Support for Titan skin
  * MyAnime3: Support for MP 1.3
  * MyAnime3: Fix wide banners not dsiplaying

### Version 3.1.29 (January 10 2013) ###

  * More fixes to MAL searching

### Version 3.1.28 (January 9 2013) ###

  * File Renamer: Make sure VideoInfo record is use for Resolution on manually linked files
  * [Issue #366](https://code.google.com/p/jmm/issues/detail?id=#366): Metro dash doesn't hide anime correctly
  * [Issue #370](https://code.google.com/p/jmm/issues/detail?id=#370): JMM Desktop crashes when rating a series after watching last episode
  * [Issue #368](https://code.google.com/p/jmm/issues/detail?id=#368): Non-existing unrecognized file cannot be deleted
  * [Issue #212](https://code.google.com/p/jmm/issues/detail?id=#212): The "new series" dialog in the unrecognised files utility is confusing at first
  * Hasher.dll now runs at low priority, to make system more responsive when multi-tasking  (thanks a lot gibwar)
  * [Issue #369](https://code.google.com/p/jmm/issues/detail?id=#369): Various File renamer problems
  * [Issue #363](https://code.google.com/p/jmm/issues/detail?id=#363): File Renamer - two news tests for manually linked files, and checking if a file has any episodes attached
  * Fix issue with MyAnimeList search and associations
  * Better handling of multiple folder creation events for watched import folders

### Version 3.1.26 (December 21 2012) ###

  * Make sure that the 'Remove Missing Files' utility also updates the user's AniDB MyList
  * [Issue #138](https://code.google.com/p/jmm/issues/detail?id=#138): Option for JMM Server to change state to deleted rather than removing files from MyList when deleted from HDD
  * Cache some AniDB info for use during file imports to prevent chances of a ban
  * Log all API calls to AniDB into a new database table for debugging when a ban occurs
  * [Issue #352](https://code.google.com/p/jmm/issues/detail?id=#352): Slightly off-resolution files will now be grouped together, e.g. 1272x720 will be shown in same group as 1280x720
  * [Issue #176](https://code.google.com/p/jmm/issues/detail?id=#176): Empty folders are deleted from the drop folder automatically
  * [Issue #359](https://code.google.com/p/jmm/issues/detail?id=#359): Subtitle files are now moved from drop folder along with video file
  * File Renamer - test that Video Resolution info exists now works - I(res)
  * Fix to make sure duplicate files entries where the file name is actually the same are removed

### Version 3.1.25 (December 12 2012) ###

  * [Issue #354](https://code.google.com/p/jmm/issues/detail?id=#354): Autolink settings are lost, TVDB info keeps populating
  * [Issue #338](https://code.google.com/p/jmm/issues/detail?id=#338): Support PotPlayer for marking files as watched
  * [Issue #355](https://code.google.com/p/jmm/issues/detail?id=#355): Crashing if "User" button is clicked

### Version 3.1.24 (December 10 2012) ###

  * File Renaming - make sure CRC's from local file info is used properly
  * [Issue #349](https://code.google.com/p/jmm/issues/detail?id=#349): Missing episodes utility- add release group to column options
  * [Issue #346](https://code.google.com/p/jmm/issues/detail?id=#346): File summary in JMM Desktop was showing double episodes as missing
  * [Issue #332](https://code.google.com/p/jmm/issues/detail?id=#332): When user is banned show whether ban is because of the HTTP or UDP API.
  * [Issue #336](https://code.google.com/p/jmm/issues/detail?id=#336): Votes shows up as 0.00 when sync'ing votes on systems where language is not English

### Version 3.1.23 (November 28 2012) ###

  * Delete entries from database for posters, fanart and banners which no longer exist on TvDB
  * Greater control over which images and how many are downloaded for Characters, Creators, Trakt, TvDB and MovieDB
  * [Issue #304](https://code.google.com/p/jmm/issues/detail?id=#304): Ability to limit the amount of wide-banner and posters automatically downloaded
  * [Issue #306](https://code.google.com/p/jmm/issues/detail?id=#306): Prevent character/creator images being download when they are not required
  * [Issue #340](https://code.google.com/p/jmm/issues/detail?id=#340): Ability to play a file from Utilities - Unrecognised, Manually Linked, Ignored and Duplicates
  * Better handling to make sure a file is marked watched when the file was not added to AniDB originally.
  * [Issue #297](https://code.google.com/p/jmm/issues/detail?id=#297): Manual linked file do not get updated when real AniDB file info exists

### Version 3.1.22 (November 19 2012) ###

  * Fix web cache not being used for tvdb/mal and trakt in some cases
  * Fix performance of new episodes section on Metro dashboard for sqlite
  * Database performance optimisations

### Version 3.1.21 (November 12 2012) ###

  * [Issue #331](https://code.google.com/p/jmm/issues/detail?id=#331): JMM Desktop: delete files not working
  * Add a refresh button for trakt shouts/anidb recommendations in Metro dashboard
  * [Issue #314](https://code.google.com/p/jmm/issues/detail?id=#314): Ignored Files Sorted Alphabetically
  * [Issue #309](https://code.google.com/p/jmm/issues/detail?id=#309): Fanart changes in MA3 when moving the mouse
  * [Issue #324](https://code.google.com/p/jmm/issues/detail?id=#324): Continue Watching in MA3 and JMM desktop not respecting user categories
  * Fix incorrect categories/genres being returned for an anime, and fix sorting to display in correctly weighted order
  * More fixes to normal dashboard
  * Make sure that Picture is updated for seiyuus when the anime data is updated

### Version 3.1.19 (October 19 2012) ###

  * JMM Desktop - [Issue #296](https://code.google.com/p/jmm/issues/detail?id=#296): Variations exists on Anime Files, add Mark as variation in Multiple files
  * JMM Desktop - [Issue #295](https://code.google.com/p/jmm/issues/detail?id=#295): Utilities - Multiple Files (Enable delete Manual-Links and No Group Info series)
  * JMM Desktop - [Issue #69](https://code.google.com/p/jmm/issues/detail?id=#69): Toolbar for episode list always stays at the top
  * [Issue #170](https://code.google.com/p/jmm/issues/detail?id=#170): watched folders not working
  * JMM Desktop - [Issue #312](https://code.google.com/p/jmm/issues/detail?id=#312): Unrecognized Files Sorted Alphabetically
  * JMM Desktop - Toolbar on dashboard always stays at the top
  * JMM Desktop - Toolbar on Series will no longer be cut off in a smaller window
  * JMM Desktop - Episode List loads much more quickly for series with large number of episodes
  * JMM Desktop - Episode List - scroll wheel now works
  * JMM Desktop - Much improved memory usage for series with large number of episodes
  * JMM Desktop - Images tab loads much more quickly for series with large number of images
  * JMM Desktop - More consistent display of images on dashboard
  * JMM Desktop - Fix server image download icon and queue count
  * Various performance improvements for sqlite and mysql
  * Add recommendations from AniDB Users to Series display on Metro Dashboard
  * Allow JMM Desktop to run in Full Screen mode
  * Minor Metro dashboard changes - Mouse wheel now works, Display loading status for what people are saying, large scroll bars

### Version 3.1.18 (October 12 2012) ###

  * File Renamer - will always pad episode number with a zero, where the episode number is less than 10
  * Workaround for performance issue in Utilities - Multiple files when using MySQL
  * Alternative metro themed dashboard (beta)
  * Close window for multiple videos on an episode when user plays a video
  * New Utility - My Votes: view all your votes in one screen

### Version 3.1.17 (September 18 2012) ###

  * Improved performance getting groups in MyAnime3 (especially with larger collections)
  * Improved auto grouping of series, by only using some relationship types
  * Fixed detection of missing of 'missing episodes' for movies
  * [Issue #284](https://code.google.com/p/jmm/issues/detail?id=#284): Auto login to JMM Desktop using last user (only where password is blank)
  * [Issue #282](https://code.google.com/p/jmm/issues/detail?id=#282): Stop reloading of playlists in JMM Desktop every time you switch tabs
  * [Issue #288](https://code.google.com/p/jmm/issues/detail?id=#288): File renamer doesn't work for manually linked files

### Version 3.1.14 () ###

  * Fix hashing of files under 9MB
  * [Issue #278](https://code.google.com/p/jmm/issues/detail?id=#278): Bug in ED2K Calculation when hasher.dll not found
  * [Issue #262](https://code.google.com/p/jmm/issues/detail?id=#262): Options for Multiple Files utility
  * Multiple files utility no longer automatically loads data when you first click on it
  * [Issue #263](https://code.google.com/p/jmm/issues/detail?id=#263): Options for viewing and sorting file summary for an anime
  * Fix issue in auto setting files to watched with MPC, when user completely watches the file
  * Added support to JMM Desktop to send multiple episodes to a playlist file (.pls) and open in the default windows association. Supported in Continue Watching widget on dashboard, and Playlists tab
  * Added the option to automatically play one file based on user settings, when an episode has more than one file available
  * [Issue #270](https://code.google.com/p/jmm/issues/detail?id=#270): File renaming Episode test NOT operator seems buggy
  * [Issue #274](https://code.google.com/p/jmm/issues/detail?id=#274): Ability to rename entire collection
  * Allow white space in between tests for file renamer
  * Add missing episodes control as another tab in downloads
  * [Issue #269](https://code.google.com/p/jmm/issues/detail?id=#269): Add recommended anime to downloads
  * [Issue #276](https://code.google.com/p/jmm/issues/detail?id=#276): Support for Animebyt.es in downloads
  * Fix handling of torrent search results from Nyaa, when only one result is returned
  * [Issue #267](https://code.google.com/p/jmm/issues/detail?id=#267): Combine tv sources on file summary (DTV, HDTV and www are now just shown as TV)
  * [Issue #266](https://code.google.com/p/jmm/issues/detail?id=#266): Fix delete button on file summary

### Version 3.1.13 (August 16 2012) ###

  * [Issue #260](https://code.google.com/p/jmm/issues/detail?id=#260): MP Plugin does not Play files

### Version 3.1.12 (August 14 2012) ###

  * New utility to update local AniDB File data with a fresh copy from AniDB
  * [Issue #253](https://code.google.com/p/jmm/issues/detail?id=#253): New Scheduled task: update anidb file info
  * File Renaming: add censored tag and associated test
  * File Renaming: add deprecated tag and associated test
  * Added button to refresh series information when pinned
  * Added the option to automatically mark a file as watched in JMM Desktop when you watch a certain percentage (Configured via a new 'Video Player' setting page, only Media Player Classic is currently supported)

### Version 3.1.11 (August 9 2012) ###

  * File renaming is now enabled
  * [Issue #247](https://code.google.com/p/jmm/issues/detail?id=#247): Added two new tests for file renaming: Video Resolution Width and Video Resolution height
  * File renaming replacement change: if video resolution info does not exist in AniDB data try the MediaInfo generated data instead
  * File renaming: add tag for original file name by release group
  * File renaming: allow a rename script to be set as the default for automatic renaming when a file is added to the collection
  * [Issue #244](https://code.google.com/p/jmm/issues/detail?id=#244): Clear queue button for each of the operations in JMM Desktop and Server

### Version 3.1.9 (August 6 2012) ###

  * [Issue #238](https://code.google.com/p/jmm/issues/detail?id=#238): Year isn't always shown correctly in MyAnime3 and JMM Desktop
  * [Issue #237](https://code.google.com/p/jmm/issues/detail?id=#237): Single-series group displays group name instead of series name (MyAnime3)
  * When renaming a series in JMM Desktop it will also ask you if you want to apply changes to the parent group as well.
  * [Issue #239](https://code.google.com/p/jmm/issues/detail?id=#239): Option to only have one instance of JMM Server
  * Implement missing relations window for mustayaluca skin
  * Beginnings of file renaming functionality

### Version 3.1.8 (July 23 2012) ###

  * [Issue #123](https://code.google.com/p/jmm/issues/detail?id=#123): Button to view log file directory
  * [Issue #229](https://code.google.com/p/jmm/issues/detail?id=#229): JMM Server : bad link in MyAnime2 Migration tab
  * [Issue #228](https://code.google.com/p/jmm/issues/detail?id=#228): Option to scan drop folders on startup
  * Get and store FileVersion for files from AniDB e.g. v1 or v2
  * Show File Version in information for files in JMM Desktop
  * [Issue #233](https://code.google.com/p/jmm/issues/detail?id=#233): When renaming a series make sure that the new name shows up in searches in JMM Desktop
  * [Issue #210](https://code.google.com/p/jmm/issues/detail?id=#210): New utility in JMM Desktop to allow the search of files by Hash, File Name or simply Last 100 files added to collection

### Version 3.1.6 (June 21 2012) ###

  * [Issue #215](https://code.google.com/p/jmm/issues/detail?id=#215): Hover info for related or similar anime goes away.
  * [Issue #220](https://code.google.com/p/jmm/issues/detail?id=#220): Show a tooltip to explain the anime details shown in the downloads tab
  * Fix issue with parsing of torrents from BakaBT
  * [Issue #207](https://code.google.com/p/jmm/issues/detail?id=#207): Double clicking on an episode in the episode tab should play the episode.
  * [Issue #188](https://code.google.com/p/jmm/issues/detail?id=#188): Make download button on episodes optional

### Version 3.1.5 (June 4 2012) ###

  * Fix for JMM Server not starting properly when minimized

### Version 3.1.4 (May 29 2012) ###

  * [Issue #198](https://code.google.com/p/jmm/issues/detail?id=#198): Make sure JMM Server cache is updated when MAL or TvDB links are removed
  * [Issue #196](https://code.google.com/p/jmm/issues/detail?id=#196): Make wiki link for explanation of Import Folders more obvious
  * Fix problems with parsing ratings in some languages (notably french)
  * Add a global exception handler to log unexpected exceptions
  * [Issue #201](https://code.google.com/p/jmm/issues/detail?id=#201): JMM Server ignoring maximum amount of fanarts set by user
  * [Issue #25](https://code.google.com/p/jmm/issues/detail?id=#25): Reinstate the FFDShow Helper and post processing options from MA2
  * [Issue #190](https://code.google.com/p/jmm/issues/detail?id=#190): Option to minimize JMM Server to tray on start up
  * [Issue #203](https://code.google.com/p/jmm/issues/detail?id=#203): Option for a series not to pick up TvDB recommendations

### Version 3.1.3 (May 7 2012) ###

  * [Issue #184](https://code.google.com/p/jmm/issues/detail?id=#184): Only download images for clients as they are needed
  * [Issue #189](https://code.google.com/p/jmm/issues/detail?id=#189): Incorrect hash calculations
  * Added ability to view hash/crc/sha/md5 information for a file in the episode list and re-hash the file
  * Added exception handling to start up of MA3 to log errors

### Version 3.1.2 (May 1 2012) ###

  * Remove any VideoLocal records which don't have a valid import folder during the import

### Version 3.1.0 (Apr 30 2012) ###

  * Fix bug in the importer integrity check

### Version 3.0.45 (Apr 24 2012) ###

  * [Issue #182](https://code.google.com/p/jmm/issues/detail?id=#182): Video not showing in skins when not full screen
  * Add support for BakaBT in MyAnime3

### Version 3.0.44 (Apr 19 2012) ###

  * Fixed toggling of watched status on Random Episode window
  * Fixed bug which stopped user being able to create new group filters
  * [Issue #180](https://code.google.com/p/jmm/issues/detail?id=#180): Support for BakaBT as a torrent source (authenticated)
  * Add support to remove torrents from torrent monitor
  * Allow easier toggling of torrent sources when searching for a torrent
  * Allow user to select multiple torrents in uTorrent monitor to perform actions on.

### Version 3.0.43 (Apr 17 2012) ###

  * [Issue #177](https://code.google.com/p/jmm/issues/detail?id=#177): Port uTorrent functionality from MA3 to JMM Desktop
  * [Issue #175](https://code.google.com/p/jmm/issues/detail?id=#175): Link to web platform installer for MSSQL on JMM Server setup to make it easier to install
  * [Issue #173](https://code.google.com/p/jmm/issues/detail?id=#173): JMM Server not working when firewall is enabled (add firewall exception to installer)
  * Move some code from JMM Desktop start up, to a separate thread after the main window has loaded for slightly better performance
  * Minor performance improvements on dashboard
  * Add buttons to bookmark related and similar anime

### Version 3.0.42 (Apr 10 2012) ###

  * [Issue #158](https://code.google.com/p/jmm/issues/detail?id=#158): New special predefined group filter in JMM/MA3 allowing the user to browse by Year and Category
  * [Issue #160](https://code.google.com/p/jmm/issues/detail?id=#160): Allow Missing Episodes Output to be added to Bookmarks list
  * Fix position of the find text in Avalon skin for MyAnime3
  * [Issue #19](https://code.google.com/p/jmm/issues/detail?id=#19): Support Default skin for MediaPortal
  * [Issue #169](https://code.google.com/p/jmm/issues/detail?id=#169): Support Avallonis skin for MediaPortal
  * Fix the searching text, descriptions in StreamedMP skin
  * [Issue #118](https://code.google.com/p/jmm/issues/detail?id=#118): Fanart version of StreamedMP skin
  * Big performance improvements when using MySQL or Sqlite during imports, or downloading anime information by using bulk inserts
  * Add ability to create series from Calendar in MA3
  * Add ability to bookmark anime from Calendar in MA3 and JMM Desktop
  * Add ability to bookmark anime from Recommended Anime in MA3
  * [Issue #171](https://code.google.com/p/jmm/issues/detail?id=#171): Remove option to download Related and similar anime, they were disabled in the code behind due to potential banning issues
  * Make sure that individual links for an AniDB episode to a TvDB episode are shown in MA3

### Version 3.0.41 (Mar 27 2012) ###

  * Fix sorting by AniDB Rating in MA3
  * [Issue #164](https://code.google.com/p/jmm/issues/detail?id=#164): Avalon skin error - Anime3\_Notification.xml
  * [Issue #163](https://code.google.com/p/jmm/issues/detail?id=#163): Incorrect behaviour when marking all as watched
  * Stop the login window from being top most in JMM Desktop when the app doesn't have focus.
  * [Issue #167](https://code.google.com/p/jmm/issues/detail?id=#167): About screen for JMM Desktop and Server
  * [Issue #166](https://code.google.com/p/jmm/issues/detail?id=#166): Initial setup wizard for JMM Server

### Version 3.0.40 (Mar 23 2012) ###

  * Fix automatic creation of SQL Server 2008 database
  * Handle errors properly when downloading images (causing occasional crash in JMM Desktop)

### Version 3.0.39 (Mar 22 2012) ###

  * Download packages now include an automatic installer (manual install option still available)
  * Automatic updating is available in JMM Server and Desktop

### Version 3.0.38 () ###

  * Add the following option on the MyAnime3 - Continue Watching window - Play previous episode, View Episode List, View Series Info

### Version 3.0.37 (Mar 16 2012) ###

  * Prevent bans by not allowing the same http call to be made more than once every 4 hours
  * Small performance improvements by reducing number of database calls
  * Make sure the series count only shows the amount of series which actually meet the filter criteria

### Version 3.0.36 (Mar 13 2012) ###

  * [Issue #157](https://code.google.com/p/jmm/issues/detail?id=#157): End date on anime not populated properly
  * [Issue #155](https://code.google.com/p/jmm/issues/detail?id=#155): MA3: not marking episode as watched unless you press the stop button
  * Download and save anidb mylist stats locally
  * Fix error with "Has Finished Airing" group filter not working when set to Exclude

### Version 3.0.35 (Mar 09 2012) ###

  * Fix bug where file information was not saved properly for double episodes, causing bans

### Version 3.0.34 (Mar 08 2012) ###

  * Do not show episodes as missing in the report if they have not aired yet
  * JMM Desktop: remember whether episodes or series was selected in Recent Additions widget
  * Make sure to check if a file record exists before creating another one with the same hash
  * [Issue #140](https://code.google.com/p/jmm/issues/detail?id=#140): Seiyuu window in MyAnime3


### Version 3.0.33 (Mar 05 2012) ###

  * Revert back to 1 FILE command every 2 seconds to prevent bans
  * Only download information about related anime during import if the user has chosen to group related series (to prevent bans)

### Version 3.0.32 (Mar 01 2012) ###

  * [Issue #16](https://code.google.com/p/jmm/issues/detail?id=#16): MyAnime3 - From context menu add functions to play random episode/ play next unwatched episode - on group filters, groups and series

### Version 3.0.31 (Feb 27 2012) ###

  * Fix the broken refresh button on the JMM Desktop dashboard
  * [Issue #51](https://code.google.com/p/jmm/issues/detail?id=#51): Link individual episodes to TvDB episodes
  * Fix issue with wrong TvDB details being displayed for some series, due to episodes being deleted from TvDB, but not locally

### Version 3.0.30 (Feb 24 2012) ###

  * Ask user for confirmation before running the "Remove Missing Files" process.
  * Don't show the missing episode icon in the episode list, if the episode hasn't aired yet
  * Performance improvements for MySQL

### Older Updates ###

#### Version 3.0.29 (Feb 23 2012) ####

  * Make sure to really handle imports from a root drive
  * Allow the user to select the columns available in the missing episodes export

#### Version 3.0.28 (Feb 22 2012) ####

  * Make sure that the collection tab is highlighted when the user clicks on a tag or category
  * Marking episodes and files as watched, where multiple files make up one episode now works
  * Make the search bar available from main collection tab - searching will auto navigate to ALL filter and perform search
  * [Issue #151](https://code.google.com/p/jmm/issues/detail?id=#151): New JMM Desktop widget for latest additions
  * Handle access permission errors when importing files, common when an import folder is the root drive

#### Version 3.0.27 (Feb 17 2012) ####

  * Fix show pinned series button on related series
  * [Issue #149](https://code.google.com/p/jmm/issues/detail?id=#149): Allow double clicking on series for a group
  * Reduce delay for AniDB FILE command from 2 seconds to 1 second.
  * [Issue #111](https://code.google.com/p/jmm/issues/detail?id=#111): To download list / bookmark list
  * Make sure scanning an import folder only processes new files

#### Version 3.0.26 (Feb 14 2012) ####

  * [Issue #104](https://code.google.com/p/jmm/issues/detail?id=#104): Per Series Option of Title in Romanji/English regardless of defaults
  * Automatically select the "All" group filter the first time you go to the Collection tab
  * [Issue #136](https://code.google.com/p/jmm/issues/detail?id=#136): Mass avdump utility

#### Version 3.0.24 (Feb 8 2012) ####

  * Handle corrupt data during MyAnime2 migration properly
  * Add button to play a random episode from group filter, group and series

#### Version 3.0.24 (Feb 7 2012) ####

  * View Random series from group filters in the collection tab
  * [Issue #146](https://code.google.com/p/jmm/issues/detail?id=#146): Only refresh continue watching widget when marking an episode watched on Dashboard
  * [Issue #139](https://code.google.com/p/jmm/issues/detail?id=#139): Option to update AniDB file info. Useful when a file is moved from one series/episode to another on AniDB
  * [Issue #144](https://code.google.com/p/jmm/issues/detail?id=#144): Manual linking bug
  * [Issue #145](https://code.google.com/p/jmm/issues/detail?id=#145): Show more details for queues on server tab in JMM desktop
  * [Issue #141](https://code.google.com/p/jmm/issues/detail?id=#141): Changes to MAL api to include download episode count and fansub groups
  * Make sure vote is updated on MAL when the user votes.
  * Make sure all series are reflected on MAL anime list, not just the series where an episode has been watched
  * Update MAL anime status any time a new file has been added
  * Make sure MAL statuses of On Hold and Dropped are not over-written

#### Version 3.0.23 ####

  * Playlists support for SQLite and MySQL
  * Fixed bug when filtering by video quality
  * JMM Desktop and Server now display when a new version is available

#### Version 3.0.22 ####

  * New Playlists tab in JMM Desktop
  * [Issue #135](https://code.google.com/p/jmm/issues/detail?id=#135): Update MAL when the user creates a link
  * [Issue #134](https://code.google.com/p/jmm/issues/detail?id=#134): Avalon skin - only show unwatched counts in lists
  * [Issue #133](https://code.google.com/p/jmm/issues/detail?id=#133): Avalon skin - option in installer to use same layout as mp-tvseries
  * [Issue #137](https://code.google.com/p/jmm/issues/detail?id=#137): Group filters which sort by AniDB Rating cause MP to crash
  * [Issue #20](https://code.google.com/p/jmm/issues/detail?id=#20): Default Wide skin

#### Version 3.0.21 ####

  * [Issue #34](https://code.google.com/p/jmm/issues/detail?id=#34): Re-grouping of series utility
  * [Issue #132](https://code.google.com/p/jmm/issues/detail?id=#132): Options to show shouts/scrobbles in Trakt Activity widget
  * Attempt to fix incorrect values in voting

#### Version 3.0.20 ####

  * Allow user to adjust the size of fanart/poster on series/group view
  * Swap position of overview and play next episode on series display
  * Can now upload/download watched states to/from MyAnimeList
  * [Issue #117](https://code.google.com/p/jmm/issues/detail?id=#117): new group filter: number of episodes
  * [Issue #27](https://code.google.com/p/jmm/issues/detail?id=#27): Pressing the play button in MA3, when highlighting a group/series should play the next episode
  * Add option to get AniDB file data from web cache

#### Version 3.0.19 ####

  * [Issue #119](https://code.google.com/p/jmm/issues/detail?id=#119): jmm desktop crash on dashboard
  * Search and link AniDB to MyAnimeList
  * New group filter - MyAnimeList Link Missing
  * Option to display fanart image instead of posters on a series
  * Episode overviews and Series descriptions are now expanded by directly clicking on them
  * [Issue #124](https://code.google.com/p/jmm/issues/detail?id=#124): Shorten episode names in Trakt activity to max 30 characters
  * [Issue #120](https://code.google.com/p/jmm/issues/detail?id=#120): File Sizes are Not Updated on Re-Scan
  * Layout changes to viewing a series
  * Add a link to MAL fro external series links
  * [Issue #125](https://code.google.com/p/jmm/issues/detail?id=#125): Trakt shouts not refreshing properly
  * [Issue #122](https://code.google.com/p/jmm/issues/detail?id=#122): Allow user to modify episode type and number on MAL link
  * Force re-connection to AniDB on "598 Unknown Command" to prevent being banned
  * [Issue #129](https://code.google.com/p/jmm/issues/detail?id=#129) - Disable Trakt images by default since they are exactly the same as TvDB
  * Change logging of image download fails to warnings instead of errors
  * [Issue #126](https://code.google.com/p/jmm/issues/detail?id=#126): Show Fanart/Poster on group view

#### Version 3.0.18 ####

  * [Issue #90](https://code.google.com/p/jmm/issues/detail?id=#90): Add a JMM widget to view watched history
  * Show tooltips on dashboard widgets for longer
  * [Issue #114](https://code.google.com/p/jmm/issues/detail?id=#114): Suggest to use to download votes if recommendations is empty
  * When sync'ing votes from AniDB, download the anime information if the user doesn't have it yet
  * [Issue #86](https://code.google.com/p/jmm/issues/detail?id=#86): Allow watching for new files to be set on specific folders
  * [Issue #28](https://code.google.com/p/jmm/issues/detail?id=#28) - (JMM/MA3) After finishing watching a series, pop a rating dialog
  * Include an MPEI file (MP installer) for MyAnime3

#### Version 3.0.17 ####

  * [Issue #102](https://code.google.com/p/jmm/issues/detail?id=#102): Deleting files from series view picking up wrong files
  * [Issue #92](https://code.google.com/p/jmm/issues/detail?id=#92): Log settings and version in JMM Server
  * [Issue #93](https://code.google.com/p/jmm/issues/detail?id=#93): Log settings and version in JMM Desktop
  * Fix issue where files had { or } in them
  * [Issue #115](https://code.google.com/p/jmm/issues/detail?id=#115): Make sure all text stays visible when item is selected on any of the dashboard widgets
  * Show links to Trakt for shows and episodes in the Trakt activity widget on the dashboard
  * [Issue #110](https://code.google.com/p/jmm/issues/detail?id=#110): add mpeg, mpeg to default supported videos
  * [Issue #106](https://code.google.com/p/jmm/issues/detail?id=#106): After accepting Trakt friend request it doesn't vanish
  * Allow the user to force refresh the Trakt activity widget on the Dashboard
  * [Issue #108](https://code.google.com/p/jmm/issues/detail?id=#108): Unable to Favorite Series with ease, have to go to group to favorite it
  * [Issue #113](https://code.google.com/p/jmm/issues/detail?id=#113) - Make voting default to permanent for completed series and user has watched all the episodes
  * [Issue #112](https://code.google.com/p/jmm/issues/detail?id=#112): In MyAnime3 when a group has a default series it will now also use the description as well as the images
  * [Issue #97](https://code.google.com/p/jmm/issues/detail?id=#97): Remove URLs from anidb series descriptions
  * [Issue #103](https://code.google.com/p/jmm/issues/detail?id=#103): Log database version to jmm server log file

#### Version 3.0.16 ####

  * [Issue #101](https://code.google.com/p/jmm/issues/detail?id=#101) - Get user to select the season when searching for a TvDB or Trakt link
  * Show Trakt shouts on a series, and allow the user to post a shout.
  * [Issue #100](https://code.google.com/p/jmm/issues/detail?id=#100) - Shows series link in Trakt activity
  * Show shouts on shows in Trakt activity

#### Version 3.0.15 ####

  * Make sure episodes are only scrobbled on Trakt when the user manually marks an episode/file as watched in JMM Desktop
  * [Issue #99](https://code.google.com/p/jmm/issues/detail?id=#99): Watch for files picks up non video files
  * [Issue #96](https://code.google.com/p/jmm/issues/detail?id=#96): If you add a file to your collection, where the episode has been watched before, the series watched date still gets updated
  * Show shouts from Trakt in a new tab on the Series view in JMM Desktop
  * Various MySQL Schema fixes

#### Version 3.0.14 ####

  * Logging errors properly on MyAnime2 migration
  * Change the trakt activity widget to show all activity rather than just the last action for a friend
  * Shouts from friends are now shown in the trakt activity widget
  * Disabled download of reviews until they are ready to be displayed
  * Don't try to get Trakt friend info, if the user hasn't entered any credentials

#### Version 3.0.13 ####

  * [Issue #75](https://code.google.com/p/jmm/issues/detail?id=#75): TvDB data is not being downloaded when an anime is first linked to a TvDB show
  * Allow user to update all AniDB series information from the Server window
  * JMM Server will now automatically create the database as in line with other database types
  * Provide a browse for folder prompt when adding/editing import folders in JMM Server
  * Fix issue where Trakt friend avatars were being deleted when JMM desktop and server shared the same base image path
  * [Issue #76](https://code.google.com/p/jmm/issues/detail?id=#76): Categories/Genres not scrolling in StreamedMP

#### Version 3.0.12 ####

  * On starting JMM Server the first the time, the user is prompted to select a database type
  * [Issue #82](https://code.google.com/p/jmm/issues/detail?id=#82) - JMM Desktop Password on login is now hidden
  * [Issue #82](https://code.google.com/p/jmm/issues/detail?id=#82): Hide all passwords on screen, and hash/encrypt them when storing in the database
  * [Issue #79](https://code.google.com/p/jmm/issues/detail?id=#79): Allow user to choose root folder for storage of images
  * [Issue #79](https://code.google.com/p/jmm/issues/detail?id=#79): JMM Desktop and JMM Server can now point to the same images folder so that separate copies are no longer needed.

#### Version 3.0.11 ####

  * Fixed issue when switching Trakt season in JMM Desktop
  * Fixed issue with errors in getting Trakt friend activity
  * Allow user to create a Trakt account from the activity feed if they haven't entered any credentials yet
  * [Issue #60](https://code.google.com/p/jmm/issues/detail?id=#60) - Allow user to view friend requests, approve or deny in Trakt activity feed
  * Make sure user cannot link more than anime to a Trakt or TvDB identifier (show id and season number)
  * [Issue #68](https://code.google.com/p/jmm/issues/detail?id=#68) - Now supporting MySQL databases

#### Version 3.0.10 ####

  * Added utility so that user can re-read the media information for all video files
  * Make sure that pressing the "Sync Trakt" button on JMM Server always runs rgeardless of scheduled sync settings
  * Display an indicator when a file is 10bit/Hi10P
  * Sort videos by best video quality when viewing files for an episode on episode list and multiple files utility.
  * Fixed bug in display of file summary where episode number list was not showing some times
  * Display video bit depth in the following places
    * File summary on downloads window when searching for an Episode
    * File prompt when playing an episode with more than one file

#### Version 3.0.9 ####

  * Allow user to customise the delay time when display group info and fanart in MA3
  * Prevent updating of stats twice when a user marks an episode as Watched
  * Prevent all episodes being updated when the using the "Mark all previous episodes as watched"
  * [Issue #2](https://code.google.com/p/jmm/issues/detail?id=#2): Performance - Takes too long to watch 100+ episodes as watched
  * [Issue #63](https://code.google.com/p/jmm/issues/detail?id=#63): Scan drop folder from Uitlities in MA3
  * Get Bit Depth (8/10 bit) when reading media info

#### Version 3.0.8 ####

  * [Issue #64](https://code.google.com/p/jmm/issues/detail?id=#64): Allow import of manually linked files from MA2
  * [Issue #65](https://code.google.com/p/jmm/issues/detail?id=#65): User permissions to include settings editing
  * [Issue #66](https://code.google.com/p/jmm/issues/detail?id=#66): Show fanart for trakt activity where the episode screenshot is not available

#### Version 3.0.7 ####

  * Make sure to include missing hasher.dll for much faster hashing
  * Queue status counts/icons were not showing in MyAnime3
  * [Issue #62](https://code.google.com/p/jmm/issues/detail?id=#62): Continue watching, long series name, overlaps the Ep n - Ep title
  * Finished StreamedMP skin

#### Version 3.0.6 ####

  * [Issue #54](https://code.google.com/p/jmm/issues/detail?id=#54): New files being added as in DVD always
  * [Issue #57](https://code.google.com/p/jmm/issues/detail?id=#57): Trakt should only scrobble not mark as seen as well.

#### Version 3.0.5 ####

  * [Issue #55](https://code.google.com/p/jmm/issues/detail?id=#55): Allow user to configure ports on JMM Server
  * [Issue #56](https://code.google.com/p/jmm/issues/detail?id=#56): Allow quick sort in MA3 to ascending or descending

#### Version 3.0.4 ####

  * Fixed issue with JMM Desktop not working on some PC's

#### Version 3.0.3 ####

  * [Issue #49](https://code.google.com/p/jmm/issues/detail?id=#49) - Add quick sorting options in MA3
  * Fix watched stats always showing as 1