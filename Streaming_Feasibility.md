# Introduction #

This is a developer page to investigate the possibility of streaming video


# Basic Streaming Requirements #

  * HTTP Streaming (not just RTSP)
  * Ability to pause and seek (fast forward)

# Streaming Bonus Requirements #

  * HDS (HTTP Dynamic Streaming) / Adaptive bit rate streaming

# Possible Solutions #

## VLC ##

  * Streaming over HTTP works
  * Cannot pause or seek
  * Slow to start streaming

## VLC VoD ##

  * Only works over RTSP

## FFMpeg ##

  * Requires ffserver to do seek (ffserver only runs on linux)

## Wowza ##

  * Seems to support everything
  * Costs $1,000

## TVersity ##

  * Seems to be very hard to setup
  * Very slow at encoding
  * Costs $4

## MPExtended ##

https://github.com/MPExtended/MPExtended<br>
<a href='http://mpextended.github.com/'>http://mpextended.github.com/</a><br>
<a href='http://forum.team-mediaportal.com/threads/mpextended-service-0-5-0.114105/'>http://forum.team-mediaportal.com/threads/mpextended-service-0-5-0.114105/</a><br>

<h2>Plex</h2>

<a href='http://www.plexapp.com/getplex/'>http://www.plexapp.com/getplex/</a><br>
<a href='http://dev.plexapp.com/docs/index.html'>http://dev.plexapp.com/docs/index.html</a><br>

<h2>Microsoft Smooth Streaming</h2>

<a href='http://learn.iis.net/page.aspx/89/serving-media-content/'>http://learn.iis.net/page.aspx/89/serving-media-content/</a><br>

<ul><li>Very hard to setup</li></ul>

<h2>Transcode Files</h2>

Instead of streaming, just transcode the files and then copy them over WCF to the device<br>

<ul><li>Requires a lot of disk space<br>
</li><li>A long time between deciding to watch something and then watching it