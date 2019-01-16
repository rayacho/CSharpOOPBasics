using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Forum.Data
{
	public class DataMapper
	{
		private const string DataPath = @"C:\Users\RAYA CHORBADZHIYSKA\Desktop\CSharpOOPBasics\CSharpOOPBasics\Workshop\data";
		private const string ConfigPath = "config.ini";
		private const string DefaultConfig = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

		private static readonly Dictionary<string, string> config;

		static DataMapper()
		{
			Directory.CreateDirectory(DataPath);
			config = LoadConfig(DataPath + ConfigPath);
		}

		private static void EnsureConfigFile(string configPath)
		{
			if (!File.Exists(configPath))
			{
				File.WriteAllText(configPath, DefaultConfig);
			}
		}

		private static void EnsureFile(string path)
		{
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
		}

		private static string[] ReadLines(string path)
		{
			EnsureFile(path);
			string[] lines = File.ReadAllLines(path);
			return lines;
		}

		private static void WriteLines(string path, string[] lines)
		{
			File.WriteAllLines(path, lines);
		}

		private static Dictionary<string, string> LoadConfig(string configPath)
		{
			EnsureConfigFile(configPath);
			string[] lines = ReadLines(configPath);

			Dictionary<string, string> result = lines.Select(l => l.Split('='))
				.ToDictionary(l => l[0], l => DataPath + l[1]);
			return result;
		}

		public static List<Category> LoadCategories()
		{
			string[] lines = ReadLines(config["categories"]);
			List<Category> categories = new List<Category>();

			foreach (string line in lines)
			{
				string[] splitLine = line.Split(";");
				List<int> postIds = splitLine[2].Split(',').Select(int.Parse).ToList();
				Category category = new Category(int.Parse(splitLine[0]),
					splitLine[1],
					postIds);
				categories.Add(category);
			}

			return categories;
		}

		public static void SaveCategories(List<Category> categories)
		{
			List<string> lines = new List<string>();

			foreach (Category category in categories)
			{

				const string categoryFormat = "{0};{1};{2}";
				string line = string.Format(categoryFormat,
					category.Id,
					category.Name,
					string.Join(',', category.PostIds));

				lines.Add(line);
			}

			WriteLines(config["categories"], lines.ToArray());
		}

		public static List<User> LoadUsers()
		{
			List<User> users = new List<User>();
			string[] dataLines = ReadLines(config["users"]);

			foreach (string line in dataLines)
			{
				string[] args = line.Split(";");
				int id = int.Parse(args[0]);
				string username = args[1];
				string password = args[2];
				int[] postIds = args[3]
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				User user = new User(id, username, password, postIds);
				users.Add(user);
			}

			return users;
		}

		public static void SaveUsers(List<User> users)
		{
			List<string> lines = new List<string>();

			foreach (User user in users)
			{
				const string userFormat = "{0};{1};{2};{3}";
				string line = string.Format(userFormat,
					user.Id,
					user.Username,
					user.Password,
					string.Join(',', user.PostIds));

				lines.Add(line);
			}

			WriteLines(config["users"], lines.ToArray());
		}

		public static List<Post> LoadPosts()
		{
			List<Post> posts = new List<Post>();
			string[] dataLines = ReadLines(config["posts"]);

			foreach (string line in dataLines)
			{
				string[] args = line.Split(";");
				int id = int.Parse(args[0]);
				string title = args[1];
				string content = args[2];
				int categoryId = int.Parse(args[3]);
				int authorId = int.Parse(args[4]);
				int[] replyIds = args[5]
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				Post post = new Post(id, title, content, categoryId, authorId, replyIds);

				posts.Add(post);
			}

			return posts;
		}

		public static void SavePosts(List<Post> posts)
		{
			List<string> lines = new List<string>();

			foreach (Post post in posts)
			{
				const string postFormat = "{0};{1};{2};{3};{4};{5}";
				string line = string.Format(postFormat,
					post.Id,
					post.Title,
					post.Content,
					post.CategoryId,
					post.AuthorId,
					string.Join(',', post.ReplyIds));
				lines.Add(line);
			}

			WriteLines(config["posts"], lines.ToArray());
		}

		public static List<Reply> LoadReplies()
		{
			string[] lines = ReadLines(config["replies"]);
			List<Reply> replies = new List<Reply>();

			foreach (string line in lines)
			{
				string[] args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				int id = int.Parse(args[0]);
				string content = args[1];
				int authorId = int.Parse(args[2]);
				int postId = int.Parse(args[3]);

				Reply reply = new Reply(id, content, authorId, postId);

				replies.Add(reply);
			}

			return replies;
		}

		public static void SaveReplies(List<Reply> replies)
		{
			List<string> lines = new List<string>();

			foreach (Reply reply in replies)
			{
				const string replyFormat = "{0};{1};{2};{3}";
				string line = string.Format(replyFormat,
					reply.Id,
					reply.Content,
					reply.AuthorId,
					reply.PostId);

				lines.Add(line);
			}

			WriteLines(config["replies"], lines.ToArray());
		}
	}
}
