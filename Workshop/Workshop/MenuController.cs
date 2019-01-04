namespace Forum.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Controllers;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;

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
            throw new NotImplementedException();
        }

        private void RedirectToAddReply()
        {
            throw new NotImplementedException();
        }

        private void LogOut()
        {
            throw new NotImplementedException();
        }

        private void SuccessfulLogin()
        {
            throw new NotImplementedException();
        }

        private void ViewPost()
        {
            throw new NotImplementedException();
        }

        private void OpenCategory()
        {
            throw new NotImplementedException();
        }

        private void AddPost()
        {
            throw new NotImplementedException();
        }

        private void RenderCurrentView()
        {
            CurrentView = CurrentController.GetView(Username);
            _currentOptionIndex = DEFAULT_INDEX;
            _forumViewer.RenderView(CurrentView);
        }

        private bool RedirectToMenu(MenuState newState)
        {
            throw new NotImplementedException();
        }

        private void LogInUser()
        {
            throw new NotImplementedException();
        }

        private void LogOutUser()
        {
            throw new NotImplementedException();
        }
    }
}