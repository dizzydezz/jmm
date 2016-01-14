# Anime Buddy Frequently Asked Questions #



## JMM Server ##

JMM Server allows you to keep track of files/episodes in your own collection.

### Can Anime Buddy connect to JMM Server over the internet? ###

Yes, all aspects of Anime Buddy will work over the internet.<br>
Note that images are quite large, and initially loading them can take a quite a while over a slow connection<br>
Downloading of episode files will also work since the files are transferred via JMM server rather than directly accessing the local network<br>

<h3>JMM Server Not Responding Errors</h3>

You may get an error when trying to connect to JMM Server along the lines of <br>
<b>JMM Server is not responding..</b><br>

Possible issues<br>
1. JMM Server is not running<br>
2. You have not entered the JMM Server details correcly<br>
3. Loopback issues when trying to connect Anime Buddy to JMM server on the same machine<br>

In regards to #3, this is a common issue where Metro applications are forbidden from sending network traffic to the local machine. You can over-ride this (and get a full explanation) from the following page<br>

<a href='http://blogs.msdn.com/b/fiddler/archive/2011/12/10/fiddler-windows-8-apps-enable-loopback-network-isolation-exemption.aspx'>http://blogs.msdn.com/b/fiddler/archive/2011/12/10/fiddler-windows-8-apps-enable-loopback-network-isolation-exemption.aspx</a>

Simply install the loopback utility and add Anime Buddy as an exemption<br>


<h2>Playing an episode/video</h2>

To play an episode in Anime Buddy, it first downloads the file to your local folders. The reason for this is that Windows Store apps are not allowed to access the network, or local machine folders without manually using the File Picker.<br>

The file is downloaded into your temporary folder, and you can play it again later.<br>
You can also delete the temp file after you have finished watching it, or delete all temp files from the options charm<br>

<h3>Why won't the episode play?</h3>

If you are on a Windows RT machine, you can only play videos which are supported by Windows Store apps. At the time of writing the Video app only supports avi/xvid files.<br>
Hopefully in the future an app will be released which fully supports MKV<br>

Update - The PressPlay app on windows store partially supports MKV (only H264 video, and MP3/AAC/ACE audio)<br>
<a href='http://apps.microsoft.com/webpdp/en-us/app/pressplay-video/14524998-116a-406f-994b-fefc4caa91dc'>http://apps.microsoft.com/webpdp/en-us/app/pressplay-video/14524998-116a-406f-994b-fefc4caa91dc</a><br>

If you are on Windows 8 Pro, you can download desktops apps like Media Player Class, VLC etc which will allow you to play most files.<br>