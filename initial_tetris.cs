using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace TeTris
{
	class BlockData
	{
		public int[,,] Kind;
		public int[,,] Next;
		public int[,,] UnderNext1, UnderNext2, UnderNext3;
		public int XPoint;
		public int YPoint;
		public int Shape;
		public Random r = new Random();
		public bool First = true;
		public int[][,,] BlockList = 
		{
			new int[2, 2, 4] // 0
			{
				{
					{0, 1, 2, 3},
					{0, 0, 0, 0}
				},	
				{
					{3, 3, 3, 3},
					{0, 1, 2, 3}
				}
			},
			
			new int[4, 2, 4] // 1
			{
				{
					{1, 2, 3, 3},
					{0, 0, 0, 1}
				},
				{
					{2, 3, 2, 2},
					{0, 0, 1, 2}
				},
				{
					{1, 1, 2, 3},
					{0, 1, 1, 1}
				},
				{
					{3, 3, 2, 3},
					{0, 1, 2, 2}
				}
			},

			new int[4, 2, 4] // 2
			{
				{
					{3, 1, 2, 3},
					{0, 1, 1, 1}
				},
				{
					{2, 3, 3, 3},
					{0, 0, 1, 2}
				},
				{
					{1, 2, 3, 1},
					{0, 0, 0, 1}
				},
				{
					{2, 2, 2, 3},
					{0, 1, 2, 2}
				}
			},

			new int[2, 2, 4] // 3
			{
				{
					{3, 2, 3, 2},
					{0, 1, 1, 2}
				}, 
				{
					{1, 2, 2, 3},
					{0, 0, 1, 1}
				}
			},

			new int[2, 2, 4] // 4
			{
				{
					{2, 2, 3, 3},
					{0, 1, 1, 2}
				},
				{
					{2, 3, 1, 2},
					{0, 0, 1, 1}
				}
			},

			new int[1, 2, 4] // 5
			{
				{
					{2, 3, 2, 3},
					{0, 0, 1, 1}
				}
			},

			new int[4, 2, 4] // 6
			{
				{
					{1, 2, 3, 2},
					{0, 0, 0, 1}
				},
				{
					{2, 2, 3, 2},
					{0, 1, 1, 2}
				},
				{
					{2, 1, 2, 3},
					{0, 1, 1, 1}
				},
				{	
					{3, 2, 3, 3},
					{0, 1, 1, 2}
				}
			}
		};

		public void DataSet()
		{
			this.XPoint = 6;
			this.YPoint = 0;
			this.Shape = 0;

			if(First) // 처음 시작하는 거면
			{
				First = false;
				this.Kind = BlockList[r.Next(0, 7)]; // 0 ~ 7 사이 난수 반환 받아서 BlockList 배열 저장
				this.Next = BlockList[r.Next(0, 7)];

				this.UnderNext1 = BlockList[r.Next(0, 7)];
				this.UnderNext2 = BlockList[r.Next(0, 7)];
				this.UnderNext3 = BlockList[r.Next(0, 7)];				 
			}
			else
			{
				this.Kind = this.Next;
				this.Next = this.UnderNext1;
				this.UnderNext1 = this.UnderNext2;
				this.UnderNext2 = this.UnderNext3;
				this.UnderNext3 = BlockList[r.Next(0, 7)];
			}
		}
	} // class BlockData End

	class MainApp : Form
	{
		private static MainApp form, RankForm;
		private static BlockData Block = new BlockData();
		private static bool[,] GameBoard;
		private static int Speed;
		private static int Score;
		private static Thread t1;
		private static bool Gaming = true;
		private static Label ScoreNum;
		private static Label LabelNextBlock;
		private static Label Arrow1;
		private static Label Arrow2;
		private static Label Arrow3;
		private static Label HoldBlock;
		private static Label LScore;
		private static Label LTime;
		private static Label LStopwatch;
		private static System.Windows.Forms.Timer timer;
		private static DateTime StartTime;
		private static TimeSpan Span;		

		public static void Main(string[] args)
		{
			MainApp Mainform = new MainApp();
			Mainform.Text = "Tetris";
			Mainform.Size = new Size(500, 500);
			Mainform.MaximizeBox = false;
			Mainform.CenterToScreen();

			Button BStart = new Button();
			BStart.Text = "Start";
			BStart.Size = new Size(100, 40);
			BStart.Location = new Point(47, 30);
			
			Button Rank = new Button();
			Rank.Text = "Rank";
			Rank.Size = new Size(100, 40);
			Rank.Location = new Point(47, 100);

			Button BExit = new Button();
			BExit.Text = "Exit";
			BExit.Size = new Size(100, 40);
			BExit.Location = new Point(47, 170);

			BStart.Click += (object sender, EventArgs e) => Starting(sender, e);
			Rank.Click += (object sender, EventArgs e) => FileRead();
			BExit.Click += (object sender, EventArgs e) => Application.Exit();
	
			Mainform.Controls.Add(BStart);			
			Mainform.Controls.Add(Rank);	
			Mainform.Controls.Add(BExit);		
	
			Application.Run(Mainform);
		}

		public static void Painting(object sender, PaintEventArgs e)
		{
			DrawTabel(e.Graphics);
			DrawBlock(e.Graphics);
			DrawNextBlock(e.Graphics);
		}
		
		public static void DrawTabel(Graphics g) // 26행 15열 테트리스 배경 그리기
		{
			for(int j = 0; j < 26; j++)
			{
				for(int i = 0; i < 15; i++)
				{
					DrawBlock(g, Color.DarkKhaki, i, j); // 테트리스 배경 그리기
					if(GameBoard[i, j]) // 만약 이미 떨어진 블록이 해당 자리에 있다면
					{
						DrawBlock(g, Color.Green, i, j); // 이미 떨어진 블록 색깔 바꿔서 다시 그리기
					}
				}
			}
		}

		public static void DrawBlock(Graphics g)
		{
			for(int i = 0; i < 4; i++) // 현재 떨어지고 있는 블록 그리기.
			{
				DrawBlock(g, Color.Purple, Block.XPoint + Block.Kind[Block.Shape, 1, i], Block.YPoint + Block.Kind[Block.Shape, 0, i]); // 현재 떨어지고 있는 블록 그리기
			}

			for(int j = 0; j < 26; j++) // 블록 떨어지는 위치 안내해 주는 Line 그리기
			{
				for(int i = 0; i < Block.Kind[Block.Shape, 1, 3] + 1; i++)
				{
					g.DrawRectangle(new Pen(Color.Azure), (Block.XPoint + i) * 25 + 170, j * 25 + 30, 25, 25); 		
				}		
			}
		}

		public static void SaveHoldBlock() // 블록 저장
		{
			
		}

		public static void DrawNextBlock(Graphics g)
		{
			for(int i = 0; i < 4; i++) 
			{
				for(int j = 0; j < 4; j++)
				{
					DrawBlock(g, Color.AliceBlue, 17 + i, 2 + j); // 다음 블록[0] 표시되는 배경 그리기
					DrawBlock(g, Color.Bisque, 17 + i, 8 + j); // 다음 블록[1] 표시되는 배경 그리기
					DrawBlock(g, Color.Beige, 17 + i, 14 + j); // 다음 블록[2] 표시되는 배경 그리기
					DrawBlock(g, Color.BurlyWood, 17 + i, 20 + j); // 다음 블록[3] 표시되는 배경 그리기
					DrawBlock(g, Color.BlanchedAlmond, i - 6, j + 3); // Hold 블록 표시되는 배경 그리기
				}
			}
			
			for(int i = 0; i < 4; i++) // 다음에 등장할 블록 그리기
			{
				DrawBlock(g, Color.Blue, 18 + Block.Next[0, 1, i], 2 + Block.Next[0, 0, i]); // 다음 블록 색깔	
				DrawBlock(g, Color.Crimson, 18 + Block.UnderNext1[0, 1, i], 8 + Block.UnderNext1[0, 0, i]);
				DrawBlock(g, Color.DarkOrange, 18 + Block.UnderNext2[0, 1, i], 14 + Block.UnderNext2[0, 0, i]);
				DrawBlock(g, Color.DarkRed, 18 + Block.UnderNext3[0, 1, i], 20 + Block.UnderNext3[0, 0, i]);			
			}
		}

		public static void DrawBlock(Graphics g, Color c, int x, int y)
		{
			g.FillRectangle(new SolidBrush(c), x * 25 + 170, y * 25 + 30, 25, 25); // 사각형 색 채우기
			g.DrawRectangle(new Pen(Color.Black), x * 25 + 170, y * 25 + 30, 25, 25); // 사각형 네 개의 변 색깔
		}

		public static void form_KeyDown(object sender, KeyEventArgs e)
		{
			if(Gaming)
			{
				switch(e.KeyCode)
				{
					/*case Keys.P:		
						if(IsPlay)
						{
							Thread.Suspend();
							IsPlay = false;
						}
						else
						{
							Thread.Resume();
							IsPlay = true;
						}
						
						break;	
			
					case Keys.Q:
					*/	
					case Keys.Left:
						if(BlockIndexCheck(Block.XPoint - 1, Block.YPoint, Block.Shape))
						{
							Block.XPoint--;
						}	
						break;
					
					case Keys.Right:
						if(BlockIndexCheck(Block.XPoint + 1, Block.YPoint, Block.Shape))
						{
							Block.XPoint++;
						}
						break;
			
					case Keys.Down:
						if(BlockIndexCheck(Block.XPoint, Block.YPoint + 1, Block.Shape))
						{
							Block.YPoint++;
							BlockCheck();
						}
						break;
				
					case Keys.Up:
						if(Block.Shape + 1 <= Block.Kind.GetLength(0) - 1)
						{ 
							while(Block.XPoint + Block.Kind[Block.Shape + 1, 1, 3] >= 15)
							{
								Block.XPoint--;
							}

							if(BlockIndexCheck(Block.XPoint, Block.YPoint, Block.Shape + 1))
							{
								Block.Shape++;
							}
						}
						else
						{
							while(Block.XPoint + Block.Kind[0, 1, 3] >= 15)
							{
								Block.XPoint--;
							}
							if(BlockIndexCheck(Block.XPoint, Block.YPoint, 0))
							{
								Block.Shape = 0;
							}
						}
						break;
					
					case Keys.Space:
						while(true)
						{
							Block.YPoint++;
							for(int i = 0; i < 4; i++)
							{
								if(GameBoard[Block.XPoint + Block.Kind[Block.Shape, 1, i], Block.YPoint + Block.Kind[Block.Shape, 0, i]])
								{
									BlockCheck();
									goto JUMP;
								}
							}
						}
						JUMP:	
						break;
				}

				for(int i = 0; i < 4; i++)
				{
					if(GameBoard[5 + Block.Kind[Block.Shape, 1, i], Block.Kind[Block.Shape, 0, i]])
					{
						Gaming = false;
						MessageBox.Show("Game Over!", "Score : " + Score);
						t1.Abort();
						form.Close();
						break;
					}
				}
			}
			form.Invalidate();
		}
			
		public static bool BlockIndexCheck(int x, int y, int s)
		{
			bool Check = false;	
			int xB = x + Block.Kind[Block.Shape, 1, 3];
			int yB = y + 3;

			if(x >= 0 && xB < 15 && y >= 0 && yB <= 26 && s <= 3 && s >= 0)
			{
				Check = true;

				for(int i = 0; i < 4; i++)
				{
					if(GameBoard[x + Block.Kind[s, 1, i], Block.YPoint + Block.Kind[s, 0, i]])
					{
						Check = false;
						break;
					}
				}	
			}
			return Check;
		}
		
		public static void BlockCheck()
		{
			for(int i = 0; i < 4; i++)
			{
				if(GameBoard[Block.XPoint + Block.Kind[Block.Shape, 1, i], Block.YPoint + Block.Kind[Block.Shape, 0, i]])
				{
					Block.YPoint--;
					FixBlock();
					Block.DataSet();
					break;
				}
			}
		}

		public static void FixBlock()
		{
			for(int i = 0; i < 4; i++)
			{
				GameBoard[Block.XPoint + Block.Kind[Block.Shape, 1, i], Block.YPoint + Block.Kind[Block.Shape, 0, i]] = true;
			}

			for(int i = 0; i < 4; i++)
			{
				LineCheck(i);
			}
		}

		public static void LineCheck(int y)
		{
			bool Check = false;
			bool NotBlock = true;

			for(int i = 0; i < 15; i++)
			{
				if(!GameBoard[i, Block.YPoint + y])
				{
					NotBlock = false;
				}
			}

			if(NotBlock)
			{
				Check = true;
			}

			if(Check)
			{
				Score += 100;
				Console.WriteLine(Score);
				
				if(Score <= 500)
				{
					Speed = 800;
				}
				else if(Score > 500 && Score <= 1000)
				{
					Speed = 700;
				}
				else if(Score > 1000 && Score <= 1900)
				{
					Speed = 600;
				}
				else if(Score > 1900 && Score <= 3000)
				{
					Speed = 500;
				}
				else if(Score > 3000 && Score <= 4000)
				{
					Speed = 400;
				}
				else if(Score > 4000 && Score <= 6000)
				{
					Speed = 300;
				}
				else if(Score > 6000 && Score <= 8000)
				{
					Speed = 200;
				}
				else if(Score > 8000 && Score <= 10000)
				{
					Speed = 150;
				}
				else
				{
					Speed = 100;
				}
				ScoreNum.Text = Score.ToString();
				MoveLine(Block.YPoint + y);
			}
		}

		public static void MoveLine(int y)
		{
			for(int j = y; j >= 1; j--)
			{
				for(int i = 0; i < 15; i++)
				{
					GameBoard[i, j] = GameBoard[i, j - 1];
				}
			}
		}

		public static void DownBlock()
		{
			while(true)
			{
				Thread.Sleep(Speed);
				if(!Gaming)
				{		
					break;
				}
				form_KeyDown(null, new KeyEventArgs(Keys.Down));
			}
			FileWrite(Score.ToString());
			t1.Abort();
		}

		public static void Starting(object Sender, EventArgs E)
		{
			form = new MainApp();

			Gaming = true;
			Block.DataSet();
			Score = 0;
			Speed = 800; // 처음 시작할 때 스레드 속도
			t1 = new Thread(new ThreadStart(DownBlock));
			t1.Start();

			form.Text = "테트리스";
			form.Size = new Size(800, 770); // 창 크기 조절.
			form.CenterToScreen();
			form.DoubleBuffered = true;
		
			LabelNextBlock = new Label();
			LabelNextBlock.Text = "Next Block";
			LabelNextBlock.AutoSize = true;
			LabelNextBlock.Location = new Point(575, 30);
			LabelNextBlock.Font = new Font("Courier New", 20);
			LabelNextBlock.TextAlign = ContentAlignment.MiddleCenter;
			
			Arrow1 = new Label();
			Arrow1.Text = "↑";
			Arrow1.AutoSize = true;
			Arrow1.Location = new Point(632, 185);
			Arrow1.Font = new Font("Courier New", 20);
			Arrow1.TextAlign = ContentAlignment.MiddleCenter;
		
			Arrow2 = new Label();
			Arrow2.Text = "↑";
			Arrow2.AutoSize = true;
			Arrow2.Location = new Point(632, 335);
			Arrow2.Font = new Font("Courier New", 20);
			Arrow2.TextAlign = ContentAlignment.MiddleCenter;
			
			Arrow3 = new Label();
			Arrow3.Text = "↑";
			Arrow3.AutoSize = true;
			Arrow3.Location = new Point(632, 485);
			Arrow3.Font = new Font("Courier New", 20);
			Arrow3.TextAlign = ContentAlignment.MiddleCenter;

			HoldBlock = new Label();
			HoldBlock.Text = "Hold Block";
			HoldBlock.AutoSize = true;
			HoldBlock.Location = new Point(10, 65);
			HoldBlock.Font = new Font("Courier New", 18);
			HoldBlock.TextAlign = ContentAlignment.MiddleCenter;
			
			LScore = new Label();
			LScore.Text = "Score: ";
			LScore.AutoSize = true;
			LScore.Location = new Point(560, 650);
			LScore.Font = new Font("Courier New", 20);
			LScore.TextAlign = ContentAlignment.MiddleCenter;

			ScoreNum = new Label();
			ScoreNum.Text = Score.ToString();
			ScoreNum.AutoSize = true;
			ScoreNum.Font = new Font("MyriadHebrew-Bold", 18);
			ScoreNum.Location = new Point(680, 650);
			ScoreNum.TextAlign = ContentAlignment.MiddleCenter; 

			LTime = new Label();
			LTime.Font = new Font("Courier New", 13);
			LTime.BackColor = Color.Black;
			LTime.ForeColor = Color.White;
			LTime.Size = new Size(220, 40);
			LTime.Location = new Point(570, 700);
			LTime.TextAlign = ContentAlignment.MiddleCenter;

			LStopwatch = new Label();
			LStopwatch.Text = "00:00:00";
			LStopwatch.Font = new Font("Courier New", 18);
			LStopwatch.BackColor = Color.Black;
			LStopwatch.ForeColor = Color.White;
			LStopwatch.Size = new Size(150, 40);
			LStopwatch.Location = new Point(10, 15);
			LStopwatch.TextAlign = ContentAlignment.MiddleCenter;

			timer = new System.Windows.Forms.Timer();
			ButtonStartClick(Sender, E);
			
			StartTime = DateTime.Now;
			
			form.Paint += new PaintEventHandler(Painting);
			form.KeyDown += new KeyEventHandler(form_KeyDown);

			GameBoard = new bool[15, 27];

			for(int i = 0; i < 15; i++)
			{
				GameBoard[i, 26] = true; // 이 코드의 역할은?
			}
	
			form.Closing += (object sender, CancelEventArgs e) => 
			{
				t1.Abort(); // 강제 종료
				t1.Join(); // 스레드가 종료될 때까지 호출 스레드 중단
			};
		
			form.Controls.AddRange(new Control[]{LScore, ScoreNum, LabelNextBlock, HoldBlock, Arrow1, Arrow2, Arrow3, LTime, LStopwatch});
			form.ShowDialog();
		}

		public static void ButtonStartClick(object sender, EventArgs e)
		{
			timer.Interval = 1000;
			timer.Tick += new EventHandler(TimeTick);
			timer.Tick += new EventHandler(StopwatchTick);
			timer.Start();
		}

		public static void StopwatchTick(object sender, EventArgs e)
		{
			Span = new TimeSpan(DateTime.Now.Ticks - StartTime.Ticks);
			LStopwatch.Text = Span.ToString("hh\\:mm\\:ss");
		}

		public static void TimeTick(object sender, EventArgs e)
		{
			LTime.Text = "현재시간: " + DateTime.Now.ToLongTimeString();
		}

		public static void FileRead()
		{	
			RankForm = new MainApp();
			

			RankForm.Text = "랭킹 보기";
			RankForm.Size = new Size(1000, 500); // 창 크기 조절.
			RankForm.CenterToScreen();
			RankForm.DoubleBuffered = true;
		
			Label RankFrame = new Label();
			//string FilePath = "C:\Program Files\Microsoft.NET\tetris_score_head.txt";
			

			/*string[] head = File.ReadAllLines(@"C:\Program Files\Microsoft.NET\tetris_score_num\tetris_score_head.txt");
			foreach(string i in head)
			{
				RankFrame.Text += i;
				RankFrame.Text += '\n';
			}*/

			string[] body = File.ReadAllLines(@"C:\Program Files\Microsoft.NET\tetris_score_num\T_score_body.txt");
			foreach(string i in body)
			{
				RankFrame.Text += i;
				RankFrame.Text += '\n';	
			}
			

			
			RankFrame.AutoSize = true;
			RankFrame.Location = new Point(0, 0);
			RankFrame.Font = new Font("Arial", 20);
			RankFrame.TextAlign = ContentAlignment.TopLeft;
		
			RankForm.Controls.Add(RankFrame);
			
			RankForm.ShowDialog();
		}

		public static void FileWrite(string score)
		{
			//string write = "1st         무전병짱짱맨\n                         " + score + "                     Communication213@naver.com";            
			
			//File.WriteAllLines(@"C:\Program Files\Microsoft.NET\tetris_score_num\T_score_body.txt", write);	           

		}

	}
}				