namespace Intergration
{
	internal partial class InputRankingForm : System.Windows.Forms.Form
	{		
		public delegate void FormSendDataHandler(System.String sendString1, System.String sendString2);
		public event FormSendDataHandler FormSendEvent;		

		private System.ComponentModel.IContainer components = null;
		
		TetrisForm TetrisForm;

		public InputRankingForm()
		{
			InitializeComponent();	
		}

		public InputRankingForm(TetrisForm TetrisForm)
		{
			this.TetrisForm = TetrisForm;
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

		private void SubmitButton_Click(System.Object sender, System.EventArgs e)
		{
			for(System.Int32 i = 0; i < this.ID.Text.Length; i++)
			{
				if(this.ID.Text[i] == ' ')
				{
					System.Windows.Forms.MessageBox.Show("닉네임에 공백이 있으면 안 됩니다.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					this.ID.Text = "";
					this.ID.SelectAll();
					this.ID.Focus();	
					return;
				}
			}

			for(System.Int32 i = 0; i < this.KakaoID.Text.Length; i++)
			{
				if(this.KakaoID.Text[i] == ' ')
				{
					System.Windows.Forms.MessageBox.Show("올바른 이메일 양식이 아닙니다.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					this.KakaoID.Text = "";
					this.KakaoID.SelectAll();
					this.KakaoID.Focus();	
					return;
				}
			} 
				
			this.FormSendEvent(this.ID.Text, this.KakaoID.Text);
			this.Close();
		}

		private void InitializeComponent()
		{	
			
			this.components = new System.ComponentModel.Container();
			this.ID= new System.Windows.Forms.TextBox();
			this.KakaoID = new System.Windows.Forms.TextBox();
			this.SubmitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// ID
			//
			this.ID.Name = "ID";
			this.ID.Text = "NickName";
			this.ID.Size = new System.Drawing.Size(180, 70);
			this.ID.Location = new System.Drawing.Point(10, 20);
			this.ID.BackColor = System.Drawing.Color.LavenderBlush;
			this.ID.TabIndex = 1;
			this.ID.Font = new System.Drawing.Font("AR DECODE", 20);
			this.ID.Enter += (sender, e) => {
				if(this.ID.Text == "NickName")
					this.ID.Text = "";		
			};
			this.ID.Leave += (sender, e) => {
				if(this.ID.Text == "")
					this.ID.Text = "NickName";
			};
			//
			// KakaoID
			//
			this.KakaoID.Name = "Kakao ID";
			this.KakaoID.Text = "Kakao ID"; 
			this.KakaoID.Size = new System.Drawing.Size(180, 70);
			this.KakaoID.Location = new System.Drawing.Point(10, 70);
			this.KakaoID.BackColor = System.Drawing.Color.Firebrick;
			this.KakaoID.Font = new System.Drawing.Font("AR CARTER", 20);
			this.TabIndex = 2;
			this.KakaoID.Enter += (sender, e) => {
				if(this.KakaoID.Text == "Kakao ID")
					this.KakaoID.Text = "";	
			};
			this.KakaoID.Leave += (sender, e) => {
				if(this.KakaoID.Text == "")
					this.KakaoID.Text = "Kakao ID";				
			};
			this.SubmitButton.Text = "Submit";
			this.SubmitButton.BackColor = System.Drawing.Color.DarkOrchid;
			this.SubmitButton.Font = new System.Drawing.Font("AR DARLING", 15);
			this.SubmitButton.Size = new System.Drawing.Size(100, 30);
			this.SubmitButton.Location = new System.Drawing.Point(80, 150);
			this.SubmitButton.TabIndex = 0;
			this.SubmitButton.Click += new System.EventHandler(SubmitButton_Click);
			//
			// InputRankingForm
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 200);
			this.TopMost = true;
			this.AutoScroll = true;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.ID, this.KakaoID, this.SubmitButton});
			this.FormClosing += (sender, e) => { };
			this.Name = "InputRankingForm";
			this.Text = "New Rank!!";
			/*this.FormClosing += (sender, e) => {
				if(this.KakaoID.Text == "Kakao ID" || this.ID.Text == "ID")
				{
					
				}
			};*/
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}


		System.Windows.Forms.TextBox ID;
		System.Windows.Forms.TextBox KakaoID;
		System.Windows.Forms.Button SubmitButton;

	}
}	