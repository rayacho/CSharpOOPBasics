namespace Forum.App.UserInterface
{
	using Forum.App.UserInterface.Contracts;

	class SignUpView : IView
	{
		public SignUpView(string errorMessage)
		{
			ErrorMessage = errorMessage;
			InitializeLabels();
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

		private string ErrorMessage
		{
			get;
		}

		private bool Error => !string.IsNullOrWhiteSpace(ErrorMessage);

		protected void InitializeLabels()
		{
			Position consoleCenter = Position.ConsoleCenter();

			InitializeStaticLabels(consoleCenter);

			InitializeButtons(consoleCenter);
		}

		private void InitializeStaticLabels(Position consoleCenter)
		{
			string[] labelContents = new string[] { ErrorMessage, "Name:", "Password:" };

			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 16, consoleCenter.Top - 14),   // Error
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),   // Name:
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),    // Password:
            };

			Labels = new ILabel[labelContents.Length];

			Labels[0] = new Label(labelContents[0], labelPositions[0], !Error);

			for (int i = 1; i < Labels.Length; i++)
			{
				Labels[i] = new Label(labelContents[i], labelPositions[i]);
			}
		}

		private void InitializeButtons(Position consoleCenter)
		{
			string[] buttonContents = new string[]
			{
				" ", " ", "Sign Up", "Back"
			};

			Position[] buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left - 10, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),   // Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),      // Log In
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)   // Back
            };

			Buttons = new ILabel[buttonContents.Length];

			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i] = new Label(buttonContents[i], buttonPositions[i]);
			}
		}
	}
}
