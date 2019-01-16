namespace Forum.App.Controllers
{
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.Input;
	using Forum.App.UserInterface.ViewModels;
	using System.Linq;
	using Workshop.Controllers.Services;

	public class AddPostController : IController
	{
		private const int CommandCount = 4;
		private const int TextAreaWidth = 37;
		private const int TextAreaHeight = 18;
		private const int PostMaxLength = 660;

		private static int centerTop = Position.ConsoleCenter().Top;
		private static int centerLeft = Position.ConsoleCenter().Left;

		private enum Command
		{
			AddTitle, AddCategory, Write, Post
		}

		public PostViewModel Post { get; private set; }

		public TextArea TextArea { get; set; }

		public bool Error { get; private set; }

		public AddPostController()
		{
			ResetPost();
		}

		public MenuState ExecuteCommand(int index)
		{
			switch ((Command)index)
			{
				case Command.AddTitle:
					ReadTitle();
					return MenuState.AddPost;
				case Command.AddCategory:
					ReadCategory();
					return MenuState.AddPost;
				case Command.Write:
					TextArea.Write();
					Post.Content = TextArea.Lines.ToArray();
					return MenuState.AddPost;
				case Command.Post:
					bool postAdded = PostService.TrySavePost(Post);
					if(!postAdded)
					{
						Error = true;
						return MenuState.Rerender;
					}
					return MenuState.PostAdded;
			}

			throw new InvalidCommandException();
		}

		public IView GetView(string userName)
		{
			Post.Author = userName;
			return new AddPostView(Post, TextArea, Error);
		}

		public void ReadTitle()
		{
			Post.Title = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}

		private void ReadCategory()
		{
			Post.Category = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}

		public void ResetPost()
		{
			Error = false;
			Post = new PostViewModel();
			TextArea = new TextArea(centerLeft - 18, centerTop - 7,
				TextAreaWidth, TextAreaHeight, PostMaxLength);
		}
	}
}
