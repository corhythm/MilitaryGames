namespace Intergration
{
	internal partial class TetrisForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		
		private InputRankingForm InputRankingForm;
		private SelectForm selectForm;
		private System.Int32 SmashedLineCount = 0;		
		public System.String NewRankerID {get; set;}
		public System.String NewRankerEmail {get; set;}	
		public System.Int32 RankingCount = -1;	
		
		public TetrisForm()
		{
			InitializeComponent();	
		}

		public TetrisForm(SelectForm select_form)
		{
			InitializeComponent();	

			this.selectForm = select_form;
			
			this.NewRankerID = "";
			this.NewRankerEmail = "";
		}

		

		protected override void Dispose(System.Boolean disposing)
		{
			if(disposing && (components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void TetrisForm_Load(object sender, System.EventArgs e)
		{
			//timer_Tick(sender, e);
		}
		
		private void TetrisForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Opacity = this.Opacity + ( e.Delta > 0 ? 0.1 : -0.1);
		}
		
		private void TetrisForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MainThread.Abort(); // 강제 종료
			System.Windows.Forms.Application.Exit();
		}
		
		private void TetrisForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			DrawTabel(e.Graphics);
			DrawBlock(e.Graphics);
			DrawNextBlock(e.Graphics);
			DrawHoldBlock(e.Graphics);

			if(this.Pause)
			{ 
				e.Graphics.DrawString("Pause", new System.Drawing.Font("AR CARTER", 250), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 50, 100); 
			}
		}

		private void TetrisForm_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//System.Console.WriteLine("sender : {0}", ((System.Windows.Forms.Form)sender).Text);
			//System.Console.WriteLine("X : {0}, Y : {1}", e.X, e.Y);
			//System.Console.WriteLine("Button : {0}, Clicks : {1}", e.Button, e.Clicks);
			//System.Console.WriteLine();
		}

		private void 랭킹MenuItem_Click(object sender, System.EventArgs e)
		{
			
		}
		
		private void RoundedButton_Click(System.Object sender, System.EventArgs e)
		{
			
		}

		private void DrawTabel(System.Drawing.Graphics graphics) // 26행 15열 테트리스 배경 그리기
		{
			
			for(System.Int32 i = 0; i < this.Block.TableWidth; i++)
			{
				for(System.Int32 j = 0; j < this.Block.TableHeight; j++)
				{
					DrawBlock(graphics, Block.GameBoardColor[i, j], i, j); // 테트리스 배경 그리기
					
					if(Block.GameBoard[i, j])  
					{
						DrawBlock(graphics, Block.GameBoardColor[i, j], i, j); 
					}
				}
			}
			
		}

		private void DrawBlock(System.Drawing.Graphics graphics)
		{
			if(!this.Pause)
			{
				for(System.Int32 i = 0; i < 4; i++) // 현재 떨어지고 있는 블록 그리기.
				{	
					DrawBlock(graphics, Block.RandomColorList[0], Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]); // 현재 떨어지고 있는 블록 그리기
					DrawBlock(graphics, System.Drawing.Color.FromArgb(230, Block.RandomColorList[0]), Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], PreviewBlock() + Block.NextBlockList[0][Block.NowBlockShape, 1, i]);
					System.Console.WriteLine(Block.RandomColorList[0]);
				}
			}
			else
			{
				for(System.Int32 i = 0; i < 4; i++) // 현재 떨어지고 있는 블록 그리기.
				{	
					DrawBlock(graphics, System.Drawing.Color.Khaki, Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]); // 현재 떨어지고 있는 블록 그리기
					DrawBlock(graphics, System.Drawing.Color.FromArgb(230, System.Drawing.Color.Khaki), Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], PreviewBlock() + Block.NextBlockList[0][Block.NowBlockShape, 1, i]);
				}
			}
			
		}

		private void DrawNextBlock(System.Drawing.Graphics graphics)
		{	
			for(System.Int32 i = 0; i < 4; i++) // 다음에 등장할 블록 그리기
			{
				for(System.Int32 j = 1; j < Block.RandomColorList.Length; j++)
				{
					DrawBlock(graphics, Block.RandomColorList[j], 18 + Block.NextBlockList[j][0, 0, i], (j * 3 - 1) + Block.NextBlockList[j][0, 1, i]);
				}	
			}
		}

		private void DrawHoldBlock(System.Drawing.Graphics graphics)
		{
			for(System.Int32 i = 0; i < 4; i++)
			{
				if(Block.IsSaved) 
				{
					DrawBlock(graphics, Block.HoldedBlockColor, Block.HoldedBlock[0][0, 0, i] - 5, 6 + Block.HoldedBlock[0][0, 1, i]);
				}
			}
		}

		private void DrawBlock(System.Drawing.Graphics graphics, System.Drawing.Color color, System.Int32 x, System.Int32 y)
		{
			graphics.FillRectangle(new System.Drawing.SolidBrush(color), x * 25 + 170, y * 25 + 30, 25, 25); // 사각형 색 채우기
			graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), x * 25 + 170, y * 25 + 30, 25, 25); // 사각형 네 개의 변 색깔
		}

		private void DrawHatchBlock(System.Drawing.Graphics graphics, System.Drawing.Drawing2D.HatchBrush hatch, System.Int32 x, System.Int32 y)
		{
			graphics.FillRectangle(hatch, x * 25 + 170, y * 25 + 30, 25, 25);
			graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), x * 25 + 170, y * 25 + 30, 25, 25); 
		}
			
		private System.Int32 PreviewBlock()
		{
			System.Int32 y = Block.Y;
		
			while(!Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, 0], (y + 1) + Block.NextBlockList[0][Block.NowBlockShape, 1, 0]] &&
				!Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, 1], (y + 1) + Block.NextBlockList[0][Block.NowBlockShape, 1, 1]] && 
				!Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, 2], (y + 1) + Block.NextBlockList[0][Block.NowBlockShape, 1, 2]] &&
				!Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, 3], (y + 1) + Block.NextBlockList[0][Block.NowBlockShape, 1, 3]] &&
				y < Block.TableHeight - 1)
			{
				y++;
			}
			
			return y;
		}

		
		private void timer_Tick(object sender, System.EventArgs e)
		{
			this.Span = new System.TimeSpan(System.DateTime.Now.Ticks - HoldEndTime.Ticks);	
			this.LTime.Text = Span.ToString("hh\\:mm\\:ss");
			
		}

		private void TetrisForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(Gaming)
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

					case System.Windows.Forms.Keys.H:
						if(!this.Pause)
						{
							if(this.HoldOK)
							{
								if(!Block.IsSaved) // 저장이 안 돼 있을 때
								{
									Block.HoldedBlock[0] = Block.NextBlockList[0];
									Block.HoldedBlockColor = Block.RandomColorList[0];
									Block.DataSet();							
									Block.IsHoldPossible = false;
									Block.IsSaved = true;
								}
								else // 저장 돼 있을 때.
								{					
									Block.X = 6;
									Block.Y = Block.NowBlockShape = 0;
									Block.NextBlockList[0] = Block.HoldedBlock[0];
									Block.RandomColorList[0] = Block.HoldedBlockColor;
									Block.HoldedBlock[0] = null;
									Block.IsSaved = false;
									timer.Enabled = true;
									this.HoldEndTime = System.DateTime.Now;
									this.HoldBlock.Text  = "Not Yet... Wait";
									this.HoldBlock.ForeColor = System.Drawing.Color.Red;
									this.HoldOK = false;
								
								}
							}
						}
						break;	

					case System.Windows.Forms.Keys.Left:
						if(!this.Pause)
						{
							if(BlockPositionCheck(Block.X - 1, Block.Y, Block.NowBlockShape)) 
							{
								Block.X--; // 유효한 위치이면 X좌표 왼쪽으로 한 칸 이동.
							}
						}	
						break;
					
					case System.Windows.Forms.Keys.Right:
						if(!this.Pause)
						{
							if(BlockPositionCheck(Block.X + 1, Block.Y, Block.NowBlockShape))
							{
								Block.X++; // 유효한 위치이면 X좌표 오른쪽으로 한 칸 이동.
							}
						}
						break;
				
					case System.Windows.Forms.Keys.Up:
						if(!this.Pause)
						{
							if(Block.NowBlockShape + 1 <= Block.NextBlockList[0].GetLength(0) - 1)
							{ 
								while(Block.X + Block.NextBlockList[0][Block.NowBlockShape + 1, 0, 3] >= this.Block.TableWidth)
								{
									Block.X--;
								}
		
								if(BlockPositionCheck(Block.X, Block.Y, Block.NowBlockShape + 1))
								{
									Block.NowBlockShape++;
								}
							}
							else
							{
								while(Block.X +Block.NextBlockList[0][0, 0, 3] >= this.Block.TableWidth) 
								{
									Block.X--;
								}
								
								if(BlockPositionCheck(Block.X, Block.Y, 0))
								{
									Block.NowBlockShape = 0;
								}
							}
						}
						break;
										 
					case System.Windows.Forms.Keys.Down:
						if(!this.Pause)
						{
							if(BlockPositionCheck(Block.X, Block.Y + 1, Block.NowBlockShape))
							{
								Block.Y++; // BlockIndexCheck로 검사한 다음, 유효한 위치이면 Y좌표 아래로 한 칸 이동.
								CheckBlock(); // 내려가다가 바닥 혹은 블록과 맞닿으면 블록 고정.
							}
						}
						break;

					case System.Windows.Forms.Keys.Space:
						if(!this.Pause)
						{
							while(true)
							{
								for(System.Int32 i = 0; i < 4; i++)
								{	
									if(Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]])
									{
										CheckBlock();
										goto IsGameOver;
									}
								}
							
								Block.Y++;	
							}
						}
						break;
				}

				IsGameOver:
					
					for(System.Int32 i = 0; i < 4; i++)
					{
						if(Block.GameBoard[6 + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.NextBlockList[0][Block.NowBlockShape, 1, i]]) // + 6를 하는 이유는 블록이 가운데서 나오니까
						{
							// 여기에 spacebar를 비활성화하면 될 듯...
							
							Gaming = false;
							CheckRanking(); // 랭킹 체크하고
							if(System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show("계속 하시겠습니까?", "Game Over!", System.Windows.Forms.MessageBoxButtons.YesNo))
							{																													
								new System.Threading.Thread(() => { new TetrisForm().ShowDialog(); }).Start();
								this.Close();
								MainThread.Abort();	 // 이렇게 해도 되나 모르겠다...
								break;								
							}
							else // 아니오
							{							
								new System.Threading.Thread(() => { new SelectForm().ShowDialog(); }).Start();
								this.Close();
								MainThread.Abort();
								break;
							}
						}
					}	
		
					this.Invalidate();
			}
				
		}	
		
		private void TetrisForm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{

		}
	
		private void CheckRanking()
		{
			System.String[] ReadFileString = System.IO.File.ReadAllLines(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\knar.txt");
			System.String[] ReadFileMicroString;

			System.Collections.Generic.List<System.String> RankingIDList = new System.Collections.Generic.List<System.String>();
			System.Collections.Generic.List<System.Int32> RankingScoreList = new System.Collections.Generic.List<System.Int32>();
			System.Collections.Generic.List<System.String> RankingEmailList = new System.Collections.Generic.List<System.String>();

			try
			{
				for(System.Int32 i = 0; i < 20; i++) // Ranking ID Score Email // 이미 등록된 랭킹 불러오기.
				{
					ReadFileMicroString = ReadFileString[i].Split(new System.Char[] {' '});

					RankingIDList.Add(ReadFileMicroString[1]);
					RankingScoreList.Add(System.Int32.Parse(ReadFileMicroString[2]));
					RankingEmailList.Add(ReadFileMicroString[3]);
				}

				for(System.Int32 i = RankingScoreList.Count - 1; i >= 0; i--)
				{
					if(RankingScoreList[i] < this.Score)
						this.RankingCount = i;
				}

				if(this.RankingCount > -1) // 여기서 스페이스바를 비활성화할 필요가 있음.
				{
					if(System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show("순위권 안에 점수가 있습니다. 점수를 기록하시겠습니까??",
						 "Great Score!", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
					{
						this.InputRankingForm = new InputRankingForm(this);
						this.InputRankingForm.Owner  = this;
						this.InputRankingForm.FormSendEvent += new Intergration.InputRankingForm.FormSendDataHandler(DieaseUpdateEventMethod);
						this.InputRankingForm.ShowDialog();			
						
						if(this.NewRankerID == "" || this.NewRankerEmail == "")
							return;

						using (System.IO.StreamWriter SW = new System.IO.StreamWriter(new System.IO.FileStream(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\knar.txt", System.IO.FileMode.Create), System.Text.Encoding.UTF8))
						{	
							System.String RankingOneLine;
																				
							for(System.Int32 i = 0; i < RankingScoreList.Count; i++)
							{
								if(i == this.RankingCount)
									RankingOneLine = (i + 1).ToString() + " "+ this.NewRankerID.ToString() + " " + this.Score.ToString() + " " + this.NewRankerEmail.ToString();						
								else
									RankingOneLine = (i + 1).ToString() + " " + RankingIDList[i] + " " + RankingScoreList[i].ToString() + " " + RankingEmailList[i];								
							
								SW.WriteLine(RankingOneLine);
							}
						}
					}
					else return;	
				}											
			}
			catch(System.Exception e) 
			{	
				//System.Console.WriteLine(e.Message); // 이게 공백을 출력함....
				this.CreateGraphics().DrawString(e.Message, new System.Drawing.Font("AR CARTER", 250), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 50, 100); 
			}
		}	
		
		private void DieaseUpdateEventMethod(System.Object sender1, System.Object sender2)
		{
			this.NewRankerID = sender1.ToString();
			this.NewRankerEmail = sender2.ToString();	
		}

		private System.Boolean BlockPositionCheck(System.Int32 x, System.Int32 y, System.Int32 shape)
		{			
			System.Boolean? IsProperBlock = false; // 블록 위치가 유효한지를 true OR false
			System.Int32? CheckX = x + Block.NextBlockList[0][Block.NowBlockShape, 0, 3]; // x좌표와 Down Block의 맨 오른쪽 x값의 합.
			System.Int32? MaxY = 0;
			System.Int32? CheckY = 0;
			
			for(System.Int32 i = 0; i < 4; i++)
			{
				if(MaxY.Value < Block.NextBlockList[0][Block.NowBlockShape, 1, i]) 
				{
					MaxY = Block.NextBlockList[0][Block.NowBlockShape, 1, i];
				}
			}

			CheckY = y + MaxY.Value;  

			if(x >= 0 && CheckX.Value < this.Block.TableWidth && y >= 0 && MaxY < this.Block.TableHeight) // 블록 X좌표 최댓값과 Y좌표 최댓값이 블록 사이즈를 초과하지는 않는지
			{	
				IsProperBlock = true;

				for(System.Int32 i = 0; i < 4; i++)
				{	
					if(Block.Y + Block.NextBlockList[0][shape, 1, i] > this.Block.TableHeight - 1) 
					{
						Block.Y--;
					}

					if(Block.GameBoard[x + Block.NextBlockList[0][shape, 0, i], Block.Y + Block.NextBlockList[0][shape, 1, i]]) 
					{
						IsProperBlock = false;
						break;
					}
				}	
			}
			
			return IsProperBlock.Value;
		}
		
		private void CheckBlock()
		{
			for(System.Int32 i = 0; i < 4; i++)
			{
				if(Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]]) 
				{ 
					Block.Y--;
					FixBlock();
					CheckScore();
					Block.DataSet();
					return;
				}
			}
		}

		private void CheckScore()
		{
			switch(this.SmashedLineCount)
			{
				case 1:
					this.Score += (100 + (this.SmashedLineCount * 24));
					break;
				
				case 2:
					this.Score += (200 + (this.SmashedLineCount * 32));	
					break;
			
				case 3:
					this.Score += (300 + (this.SmashedLineCount * 47));
					break;

				case 4:
					this.Score += (400 + (this.SmashedLineCount * 59));
					break;

				default:			
					break;

			}
				
			if(Score <= 500) Speed = 800;
			else if(Score > 500 && Score <= 1000) Speed = 700;			
			else if(Score > 1000 && Score <= 1900) Speed = 600;
			else if(Score > 1900 && Score <= 3000) Speed = 500;
			else if(Score > 3000 && Score <= 4000) Speed = 400;
			else if(Score > 4000 && Score <= 6000) Speed = 300;
			else if(Score > 6000 && Score <= 8000) Speed = 200;
			else if(Score > 8000 && Score <= 10000) Speed = 150;
			else Speed = 100;
				
			this.SmashedLineCount = 0;
			ScoreNum.Text = Score.ToString("D10");
		}

		private void FixBlock() // Block 떨어지면 고정
		{
			for(System.Int32 i = 0; i < 4; i++)
			{
				Block.GameBoard[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]] = true;
				Block.GameBoardColor[Block.X + Block.NextBlockList[0][Block.NowBlockShape, 0, i], Block.Y + Block.NextBlockList[0][Block.NowBlockShape, 1, i]] = Block.RandomColorList[0];
			}

			for(System.Int32 i = 0; i < 4; i++)
			{
				CheckFullLine(i);
			}	
		}

		private void CheckFullLine(System.Int32 y) // Block.TableWidth 한 줄이 다 채워졌는지 Checking!!
		{
			for(System.Int32 i = 0; i < this.Block.TableWidth; i++)
			{
				while(Block.Y + y > this.Block.TableHeight - 1) Block.Y--;
				if(!Block.GameBoard[i, Block.Y + y]) return; // y = 0, 1, 2, 3 
			}
		
			this.SmashedLineCount++;	
			MoveLineDown(Block.Y + y); 	
		}

		private void MoveLineDown(System.Int32 y) // 한 줄 다차면 아래로 이동.
		{
			for(System.Int32 j = y; j >= 1; j--)
			{
				for(System.Int32 i = 0; i < this.Block.TableWidth; i++)
				{
					Block.GameBoard[i, j] = Block.GameBoard[i, j - 1];
					Block.GameBoardColor[i, j] = Block.GameBoardColor[i, j - 1];
				}
			}
		}

		private void InitializeComponent()
		{	
			this.components = new System.ComponentModel.Container();
			this.Block = new BlockData();
			this.LabelNextBlock = new System.Windows.Forms.Label();
			this.HoldBlock = new System.Windows.Forms.Label();
			this.ScoreNum = new System.Windows.Forms.Label();
			this.LTime = new System.Windows.Forms.Label();
			this.BestScore = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer();
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.파일MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.새로만들기MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.폴더MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.바로가기MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.비트맵MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.열기MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.저장MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.다른이름으로저장MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.인쇄MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.보기MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.자세히MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.랭킹MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.작게MenuItem = new System.Windows.Forms.ToolStripMenuItem(); 
			this.리스트MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.타일MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EWH = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);
			this.Pause = false;
			this.RoundedButton = new Button_WOC();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// LabelNextBlock
			//
			this.LabelNextBlock.Text = "Next Block";
			this.LabelNextBlock.AutoSize = true;
			this.LabelNextBlock.Location = new System.Drawing.Point(575, 30);
			this.LabelNextBlock.Font = new System.Drawing.Font("AR DELANEY", 20);
			this.LabelNextBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// HoldBlock
			//
			this.HoldBlock.Text = "Hold Block\n(Press H)";
			this.HoldBlock.AutoSize = true;
			//this.HoldBlock.Size = new System.Drawing.Size(10, 10);
			this.HoldBlock.Location = new System.Drawing.Point(10, 90);
			this.HoldBlock.Font = new System.Drawing.Font("AR CHRISTY", 18);
			this.HoldBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 	
			// ScoreNum
			//
			this.ScoreNum.Text = Score.ToString("D10");
			this.ScoreNum.AutoSize = true;
			this.ScoreNum.Font = new System.Drawing.Font("AR HERMANN", 30);
			this.ScoreNum.Location = new System.Drawing.Point(270, 660);
			this.ScoreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; 
			//
			// LTime
			//
			this.LTime.Font = new System.Drawing.Font("AR DESTINE", 14);
			this.LTime.Text = "00:00:00";
			this.LTime.BackColor = System.Drawing.Color.Black;
			this.LTime.ForeColor = System.Drawing.Color.White;
			this.LTime.Size = new System.Drawing.Size(150, 40);
			this.LTime.Location = new System.Drawing.Point(10, 40);
			this.LTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			// BestScore
			//
			this.BestScore.ForeColor = System.Drawing.Color.Red;
			this.BestScore.Font = new System.Drawing.Font("AR HERMANN", 13);
			this.BestScore.Location = new System.Drawing.Point(0, 600);
			this.BestScore.Size = new System.Drawing.Size(170, 100);
			this.BestScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; 
			this.BestScore.BackColor = this.BackColor;
			using (System.IO.StreamReader SR = new System.IO.StreamReader(new System.IO.FileStream(@".\images\tempRanking.txt", System.IO.FileMode.Open), System.Text.Encoding.UTF8))
			{	
				string[] BestScoreString = SR.ReadLine().Split(new System.Char[] {' '});
				this.BestScore.Text = string.Format("Pause : Press P\nHold : Press H\nBest Score\n{0}" ,BestScoreString[2]);
			}
			// 
			// timer & HoldEndTime
			//
			this.timer.Interval = 1000;		
			this.timer.Tick += new System.EventHandler(timer_Tick);	
			//
			// etc
			//
			this.Block.DataSet();
			this.Gaming = true;
			this.Score = 0;
			this.HoldOK = true;
			this.Speed = 800; // 처음 시작할 때 스레드 속도
			//
			// MainThread
			//
			this.MainThread = new System.Threading.Thread(new System.Threading.ThreadStart( () => {
				while(true)
				{
					System.Threading.Thread.Sleep(Speed);
					if(!Gaming) return;
					TetrisForm_KeyDown(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));
					
					if(this.Pause)
					{
						this.EWH.WaitOne();
					}
				
					if(this.Span.ToString("hh\\:mm\\:ss") == "00:00:10")
					{
						this.HoldBlock.Text  = "Hold Block\n(Press H)";
						this.HoldBlock.ForeColor = System.Drawing.Color.Black;
						this.HoldOK = true;
					}
				}	
			}));
			this.MainThread.Name = "MainThread";
			this.MainThread.Start();			
			//
			// MenuStrip
			//
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {this.파일MenuItem, this.보기MenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.MenuStrip.Size = new System.Drawing.Size(784, 24);
			this.MenuStrip.TabIndex = 1;
			//
			// 파일MenuItem
			//
			this.파일MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[]{
				this.새로만들기MenuItem,
				this.열기MenuItem,
				this.저장MenuItem,
				this.다른이름으로저장MenuItem,
				this.인쇄MenuItem});
			this.파일MenuItem.Name = "파일";
			this.파일MenuItem.Size = new System.Drawing.Size(60, 20);
			this.파일MenuItem.Text = "파일(&F)";
			//
			// 새로만들기MenuItem
			//
			this.새로만들기MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[]{
				this.폴더MenuItem,
				this.바로가기MenuItem,
				this.비트맵MenuItem});
			this.새로만들기MenuItem.Name = "새로 만들기";
			this.새로만들기MenuItem.Size = new System.Drawing.Size(60, 20);
			this.새로만들기MenuItem.Text = "새로 만들기(&N)";
			//
			// 폴더MenuItem
			//
			this.폴더MenuItem.Name = "폴더";
			this.폴더MenuItem.Size = new System.Drawing.Size(60, 20);
			this.폴더MenuItem.Text = "폴더(&F)";
			//
			// 바로가기MenuItem
			//
			this.바로가기MenuItem.Name = "바로가기";
			this.바로가기MenuItem.Size = new System.Drawing.Size(60, 20);
			this.바로가기MenuItem.Text = "바로가기(&S)";
			//
			// 비트맵MenuItem
			//
			this.비트맵MenuItem.Name = "비트맵";
			this.비트맵MenuItem.Size = new System.Drawing.Size(60, 20);
			this.비트맵MenuItem.Text = "비트맵(&B)";
			//
			// 열기MenuItem
			//
			this.열기MenuItem.Name = "열기";
			this.열기MenuItem.Size = new System.Drawing.Size(60, 20);
			this.열기MenuItem.Text = "열기(&O)";
			//
			// 저장MenuItem
			//
			this.저장MenuItem.Name = "저장";
			this.저장MenuItem.Size = new System.Drawing.Size(60, 20);
			this.저장MenuItem.Text = "저장(&S)";
			//
			// 다른이름으로저장MenuItem
			//
			this.다른이름으로저장MenuItem.Name = "다른 이름으로 저장";
			this.다른이름으로저장MenuItem.Size = new System.Drawing.Size(60, 20);
			this.다른이름으로저장MenuItem.Text = "저장(&A)";
			//
			// 인쇄MenuItem
			//
			this.인쇄MenuItem.Name = "인쇄";
			this.인쇄MenuItem.Size = new System.Drawing.Size(60, 20);
			this.인쇄MenuItem.Text = "인쇄(&P)";
			//
			// 보기MenuItem
			//
			this.보기MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
				this.자세히MenuItem,
				this.랭킹MenuItem,
				this.작게MenuItem,
				this.리스트MenuItem,
				this.타일MenuItem});
			this.보기MenuItem.Name = "보기MenuItem";
			this.보기MenuItem.Size = new System.Drawing.Size(60, 20);
			this.보기MenuItem.Text = "보기(&V)";
			//
			// 자세히MenuItem
			//
			this.자세히MenuItem.Checked = true;
			this.자세히MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.자세히MenuItem.Name = "자세히MenuItem";
			this.자세히MenuItem.Size = new System.Drawing.Size(60, 20);
			this.자세히MenuItem.Text = "자세히(&D)";
			//
			// 랭킹MenuItem
			//
			this.랭킹MenuItem.Name = "랭킹MenuItem";
			this.랭킹MenuItem.Size = new System.Drawing.Size(60, 20);
			this.랭킹MenuItem.Text = "랭킹(&R)";
			this.랭킹MenuItem.Click += new System.EventHandler(this.랭킹MenuItem_Click);
			//
			// 리스트MenuItem
			//	
			this.리스트MenuItem.Name = "리스트MenuItem";
			this.리스트MenuItem.Size = new System.Drawing.Size(60, 20);
			this.리스트MenuItem.Text = "목록(&L)";
			//
			// 작게MenuItem
			//
			this.작게MenuItem.Name = "작게MenuItem";
			this.작게MenuItem.Size = new System.Drawing.Size(60, 20);
			this.작게MenuItem.Text = "작은 아이콘(&S)";
			//	
			// 타일MenuItem
			//
			this.타일MenuItem.Name = "타일MenuItem";
			this.타일MenuItem.Size = new System.Drawing.Size(60, 20);
			this.타일MenuItem.Text = "타일(&T)";
			//
			// RoundedButton
			// 
			this.RoundedButton.BorderColor = this.BackColor;
			this.RoundedButton.ButtonColor = this.BackColor;
			this.RoundedButton.FlatAppearance.BorderSize = 0;
			this.RoundedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((System.Int32)(((System.Byte)(11)))), 
				((System.Int32)(((System.Byte)(29)))), ((System.Int32)(((System.Byte)(36)))));
			this.RoundedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((System.Int32)(((System.Byte)(11)))), 
				((System.Int32)(((System.Byte)(29)))), ((System.Int32)(((System.Byte)(36)))));
			this.RoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RoundedButton.OnHoverBorderColor = System.Drawing.Color.Green;
			this.RoundedButton.OnHoverButtonColor = System.Drawing.Color.Green;
			this.RoundedButton.OnHoverTextColor = System.Drawing.Color.FromArgb(((System.Int32)(((System.Byte)(11)))), 
				((System.Int32)(((System.Byte)(29)))), ((System.Int32)(((System.Byte)(36)))));
			this.RoundedButton.TextColor = System.Drawing.Color.White;
			this.RoundedButton.UseVisualStyleBackColor = true;
			this.RoundedButton.Click += new System.EventHandler(RoundedButton_Click);
			this.RoundedButton.Location = new System.Drawing.Point(30, 620);
			//this.RoundedButton.Size = new System.Drawing.Size(80, 30);
			this.RoundedButton.Text = "";
			this.RoundedButton.TextColor = System.Drawing.Color.White;
			this.RoundedButton.OnHoverTextColor = System.Drawing.Color.Gray;
			this.RoundedButton.Font = new System.Drawing.Font("AR DESTINE", 18);
			this.RoundedButton.Enabled = false;
			// TetrisForm
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Text = "테트리스";
			this.Size = new System.Drawing.Size(800, 770); // 창 크기 조절.
			this.CenterToScreen();
			this.DoubleBuffered = true;
			this.Icon = new System.Drawing.Icon(@".\images\tetris.ico");
			this.AutoScroll = true;
			this.TopMost = false;
			this.HelpButton = true;
			this.ShowIcon = true;
			this.ShowInTaskbar = true;
			//this.AutoSizeMode = System.Windows.Forms.GrowAndShrink;
			this.ShowInTaskbar = true;
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(TetrisForm_MouseWheel);
			this.Load += new System.EventHandler(TetrisForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(TetrisForm_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(TetrisForm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TetrisForm_KeyPress);
			this.Closing += new System.ComponentModel.CancelEventHandler(TetrisForm_Closing);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(TetrisForm_MouseClick);
			//this.IsMdiContainer = true;
			this.MainMenuStrip = this.MenuStrip;
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			this.Controls.AddRange(new System.Windows.Forms.Control[]{this.ScoreNum, this.BestScore, this.LabelNextBlock, this.HoldBlock, this.LTime, this.MenuStrip, this.RoundedButton});
			//git test

		}


		private BlockData Block;
		private System.Int32 Speed;
		protected System.Int32 Score;
		private System.Threading.Thread MainThread;
		private System.Boolean Gaming;
		private System.Boolean Pause;
		private System.Boolean HoldOK;
		private System.Windows.Forms.Label ScoreNum;
		private System.Windows.Forms.Label LabelNextBlock;
		private System.Windows.Forms.Label HoldBlock;
		private System.Windows.Forms.Label BestScore;
		private System.Windows.Forms.Label LTime;
		private System.DateTime HoldEndTime;
		private System.Windows.Forms.Timer timer;
		private System.TimeSpan Span;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem 파일MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 새로만들기MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 폴더MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 바로가기MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 비트맵MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 열기MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 저장MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 인쇄MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 보기MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 자세히MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 랭킹MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 리스트MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 작게MenuItem;
		private System.Windows.Forms.ToolStripMenuItem 타일MenuItem;
		private System.Threading.EventWaitHandle EWH;
		private Button_WOC RoundedButton;
		







	}
}	