using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FacebookNewsFeed_WebForms_UI
{
    public partial class PostFeed : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadPosts();
            }
        }

        private async Task LoadPosts()
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/12345");
            var posts = JsonConvert.DeserializeObject<Post[]>(response);

            rptPosts.DataSource = posts;
            rptPosts.DataBind();

            foreach (var post in posts)
            {
                await LoadLikes(post.Id);
                await LoadComments(post.Id);
            }
        }


        private async Task LoadLikes(string postId)
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/likes/{postId}");
            var likes = JsonConvert.DeserializeObject<Like[]>(response);
            // You can update the UI to display the number of likes
        }

        private async Task LoadComments(string postId)
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/comments/{postId}");
            var comments = JsonConvert.DeserializeObject<Comment[]>(response);
            // You can update the UI to display the comments
        }


    }
}



