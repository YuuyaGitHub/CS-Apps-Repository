# YouTube Video Details Viewer
This program displays the details of a YouTube video given the URL.

# What can be displayed
The following information can be displayed using this program:
* Video title
* Uploaded User
* Number of views
* Number of likes
* Number of comments
* Upload date

However, specifying a short video is considered invalid and must be replaced with:
<br>```https://www.youtube.com/shorts/(YOUR_VIDEO_ID)``` -> ```https://www.youtube.com/watch?v=(YOUR_VIDEO_ID)```

Note: For unknown reasons, line breaks in the description are not displayed correctly. Displayed in one line.

# Disclaimer
Do not decompile the **Original EXE**.

# How the program works
If you look at From1.cs, it is stated that the structure of this program is as follows.

Get the title with ```video.Snippet.Title```.
<br>Get the video uploader with ```video.Snippet.ChannelTitle```.
<br>Get the number of views and the number of likes and comments with ```video.Statistics.ViewCount```, ```video.Statistics.LikeCount``` and ```video.Statistics.CommentCount``` respectively.
<br>Get the video description with ```video.Snippet.Description```.
````
DateTime publishedDate = video.Snippet.PublishedAt ?? DateTime.MinValue;
label6.Text = "アップロード日: " + publishedDate.ToString("yyyy/MM/dd");
````
The above code will display the upload date as "2023/11/07".

# Related item
* [YouTube Search Tool](https://github.com/YuuyaGitHub/CS-Apps-Repository/tree/main/YouTube%20Search%20Tool)

# Download
This program can be downloaded [here](https://).

# Screenshot
![Screenshot](Screenshot.png)
