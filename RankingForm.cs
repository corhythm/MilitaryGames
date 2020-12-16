namespace Intergration
{
	internal partial class RankingForm : System.Windows.Forms.Form
	{	
		private System.ComponentModel.IContainer components = null;
		private System.String[] ReadMicroString;

		public RankingForm()
		{
			InitializeComponent();
			ReadRanking();
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ListView = new System.Windows.Forms.ListView();
			this.RankHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.IDHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ScoreHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this. KakaoIDHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.GamePlayTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LargeIconMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SmallIconMenuItem = new System.Windows.Forms.ToolStripMenuItem(); 
			this.ListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			//
			// ListView
			//
			this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this.RankHeader,
				this.IDHeader,
				this.ScoreHeader,
				this.KakaoIDHeader,
				this.GamePlayTimeHeader});

			for(int i = 0; i < this.ListView.Columns.Count; i++)
			{
				this.ListView.Columns[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			}

			this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListView.Location = new System.Drawing.Point(0, 24);
			this.ListView.Name = "Ranking";
			this.ListView.Size = new System.Drawing.Size(800, 540);
			this.ListView.TabIndex = 0;
			this.ListView.UseCompatibleStateImageBehavior = false;
			this.ListView.View = System.Windows.Forms.View.Details;
			this.ListView.FullRowSelect = true;
			this.ListView.GridLines = true;
			//
			// RankHeader
			//
			this.RankHeader.Text = "Rank";
			this.RankHeader.Width = 60;
			//
			// IDHeader
			// 
			this.IDHeader.Text = "ID";
			this.IDHeader.Width = 150;
			//
			// ScoreHeader
			//
			this.ScoreHeader.Text = "Score";
			this.ScoreHeader.Width = 100;
			//
			// KakaoIDHeader
			//
			this.KakaoIDHeader.Text = "Kakao ID";
			this.KakaoIDHeader.Width = 200;
			//
			// GamePlayTime
			//
			this.GamePlayTimeHeader.Text = "Play Time";
			this.GamePlayTimeHeader.Width = 100;
			//this.GamePlayTimeHeader.Font = new System.Drawing.Font("AR CARTER", 18);
			//
			// MenuStrip
			//
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {this.ViewMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.MenuStrip.Size = new System.Drawing.Size(784, 24);
			this.MenuStrip.TabIndex = 1;
			//
			// ViewMenuItem
			//
			this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
				this.DetailMenuItem,
				this.LargeIconMenuItem,
				this.SmallIconMenuItem,
				this.TileMenuItem});
			this.ViewMenuItem.Name = "ViewMenuItem";
			this.ViewMenuItem.Size = new System.Drawing.Size(60, 20);
			this.ViewMenuItem.Text = "보기(&V)";
			//
			// DetailMenuItem
			//
			this.DetailMenuItem.Checked = true;
			this.DetailMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DetailMenuItem.Name = "DetailMenuItem";
			this.DetailMenuItem.Size = new System.Drawing.Size(153, 22);
			this.DetailMenuItem.Font = new System.Drawing.Font("AR CARTER", 10);
			this.DetailMenuItem.Text = "상세(&D)";
			this.DetailMenuItem.Click += new System.EventHandler(DetailMenuItem_Click);
			//
			// LargeIconMenuItem
			//
			this.LargeIconMenuItem.Name = "LargeIconMenuItem";
			this.LargeIconMenuItem.Size = new System.Drawing.Size(153, 22);
			this.LargeIconMenuItem.Text = "큰 아이콘(&B)";
			this.LargeIconMenuItem.Font = new System.Drawing.Font("AR BONNIE", 10);
			this.LargeIconMenuItem.Click += new System.EventHandler(LargeIconMenuItem_Click);
			//
			// ListMenuItem
			//	
			this.ListMenuItem.Name = "ListMenuItem";
			this.ListMenuItem.Size = new System.Drawing.Size(153, 22);
			this.ListMenuItem.Text = "목록(&L)";
			this.ListMenuItem.Click += new System.EventHandler(ListMenuItem_Click);
			//
			// SmallIconMenuItem
			//
			this.SmallIconMenuItem.Name = "SmallIconMenuItem";
			this.SmallIconMenuItem.Size = new System.Drawing.Size(153, 22);
			this.SmallIconMenuItem.Text = "작은 아이콘(&S)";
			this.SmallIconMenuItem.Click += new System.EventHandler(SmallIconMenuItem_Click);
			//	
			// TileMenuItem
			//
			this.TileMenuItem.Name = "TileMenuItem";
			this.TileMenuItem.Size = new System.Drawing.Size(153, 22);
			this.TileMenuItem.Text = "타일(&T)";
			this.TileMenuItem.Click += new System.EventHandler(TileMenuItem_Click);
			//
			// RankingForm
			//
			this.Name = "RankingForm";	
			this.Text = "Ranking";
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(615, 600);
			this.TopMost = true;
			this.AutoScroll = true;
			this.Icon = new System.Drawing.Icon(@".\images\peanut.ico");
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.ListView, this.MenuStrip});
			this.Font = new System.Drawing.Font("AR CHRISTY", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.FormClosing += (sender, e) => {
				//this.SelectForm.ShowDialog();
				//this.Dispose();
			};
			this.MainMenuStrip = this.MenuStrip;
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}


		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		private void DetailMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ListView.View = System.Windows.Forms.View.Details;
			CheckMenuItem(this.ViewMenuItem, this.DetailMenuItem);
		}
	
		private void LargeIconMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ListView.View = System.Windows.Forms.View.LargeIcon;
			CheckMenuItem(this.ViewMenuItem, this.LargeIconMenuItem);
		}
	
		private void ListMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ListView.View = System.Windows.Forms.View.List;
			CheckMenuItem(this.ViewMenuItem, this.ListMenuItem);
		}
		
		private void SmallIconMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ListView.View = System.Windows.Forms.View.SmallIcon;
			CheckMenuItem(this.ViewMenuItem, this.SmallIconMenuItem);
		}
		
		private void TileMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ListView.View = System.Windows.Forms.View.Tile;
			CheckMenuItem(this.ViewMenuItem, this.TileMenuItem);
		}
		
		private void CheckMenuItem(System.Windows.Forms.ToolStripMenuItem ParentMenuItem, System.Windows.Forms.ToolStripMenuItem CheckChildMenuItem)
		{
			foreach(System.Windows.Forms.ToolStripItem toolStripItem in ParentMenuItem.DropDownItems)
			{	
				if(toolStripItem is System.Windows.Forms.ToolStripMenuItem)
				{
					System.Windows.Forms.ToolStripMenuItem ChildMenuItem  = toolStripItem as System.Windows.Forms.ToolStripMenuItem;
					ChildMenuItem.Checked = false;
				}
			}

			CheckChildMenuItem.Checked = false;
		}
		
		private void ReadRanking()
		{
			if(!System.IO.File.Exists(@"C:\Program Files\ginknar.txt"))
			{											
				System.IO.FileStream stream = System.IO.File.Create(@"C:\Program Files\ginknar.txt");
				stream.Close();							

				System.Windows.Forms.MessageBox.Show("랭킹 기록이 없습니다",
					"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);

				return;
			}

			using(System.IO.StreamReader SR = new System.IO.StreamReader(
				new System.IO.FileStream(@"C:\Program Files\ginknar.txt", System.IO.FileMode.Open), System.Text.Encoding.Default))
			{
				try
				{
					for(System.Int32 i = 0; i < 20; i++)
					{				
						//ReadMicroString = this.ReadString[i].Split(new System.Char[] {' '});		
						ReadMicroString = SR.ReadLine().Split(new System.Char[] {' '});
						this.ListView.Items.Add(new System.Windows.Forms.ListViewItem(new System.String[] {
						ReadMicroString[0],
						ReadMicroString[1],
						ReadMicroString[2],
						ReadMicroString[3]}));
					}
	
				}
				catch(System.Exception) 
				{	
					System.Console.WriteLine("Error");
				}
			}
			
			/*try
			{
				for(System.Int32 i = 0; i < 20; i++)
				{
				
					ReadMicroString = this.ReadString[i].Split(new System.Char[] {' '});		
					this.ListView.Items.Add(new System.Windows.Forms.ListViewItem(new System.String[] {
					ReadMicroString[0],
					ReadMicroString[1],
					ReadMicroString[2],
					ReadMicroString[3]}));
				}
	
			}
			catch(System.Exception) 
			{	
				System.Console.WriteLine("Error");
			}*/

			
		}

		private void WriteRanking()
		{

		}
			
		private System.Windows.Forms.ListView ListView;
		private System.Windows.Forms.ColumnHeader RankHeader;
		private System.Windows.Forms.ColumnHeader IDHeader;
		private System.Windows.Forms.ColumnHeader ScoreHeader;
		private System.Windows.Forms.ColumnHeader KakaoIDHeader;
		private System.Windows.Forms.ColumnHeader GamePlayTimeHeader;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DetailMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LargeIconMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ListMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SmallIconMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TileMenuItem;
	

	}
}