namespace Intergration
{
	
	[System.Serializable]
	public class BlockData
	{
		private System.Int32 XPoint;
		private System.Int32 YPoint;
		private System.Random Random; 
		private System.Boolean First;
		private System.Int32 Shape;
		public readonly System.Int32 Width;
		public readonly System.Int32 Height;
		public System.Boolean[,] GameBoard;
		public System.Drawing.Color[,] GameBoardColor;
		//public System.Drawing.
		public System.Int32[][,,] HoldedBlock;
		private System.Boolean HoldTime;
		private System.Boolean IsSavedBlock;
		public System.Drawing.Color HoldedBlockColor;
		public readonly System.Int32[][,,] NextBlockList;
		public readonly System.Drawing.Color[] RandomColorList;
		public readonly System.Drawing.Color[] AllColor;
		public readonly System.Int32[][,,] BlockShapeList =	
		{
			new System.Int32[2, 2, 4] // 0, I
			{
				{		
					{0, 1, 2, 3},	// ■ ■ ■ ■	
					{0, 0, 0, 0}
				},	
				{			// ■
					{0, 0, 0, 0},	// ■		
					{0, 1, 2, 3}	// ■
				}			// ■
			},
			
			new System.Int32[4, 2, 4] // 1, L
			{
				{
					{0, 1, 2, 2},	//    	■		
					{1, 1, 0, 1}	//  ■ ■ ■
				},
				{		
					{0, 0, 0, 1},	//  ■	
					{0, 1, 2, 2}	//  ■
				},			//  ■ ■
				{			
					{0, 0, 1, 2},	//  ■ ■ ■	
					{0, 1, 0, 0}	//  ■
				},
				{			
					{0, 1, 1, 1},      //   ■ ■		
					{0, 0, 1, 2}	//     ■
				}			//     ■	
			},

			new System.Int32[4, 2, 4] // 2, J
			{
				{
					{0, 0, 1, 2},	// ■		
					{0, 1, 1, 1}	// ■ ■ ■
				},
				{
					{0, 0, 0, 1},	// ■ ■	
					{0, 1, 2, 0}	// ■
				},			// ■
				{
					{0, 1, 2, 2},	// ■ ■ ■				
					{0, 0, 0, 1}	//     ■
				},
				{								
					{0, 1, 1, 1},	//     ■			
					{2, 0, 1, 2}	//     ■
				}			// ■ ■
			},

			new System.Int32[2, 2, 4] // 3, S
			{
				{
					{0, 1, 1, 2},	//     ■ ■		
					{1, 0, 1, 0}	// ■ ■
				}, 
				{
					{0, 0, 1, 1},	// ■		
					{0, 1, 1, 2}	// ■ ■
				}			//     ■
			},

			new System.Int32[2, 2, 4] // 4, Z
			{
				{	
					{0, 1, 1, 2},	// ■ ■		
					{0, 0, 1, 1}	//   ■ ■
				},
				{
					{0, 0, 1, 1},	//   ■		
					{1, 2, 0, 1}	// ■ ■
				}			// ■
			},

			new System.Int32[1, 2, 4] // 5, O
			{
				{	
					{0, 0, 1, 1},	// ■ ■
					{0, 1, 0, 1}	// ■ ■
				}
			},

			new System.Int32[4, 2, 4] // 6
			{
				{	 		
					{0, 1, 1, 2},	//     ■
					{1, 0, 1, 1}	// ■ ■ ■
				},			
				{	
					{0, 0, 0, 1},	// ■			
					{0, 1, 2, 1}	// ■ ■
				},			// ■
				{	
					{0, 1, 1, 2},	// ■ ■ ■		
					{0, 0, 1, 0}	//     ■
				},
				{	
					{0, 1, 1, 1},	//   ■
					{1, 0, 1, 2}	// ■ ■
				}			//   ■

			}
		};
		
		
		public BlockData()
		{	
			this.First = true;
			this.Width = 15;
			this.Height = 25;
			this.Random = new System.Random();
			this.NextBlockList = new System.Int32[9][,,];
			this.RandomColorList = new System.Drawing.Color[9];
			this.HoldedBlock = new System.Int32[1][,,];
			this.HoldTime = true;
			this.IsSavedBlock = false;
			

			this.GameBoard = new System.Boolean[this.Width, this.Height + 1]; 
			for(System.Int32 x = 0; x < this.Width; x++)
			{
				this.GameBoard[x, this.Height] = true; // It's floor.
			}
			
			this.GameBoardColor = new System.Drawing.Color[this.Width, this.Height];
			for(System.Int32 width = 0; width < this.Width; width++)
			{
				for(System.Int32 height = 0; height < this.Height; height++)
				{
					this.GameBoardColor[width, height] = System.Drawing.Color.Beige;
				}
			}

			this.AllColor = new System.Drawing.Color[]{ 
				System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, 
				System.Drawing.Color.Black, 
				System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, 
				System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, 
				System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, 
				System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Crimson, 
				System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, 
				System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, 
				System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen,
				System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, 
				System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, 
				System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, 
				System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, 
				System.Drawing.Color.Firebrick,  System.Drawing.Color.ForestGreen, 
				System.Drawing.Color.Fuchsia, 
				System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, 
				System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, 
				System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, 
				System.Drawing.Color.Khaki,
				System.Drawing.Color.LawnGreen,  
				System.Drawing.Color.LightBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, 
				System.Drawing.Color.Green, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, 
				System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, 
				System.Drawing.Color.LightSteelBlue, System.Drawing.Color.Lime, 
				System.Drawing.Color.LimeGreen, System.Drawing.Color.Magenta, 
				System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumSeaGreen, 
				System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, 
				System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, 
				System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, 		
				System.Drawing.Color.Navy, System.Drawing.Color.Olive, 
				System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, 
				System.Drawing.Color.PaleGreen,  
				System.Drawing.Color.PaleVioletRed, 
				System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, 
				System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, 
				System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, 
				System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, 
				System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.SpringGreen, 
				System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, 
				System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, 
				System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen 
			};
		}
	
