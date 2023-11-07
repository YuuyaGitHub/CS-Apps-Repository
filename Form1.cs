using System;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTube_Video_Details_Viewer
{
    public partial class Form1 : Form
    {
        private const string apiKey = "YOUR_API_HERE"; // ここにYouTube APIキーを設定してください

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string videoUrl = textBox1.Text;
            string videoId = GetVideoId(videoUrl);

            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("無効なYouTube動画のURLです。", "YouTube Video Details Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "YouTube Video Details Viewer"
            });

            VideosResource.ListRequest listRequest = youtubeService.Videos.List("snippet,statistics");
            listRequest.Id = videoId;

            VideoListResponse videoResponse = listRequest.Execute();

            if (videoResponse.Items.Count > 0)
            {
                Video video = videoResponse.Items[0];
                label1.Text = "タイトル: " + video.Snippet.Title;
                label2.Text = "アップロード者: " + video.Snippet.ChannelTitle;
                label3.Text = "視聴回数: " + video.Statistics.ViewCount;
                label4.Text = "高評価数: " + video.Statistics.LikeCount;
                label5.Text = "コメント数: " + video.Statistics.CommentCount;
                textBox2.Text = video.Snippet.Description;

                // アップロード日を表示
                DateTime publishedDate = video.Snippet.PublishedAt ?? DateTime.MinValue;
                label6.Text = "アップロード日: " + publishedDate.ToString("yyyy/MM/dd");
            }
            else
            {
                MessageBox.Show("動画情報を取得できませんでした。", "YouTube Video Details Viewer");
            }
        }
        private string GetVideoId(string videoUrl)
        {
            // YouTubeのURLからビデオIDを抽出する
            if (Uri.TryCreate(videoUrl, UriKind.Absolute, out Uri uri))
            {
                string query = uri.Query;
                if (!string.IsNullOrEmpty(query))
                {
                    string[] queryParams = query.TrimStart('?').Split('&');
                    foreach (string param in queryParams)
                    {
                        string[] keyValue = param.Split('=');
                        if (keyValue.Length == 2 && keyValue[0] == "v")
                        {
                            return keyValue[1];
                        }
                    }
                }
            }

            return null;
        }
    }
}
