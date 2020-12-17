using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
// C:\Program Files\Microsoft.NET\slither score.txt

namespace SlitherIO
{
	public delegate void Check(int x, int y); // 델리게이트 선언
	
	class MainApp : Form
	{
		static MainApp Mainform;
		static System.Windows.Forms.Button BStart;
		static System.Windows.Forms.Button BExit;

		public static void Main(string[] args)
		{
			Mainform = new MainApp();
			Mainform.Text = "Slither.IO";
			Mainform.Size = new Size(210, 210);
			Mainform.MaximizeBox = false;
			Mainform.CenterToScreen();

			BStart = new Button();
			BStart.Text = "시작";
			BStart.Size = new Size(100, 40);
			BStart.Location = new Point(47, 30);
			
			BExit = new Button();
			BExit.Text = "종료";
			BExit.Size = new Size(100, 40);
			BExit.Location = new Point(47, 100);	

			BStart.Click += (object sender, EventArgs e) => GameBoard.Start();
			BExit.Click += (object sender, EventArgs e) => Application.Exit();

			Mainform.Controls.Add(BStart);
			Mainform.Controls.Add(BExit);
			
			Application.Run(Mainform);
		}
	} // class MainApp End
	
	class Player
	{
		public static Player User;
		public List<int> XPoint = new List<int>(); // 지렁이 x 좌표 저장.
		public List<int> YPoint = new List<int>(); // 지렁이 y 좌표 저장.
		public string Direction; // 지렁이의 이동방향.
		public string OldDirection;
		public static Thread MoveThread;
		public static Check CheckAll;
		private static bool Gaming;
		private static int Speed;
		public static int Score;
		public static int GotFeed;
		public static Label ScoreNum;
	
		public static void SetBasic()
		{
			User = new Player();

			User.BlockAdd(15, 5);
			User.BlockAdd(16, 5);
			User.BlockAdd(17, 5);
			User.Direction = "Down"; // 처음 시작할 때 지렁이 가는 방향
			User.OldDirection = User.Direction;

			CheckAll = OverCheck; 
			CheckAll += GetCheck; // 델리게이트 체인

			Gaming = true;
			Score = 0;
			Speed = 350;
			GotFeed = 0;

			MoveThread = new Thread(new ThreadStart(MoveUser));
			MoveThread.Start();
		} 

		public static void MoveUser()
		{
			while(true)
			{
				Thread.Sleep(Speed);
				Moving();
				if(!Gaming)
				{
					break;
				}
			}
			MoveThread.Abort();
			// add a code about record		
		} 

		public static void Moving()
		{
			if(Gaming)
			{
				switch(User.Direction)
				{
					case "Left" :
						CheckAll(User.XPoint[0] - 1, User.YPoint[0]);
						User.IndexMove();
						User.XPoint[0]--;
						break;

					case "Right" :
						CheckAll(User.XPoint[0] + 1, User.YPoint[0]);
						User.IndexMove();
						User.XPoint[0]++;
						break;

					case "Up" :
						CheckAll(User.XPoint[0], User.YPoint[0] - 1);
						User.IndexMove();
						User.YPoint[0]--;
						break;

					case "Down" :
						CheckAll(User.XPoint[0], User.YPoint[0] + 1);
						User.IndexMove();
						User.YPoint[0]++;
						break;
				}
			}
			GameBoard.Field.Refresh();  // GUI 최신화.
		} 
	
		private void IndexMove()
		{
			for(int i = this.YPoint.Count - 1; i > 0; i--)
			{
				this.XPoint[i] = this.XPoint[i - 1];
				this.YPoint[i] = this.YPoint[i - 1];
			}
			this.OldDirection = this.Direction;	
		}

		private static void GetCheck(int x, int y)
		{
			if(x == GameBoard.Feed[0] && y == GameBoard.Feed[1])
			{
				User.BlockAdd(GameBoard.Feed[0], GameBoard.Feed[1]); // 먹이 먹은 즉시 지렁이 몸에 추가.
				Score++;
				GotFeed++;
				Console.WriteLine("Score = {0}, GotFeed = " + GetFeed(), Score) ;
				if(Speed > 150)
				{
					Speed -= 20;
				}
				GameBoard.SetFeed(); // 다시 먹이 만들고
				GameBoard.SetObstacle();
			}	
		}  

		private static void OverCheck(int x, int y)
		{
			if(x < 0 || y < 0 || x >= GameBoard.FieldX || y >= GameBoard.FieldY) // 범위 밖을 벗어나면 종료.
			{
				Gaming = false; 
			}

			for(int i = User.XPoint.Count - 1; i > 0; i--) // 지렁이의 몸통에 부딪히면 종료.
			{	
				if(User.XPoint[0] == User.XPoint[i] && User.YPoint[0] == User.YPoint[i]) // User.XPoint[0]과 User.YPoint[0]이 머리
				{
					Gaming = false;	
				}
			}
			
			for(int i = 0; i < GameBoard.ObstacleX.Length; i++)
			{
				if(x == GameBoard.ObstacleX[i] && y == GameBoard.ObstacleY[i]) // 장애물 충돌하면
				{
					Gaming = false;
				}
			}

			if(!Gaming) // 게임 종료되면
			{
				if(MessageBox.Show("Do you want restart?", "Game Over!",  MessageBoxButtons.YesNo) == DialogResult.Yes) Gaming = true;
				else Application.Exit();
			}
		} 

		private void BlockAdd(int x, int y) 
		{
			this.XPoint.Add(x);
			this.YPoint.Add(y);
		} 

		public static string GetFeed()
		{
			return GotFeed.ToString();
		}	

	} // class Player End.

