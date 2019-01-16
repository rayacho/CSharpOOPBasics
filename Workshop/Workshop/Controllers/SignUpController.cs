namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface;
	using Forum.App.UserInterface.Contracts;
	using System;
	using Workshop.Controllers.Services;

	public class SignUpController : IController, IReadUserInfoController
	{
		private enum Command
		{
			ReadUsername, ReadPassword, SingUp, Back
		}

		public enum SingUpStatus
		{
			Success, DetailsError, UsernameTakenError
		}

		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

		private string ErrorMessage { get; set;	}

		public string Username { get; set; }

		public string Password { get; set; }

		public MenuState ExecuteCommand(int index)
		{
			switch ((Command)index)
			{
				case Command.ReadUsername:
					ReadUsername();
					return MenuState.Signup;
				case Command.ReadPassword:
					ReadPassword();
					return MenuState.Signup;
				case Command.SingUp:
					SingUpStatus signedUp = UsersService.TrySignUpUser(Username, Password);

					switch (signedUp)
					{
						case SingUpStatus.Success:
							return MenuState.SuccessfulLogIn;
						case SingUpStatus.DetailsError:
							ErrorMessage = DETAILS_ERROR;
							return MenuState.Error;
						case SingUpStatus.UsernameTakenError:
							ErrorMessage = USERNAME_TAKEN_ERROR;
							return MenuState.Error;
					}

					return MenuState.Error;
				case Command.Back:
					ResetSingUp();
					return MenuState.Back;
				default:
					throw new NotSupportedException();
			}
		}

		public IView GetView(string userName)
		{
			return new SignUpView(ErrorMessage);
		}

		public void ReadPassword()
		{
			Password = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}

		public void ReadUsername()
		{
			Username = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}

		private void ResetSingUp()
		{
			Username = string.Empty;
			ErrorMessage = string.Empty;
			Password = string.Empty;
		}
	}
}
