# User Manual - File Renaming #

Guide on the File Renaming tab in JMM Desktop



## Introduction ##

The File Renaming tab allows you to configure how you would like to rename your files (optional of course)<br>

It allows you to set up a profile to automatically rename your files as they are imported into your collection, or rename files already in your collection<br>

The renaming functionality provided is a subset of the functionality provided by WebAOM, with some modifications<br>
<a href='http://wiki.anidb.net/w/WebAOM#Move.2Frename_system'>http://wiki.anidb.net/w/WebAOM#Move.2Frename_system</a><br>

Renaming works by taking the metadata provided by AniDB, and then using this information to rename your files<br>

<h3>Scripting</h3>

You will need to create a script which contains a series of rules, tests and replacement tags which determines how your file will be renamed<br>

Use the tests to create a string of tags and other text which will be used ro rename the file.<br>

<h4>Tests</h4>

For most tests you can insert '!' inside the brackets to indicate NOT<br>
For example <br>
<pre><code>IF A(69) DO FAIL // If the anime id is 69 (Naruto) then don't rename the file<br>
IF A(!69) DO FAIL // If the anime id is NOT 69 (Naruto) then don't rename the file<br>
</code></pre>

For some tests it will also allow the following operators. These will be referred to as <b>numerical operators</b> below<br>
<pre><code>&gt; // Greater Than<br>
&gt;= // Greater Than or Equal To<br>
&lt; // Less Than<br>
&lt;= // Less Than or Equal To<br>
</code></pre>

You can have multiple tests on one line by using the AND and OR operators<br>
However you cannot have both an AND and an OR on the same line<br>
<pre><code>, // OR<br>
; // AND<br>
IF A(69),A(1),A(2) DO FAIL // If Anime ID is 69 or 1 or 2, do not rename the file<br>
IF I(epn);I(!epr) DO ADD '%epn' //If the episode has an romaji title but not an english title add the romaji episode title<br>
</code></pre>

<table><thead><th> <b>Test</b> </th><th> <b>Example</b> </th><th> <b>Explanation</b></th></thead><tbody>
<tr><td> A           </td><td> A(69)          </td><td> Test if the anime for the file has the specified Anime ID </td></tr>
<tr><td> G           </td><td> G(1012)        </td><td> Group id or 'unknown' </td></tr>
<tr><td> E           </td><td> E(67987)       </td><td> Episode number    </td></tr>
<tr><td> H           </td><td> H(S)           </td><td> Episode Type [E=episode, S=special, T=trailer, C=credit, P=parody, O=other] </td></tr>
<tr><td> X           </td><td> X(13) ,  X(<100) </td><td> Total number of episodes, Numerical operators allowed, only for normal episodes not specials, credits etc </td></tr>
<tr><td> R           </td><td> R(DVD)         </td><td> Rip source [Blu-ray, unknown, camcorder, TV, DTV, VHS, VCD, SVCD, LD, DVD, HKDVD, www] </td></tr>
<tr><td> T           </td><td> T(TV)          </td><td> Type [unknown, TV, OVA, Movie, Other, web] </td></tr>
<tr><td> Y           </td><td> Y(2008)        </td><td> Year first aired, Numerical operators allowed </td></tr>
<tr><td> D           </td><td> D(english)     </td><td> Dub language (one of the audio tracks) [japanese, english, ...] </td></tr>
<tr><td> S           </td><td> S(english)     </td><td> Sub language (one of the subtitle tracks) [japanese, english, ...] </td></tr>
<tr><td> I           </td><td> I(ann)         </td><td> Tag is defined. Do not use %, i.e. I(eng) [eng, kan, rom, ann, ...] </td></tr>
<tr><td> C           </td><td> C(H264/AVC)    </td><td> Video Codec (one of the video tracks) [H264/AVC, DivX5/6, unknown, VP Other, WMV9 (also WMV3), XviD, ...] </td></tr>
<tr><td> J           </td><td> J(FLAC)        </td><td> Audio Codec (one of the audio tracks) [AC3, FLAC, MP3 CBR, MP3 VBR, Other, unknown, Vorbis (Ogg Vorbis)  ...] </td></tr>
<tr><td> Z           </td><td> Z(10)          </td><td> Video Bit Depth, Numerical operators allowed [8,10] </td></tr>
<tr><td> W           </td><td> W(>=1280)      </td><td> Video Resolution Width, Numerical operators allowed, [720, 1280, 1920, ...] </td></tr>
<tr><td> U           </td><td> U(>=1080)      </td><td> Video Resolution Height, Numerical operators allowed, [576, 720, 1080, ...] </td></tr>
<tr><td> M           </td><td> M() or M(!)    </td><td> Test if the file is manually linked </td></tr>
<tr><td> N           </td><td> N() or N(!)    </td><td> Test if the file has any episodes attached (for check if unrecognized) </td></tr></tbody></table>

