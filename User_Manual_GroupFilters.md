# User Manual - Group Filters #

Explanation of group filters in JMM



## Introduction ##

Group Filters allow you to better organise your collection.<br>
The conditions and operators are evaluated at series level, but also shown at group level.<br>
For example - if a group has 3 different series, and any of those series are considered "Complete" the group will show up in any filters with the "Completed Series" condition<br>

If you add multiple conditions to a filter they act as an AND. Which means a series must pass all the conditions you set to be shown in the filter<br>

<h3>Basics</h3>

<b>Base Condition</b> - Most of the time you will want to have this set as 'Include all'. This means you start with all groups, and the use filters to remove the ones you don't want. Selecting 'Exclude All' is only needed when you want to build a watch list by manually selecting the groups you want<br>

<b>Apply To Series</b> - By default the conditions work at the group level. If you also want to filter the series within a group you need to enable this. For Example<br>
- You have a filter set to show 'Completed Series'<br>
- A group has 3 series in it, 2 of which are complete<br>
- This makes the group considered as complete<br>
- Opening the group will show all the series including the one that is not complete<br>
- If you select this option instead, the incomplete series will be hidden<br>

<h3>Condition Types</h3>

<h4>Air Date</h4>
Air Date is the date a series first starting airing. You can filter series that start before of after your selected date, or select an air date that is within the last 'X' days.<br>

<h4>Anime Type</h4>
This is basically a choice between Movie, TV Series, TV Special, OVA and Web.<br>

<h4>Audio Language</h4>
Filter by the possible audio tracks in your collection (english, japanese etc)<br>

<h4>Category</h4>
Categories are genre's such as 'Action', 'School' and 'Mecha'<br>
You can select multiple categories to filter by. All the categories are those as defined by AniDB, and restricted to the series in your collection<br>

<h4>Completed Series</h4>
A series is considered complete if (1) The show has finished airing (2) You have all the episodes for that series in you collection<br>

<h4>Episode Added Date</h4>
This refers to the date an episode was added to your local collection. The date for a series, will be the latest time an episode was added for that series<br>

<h4>Episode Watched Date</h4>
This refers to the date an episode was watched. The date for a series, will be the latest time an episode was watched for that series<br>

<h4>Favorite</h4>
Favorites are an exception to the 'series' rule, as they apply at the group level only<br>
You can toggle a group as being a favorite using the 'Star' button when viewing a group in JMM Client<br>

<h4>Finished Airing</h4>
A series is finished airing if the end date is greater than today's date<br>

<h4>Group</h4>
Group is an exception to the 'series' rule, as they apply at the group level only<br>
When using this filter you will be prompted to select an existing Anime Group from your collection<br>
This condition is evaluated in a special manner.<br>
For example - if you add a condition which specified your group 'Macross Frontier', this group will always be included in the filter, even if it doesn't match the other conditions<br>
You can use this to always exclude a series/group that you don't want to appear, or you can manually build a watch list of series/groups<br>

<h4>Has Unwatched Episodes</h4>
A series will pass this condition if you have episodes that are not yet watched, and also available in your collection<br>

<h4>Missing Episodes</h4>
If a subbing group has released an episode which you do not have, this condition will be true.<br>
For example - Doki has released up to episode 13 of Bleach, but you only have up to episode 12<br>

<h4>Missing Episodes (Collecting)</h4>
This is the same as "Missing Episodes" except that it will only look at the release groups for which you are collecting<br>
You are collecting the files from release group Doki, for the series Bleach. Doki have released up to episode 13 (which you have), however speed-subber has released up to episode 14. Bleach will not show up using this filter<br>

<h4>Rating - AniDB</h4>
This condition looks at the overall rating given by AniDB users. You can specify a value to filter by, between 0 and 10<br>
The actual rating value is an average value of permanent and temporary votes<br>

<h4>Rating - User</h4>
This is the same as 'Rating - AniDB' except that it only looks at your own votes<br>

<h4>Series Added Date</h4>
This looks at the date a series was added to your local collection. It can be useful for finding what you have recently added<br>

<h4>Subtitle Language</h4>
Filter by the possible Subtitle tracks in your collection (english, japanese etc)<br>

<h4>User Voted (Perm)</h4>
This is a simple condition to determine if you have voted permanently for a series. It would usually be used in conjunction with the 'Completed Series' condition to determine which series you need to vote for<br>

<h4>Video Quality</h4>
Video quality looks at the original source of the files such as Blu-ray, DVD, HDTV etc<br>


<h3>Operators</h3>

<h4>Include</h4>

This is generally uses on true/false conditions such as 'Completed series' and 'Missing Episodes". <br>

<h4>Exclude</h4>

Opposite of Include<br>

<h4>Greater Than</h4>

Used for conditions which require a date input or value input, e.g. 'Air Date' or 'Rating - AniDB'<br>

<h4>Less Than</h4>

Opposite of Greater Than<br>

<h4>Equals</h4>

Used only in the 'Group' condition to indicate that you want this group to always be shown.<br>

<h4>Not Equals</h4>

Opposite of Equals <br>

<h4>In</h4>

Use for conditions where you can select more than one filter value e.g. Category IN 'Mecha,Action,School'. Any series which match at least one of those categories would be shown.<br>

<h4>Not In</h4>

Opposite of 'In' <br>

<h4>In (All Episodes)</h4>

Same as 'In' but will only evaluate to true if all episodes/files in a series match the criteria. This can only be used on conditions where this would make sense, such as Video Quality<br>

<h4>Not In (All Episodes)</h4>

Opposite of 'In (All Episodes)' <br>

<h4>Last 'X' Days</h4>

Used for conditions which are dates, and is evaluated relative to the current date. e.g. You can specify an Air Date of the Last '30' Days, which means it will only show you series which have started airing in the last 30 days<br>

<h3>Useful Sample Filters</h3>