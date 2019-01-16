namespace Forum.App.UserInterface
{
	using Forum.App.UserInterface.Contracts;

	public class MainView : IView
	{
		public MainView(string userName)
		{
			Username = userName;
			InitializeLabels();
		}

		public ILabel[] Labels { get; private set; }

		public ILabel[] Buttons { get; private set; }

		public string Username {get; }

		protected void InitializeLabels()
		{
			Position consoleCenter = Position.ConsoleCenter();

			InitializeStaticLabels(consoleCenter);

			InitializeButtons(consoleCenter);
		}

		private void InitializeButtons(Position consoleCenter)
		{
			string[] buttonContents = new string[] { "Categories", "Log In", "Sign Up" };

			if (!string.IsNullOrWhiteSpace(Username))
			{
				buttonContents[1] = "Add Post";
				buttonContents[2] = "Log Out";
			}

			Position[] buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left - 4, consoleCenter.Top - 2),
				new Position(consoleCenter.Left - 4, consoleCenter.Top + 6),
				new Position(consoleCenter.Left - 4, consoleCenter.Top + 8),
			};

			Buttons = new ILabel[buttonContents.Length];

			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i] = new Label(buttonContents[i], buttonPositions[i]);
			}
		}

		private void InitializeStaticLabels(Position consoleCenter)
		{
			string[] labelContents = new string[]
			{
            //@"
            //▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
            //█        ▀█▄▀▄▀██████ ▀█▄▀▄▀██████
            //            ▀█▄█▄███▀    ▀█▄█▄███",
                "FORUM",
				string.Format("Hi, {0}", Username),
			};
			Position[] labelPositions = new Position[]
			{
                //new Position(consoleCenter.Left - 4, consoleCenter.Top - 11),
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 6),
				new Position(consoleCenter.Left - 4, consoleCenter.Top - 7),
			};

			Labels = new ILabel[labelContents.Length];

			int lastIndex = Labels.Length - 1;
			for (int i = 0; i < lastIndex; i++)
			{
				Labels[i] = new Label(labelContents[i], labelPositions[i]);
			}

			Labels[lastIndex] = new Label(labelContents[lastIndex], labelPositions[lastIndex], string.IsNullOrWhiteSpace(Username));
		}
	}
}
