namespace Forum.App.UserInterface.Input
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Forum.App.UserInterface.Contracts;

	public class TextArea : IInput
	{
		private int _x;
		private int _y;
		private int _width;
		private int _height;
		private int _textCursorPosition;
		private Position _displayCursor;
		private const int OFFSET = 37;
		private IEnumerable<string> _lines = new List<string>();
		private string _text = string.Empty;
		private static char[] _forbiddenCharacters = { ';' };

		private int MaxLength { get; set; }

		public int Left { get => _x; }
		public int Top { get => _y; }

		public IEnumerable<string> Lines
		{
			get => _lines;
		}

		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				_lines = StringProcessor.Split(value);
			}
		}

		public Position DisplayCursor
		{
			get => _displayCursor;
		}

		public TextArea(int x, int y, int width, int height, int maxLength)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
			_displayCursor = new Position(x, y);
			MaxLength = maxLength;
		}

		public bool AddCharacter(char character)
		{
			if (Text.Length < MaxLength)
			{
				string stringBefore = Text.Substring(0, _textCursorPosition);
				string stringAfter = Text.Substring(_textCursorPosition, Text.Length - _textCursorPosition);

				Text = stringBefore + character + stringAfter;

				_textCursorPosition++;
				ForumViewEngine.DrawTextArea(this);
				return true;
			}
			return false;
		}

		internal void Write()
		{
			ForumViewEngine.DrawTextArea(this);
			ForumViewEngine.ShowCursor();

			while (true)
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				ConsoleKey key = keyInfo.Key;

				if (key == ConsoleKey.Backspace)
				{
					Delete();
				}
				else if (Text.Length == MaxLength || _forbiddenCharacters.Contains(keyInfo.KeyChar))
				{
					Console.Beep(415, 260);
					continue;
				}
				else if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
				{
					break;
				}
				else
				{
					AddCharacter(keyInfo.KeyChar);
				}
			}

			ForumViewEngine.HideCursor();
		}

		public void Delete()
		{
			if (_textCursorPosition > 0)
			{
				string stringBefore = Text.Substring(0, _textCursorPosition);
				string stringAfter = Text.Substring(_textCursorPosition, Text.Length - _textCursorPosition);

				stringBefore = stringBefore.Substring(0, stringBefore.Length - 1);
				Text = stringBefore + stringAfter;
				_textCursorPosition--;
				ForumViewEngine.DrawTextArea(this);
			}
			_lines = StringProcessor.Split(Text);
		}
	}
}
