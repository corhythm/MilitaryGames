namespace Intergration
{
	internal class Button_WOC : System.Windows.Forms.Button
	{
		private System.Drawing.Color _borderColor = System.Drawing.Color.Silver;
		private System.Drawing.Color _onHoverBorderColor = System.Drawing.Color.Green;
		private System.Drawing.Color  _buttonColor = System.Drawing.Color.Red;
		private System.Drawing.Color _onHoverButtonColor = System.Drawing.Color.Beige;
		private System.Drawing.Color _textColor = System.Drawing.Color.White;
		private System.Drawing.Color _onHoverTextColor = System.Drawing.Color.Gray;

		public System.Boolean _isHovering;
		private System.Int32 _borderThickness = 6;
		private System.Int32 _borderThicknessByTwo = 3;

		public Button_WOC()
		{
			this.DoubleBuffered = true;
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);
			System.Drawing.Graphics g = e.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			System.Drawing.Brush brush = new System.Drawing.SolidBrush(_isHovering ? _onHoverBorderColor : _borderColor);

			// Border
			g.FillEllipse(brush, 0, 0, Height, Height);
			g.FillEllipse(brush, Width - Height, 0, Height, Height);
			g.FillRectangle(brush, Height / 2, 0, Width - Height, Height);
	
			brush.Dispose();
			brush = new System.Drawing.SolidBrush(_isHovering ? _onHoverButtonColor : _buttonColor);

			// Inner Part. Button inself
			g.FillEllipse(brush, _borderThicknessByTwo, _borderThicknessByTwo, Height - _borderThickness, Height -  _borderThickness);
			g.FillEllipse(brush, (Width - Height) + _borderThicknessByTwo, _borderThicknessByTwo, Height - _borderThickness, Height - _borderThickness);
			g.FillRectangle(brush, Height / 2 + _borderThicknessByTwo, _borderThicknessByTwo, Width - Height - _borderThickness, Height - _borderThickness);

			brush.Dispose();
			brush = new System.Drawing.SolidBrush(_isHovering ? _onHoverTextColor : _textColor);
		
			// Button Text
			System.Drawing.SizeF stringSize = g.MeasureString(Text, Font);		
			g.DrawString(Text, Font, brush, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
		}

		public System.Drawing.Color BorderColor
		{
			get  { return _borderColor; }
			set	
			{
				_borderColor = value;
				Invalidate();
			}
		}

		public System.Drawing.Color OnHoverBorderColor
		{
			get {  return _onHoverBorderColor; }
			set
			{
				_onHoverBorderColor = value;
				Invalidate();
			}
		}
			
		public System.Drawing.Color ButtonColor
		{
			get  { return _buttonColor; }
			set
			{
				_buttonColor = value;
				Invalidate();
			}
		}

		public System.Drawing.Color OnHoverButtonColor
		{
			get  { return _onHoverButtonColor; }
			set
			{
				_onHoverButtonColor = value;
				Invalidate();
			}
		}

		public System.Drawing.Color OnHoverTextColor
		{
			get  { return  _onHoverTextColor; }
			set
			{
				_onHoverTextColor = value;
				Invalidate();
			}
		}

		public System.Drawing.Color TextColor
		{
			get  { return _textColor; }
			set
			{
				_textColor = value;
				Invalidate();
			}
		}
	}
}