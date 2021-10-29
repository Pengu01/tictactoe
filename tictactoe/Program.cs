using System.Collections.Generic;
using System;

namespace tictactoe
{
	class Program
	{
		static void Main(string[] args)
		{
			bool running = true;
			Random rnd = new Random();
			tictac tac = new tictac();
			Console.WriteLine("Write ONLY number corresponding to where you want to place");
			while (running)
			{
				tac.board();
				int place = Convert.ToInt32(Console.ReadLine());
				while (tac.bot.Contains(place) || tac.player.Contains(place) || place < 1 || place > 9)
				{
					if (tac.bot.Contains(place) || tac.player.Contains(place))
					{
						Console.Clear();
						Console.WriteLine("Do not write used numbers");
						tac.board();
						place = Convert.ToInt32(Console.ReadLine());
					}
					if (place < 1 || place > 9)
					{
						Console.Clear();
						Console.WriteLine("Can only write the numbers 1-9");
						tac.board();
						place = Convert.ToInt32(Console.ReadLine());
					}
				}
				tac.playerplace(place);
				Console.Clear();
				running = tac.checkwin();
                if (!running)
                {
					break;
                }
				tac.botai(place);
				running = tac.checkwinbot();
			}
		}
	}
	class tictac
	{
		string[] placeArray = { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
		public List<int> player = new List<int>();
		public List<int> bot = new List<int>();
		public void playerplace(int place)
		{
			player.Add(place);
			switch (place)
			{
				case 1:
					placeArray[place - 1] = "X";
					break;
				case 2:
					placeArray[place - 1] = "X";
					break;
				case 3:
					placeArray[place - 1] = "X";
					break;
				case 4:
					placeArray[place - 1] = "X";
					break;
				case 5:
					placeArray[place - 1] = "X";
					break;
				case 6:
					placeArray[place - 1] = "X";
					break;
				case 7:
					placeArray[place - 1] = "X";
					break;
				case 8:
					placeArray[place - 1] = "X";
					break;
				case 9:
					placeArray[place - 1] = "X";
					break;
			}
		}
		public void board()
		{
			Console.Write("|" + placeArray[0] + placeArray[1] + placeArray[2] + "|\n");
			Console.Write("|" + placeArray[3] + placeArray[4] + placeArray[5] + "|\n");
			Console.Write("|" + placeArray[6] + placeArray[7] + placeArray[8] + "|\n");
		}
		public bool checkwin()
		{
			if (player.Contains(1) && player.Contains(2) && player.Contains(3) || player.Contains(4) && player.Contains(5) && player.Contains(6) || player.Contains(7) && player.Contains(8) && player.Contains(9))
			{
				board();
				Console.WriteLine("Horizontal win!");
				return false;
			}
			else if (player.Contains(1) && player.Contains(4) && player.Contains(7) || player.Contains(2) && player.Contains(5) && player.Contains(8) || player.Contains(3) && player.Contains(6) && player.Contains(9))
			{
				board();
				Console.WriteLine("Vertical win!");
				return false;
			}
			else if (player.Contains(1) && player.Contains(5) && player.Contains(9) || player.Contains(3) && player.Contains(5) && player.Contains(7))
			{
				board();
				Console.WriteLine("Diagonal win!");
				return false;
			}
			else return true;
		}
		public bool checkwinbot()
		{
			if (bot.Contains(1) && bot.Contains(2) && bot.Contains(3) || bot.Contains(4) && bot.Contains(5) && bot.Contains(6) || bot.Contains(7) && bot.Contains(8) && bot.Contains(9))
			{
				board();
				Console.WriteLine("Horizontal loss!");
				return false;
			}
			else if (bot.Contains(1) && bot.Contains(4) && bot.Contains(7) || bot.Contains(2) && bot.Contains(5) && bot.Contains(8) || bot.Contains(3) && bot.Contains(6) && bot.Contains(9))
			{
				board();
				Console.WriteLine("Vertical loss!");
				return false;
			}
			else if (bot.Contains(1) && bot.Contains(5) && bot.Contains(9) || bot.Contains(3) && bot.Contains(5) && bot.Contains(7))
			{
				board();
				Console.WriteLine("Diagonal loss!");
				return false;
			} else if (placeArray[0] != "_" && placeArray[1] != "_" && placeArray[2] != "_" && placeArray[3] != "_" && placeArray[4] != "_" && placeArray[5] != "_" && placeArray[6] != "_" && placeArray[7] != "_" && placeArray[8] != "_")
            {
				board();
				Console.WriteLine("No more moves!");
				return false;
			}
			else return true;
		}
		public void botai(int place)
        {
			bool foundwin = false;
            if (bot.Contains(2) && bot.Contains(3) && !player.Contains(1) || bot.Contains(4) && bot.Contains(7) && !player.Contains(1) || bot.Contains(5) && bot.Contains(9) && !player.Contains(1))
            {
				placeArray[0] = "O";
				bot.Add(1);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(3) && !player.Contains(2) || bot.Contains(5) && bot.Contains(8) && !player.Contains(2))
			{
				placeArray[1] = "O";
				bot.Add(2);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(2) && !player.Contains(3) || bot.Contains(5) && bot.Contains(7) && !player.Contains(3) || bot.Contains(6) && bot.Contains(9) && !player.Contains(3))
			{
				placeArray[2] = "O";
				bot.Add(3);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(7) && !player.Contains(4) || bot.Contains(5) && bot.Contains(6) && !player.Contains(4))
			{
				placeArray[3] = "O";
				bot.Add(4);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(9) && !player.Contains(5) || bot.Contains(3) && bot.Contains(7) && !player.Contains(5) || bot.Contains(4) && bot.Contains(6) && !player.Contains(5) || bot.Contains(2) && bot.Contains(8) && !player.Contains(5))
			{
				placeArray[4] = "O";
				bot.Add(5);
				foundwin = true;
			}
			if (bot.Contains(3) && bot.Contains(9) && !player.Contains(6) || bot.Contains(4) && bot.Contains(5) && !player.Contains(6))
			{
				placeArray[5] = "O";
				bot.Add(6);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(4) && !player.Contains(7) || bot.Contains(5) && bot.Contains(3) && !player.Contains(7) || bot.Contains(8) && bot.Contains(9) && !player.Contains(7))
			{
				placeArray[6] = "O";
				bot.Add(7);
				foundwin = true;
			}
			if (bot.Contains(7) && bot.Contains(9) && !player.Contains(8) || bot.Contains(2) && bot.Contains(5) && !player.Contains(8))
			{
				placeArray[7] = "O";
				bot.Add(8);
				foundwin = true;
			}
			if (bot.Contains(1) && bot.Contains(5) && !player.Contains(9) || bot.Contains(7) && bot.Contains(8) && !player.Contains(9) || bot.Contains(3) && bot.Contains(6) && !player.Contains(9))
			{
				placeArray[8] = "O";
				bot.Add(9);
				foundwin = true;
			}
			if (!foundwin)
			{
				switch (place)
				{
					case 1:
						if (player.Contains(2) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(3) && !bot.Contains(2))
						{
							placeArray[1] = "O";
							bot.Add(2);
							break;
						}
						if (player.Contains(5) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(9) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (player.Contains(4) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(4))
						{
							placeArray[3] = "O";
							bot.Add(4);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 2:
						if (player.Contains(1) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(3) && !bot.Contains(1))
						{
							placeArray[0] = "O";
							bot.Add(1);
							break;
						}
						if (player.Contains(5) && !bot.Contains(8))
						{
							placeArray[7] = "O";
							bot.Add(8);
							break;
						}
						if (player.Contains(8) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 3:
						if (player.Contains(2) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(1) && !bot.Contains(2))
						{
							placeArray[1] = "O";
							bot.Add(2);
							break;
						}
						if (player.Contains(5) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (player.Contains(6) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(9) && !bot.Contains(6))
						{
							placeArray[5] = "O";
							bot.Add(6);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 4:
						if (player.Contains(1) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(1))
						{
							placeArray[0] = "O";
							bot.Add(1);
							break;
						}
						if (player.Contains(5) && !bot.Contains(6))
						{
							placeArray[5] = "O";
							bot.Add(6);
							break;
						}
						if (player.Contains(6) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 5:
						if (player.Contains(1) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(9) && !bot.Contains(1))
						{
							placeArray[0] = "O";
							bot.Add(1);
							break;
						}
						if (player.Contains(3) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(2) && !bot.Contains(8))
						{
							placeArray[7] = "O";
							bot.Add(8);
							break;
						}
						if (player.Contains(8) && !bot.Contains(2))
						{
							placeArray[1] = "O";
							bot.Add(2);
							break;
						}
						if (player.Contains(4) && !bot.Contains(6))
						{
							placeArray[5] = "O";
							bot.Add(6);
							break;
						}
						if (player.Contains(6) && !bot.Contains(4))
						{
							placeArray[3] = "O";
							bot.Add(4);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 6:
						if (player.Contains(3) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(9) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(4) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (player.Contains(5) && !bot.Contains(4))
						{
							placeArray[3] = "O";
							bot.Add(4);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 7:
						if (player.Contains(1) && !bot.Contains(4))
						{
							placeArray[3] = "O";
							bot.Add(4);
							break;
						}
						if (player.Contains(4) && !bot.Contains(1))
						{
							placeArray[0] = "O";
							bot.Add(1);
							break;
						}
						if (player.Contains(5) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(3) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (player.Contains(8) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(9) && !bot.Contains(8))
						{
							placeArray[7] = "O";
							bot.Add(8);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 8:
						if (player.Contains(9) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(9))
						{
							placeArray[8] = "O";
							bot.Add(9);
							break;
						}
						if (player.Contains(5) && !bot.Contains(2))
						{
							placeArray[1] = "O";
							bot.Add(2);
							break;
						}
						if (player.Contains(2) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
					case 9:
						if (player.Contains(8) && !bot.Contains(7))
						{
							placeArray[6] = "O";
							bot.Add(7);
							break;
						}
						if (player.Contains(7) && !bot.Contains(8))
						{
							placeArray[7] = "O";
							bot.Add(8);
							break;
						}
						if (player.Contains(6) && !bot.Contains(3))
						{
							placeArray[2] = "O";
							bot.Add(3);
							break;
						}
						if (player.Contains(3) && !bot.Contains(6))
						{
							placeArray[5] = "O";
							bot.Add(6);
							break;
						}
						if (player.Contains(5) && !bot.Contains(1))
						{
							placeArray[0] = "O";
							bot.Add(1);
							break;
						}
						if (player.Contains(1) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						if (!player.Contains(5) && !bot.Contains(5))
						{
							placeArray[4] = "O";
							bot.Add(5);
							break;
						}
						for (int i = 1; i < 10; i++)
						{
							if (!player.Contains(i) && !bot.Contains(i))
							{
								placeArray[i - 1] = "O";
								bot.Add(i);
								break;
							}
						}
						break;
				}
			}
		}
	}
}
