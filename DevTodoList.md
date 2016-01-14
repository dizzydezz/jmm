# Developer To Do List #



## Leo - Current work list ##

## MP Plugin ##

## Web Cache ##

## Windows Client ##

Handle folders being moves from one import folder to another as per mpiva's suggestion
http://www.otakumm.com/forums/viewtopic.php?f=11&t=130&start=10<br>

Design for Dashboard<br>
<b>Recently Added</b> - show series/groups that have recently been added to the library<br>
<b>Random Series</b> - picks a random series for you that you havent watched yet but is sitting on your hdd (option to only show complete) You could pick from any genre, or select from a list of genres<br>

Blank poster image<br>

Validation on data entry, especially for settings<br>
<a href='http://weblogs.asp.net/monikadyrda/archive/2009/06/24/wpf-textbox-validation.aspx'>http://weblogs.asp.net/monikadyrda/archive/2009/06/24/wpf-textbox-validation.aspx</a>

<h3>Group Filtering</h3>


<h4>Filters</h4>

Series Count<br>
Studio (Equals, Not Equals)<br>
Release Group (Equals, Not Equals)<br>
<br>


<h3>Series Display Ideas</h3>

Have a new Community tab<br>
- Show links to discuss/forums on various sites<br>
- Reviews<br>
- List of blog posts from Anime Nano<br>

Other Tabs<br>
Show awards< br><br>
Tab for characters<br>



<h2>JMM Server</h2>

After hashing a file save the filename, size and hash to a new FilenameHash table instead of just sending to the web cache. This should make moving files around a lot less painful.<br>
For users with capable systems, allow them to populate this from the web cache<br>


Move other types of association as well (MAL and MovieDB)<br>
- AssociationType (int)<br>
- AssociationSource (int) (WebCache/Personal)<br>
- AssociationID (string)<br>

MAL - ID<br>
AnimePlanet - ID<br>
BakaBT - URL<br>
AnimeNano - Tag<br>
Crunchyroll<br>

Support for files on DVD<br>

Check whether it is possible to create a report which checks to see if we have v2's of a file. This occurs where a fansub groups releases fixes for a file. usually we want to delete the previous versions of the file<br>

Enable logging of sql commands for trace statements<br>
<a href='http://devio.wordpress.com/2010/04/14/logging-sql-statements-generated-by-nhibernate/'>http://devio.wordpress.com/2010/04/14/logging-sql-statements-generated-by-nhibernate/</a><br><br>

Add a Drop/move LQ ver if HQ is found option<br>
(if 2 of EP is found keep the bigger / 720P / 1080P ver and trash the LQ "require conformation")<br>
Tie this is with version 2's of files as well<br>
Suggested by techmasterjoe<br>
<a href='http://www.otakumm.com/forums/viewtopic.php?t=144'>http://www.otakumm.com/forums/viewtopic.php?t=144</a><br>

Support for techmasterjoe's signatures<br>
<a href='http://www.otakumm.com/forums/viewtopic.php/f,6/t,132/'>http://www.otakumm.com/forums/viewtopic.php/f,6/t,132/</a><br>

Investigate UPNP/DLNA support<br>
<a href='http://www.otakumm.com/forums/viewtopic.php/p,544/#p544'>http://www.otakumm.com/forums/viewtopic.php/p,544/#p544</a><br>

Remove fields which are not displayed in group/series data<br>

<h3>Import</h3>

Get awards from http api<br>

<h2>Installer</h2>

<a href='http://jrsoftware.org/is3rdparty.php'>http://jrsoftware.org/is3rdparty.php</a><br>

In installer, have recommendations on which database to use<br>
If over 200 series and server has 4GB of memory recommend sql server<br>