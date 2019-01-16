namespace Forum.App
{
	using System;
	using System.Collections.Generic;
	using Forum.App.Controllers;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface;

	public class Engine
	{
		private ForumViewEngine _forumViewer;
		private MenuController _menuController;
		private IEnumerable<IController> _controllers;

		public Engine()
		{
			_forumViewer = new ForumViewEngine();
			_controllers = InitializeControllers();
			_menuController = new MenuController(_controllers, _forumViewer);
		}

		internal void Run()
		{
			while (true)
			{
				_forumViewer.Mark(_menuController.CurrentLabel);

				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				ConsoleKey key = keyInfo.Key;

				_forumViewer.Mark(_menuController.CurrentLabel, false);

				switch (key)
				{
					case ConsoleKey.Backspace:
					case ConsoleKey.Escape:
						_menuController.Back();
						break;
					case ConsoleKey.Home:
						break;
					case ConsoleKey.LeftArrow:
					case ConsoleKey.UpArrow:
						_menuController.PreviousOption();
						break;
					case ConsoleKey.Tab:
					case ConsoleKey.RightArrow:
					case ConsoleKey.DownArrow:
						_menuController.NextOption();
						break;
					case ConsoleKey.Enter:
						_menuController.ExecuteCommand();
						break;
				}
			}
		}

		private IEnumerable<IController> InitializeControllers()
		{
			List<IController> controllers = new List<IController>
			{
				new MainController(),
				new LogInController(),
				new CategoriesController(),
				new CategoryController(),
				new SignUpController(),
				new PostDetailsController(),
				new AddPostController(),
				new AddReplyController(),
			};

			return controllers;
		}
	}
}
