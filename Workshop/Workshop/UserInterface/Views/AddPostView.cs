namespace Forum.App.UserInterface
{
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.ViewModels;
	using Forum.App.UserInterface.Input;

	public class AddPostView : IView
	{
		private TextArea _textArea;

		public AddPostView(PostViewModel post, TextArea textArea, bool error = false)
		{
			_textArea = textArea;

			if (error)
			{
				Title = post.Title ?? " ";
				Category = post.Category ?? " ";
				ErrorMessage = "All fields must be filled!";
			}

			InitializeLabels();
		}

		private string Title { get; set; } = " ";

		private string Category { get; set; } = " ";

		private string ErrorMessage { get; set; } = "";

		public ILabel[] Labels { get; private set; }

		public ILabel[] Buttons { get; private set; }

		public TextArea TextArea
		{
			get
			{
				return _textArea;
			}
			set
			{
				_textArea = value;
			}
		}

		private void InitializeLabels()
		{
			Position consoleCenter = Position.ConsoleCenter();

			string[] labelContents = new string[] { ErrorMessage, "Title:", "Category:", "", "" };
			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 14), // Error: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Category:
                new Position(consoleCenter.Left - 9, consoleCenter.Top - 12),  // Title: 
                new Position(consoleCenter.Left - 7, consoleCenter.Top - 10),  // Category:
            };

			Labels = new ILabel[labelContents.Length];

			for (int i = 0; i < Labels.Length; i++)
			{
				Labels[i] = new Label(labelContents[i], labelPositions[i]);
			}

			string[] buttonContents = new string[] { Title, Category, "Write", "Post" };
			Position[] buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left - 10, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 8, consoleCenter.Top - 10),  // Category:
                new Position(consoleCenter.Left + 14, consoleCenter.Top - 8),  // Write
                new Position(consoleCenter.Left + 14, consoleCenter.Top + 12)  // Post
            };

			Buttons = new ILabel[buttonContents.Length];

			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i] = new Label(buttonContents[i], buttonPositions[i]);
			}
		}
	}
}
