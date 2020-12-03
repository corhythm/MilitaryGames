namespace Intergration
{
	internal delegate void Check(System.Int32 x, System.Int32 y); 
	internal delegate void FocusButton();

	internal partial class SlitherIOForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		private SelectForm selectForm;
		private System.Boolean Pause = false;
		private System.Threading.EventWaitHandle EWH;
		private System.Int32 FieldX = 50; 
		private System.Int32 FieldY = 30; 
		private System.Int32[] JumpGateX = new System.Int32[15];
		private System.Int32[] JumpGateY = new System.Int32[15];
		private System.Int32 Speed;
		private System.Int32 Score;
		private System.Int32 FeedX;
		private System.Int32 FeedY;
		private System.Int32[] ObstacleX = new System.Int32[30];
		private System.Int32[] ObstacleY = new System.Int32[30];
		private System.Random random = new System.Random();
		private System.Collections.Generic.List<int> SlitherX = new System.Collections.Generic.List<int>(); 
		private System.Collections.Generic.List<int> SlitherY = new System.Collections.Generic.List<int>(); 
		private System.String Direction; 
		private System.String OldDirection;
		private System.Threading.Thread MoveThread;
		//private System.Threading.Thread IntroThread;
		private Check CheckAll;
		private System.Boolean Gaming;
		private System.Boolean Intro = true;
		private System.Drawing.Color[] AllColor = new System.Drawing.Color[] {	
			System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, 
			System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, 
			System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, 
			System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, 
			System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, 
			System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, 
			System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, 
			System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, 
			System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, 
			System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen,
			System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, 
			System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, 
			System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, 
			System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, 
			System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, 
			System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, 
			System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, 
			System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, 
			System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, 
			System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, 
			System.Drawing.Color.LavenderBlush,  System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, 
			System.Drawing.Color.LightBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, 
			System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, 
			System.Drawing.Color.Green, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, 
			System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, 
			System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, 
			System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, 
			System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumSeaGreen, 
			System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, 
			System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, 
			System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, 
			System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, 
			System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, 
			System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, 
			System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, 
			System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, 
			System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, 
			System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, 
			System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, 
			System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, 
			System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, 
			System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, 
			System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, 
			System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen 
		};
					
		public SlitherIOForm()
		{
			InitializeComponent();	
		}

		public SlitherIOForm(SelectForm select_form)
		{
			this.selectForm = select_form;
			InitializeComponent();
		}

		protected override void Dispose(System.Boolean disposing)
		{
			if(disposing && (components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void SlitherIOForm_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Console.WriteLine("X : {0}, Y : {1}", e.X, e.Y);
		}

		private void SlitherIOForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Opacity = this.Opacity + ( e.Delta > 0 ? 0.1 : -0.1);
		}
		
		private void DrawTabel(System.Drawing.Graphics g) // BackGround
		{
			//DrawIntro();
			for(System.Int32 i = 0; i < FieldX; i++)
			{
				for(System.Int32 j = 0; j < FieldY; j++)
				{
					DrawBlock(g, System.Drawing.Color.Black, i, j);
				}
			}
		}
		
		private void DrawIntro()
		{
			System.Drawing.Graphics graphics = this.CreateGraphics();
			if(Intro)
			{
				Intro = false;
				for(System.Int32 x = 0; x < FieldX; x++)
				{
					for(System.Int32 y = 0; y < FieldY; y++)
					{
						graphics.FillRectangle(new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)random.Next(1, 52),
						System.Drawing.Color.FromArgb(random.Next(1, 255), random.Next(1, 255), random.Next(1, 255)),
						System.Drawing.Color.FromArgb(random.Next(1, 255), random.Next(1, 255), random.Next(1, 255))), x * 25 + 30, y * 25 + 30, 25, 25);	 
					}
					System.Threading.Thread.Sleep(50);	
				}
			}
		}

		private void DrawBlock(System.Drawing.Graphics g)
		{
			for(System.Int32 i = 0; i < SlitherX.Count; i++)
			{
				DrawBlock(g, System.Drawing.Color.White, SlitherX[i], SlitherY[i]); // 지렁이
			}
			DrawBlock(g, System.Drawing.Color.Blue, FeedX, FeedY); // Feed
			
			for(System.Int32 i = 0; i < ObstacleX.Length; i++)
			{
				DrawBlock(g, System.Drawing.Color.Red, ObstacleX[i], ObstacleY[i]);
			}

			for(System.Int32 i = 0; i < this.JumpGateX.Length; i++)
			{
				DrawBlock(g, this.AllColor[this.random.Next(this.AllColor.Length)], this.JumpGateX[i], this.JumpGateY[i]);
			}

		}
	
		private void DrawBlock(System.Drawing.Graphics g, System.Drawing.Color c, System.Int32 x, System.Int32 y)
		{
			g.FillRectangle(new System.Drawing.SolidBrush(c), x * 25 + 30, y * 25 + 30, 25, 25);
			g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.FromArgb(25, 255, 255)), x * 25 + 30, y * 25 + 30, 25, 25);
		}
		
		private void Key_Down(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case System.Windows.Forms.Keys.P:
					if(!this.Pause)
					{
						this.Pause = true;
						
							
					}
					else
					{
						this.Pause = false;
						this.EWH.Set();
						
					}
					break;

				case System.Windows.Forms.Keys.Left : 
					if(!this.Pause)
					{
						if(OldDirection != "Right")
						{
							Direction = "Left";
						}
					}
					break;

				case System.Windows.Forms.Keys.Right : 
					if(!this.Pause)
					{
						if(OldDirection != "Left")
						{
							Direction = "Right";
						}
					}
					break;
				
				case System.Windows.Forms.Keys.Up : 
					if(!this.Pause)
					{
						if(OldDirection != "Down")
						{
							Direction = "Up";
						}
					}
					break;
			
				case System.Windows.Forms.Keys.Down :
					if(!this.Pause)
					{
						if(OldDirection != "Up")
						{
							Direction = "Down";
						}
					}
					break;
			}
		} 

		private void SetFeed()
		{
			FeedX = random.Next(1, FieldX - 1);    
			FeedY = random.Next(1, FieldY - 1);  

			for(System.Int32 i = 0; i < SlitherX.Count; i++) // 만약 지렁이가 지나가는 위치에 Feed가 생성되면 SetBlock() 다시 실행.
			{
				if(SlitherX[i] == FeedX && SlitherY[i] == FeedY)
				{ 
					SetFeed(); 
				}
			}
		}

		private void SetJumpGate() // FieldX = 50, FieldY = 30
		{
			JumpGateException:

			for(System.Int32 i = 0; i < JumpGateX.Length; i++)
			{
				this.JumpGateX[i] = random.Next(1, FieldX);
				this.JumpGateY[i] = random.Next(1, FieldY);	

				if(this.FeedX == this.JumpGateX[i] && this.FeedY == this.JumpGateY[i]) goto JumpGateException;

				for(System.Int32 j = 0; j < this.SlitherX.Count; j++)
				{
					if(this.JumpGateX[i] == this.SlitherX[j] && this.JumpGateY[i] == this.SlitherY[j]) goto JumpGateException;
				}

				for(System.Int32 j = 0; j < this.ObstacleX.Length; j++)
				{
					if(this.JumpGateX[i] == this.ObstacleX[j] && this.JumpGateY[i] == this.ObstacleY[j]) goto JumpGateException;
				}
			}

		
			
		}
		
		private void SetObstacle() // 지렁이 위치와 장애물 생성 위치 겹치지 않게 조정해야 함.
		{
			StackOverFlowException:

			for(System.Int32 i = 0; i < ObstacleX.Length; i++)
			{
				ObstacleX[i] = random.Next(1, FieldX - 1);
				ObstacleY[i] = random.Next(1, FieldY - 1);		
			}		
			
			for(System.Int32 i = 0; i < ObstacleX.Length; i++)
			{
				if(FeedX == ObstacleX[i] && FeedY == ObstacleY[i])
				{
					// SetObstacle();
					goto StackOverFlowException;
				}
			
			
				for(System.Int32 j = 0; j < SlitherX.Count; j++)
				{
					if(SlitherX[j] == ObstacleX[i] && SlitherY[j] == ObstacleY[i])
					{
						// SetObstacle();
						goto StackOverFlowException;
					}
				}
			}		
		} 

		private void MoveUser()
		{
			//DrawIntro();
			while(true)
			{
				System.Threading.Thread.Sleep(Speed);
				Moving();
				if(!Gaming)
				{
					break;
				}
				if(this.Pause)
				{
					this.EWH.WaitOne();
				}
			}
			MoveThread.Abort();
			// add a code about record		
		} 

		private void Moving()
		{
			if(Gaming)
			{
				switch(Direction)
				{
					case "Left" :
						CheckAll(SlitherX[0] - 1, SlitherY[0]);
						IndexMove();
						SlitherX[0]--;
						break;

					case "Right" :
						CheckAll(SlitherX[0] + 1, SlitherY[0]);
						IndexMove();
						SlitherX[0]++;
						break;

					case "Up" :
						CheckAll(SlitherX[0], SlitherY[0] - 1);
						IndexMove();
						SlitherY[0]--;
						break;

					case "Down" :
						CheckAll(SlitherX[0], SlitherY[0] + 1);
						IndexMove();
						SlitherY[0]++;
						break;
				}
			}
			this.Refresh();  
		} 
	
		private void IndexMove()
		{
			for(System.Int32 i = this.SlitherY.Count - 1; i > 0; i--)
			{
				this.SlitherX[i] = this.SlitherX[i - 1];
				this.SlitherY[i] = this.SlitherY[i - 1];
			}
			this.OldDirection = this.Direction;	
		}

		private void GetCheck(int x, int y)
		{
			if(x == FeedX && y == FeedY)
			{
				BlockAdd(FeedX, FeedY); // 먹이 먹은 즉시 지렁이 몸에 추가.
				Score += 100;
				LScoreNum.Text = Score.ToString();
				if(Speed > 100)
				{
					Speed -= 30;
				}
				SetFeed(); // 다시 먹이 만들고
				SetObstacle();
				SetJumpGate();
			}	
		}  

		private void OverCheck(System.Int32 x, System.Int32 y)
		{
			if(x < 0 || y < 0 || x >= FieldX || y >= FieldY) // 범위 밖을 벗어나면 종료.
			{
				Gaming = false; 
			}

			for(System.Int32 i = SlitherX.Count - 1; i > 0; i--) // Slither 자기 몸통에 부딪히면 종료.
			{	
				if(SlitherX[0] == SlitherX[i] && SlitherY[0] == SlitherY[i]) 
				{
					Gaming = false;	
				}
			}
			
			for(System.Int32 i = 0; i < ObstacleX.Length; i++) 
			{
				if(x == ObstacleX[i] && y == ObstacleY[i]) // 장애물 충돌하면
				{
					Gaming = false;
				}
			}

			for(System.Int32 i = 0; i < this.JumpGateX.Length; i++) // Sliter이 JumpGate에 충돌 시
			{
				if(x == this.JumpGateX[i] && y == this.JumpGateY[i])
				{
					SlitherX[0] = this.JumpGateX[this.random.Next(this.JumpGateX.Length)];
					SlitherY[0] = this.JumpGateY[this.random.Next(this.JumpGateY.Length)];
				}
			}

			if(!Gaming) // 게임 종료되면
			{
				if(System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show("Do you want restart?", "Game Over!",  System.Windows.Forms.MessageBoxButtons.YesNo)) 
				{	
					LScoreNum.Text = 0.ToString();
					Score = 0;
					Speed = 300;
					Gaming = true;
					SlitherX = null;
					SlitherY = null;
					SlitherX = new System.Collections.Generic.List<int>(); 
					SlitherY = new System.Collections.Generic.List<int>(); 
					BlockAdd(15, 5);
					BlockAdd(16, 5);
					BlockAdd(17, 5);
					//Direction = "Down"; // 처음 시작할 때 지렁이 가는 방향
					//OldDirection = Direction;
					SetObstacle();
				}
				else 
				{	
					new System.Threading.Thread(() => { new SelectForm().ShowDialog(); }).Start();
					//System.Windows.Forms.Application.Exit();
					this.Dispose();
					this.MoveThread.Abort();
				}
			}
		} 

		private void BlockAdd(System.Int32 x, System.Int32 y) 
		{
			this.SlitherX.Add(x);
			this.SlitherY.Add(y);
		} 
	
		private void InitializeComponent()
		{
			
			this.LFeed = new System.Windows.Forms.Label();
			this.LScoreNum = new System.Windows.Forms.Label();
			this.BackArrow = new System.Windows.Forms.Button();
			MoveThread = new System.Threading.Thread(MoveUser);
			this.Pause = false;
			this.EWH = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);
			SetFeed();
			SetObstacle();
			SetJumpGate();
			//
			// etc
			//
			BlockAdd(15, 5);
			BlockAdd(16, 5);
			BlockAdd(17, 5);
			Direction = "Down"; // 처음 시작할 때 지렁이 가는 방향
			OldDirection = Direction;

			CheckAll = OverCheck; 
			CheckAll += GetCheck; // 델리게이트 체인

			Gaming = true;
			Score = 0;
			Speed = 300;
			
			
			MoveThread.Start();
			//IntroThread = new System.Threading.Thread(DrawIntro);
			//IntroThread.Start(this.CreateGraphics());
			//
			// LFeed
			//
			LFeed.Text = "Score  : ";
			LFeed.AutoSize = false;
			LFeed.BackColor = System.Drawing.Color.Beige;
			LFeed.Size = new System.Drawing.Size(120, 30);
			LFeed.Location = new System.Drawing.Point(1300, 700);
			LFeed.Font = new System.Drawing.Font("AR DESTINE", 20);
			//LFeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			// LScoreNum
			//			
			LScoreNum.Text = "0";
			LScoreNum.AutoSize = false;
			LScoreNum.Size = new System.Drawing.Size(100, 50);
			LScoreNum.Font = new System.Drawing.Font("AR HERMANN", 30);
			LScoreNum.Location = new System.Drawing.Point(1420, 690);
			//LScoreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//LScoreNum.BackColor = System.Drawing.Color.Coral;
			//
			// BackArrow
			//
			this.BackArrow.Text = "←";
			this.BackArrow.Size = new System.Drawing.Size(100, 40);
			this.BackArrow.Location = new System.Drawing.Point(1450, 50);
			this.BackArrow.BackColor = System.Drawing.Color.Coral;
			this.BackArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BackArrow.Font = new System.Drawing.Font("AR DELANEY", 30);
			this.BackArrow.Click += (sender, e) => {
			
			};
			this.BackArrow.Enabled = false;
			//
			// SlitherIOForm
			//
			this.Text = "Slither.IO";
			this.ClientSize = new System.Drawing.Size(1600, 1000);
			this.DoubleBuffered = true;
			this.CenterToScreen();
			this.DoubleBuffered = true;
			this.AutoScroll = true;
			this.Icon = new System.Drawing.Icon(@"C:\Users\a\Roaming\강틀닭\.ico files\Chuzzle Deluxe.ico");
			this.TopMost = false;
			this.HelpButton = true;
			this.ShowIcon = true;
			this.ShowInTaskbar = true;
			//this.AutoSizeMode = System.Windows.Forms.GrowAndShrink;
			this.ShowInTaskbar = true;
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(SlitherIOForm_MouseWheel);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(SlitherIOForm_MouseDown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(Key_Down);
			this.Paint += new System.Windows.Forms.PaintEventHandler((sender, e) => 
			{ 
				DrawTabel(e.Graphics);
				DrawBlock(e.Graphics);
				
				if(this.Pause)
				{ 
					e.Graphics.DrawString("Pause", new System.Drawing.Font("AR CARTER", 400), new System.Drawing.SolidBrush(System.Drawing.Color.White), 0, 0); 
				}
			});
			this.Closing += new System.ComponentModel.CancelEventHandler((sender, e) =>
			{
				//this.Close();
				this.MoveThread.Abort();			
				System.Windows.Forms.Application.Exit();
			});
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.LFeed, this.LScoreNum, this.BackArrow});
			this.FormClosing += (sender, e) => { };

			
		}
		
		private System.Windows.Forms.Label LFeed;
		private System.Windows.Forms.Label LScoreNum;
		private System.Windows.Forms.Button BackArrow;

	




			





	} 

}