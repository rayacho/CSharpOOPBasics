namespace Forum.App.UserInterface.ViewModels
{
	using Forum.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Workshop.Controllers.Services;

	public class PostViewModel
	{
		private const int LINE_LENGTH = 37;

		public PostViewModel()
		{
			Content = new List<string>();
		}

		public PostViewModel(Post post)
		{
			Author = UsersService.GetUser(post.AuthorId).Username;
			Category = PostService.GetCategory(post.CategoryId).Name;
			Title = post.Title;
			PostId = post.Id;
			Content = GetLines(post.Content);
			Replies = PostService.GetPostReplies(post.Id);
		}

		private IList<string> GetLines(string content)
		{
			char[] contentChars = content.ToCharArray();
			List<string> contentLines = new List<string>();

			for(int i = 0; i < content.Length; i += LINE_LENGTH)
			{
				char[] row = contentChars.Skip(i).Take(LINE_LENGTH).ToArray();
				string rowString = string.Join("", row);
				contentLines.Add(rowString);
			}

			return contentLines;
		}

		public int PostId { get; set; }

		public string Title {get; set; }

		public string Author {get; set; }

		public string Category {get; set; }

		public IList<string> Content {get; set; }

		public IList<ReplyViewModel> Replies { get; set; }
	}
}
