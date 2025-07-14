<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostFeed.aspx.cs" Inherits="FacebookNewsFeed.WebForms.PostFeed" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook News Feed</title>
</head>
<body>
    <div>
        <h2>News Feed</h2>
        <textarea id="newPostContent" runat="server" placeholder="What's on your mind?"></textarea>
        <button id="btnPost" runat="server" OnClick="CreatePost_Click">Post</button>

        <div id="posts">
            <asp:Repeater ID="rptPosts" runat="server">
                <ItemTemplate>
                    <div>
                        <strong><%# Eval("UserId") %></strong> - <%# Eval("DateCreated") %>
                        <p><%# Eval("Content") %></p>
                        <button onclick="LikePost('<%# Eval("Id") %>')">Like</button>
                        <div id="likes_<%# Eval("Id") %>">
                            <!-- Likes will be displayed here -->
                        </div>
                        <button onclick="ShowComments('<%# Eval("Id") %>')">Show Comments</button>
                        <div id="comments_<%# Eval("Id") %>">
                            <!-- Comments will be displayed here -->
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script type="text/javascript">
        function LikePost(postId) {
            var likeData = {
                userId: '12345', // Example user ID
                postId: postId,
                dateCreated: new Date()
            };
            fetch(`http://localhost:5000/api/post/like/${postId}`, {
                method: 'POST',
                body: JSON.stringify(likeData),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(response => response.json())
              .then(data => loadLikes(postId));
        }

        function ShowComments(postId) {
            fetch(`http://localhost:5000/api/post/comments/${postId}`)
                .then(response => response.json())
                .then(comments => {
                    let commentsDiv = document.getElementById('comments_' + postId);
                    commentsDiv.innerHTML = '';
                    comments.forEach(comment => {
                        commentsDiv.innerHTML += `<div>${comment.userId} said: ${comment.content}</div>`;
                    });
                });
        }

        function loadLikes(postId) {
            fetch(`http://localhost:5000/api/post/likes/${postId}`)
                .then(response => response.json())
                .then(likes => {
                    let likesDiv = document.getElementById('likes_' + postId);
                    likesDiv.innerHTML = `Likes: ${likes.length}`;
                });
        }
    </script>
</body>
</html>
