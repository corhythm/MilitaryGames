namespace Intergration
{
	public partial class SelectForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		public SelectForm()
		{
			InitializeComponent();	
		}
	
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{	
			
			this.components = new System.ComponentModel.Container();
			this.TetrisButton = new System.Windows.Forms.Button();
			this.SlitherIOButton = new System.Windows.Forms.Button();
			this.LauchingButton = new System.Windows.Forms.Button();
			this.RankingButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// TetrisButton
			//
			this.TetrisButton.Font = new System.Drawing.Font("AR DECODE", 20);
			this.TetrisButton.Text = "Tetris";
			this.TetrisButton.Size = new System.Drawing.Size(280, 70);
			this.TetrisButton.Location = new System.Drawing.Point(30, 30);
			this.TetrisButton.BackColor = System.Drawing.Color.LavenderBlush;
			this.TetrisButton.Click += new System.EventHandler(TetrisButton_Click);
			this.TetrisButton.BackgroundImage = System.Drawing.Image.FromFile(@".\images\tetrisbtn.jpg");
			//
			// SlitherIOButton
			//
			this.SlitherIOButton.Font = new System.Drawing.Font("AR CARTER", 20);	
			this.SlitherIOButton.Text = "SlitherIO";
			this.SlitherIOButton.ForeColor = System.Drawing.Color.White;
			this.SlitherIOButton.BackColor = System.Drawing.Color.Firebrick;
			this.SlitherIOButton.Size = new System.Drawing.Size(280, 70);
			this.SlitherIOButton.Location = new System.Drawing.Point(30, 130);
			this.SlitherIOButton.BackgroundImage = System.Drawing.Image.FromFile(@".\images\slitherbtn.jpg");
			this.SlitherIOButton.Click += (sender, e) => {
				new System.Threading.Thread(() => { new SlitherIOForm(this).ShowDialog(); }).Start();
				this.Dispose();	
			};
			//
			// LauchingButton
			//
			this.LauchingButton.Font = new System.Drawing.Font("AR DARLING", 20);
			this.LauchingButton.Text = "Not Yet";
			this.LauchingButton.BackColor = System.Drawing.Color.DarkOrchid;
			this.LauchingButton.Size = new System.Drawing.Size(280, 70);
			this.LauchingButton.Location = new System.Drawing.Point(30, 230);
			this.LauchingButton.Click += (sender, e) => {
				System.Windows.Forms.MessageBox.Show("No Match",
					  "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);
			};
			//
			// RankingButton
			//
			this.RankingButton.Font = new System.Drawing.Font("AR ESSENCE", 17);
			this.RankingButton.Text = "Show Ranking";
			this.RankingButton.BackColor = System.Drawing.Color.Coral;
			this.RankingButton.Size = new System.Drawing.Size(160, 40);
			this.RankingButton.Location = new System.Drawing.Point(10, 330);
			this.RankingButton.Click += (sender, e) => {
				this.RankingForm = new RankingForm();
				this.RankingForm.ShowDialog();
			};
			//
			// ExitButton
			//
			this.ExitButton.Font = new System.Drawing.Font("AR JULIAN", 20);
			this.ExitButton.Text = "Exit";
			this.ExitButton.BackColor = System.Drawing.Color.IndianRed;
			this.ExitButton.Size = new System.Drawing.Size(160, 40);
			this.ExitButton.Location = new System.Drawing.Point(180, 330);
			this.ExitButton.Click += (sender, e) => {
				//this.Close(); 
				this.Dispose();	 
				System.Windows.Forms.Application.Exit(); 				
			};
			//
			// SelectForm
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 400);
			this.Name = "SelectForm";
			this.Text = "½É½ÉÇ®ÀÌ ¶¥Äá";
			this.Icon = new System.Drawing.Icon(@".\images\peanut.ico");
			this.Controls.AddRange(new System.Windows.Forms.Control[]{this.TetrisButton, this.SlitherIOButton, this.LauchingButton, this.RankingButton, this.ExitButton});
			this.FormClosing += (sender, e) => { 
				//this.Close();
				this.Dispose();
				System.Windows.Forms.Application.Exit(); 				
			};
			this.BackColor = System.Drawing.Color.Beige;
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
			
		private void TetrisButton_Click(System.Object sender, System.EventArgs e)
		{
			new System.Threading.Thread(() => { new TetrisForm(this).ShowDialog(); }).Start();
			this.Dispose();
		}

		private System.Windows.Forms.Button TetrisButton;
		private System.Windows.Forms.Button SlitherIOButton;
		private System.Windows.Forms.Button LauchingButton;
		private System.Windows.Forms.Button RankingButton;
		private System.Windows.Forms.Button ExitButton;
		private RankingForm RankingForm;




	}
}	