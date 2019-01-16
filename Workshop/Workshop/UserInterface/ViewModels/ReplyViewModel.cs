namespace Forum.App.UserInterface.ViewModels
{
	using Forum.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Workshop.Controllers.Services;

	public class ReplyViewModel
	{
		private const int LINE_LENGTH = 37;

		public ReplyViewModel()
		{
			Content = new List<string>();
		}

		public ReplyViewModel(Reply reply)
		{
			Author = UsersService.GetUser(reply.AuthorId).Username;
			Content = GetLines(reply.Content);
		}
	
		public string Author { get; set; }
		
		public IList<string> Content {get; set; }

		private IList<string> GetLines(string content)
		{
			char[] contentChars = content.ToCharArray();
			List<string> contentLines = new List<string>();

			for (int i = 0; i < content.Length; i += LINE_LENGTH)
			{
				char[] row = contentChars.Skip(i).Take(LINE_LENGTH).ToArray();
				string rowString = string.Join("", row);
				contentLines.Add(rowString);
			}

			return contentLines;
		}
	}
}