using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Forum.App.UserInterface.ViewModels;

namespace Workshop.Controllers.Services
{
	internal class PostService
	{
		internal static Category GetCategory(int categoryId)
		{
			ForumData forumData = new ForumData();
			Category category = forumData.Categories.Single(c => c.Id == categoryId);
			return category;
		}

		public static IList<ReplyViewModel> GetPostReplies(int postId)
		{
			ForumData forumData = new ForumData();
			Post post = forumData.Posts.Single(p => p.Id == postId);

			List<ReplyViewModel> replies = new List<ReplyViewModel>();
			foreach (int replyId in post.ReplyIds)
			{
				Reply reply = forumData.Replies.First(r => r.Id == replyId);
				replies.Add(new ReplyViewModel(reply));
			}
			return replies;
		}

		public static string[] GetAllCategoryNames()
		{
			ForumData forumData = new ForumData();
			return forumData.Categories.Select(c => c.Name).ToArray();
		}

		public static IEnumerable<Post> GetPostsByCategory(int categoryId)
		{
			ForumData forumdata = new ForumData();
			Category category = forumdata.Categories.Single(c => c.Id == categoryId);
			List<Post> forumata1 = forumdata.Posts;
			return forumata1.Where(p => category.PostIds.Contains(p.Id)).ToList();
		}

		public static PostViewModel GetPostViewModel(int postId)
		{
			ForumData forumData = new ForumData();
			Post post = forumData.Posts.Single(p => p.Id == postId);
			return new PostViewModel(post);
		}

		private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
		{
			var categoryName = postView.Category;
			Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
			if (category == null)
			{
				var categories = forumData.Categories;
				int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
				category = new Category(categoryId, categoryName, new List<int>());
				forumData.Categories.Add(category);
			}

			return category;
		}

		public static bool TrySavePost(PostViewModel postViewModel)
		{
			bool isTitleValid = !string.IsNullOrWhiteSpace(postViewModel.Title);
			bool isContentValid = postViewModel.Content.Any();
			bool isCategoryValid = !string.IsNullOrWhiteSpace(postViewModel.Category);

			if (!isTitleValid || !isContentValid || isCategoryValid)
			{
				return false;
			}

			ForumData forumData = new ForumData();

			Category category = EnsureCategory(postViewModel, forumData);

			int postId = forumData.Posts.Last()?.Id + 1 ?? 1;
			User author = forumData.Users.Single(u => u.Username == postViewModel.Author);
			string content = string.Join("", postViewModel.Content);
			Post post = new Post(postId, postViewModel.Title, content, category.Id, author.Id, new List<int>());

			forumData.Posts.Add(post);
			category.PostIds.Add(postId);
			author.PostIds.Add(postId);
			forumData.SaveChanges();
			postViewModel.PostId = postId;

			return true;
		}

		public static bool TrySaveReply(ReplyViewModel replyView, int postId)
		{
			if (!replyView.Content.Any())
			{
				return false;
			}

			ForumData forumData = new ForumData();

			List<Reply> replies = forumData.Replies;
			int replyId = replies.Any() ? replies.Last().Id + 1 : 1;
			Post post = forumData.Posts.First(p => p.Id == postId);
			User author = UsersService.GetUser(replyView.Author);
			int authorId = author.Id;
			string content = string.Join("", replyView.Content);
			Reply reply = new Reply(replyId, content, authorId, postId);

			forumData.Replies.Add(reply);
			post.ReplyIds.Add(replyId);
			forumData.SaveChanges();

			return true;
		}
	}
}
