namespace Forum.App
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Forum.App.Controllers;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface;
	using Forum.App.UserInterface.Contracts;
	using Workshop.Controllers.Services;

	internal class MenuController
	{
		private const int DEFAULT_INDEX = 0;

		private IController[] _controllers;
		private Stack<int> _controllerHistory;
		private int _currentOptionIndex;
		private ForumViewEngine _forumViewer;

		public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
		{
			_controllers = controllers.ToArray();
			_forumViewer = forumViewer;

			InitializeControllerHistory();

			_currentOptionIndex = DEFAULT_INDEX;
		}

		private string Username { get; set; }

		private IView CurrentView { get; set; }

		private MenuState State => (MenuState)_controllerHistory.Peek();
		private int CurrentControllerIndex => _controllerHistory.Peek();
		private IController CurrentController => _controllers[_controllerHistory.Peek()];
		internal ILabel CurrentLabel => CurrentView.Buttons[_currentOptionIndex];

		private void InitializeControllerHistory()
		{
			if (_controllerHistory != null)
			{
				throw new InvalidOperationException($"{nameof(_controllerHistory)} already initialized!");
			}

			int mainControllerIndex = 0;
			_controllerHistory = new Stack<int>();
			_controllerHistory.Push(mainControllerIndex);
			RenderCurrentView();
		}

		internal void PreviousOption()
		{
			_currentOptionIndex--;

			if (_currentOptionIndex < 0)
			{
				_currentOptionIndex += CurrentView.Buttons.Length;
			}

			if (CurrentLabel.IsHidden)
			{
				PreviousOption();
			}
		}

		internal void NextOption()
		{
			_currentOptionIndex++;

			int totalOptions = CurrentView.Buttons.Length;

			if (_currentOptionIndex >= totalOptions)
			{
				_currentOptionIndex -= totalOptions;
			}

			if (CurrentLabel.IsHidden)
			{
				NextOption();
			}
		}

		internal void Back()
		{
			if (State == MenuState.Categories || State == MenuState.OpenCategory)
			{
				IPaginationController currentController = (IPaginationController)CurrentController;
				currentController.CurrentPage = 0;
			}

			if (_controllerHistory.Count > 1)
			{
				_controllerHistory.Pop();
				_currentOptionIndex = DEFAULT_INDEX;
			}

			RenderCurrentView();
		}

		internal void ExecuteCommand()
		{
			MenuState newState = CurrentController.ExecuteCommand(_currentOptionIndex);

			switch (newState)
			{
				case MenuState.PostAdded:
					AddPost();
					break;
				case MenuState.OpenCategory:
					OpenCategory();
					break;
				case MenuState.ViewPost:
					ViewPost();
					break;
				case MenuState.SuccessfulLogIn:
					SuccessfulLogin();
					break;
				case MenuState.LoggedOut:
					LogOut();
					break;
				case MenuState.Back:
					Back();
					break;
				case MenuState.Error:
				case MenuState.Rerender:
					RenderCurrentView();
					break;
				case MenuState.AddReplyToPost:
					RedirectToAddReply();
					break;
				case MenuState.ReplyAdded:
					AddReply();
					break;
				default:
					RedirectToMenu(newState);
					break;
			}
		}

		private void AddReply()
		{
			_controllerHistory.Pop();
			RenderCurrentView();
		}

		private void RedirectToAddReply()
		{
			PostDetailsController postDetailsController = (PostDetailsController)CurrentController;
			AddReplyController addReplyController = (AddReplyController)_controllers[(int)MenuState.AddReply];
			addReplyController.GetPostViewModel(postDetailsController.PostId);
			RedirectToMenu(MenuState.AddReply);
		}

		private void LogOut()
		{
			Username = string.Empty;
			LogOutUser();
			RenderCurrentView();
		}

		private void SuccessfulLogin()
		{
			Username = ((IReadUserInfoController)CurrentController).Username;
			LogInUser();
			RedirectToMenu(MenuState.Main);
		}

		private void ViewPost()
		{
			CategoryController categoryController = (CategoryController)CurrentController;

			int categoryId = categoryController.CategoryId;

			var posts = PostService.GetPostsByCategory(categoryId).ToArray();

			int postIndex = categoryController.CurrentPage * CategoryController.PAGE_OFFSET + _currentOptionIndex;
			int postId = posts[postIndex - 1].Id;

			PostDetailsController postController = (PostDetailsController)_controllers[(int)MenuState.ViewPost];
			postController.SetPostId(postId);

			RedirectToMenu(MenuState.ViewPost);
		}

		private void OpenCategory()
		{
			CategoriesController categoriesController = (CategoriesController)CurrentController;
			int categoryIndex = categoriesController.CurrentPage * CategoriesController.PAGE_OFFSET +
				_currentOptionIndex;

			CategoryController categoryController = (CategoryController)_controllers[(int)MenuState.OpenCategory];
			categoryController.SetCategory(_currentOptionIndex);
			RedirectToMenu(MenuState.OpenCategory);
		}

		private void AddPost()
		{
			AddPostController addPostController = (AddPostController)CurrentController;
			int postId = addPostController.Post.PostId;
			PostDetailsController postViewer = (PostDetailsController)_controllers[(int)MenuState.ViewPost];

			postViewer.SetPostId(postId);
			addPostController.ResetPost();

			_controllerHistory.Pop();

			RedirectToMenu(MenuState.ViewPost);
		}

		private void RenderCurrentView()
		{
			CurrentView = CurrentController.GetView(Username);
			_currentOptionIndex = DEFAULT_INDEX;
			_forumViewer.RenderView(CurrentView);
		}

		private bool RedirectToMenu(MenuState newState)
		{
			if (State != newState)
			{
				_controllerHistory.Push((int)newState);
				RenderCurrentView();
				return true;
			}

			return false;
		}

		private void LogInUser()
		{
			foreach (IController controller in _controllers)
			{
				if (controller is IUserRestrictedController userRestrictedController)
				{
					userRestrictedController.UserLogIn();
				}
			}
		}

		private void LogOutUser()
		{
			foreach (IController controller in _controllers)
			{
				if (controller is IUserRestrictedController userRestrictedController)
				{
					userRestrictedController.UserLogOut();
				}
			}
		}
	}
}