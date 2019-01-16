﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
	public class Post
	{
		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public int CategoryId
		{
			get;
			set;
		}

		public int AuthorId
		{
			get;
			set;
		}

		public ICollection<int> ReplyIds
		{
			get;
			set;
		}

		public Post(int id, string title, string content, int categoryId, int authorId, ICollection<int> replyIds)
		{
			Id = id;
			Title = title;
			Content = content;
			CategoryId = categoryId;
			AuthorId = authorId;
			ReplyIds = new List<int>(replyIds);
		}
	}
}
