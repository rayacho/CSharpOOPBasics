namespace Forum.App.Controllers
{
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.ViewModels;
	using Forum.App.Views;
	using Workshop.Controllers.Services;

	public class PostDetailsController : IController, IUserRestrictedController
	{
		private enum Command
		{
			Back,
			AddReply
		}

		public bool LoggedInUser { get; set; }

		public int PostId { get; private set; }

		public MenuState ExecuteCommand(int index)
		{
			switch ((Command)index)
			{
				case Command.Back:
					break;
				case Command.AddReply:
					break;
				default:
					break;
			}

			throw new InvalidCommandException();
		}

		public IView GetView(string userName)
		{
			PostViewModel postViewModel = PostService.GetPostViewModel(PostId);
			return new PostDetailsView(postViewModel, LoggedInUser);
		}

		public void UserLogIn()
		{
			LoggedInUser = true;
		}

		public void UserLogOut()
		{
			LoggedInUser = false;
		}

		public void SetPostId(int postId)
		{
			PostId = postId;
		}
	}
}
