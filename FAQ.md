# Frequently Asked Questions #



## What are groups? ##

Groups are used to group together related anime series<br>
Any anime that show up as related series on AniDB will automatically be placed to together in the same group. (eg Naruto and Naruto Shippuden)<br>
However you are free to create and delete groupings however you want. You can move anime from group to another, and also great sub groups within another group.<br>
<br>
<h2>Banned from AniDB?</h2>

AniDB will sometimes ban a user if it detects that you are trying to leech data. The algorithm which does this is not perfect, so you may find yourself with a ban every now and then, even if you haven't done anything wrong.<br>

Bans can last anywhere from a few hours to more than a day depending on the severity. If you find yourself with a ban, you should not attempt to run again for at least 12 hours, otherwise you might get a larger ban.<br>

In my experience it only every happens with collections of more than 200 series<br>

<h2>Do i need to manually link files again that I did in MyAnime2</h2>

You can do this if you want and it should be much easier in JMM<br>
However you can import all your manual links from MyAnime2 to JMM using the <b>MyAnime2 Migration</b> tab in JMM Server<br>

<table>
<tr>
<td>
<a href='http://jmm.googlecode.com/svn/trunk/Screenshots/Instructions/MA2_Migration_01.jpg'>
<img src='http://jmm.googlecode.com/svn/trunk/Screenshots/Instructions/MA2_Migration_01.jpg' width='400' />
</a>
</td>
</tr>
</table>

All you need to do is click on the button <b>Select MA2 database and start processing</b><br>
This will prompt you to selected your MyAnime2 database file. This file is usually in the following location<br>
<code>C:\ProgramData\Team MediaPortal\MediaPortal\database\AnimeDatabaseV20.db3</code>

After selecting the database the process will loop through all of your unlinked files in JMM, and check if you manually linked them in MyAnime2. It will then proceed to link them in JMM, downloading information from AniDB as it needs to<br>

NOTE - you should not run this process until you have finished your initial import in JMM<br>