using System;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTube_Search_Tool
{
    public partial class Form1 : Form
    {
        //このコードがないと機能しません
        //再コンパイルは禁止します。
        //あなたが作成したYouTuhe API Keyを使用してください。
        private const string apiKey = "YOUR_API_HERE";
        private SearchListResponse searchListResponse;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //検索キーワードを抽出
            string searchQuery = textBox1.Text;

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchQuery;
            searchListRequest.MaxResults = (long?)numericUpDown1.Value; //指定された検索件数で検索を実行
            
            searchListResponse = searchListRequest.Execute(); //検索処理を実行

            //検索結果を初期化
            listBox1.Items.Clear();

            //アップロード者の表示をリセット
            label3.Text = "アップロード者: ";

            foreach (var searchResult in searchListResponse.Items)
            {
                //検索結果を表示
                listBox1.Items.Add(searchResult.Snippet.Title);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                //選択されている動画を取得し、ブラウザ開く
                var selectedItem = searchListResponse.Items[selectedIndex];
                string videoId = selectedItem.Id.VideoId;
                string videoUrl = "https://www.youtube.com/watch?v=" + videoId;
                System.Diagnostics.Process.Start(videoUrl);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedVideoTitle = listBox1.SelectedItem.ToString();
                string uploader = GetUploaderForVideo(selectedVideoTitle);

                label3.Text = "アップロード者: " + uploader;
            }
            else
            {
                label3.Text = "アップロード者: ";
            }
        }
        private string GetUploaderForVideo(string videoTitle)
        {
            // YouTube Data API v3の初期化
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "YOUR_KEY_HERE", // ここにAPIキーを設定
                ApplicationName = "YouTube Search Tool"
            });

            // 動画情報を取得するための検索リクエストを作成
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = videoTitle;
            searchListRequest.MaxResults = 1; // 最初の一つの結果を取得

            // 動画情報を取得
            var searchListResponse = searchListRequest.Execute();
            if (searchListResponse.Items.Count > 0)
            {
                var videoId = searchListResponse.Items[0].Id.VideoId;

                // 動画の詳細情報を取得
                var videoListRequest = youtubeService.Videos.List("snippet");
                videoListRequest.Id = videoId;
                var videoListResponse = videoListRequest.Execute();

                if (videoListResponse.Items.Count > 0)
                {
                    return videoListResponse.Items[0].Snippet.ChannelTitle;
                }
            }

            return "アップロード者が見つかりません";
        }
    }
}