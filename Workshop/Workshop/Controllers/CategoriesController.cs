﻿namespace Forum.App.Controllers
{
	using System;
	using System.Linq;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.Views;
	using Workshop.Controllers.Services;

	public class CategoriesController : IController, IPaginationController
	{
		public const int PageOffset = 10;
		private const int CommandCount = PageOffset + 3;

		private enum Command
		{
			Back = 0,
			ViewCategory = 1,
			PreviousPage = 11,
			NextPage = 12
		};

		public int CurrentPage { get; set; }
		private string[] AllCategoryNames { get; set; }
		private string[] CurrentCategoryNames { get; set; }

		private int LastPage => AllCategoryNames.Length / (PageOffset + 1);

		private bool IsFirstPage => CurrentPage == 0;

		private bool IsLastPage => CurrentPage == LastPage;

		public CategoriesController()
		{
			CurrentPage = 0;
			LoadCategories();
		}

		private void ChangePage(bool forward = true)
		{
			CurrentPage += forward ? 1 : -1;
		}

		public MenuState ExecuteCommand(int index)
		{
			if (index > 1 && index < 11)
			{
				index = 1;
			}

			switch ((Command)index)
			{
				case Command.Back:
					return MenuState.Back;
				case Command.ViewCategory:
					return MenuState.OpenCategory;
				case Command.PreviousPage:
					ChangePage(false);
					return MenuState.Rerender;
				case Command.NextPage:
					ChangePage();
					return MenuState.Rerender;
			}

			throw new InvalidOperationException();
		}

		public IView GetView(string userName)
		{
			LoadCategories();
			return new CategoriesView(CurrentCategoryNames, IsFirstPage, IsLastPage);
		}

		private void LoadCategories()
		{
			AllCategoryNames = PostService.GetAllCategoryNames();
			CurrentCategoryNames = AllCategoryNames
				.Skip(CurrentPage * PageOffset)
				.Take(PageOffset)
				.ToArray();
		}
	}
}