	class GameBoard : Form
	{
		public static GameBoard Field;
		public const int FieldX = 30; 
		public const int FieldY = 20; 
		public static int[] Feed = new int[2];
		public static int[] ObstacleX = new int[30];
		public static int[] ObstacleY = new int[30];
		private static Random random = new Random();
		
		/* public GameBoard()
		{
			this.Field = new GameBoard();
			this.Feed = new int[2];
			this.ObstacleX = new int[30];
			this.ObstacleY = new int[30];
			random = new Random();
		}*/

		public static void Key_Down(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Left : 
					if(Player.User.OldDirection != "Right")
					{
						Player.User.Direction = "Left";
					}
					break;

				case Keys.Right : 
					if(Player.User.OldDirection != "Left")
					{
						Player.User.Direction = "Right";
					}
					break;
				
				case Keys.Up : 
					if(Player.User.OldDirection != "Down")
					{
						Player.User.Direction = "Up";
					}
					break;
			
				case Keys.Down :
					if(Player.User.OldDirection != "Up")
					{
						Player.User.Direction = "Down";
					}
					break;
			}
		} 

		public static void SetFeed()
		{
			Feed = SetBlock();
		}

		public static void SetObstacle() // 지렁이 위치와 장애물 생성 위치 겹치지 않게 조정해야 함.
		{
			StackOverFlowException:

			for(int i = 0; i < ObstacleX.Length; i++)
			{
				ObstacleX[i] = random.Next(1, FieldX);
				ObstacleY[i]  = random.Next(1, FieldY);		
			}
			
			for(int i = 0; i < ObstacleX.Length; i++)
			{
				if(Feed[0] == ObstacleX[i] && Feed[1] == ObstacleY[i])
				{
					// SetObstacle();
					goto StackOverFlowException;
				}
			
			
				for(int j = 0; j < Player.User.XPoint.Count; j++)
				{
					if(Player.User.XPoint[j] == ObstacleX[i] && Player.User.YPoint[j] == ObstacleY[i])
					{
						// SetObstacle();
						goto StackOverFlowException;
					}
				}
			}		
		} 

		private static int[] SetBlock() // Feed Block 생성해서 전달
		{
			int[] Position = new Int32[2];

			Position[0] = random.Next(1, FieldX - 1);    
			Position[1] = random.Next(1, FieldY - 1);  

			for(int i = 0; i < Player.User.XPoint.Count; i++) // 만약 지렁이가 지나가는 위치에 Feed가 생성되면 SetBlock() 다시 실행.
			{
				if(Player.User.XPoint[i] == Position[0] && Player.User.YPoint[i] == Position[1])
				{ 
					return SetBlock(); 
				}
			}
			return Position;
		}

		public static void Start()
		{
			Player.SetBasic();
			SetFeed();
			SetObstacle();
			
			Field = new GameBoard();
			Field.Text = "Slither.IO";
			Field.Size = new Size(1100, 600);
			Field.DoubleBuffered = true;
			Field.CenterToScreen();

			Label LFeed = new Label();
			LFeed.Text = "먹은 Feed  : ";
			LFeed.AutoSize = true;
			LFeed.Location = new Point(820, 500);
			LFeed.Font = new Font("Arial", 20);
			LFeed.TextAlign = ContentAlignment.MiddleCenter;

			Player.ScoreNum = new Label();
			Player.ScoreNum.Text = Player.GetFeed();
			Console.WriteLine(Player.Score); // 업데이트가 안 되고 있음
			Player.ScoreNum.AutoSize = true;
			Player.ScoreNum.Font = new Font("Arial", 20);
			Player.ScoreNum.Location = new Point(990, 500);
			Player.ScoreNum.TextAlign = ContentAlignment.MiddleCenter;

			Field.Paint += new PaintEventHandler(GUI.Painting);
			Field.KeyDown += new KeyEventHandler(Key_Down);
			Field.Closing += (object sender, CancelEventArgs e) =>
			{
				Player.MoveThread.Abort();
				Player.MoveThread.Join();
			};
	
			Field.Controls.Add(LFeed);
			Field.Controls.Add(Player.ScoreNum);

			Field.ShowDialog();
		} 
 
	}  // class GameBoard End.

	internal class GUI
	{
		public static void Painting(object sender, PaintEventArgs e)
		{
			DrawTabel(e.Graphics);
			DrawBlock(e.Graphics);
		}

		public static void DrawTabel(Graphics g) // BackGround
		{
			for(int i = 0; i < GameBoard.FieldX; i++)
			{
				for(int j = 0; j < GameBoard.FieldY; j++)
				{
					DrawBlock(g, Color.Black, i, j);
				}
			}
		}

		private static void DrawBlock(Graphics g)
		{
			for(int i = 0; i < Player.User.XPoint.Count; i++)
			{
				DrawBlock(g, Color.White, Player.User.XPoint[i], Player.User.YPoint[i]); // 지렁이
			}
			DrawBlock(g, Color.Blue, GameBoard.Feed[0], GameBoard.Feed[1]); // Feed
			for(int i = 0; i < GameBoard.ObstacleX.Length; i++)
			{
				DrawBlock(g, Color.Red, GameBoard.ObstacleX[i], GameBoard.ObstacleY[i]);
			}
		}
	
		private static void DrawBlock(Graphics g, Color c, int x, int y)
		{
			g.FillRectangle(new SolidBrush(c), x * 25 + 30, y * 25 + 30, 25, 25);
			g.DrawRectangle(new Pen(Color.FromArgb(25, 255, 255)), x * 25 + 30, y * 25 + 30, 25, 25);
		}
	}
}				