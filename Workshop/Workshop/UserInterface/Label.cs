namespace Forum.App
{
	using Forum.App.UserInterface.Contracts;

	internal class Label : ILabel
	{
		public Label(string text, Position position, bool isHidden = false)
		{
			Text = text;
			Position = position;
			IsHidden = isHidden;
		}

		public string Text
		{
			get;
			private set;
		}

		public bool IsHidden
		{
			get;
			private set;
		}

		public Position Position
		{
			get; private set;
		}
	}
}
