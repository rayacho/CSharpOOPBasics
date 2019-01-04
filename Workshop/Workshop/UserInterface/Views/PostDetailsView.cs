namespace Forum.App.Views
{
	using System.Collections.Generic;
	using Forum.App.UserInterface;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.ViewModels;

	public class PostDetailsView : IView
	{
		private const int AUTHOR_OFFSET = 8;
		private const int LEFT_OFFSET = 18;
		private const int TOP_OFFSET = 7;

		public PostDetailsView(PostViewModel post, bool isLoggedIn = false)
		{
			Post = post;
			IsLoggedIn = isLoggedIn;
			SetBuffer();
			InitalizeLabels();
		}

		public ILabel[] Labels
		{
			get;
			private set;
		}

		public ILabel[] Buttons
		{
			get;
			private set;
		}

		private PostViewModel Post
		{
			get;
		}

		public bool IsLoggedIn
		{
			get;
		}

		private void SetBuffer()
		{
			int totalLines = 10 + Post.Content.Count;

			foreach (ReplyViewModel reply in Post.Replies)
			{
				totalLines += 2 + reply.Content.Count;
			}

			if (totalLines > 30)
			{
				ForumViewEngine.SetBufferHeight(totalLines);
			}
		}

		private void InitalizeLabels()
		{
			Position consoleCenter = Position.ConsoleCenter();

			Position titlePosition =
				new Position(consoleCenter.Left - Post.Title.Length / 2, consoleCenter.Top - 10);
			Position authorPosition =
				new Position(consoleCenter.Left - Post.Author.Length, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
				new Label(Post.Title, titlePosition),
				new Label($"Author: {Post.Author}", authorPosition),
			};

			int leftPosition = consoleCenter.Left - LEFT_OFFSET;

			int lineCount = Post.Content.Count;

			// Add post contents
			for (int i = 0; i < lineCount; i++)
			{
				Position position = new Position(leftPosition, consoleCenter.Top - (TOP_OFFSET - i));
				ILabel label = new Label(Post.Content[i], position);
				labels.Add(label);
			}

			int currentRow = consoleCenter.Top - (TOP_OFFSET - lineCount) + 1;

			InitializeButtons(leftPosition, currentRow);

			// Add replies
			Position repliesStartPosition = new Position(leftPosition, currentRow++);
			int repliesCount = Post.Replies.Count;

			labels.Add(new Label($"Replies: {repliesCount}", repliesStartPosition));

			foreach (ReplyViewModel reply in Post.Replies)
			{
				Position replyAuthorPosition = new Position(leftPosition, ++currentRow);

				labels.Add(new Label(reply.Author, replyAuthorPosition));

				foreach (string line in reply.Content)
				{
					Position rowPosition = new Position(leftPosition, ++currentRow);
					labels.Add(new Label(line, rowPosition));
				}
				currentRow++;
			}

			Labels = labels.ToArray();
		}

		private void InitializeButtons(int left, int top)
		{
			Buttons = new ILabel[2];

			Buttons[0] = new Label("Back", new Position(left + 33, top));
			Buttons[1] = new Label("Add Reply", new Position(left + 28, top - 1), !IsLoggedIn);
		}
	}
}
