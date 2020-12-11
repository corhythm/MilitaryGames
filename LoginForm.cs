namespace Intergration
{
	internal partial class LoginForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		public LoginForm()
		{
			InitializeComponent();
			this.ID.Focus();	
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
			this.RoundedButton = new Button_WOC();	
			this.ID = new System.Windows.Forms.TextBox();
			this.Password = new System.Windows.Forms.TextBox();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// RoundedButton
			//
			//
			// RoundedButton
			// 
			this.RoundedButton.BorderColor = System.Drawing.Color.Orange;
			this.RoundedButton.ButtonColor = System.Drawing.Color.Orange;
			this.RoundedButton.OnHoverBorderColor = System.Drawing.Color.Orange;
			this.RoundedButton.OnHoverButtonColor = System.Drawing.Color.Beige;
			this.RoundedButton.TextColor = System.Drawing.Color.Black;
			this.RoundedButton.OnHoverTextColor = System.Drawing.Color.Black;
			this.RoundedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Beige;
			this.RoundedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige;
			this.RoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RoundedButton.UseVisualStyleBackColor = true;
			this.RoundedButton.FlatAppearance.BorderSize = 0;
			this.RoundedButton.Click += new System.EventHandler(RoundedButton_Click);
			this.RoundedButton.Location = new System.Drawing.Point(100, 250);
			this.RoundedButton.Size = new System.Drawing.Size(150, 60);
			this.RoundedButton.Text = "Login";
			this.RoundedButton.Font = new System.Drawing.Font("AR CENA", 20);
			this.RoundedButton.Enabled = true;
			this.RoundedButton.MouseEnter += new System.EventHandler(RoundedButton_MouseEnter);
			this.RoundedButton.MouseLeave += new System.EventHandler(RoundedButton_MouseLeave);
			//
			// ID
			//
			this.ID.Text = "ID";
			this.ID.Size = new System.Drawing.Size(280, 150);
			this.ID.Location = new System.Drawing.Point(30, 120);
			this.ID.Font = new System.Drawing.Font("AR DESTINE", 20);
			this.ID.Enter += (sender, e) => {
				if(this.ID.Text == "ID")
				{
					this.ID.Text = "";
				}
			};
			this.ID.Leave += (sender, e) => {
				if(this.ID.Text == "")
				{
					this.ID.Text = "ID";
				}
			};
			//
			// Password
			//
			this.Password.Text = "password";
			this.Password.Size = new System.Drawing.Size(280, 150);
			this.Password.Location = new System.Drawing.Point(30, 180);
			this.Password.MaxLength = 15;
			
			this.Password.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			//this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Password.Font = new System.Drawing.Font("AR DELANEY", 20);
			this.Password.Enter += (sender, e) =>{
				if(this.Password.Text == "password")
				{
					this.Password.Text = "";
					this.Password.PasswordChar = '●';
				}
			};

			this.Password.Leave += (sender, e) => {
				if(this.Password.Text == "")
				{
					this.Password.Text = "password";
					this.Password.PasswordChar = '\0';
				}
			};

			this.Password.KeyDown += (sender, e) => {
				if(e.KeyCode == System.Windows.Forms.Keys.Enter)
				{
					RoundedButton_Click(sender, e);
					//RoundedButton_Click(sender, e);
					//RoundedButton_MouseLeave(sender, e);
				}
			};
			//
			// LoginLabel
			//
			this.LoginLabel.Text = "Login";
			this.LoginLabel.Size = new System.Drawing.Size(300, 100);
			this.LoginLabel.Location = new System.Drawing.Point(60, 20);
			this.LoginLabel.Font = new System.Drawing.Font("AR DELANEY", 60);
			//
			// LoginForm
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 350);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.RoundedButton, this.ID, this.Password, this.LoginLabel});
			this.Name = "Login";
			this.Icon = new System.Drawing.Icon(@".\images\login.ico");
			this.BackColor = System.Drawing.Color.Beige;
			this.FormClosing += (sender, e) => {
				System.Windows.Forms.Application.Exit();
				this.Dispose();
			};
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		
		private void RoundedButton_Click(System.Object sender, System.EventArgs e)
		{
			if((this.ID.Text == "1" || this.ID.Text == "xhdtls!!!")&& this.Password.Text == "1")
			{	
				//System.Threading.ThreadPool.QueueUserWorkItem(Invoke, null);
				new System.Threading.Thread(() => { new SelectForm().ShowDialog(); }).Start();
				this.Dispose();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다!\n(Hint : ID는 보급계 1차 비번, PW는 2차 비번)",
					  "Error", System.Windows.Forms.MessageBoxButtons.OK);
				this.Password.Text = "password";
				this.Password.PasswordChar = '\0';
				this.ID.Text = "";
				this.ID.Focus();
			}
		}
		
		private void RoundedButton_MouseEnter(System.Object sender, System.EventArgs e)
		{
			this.RoundedButton._isHovering = true;
			this.RoundedButton.Location = new System.Drawing.Point(30, 250);
			this.RoundedButton.Size =  new System.Drawing.Size(300, 60);
			this.RoundedButton.Invalidate();
		}

		private void RoundedButton_MouseLeave(System.Object sender, System.EventArgs e)
		{
			this.RoundedButton._isHovering = false;
			this.RoundedButton.Location = new System.Drawing.Point(100, 250);
			this.RoundedButton.Size =  new System.Drawing.Size(150, 60);
			this.RoundedButton.Invalidate();
		}


		private Button_WOC RoundedButton;	
		private System.Windows.Forms.TextBox ID;
		private System.Windows.Forms.TextBox Password;
		private System.Windows.Forms.Label LoginLabel;
		
	}
}	