<h4>Tags</h4>

Tags are always inside single quotes, preceded by a % and three letters long<br>
Tags will be replaced with the metadata from AniDB<br>
<br>
<table><thead><th> <b>Tag</b> </th><th> <b>Replaced With</b></th></thead><tbody>
<tr><td> %ann       </td><td> Anime Name - Romaji </td></tr>
<tr><td> %kan       </td><td> Anime Name - Kanji  </td></tr>
<tr><td> %eng       </td><td> Anime Name - English </td></tr>
<tr><td> %epn       </td><td> Episode Name - Romaji </td></tr>
<tr><td> %epr       </td><td> Episode Name - English </td></tr>
<tr><td> %enr       </td><td> Episode Number      </td></tr>
<tr><td> %grp       </td><td> Group Name - Short  </td></tr>
<tr><td> %grl       </td><td> Group Name - Long   </td></tr>
<tr><td> %ed2/%ED2  </td><td> ED2K - Lower/Upper  </td></tr>
<tr><td> %crc/%CRC  </td><td> CRC- Lower/Upper    </td></tr>
<tr><td> %ver       </td><td> File Version        </td></tr>
<tr><td> %qua       </td><td> Video Quality       </td></tr>
<tr><td> %src       </td><td> Video Source        </td></tr>
<tr><td> %res       </td><td> Video Resolution    </td></tr>
<tr><td> %yea       </td><td> Year                </td></tr>
<tr><td> %eps       </td><td> Episode Count       </td></tr>
<tr><td> %typ       </td><td> Anime Type // [unknown, TV Series, OVA, Movie, TV Special, Other, web] </td></tr>
<tr><td> %fid       </td><td> File ID             </td></tr>
<tr><td> %aid       </td><td> Anime ID            </td></tr>
<tr><td> %eid       </td><td> Episode ID          </td></tr>
<tr><td> %gid       </td><td> Group ID            </td></tr>
<tr><td> %dub       </td><td> Dub Language        </td></tr>
<tr><td> %sub       </td><td> Sub Language        </td></tr>
<tr><td> %vid       </td><td> Video codec (tracks separated with ' </td></tr>
<tr><td> %aud       </td><td> Audio codec (tracks separated with ' </td></tr>
<tr><td> %bit       </td><td> Video Bit Depth (8bit, 10bit) </td></tr>
<tr><td> %sna       </td><td> The original file name as specified by the sub group </td></tr>
<tr><td> %cen       </td><td> Censored            </td></tr>
<tr><td> %dep       </td><td> Deprecated          </td></tr></tbody></table>

<h4>Scripting Basics</h4>

<table><thead><th> <b>Syntax</b> </th><th> <b>Example</b> </th><th> <b>Explanation</b></th></thead><tbody>
<tr><td> //            </td><td> <code>// This is a comment</code> </td><td> This is used to indicate a comment, and everything after this willl be ignored </td></tr>
<tr><td> ' '           </td><td> <code>' Version_%ver '</code> </td><td> Everything inside the single quotes will be added to the file name including spaces.</td></tr>
<tr><td> %tag          </td><td> <code>%ann</code> </td><td> Tags are preceded by a % and will be replaced with the metadata.</td></tr></tbody></table>

<h4>Scripting Rules</h4>

<ul><li>Scripts are not validated so you must make sure they conform to the rules<br>
</li><li>You can only have one action <code>DO ADD</code> per line</li></ul>

<h3>Sample Scripts</h3>

<h4>General Example</h4>
<pre><code>IF A(69) DO FAIL //Do not rename file if it is Naruto<br>
// Sub groups<br>
DO ADD '[%grp] ' //sub group name short<br>
// Anime Name<br>
IF I(eng) DO ADD '%eng - ' // if the anime has an official/main title english add it to the string<br>
IF I(ann);I(!eng) DO ADD '%ann - ' //If the anime has a romaji title but not an english title add the romaji anime title<br>
// Episode number<br>
DO ADD '%enr - ' //Add the Episode number, same for all files<br>
// Episode name<br>
IF I(epr) DO ADD '%epr' //If the episode has an english title add to string<br>
IF I(epn);I(!epr) DO ADD '%epn' //If the episode has an romaji title but not an english title add the romaji episode title<br>
// Audio and subtitle languages<br>
IF I(sub) DO ADD ' (SUB:%sub)'<br>
IF I(dub) DO ADD ' (LAN:%dub)'<br>
// FILE Version<br>
IF F(!1) DO ADD ' [v%ver]' //If the file is not version 1, add the file version<br>
</code></pre>

<h4>Format:  Sample 1</h4>

<b>Output:</b> <code>[Coalgirls]_Highschool_of_the_Dead_-_01_(1920x1080_Blu-ray_H264)_[90CC6DC1].mkv</code><br>
<b>Script</b><br>
<pre><code>// Sub group name<br>
DO ADD '[%grp] '<br>
// Anime Name, use english name if it exists, otherwise use the Romaji name<br>
IF I(eng) DO ADD '%eng '<br>
IF I(ann);I(!eng) DO ADD '%ann '<br>
// Episode Number, don't use episode number for movies<br>
IF T(!Movie) DO ADD '- %enr'<br>
// If the file version is v2 or higher add it here<br>
IF F(!1) DO ADD 'v%ver'<br>
// Video Resolution<br>
DO ADD ' (%res'<br>
// Video Source (only if blu-ray or DVD)<br>
IF R(DVD),R(Blu-ray) DO ADD ' %src'<br>
// Video Codec<br>
DO ADD ' %vid'<br>
// Video Bit Depth (only if 10bit)<br>
IF Z(10) DO ADD ' %bitbit'<br>
DO ADD ') '<br>
DO ADD '[%CRC]'<br>
<br>
// Replacement rules (cleanup)<br>
DO REPLACE ' ' '_' // replace spaces with underscores<br>
DO REPLACE '0x0' ''<br>
DO REPLACE '__' '_'<br>
DO REPLACE '__' '_'<br>
<br>
// Replacement rules (codecs)<br>
DO REPLACE 'H264/AVC' 'H264'<br>
DO REPLACE 'DivX5/6' 'DivX'<br>
DO REPLACE 'WMV9' 'WMV9'<br>
<br>
DO REPLACE 'MP3 CBR' 'MP3'<br>
DO REPLACE 'MP3 VBR' 'MP3'<br>
DO REPLACE 'Vorbis (Ogg Vorbis)' 'Vorbis'<br>
<br>
// Replace all illegal file name characters<br>
DO REPLACE '&lt;' '(' <br>
DO REPLACE '&gt;' ')' <br>
DO REPLACE ':' ';' <br>
DO REPLACE '"' '`'<br>
DO REPLACE '/' '_'<br>
DO REPLACE '\' '_' <br>
DO REPLACE '|' '_' <br>
DO REPLACE '?' '_' <br>
DO REPLACE '*' '_'<br>
</code></pre>

<h4>Format:  Sample 2 - Video format instead of resolution</h4>

<b>Output:</b> <code>[Coalgirls]_Highschool_of_the_Dead_-_01_(1080p_Blu-ray_H264)_[90CC6DC1].mkv</code><br>
<b>Script</b><br>

<pre><code>// Sub group name<br>
DO ADD '[%grp] '<br>
// Anime Name, use english name if it exists, otherwise use the Romaji name<br>
IF I(eng) DO ADD '%eng '<br>
IF I(ann);I(!eng) DO ADD '%ann '<br>
// Episode Number, don't use episode number for movies<br>
IF T(!Movie) DO ADD '- %enr'<br>
// If the file version is v2 or higher add it here<br>
IF F(!1) DO ADD 'v%ver'<br>
// Video Format<br>
IF W(&gt;=1920) DO ADD ' (1080p'<br>
IF W(&gt;=1280);W(&lt;1920) DO ADD ' (720p'<br>
IF W(&lt;1280) DO ADD ' (SD'<br>
// Video Source (only if blu-ray or DVD)<br>
IF R(DVD),R(Blu-ray) DO ADD ' %src'<br>
// Video Codec<br>
DO ADD ' %vid'<br>
// Video Bit Depth (only if 10bit)<br>
IF Z(10) DO ADD ' %bitbit'<br>
DO ADD ') '<br>
DO ADD '[%CRC]'<br>
<br>
// Replacement rules (cleanup)<br>
DO REPLACE ' ' '_' // replace spaces with underscores<br>
DO REPLACE 'H264/AVC' 'H264'<br>
DO REPLACE '0x0' ''<br>
DO REPLACE '__' '_'<br>
DO REPLACE '__' '_'<br>
<br>
// Replace all illegal file name characters<br>
DO REPLACE '&lt;' '('<br>
DO REPLACE '&gt;' ')'<br>
DO REPLACE ':' '-'<br>
DO REPLACE '"' '`'<br>
DO REPLACE '/' '_'<br>
DO REPLACE '/' '_'<br>
DO REPLACE '\' '_'<br>
DO REPLACE '|' '_'<br>
DO REPLACE '?' '_'<br>
DO REPLACE '*' '_'<br>
</code></pre>

<h4>Format:  Sample 3</h4>

<b>Output:</b> <code>Highschool of the Dead - 01 [1920x1080] [Coalgirls].mkv</code><br>
<b>Script</b><br>

<pre><code>// Anime Name, use english name if it exists, otherwise use the Romaji name<br>
IF I(eng) DO ADD '%eng '<br>
IF I(ann);I(!eng) DO ADD '%ann '<br>
// Episode Number, don't use episode number for movies<br>
IF T(!Movie) DO ADD '- %enr'<br>
// If the file version is v2 or higher add it here<br>
IF F(!1) DO ADD 'v%ver'<br>
// Video Resolution<br>
DO ADD ' [%res]'<br>
// Sub group name<br>
DO ADD ' [%grp] '<br>
<br>
// Replacement rules (cleanup)<br>
DO REPLACE ' ' '_' // replace spaces with underscores<br>
DO REPLACE '0x0' ''<br>
DO REPLACE '__' '_'<br>
DO REPLACE '__' '_'<br>
<br>
// Replacement rules (codecs)<br>
DO REPLACE 'H264/AVC' 'H264'<br>
DO REPLACE 'DivX5/6' 'DivX'<br>
DO REPLACE 'WMV9' 'WMV9'<br>
<br>
DO REPLACE 'MP3 CBR' 'MP3'<br>
DO REPLACE 'MP3 VBR' 'MP3'<br>
DO REPLACE 'Vorbis (Ogg Vorbis)' 'Vorbis'<br>
<br>
// Replace all illegal file name characters<br>
DO REPLACE '&lt;' '(' <br>
DO REPLACE '&gt;' ')' <br>
DO REPLACE ':' ';' <br>
DO REPLACE '"' '`'<br>
DO REPLACE '/' '_'<br>
DO REPLACE '\' '_' <br>
DO REPLACE '|' '_' <br>
DO REPLACE '?' '_' <br>
DO REPLACE '*' '_'<br>
</code></pre>


<h4>Format:  Sample 4 - Original File Name</h4>

<b>Output:</b> <code>[Coalgirls] Highschool of the Dead - 06 [1920x1080 Blu-Ray FLAC] [00AF0C10].mkv</code><br>
<b>Script</b><br>

<pre><code>// Use the file name as original specified by the release group<br>
DO ADD '%sna'<br>
</code></pre>