		// e.Graphics.FillRectangle(new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)random.Next(1, 52), AllColor[random.Next(1, AllColor.Length)], 
		//	AllColor[random.Next(1, AllColor.Length)]), x * 25, y * 25, 25, 25);

		public System.Int32 X
		{
			get {return this.XPoint;}
			set {this.XPoint = value;}
		}
		
		public System.Int32 Y
		{
			get {return this.YPoint;}
			set {this.YPoint = value;}
		}
		
		public System.Int32 NowBlockShape
		{
			get {return this.Shape;}
			set {this.Shape = value;}
		}

		public System.Int32 TableWidth
		{
			get {return this.Width;}
		}
		
		public System.Int32 TableHeight
		{
			get {return this.Height;}
		}

		/*public System.Int32[][,,] HoldedBlock
		{
			get {return this.HoldBlock;}
			set { this.HoldBlock = value;}
		}*/

		public System.Boolean IsHoldPossible
		{
			get {return this.HoldTime;}
			set {this.HoldTime = value;}
		}

		public System.Boolean IsSaved
		{
			get {return this.IsSavedBlock; }
			set {this.IsSavedBlock = value;}
		}

		public void DataSet()
		{
			this.XPoint = 6;
			this.YPoint = 0;
			this.Shape = 0;

			if(First) // 처음 시작하는 거면
			{
				First = false;
				
				for(System.Int32 i = 0; i < this.NextBlockList.Length; i++)
				{
					this.NextBlockList[i] = this.BlockShapeList[this.Random.Next(0, this.BlockShapeList.Length)];
					this.RandomColorList[i] = this.AllColor[this.Random.Next(0, this.AllColor.Length)];
				}	 
			}
			else
			{	
				for(System.Int32 index = 0; index < this.NextBlockList.Length; index++)
				{
					if(index == this.NextBlockList.Length - 1)
					{
						this.NextBlockList[index] = this.BlockShapeList[this.Random.Next(0, this.BlockShapeList.Length)];
						this.RandomColorList[index] = this.AllColor[this.Random.Next(0, this.AllColor.Length)];
					}
					else
					{
						this.NextBlockList[index] = this.NextBlockList[index + 1];
						this.RandomColorList[index] = this.RandomColorList[index + 1];
					}				
				}
			}	

		}
	














	} 
}