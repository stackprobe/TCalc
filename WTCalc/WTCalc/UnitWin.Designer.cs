namespace WTCalc
{
	partial class UnitWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitWin));
			this.label1 = new System.Windows.Forms.Label();
			this.CBSeido = new System.Windows.Forms.ComboBox();
			this.MainGrp = new System.Windows.Forms.GroupBox();
			this.CBOutput = new System.Windows.Forms.ComboBox();
			this.TBOutput = new System.Windows.Forms.TextBox();
			this.LOutput = new System.Windows.Forms.Label();
			this.CBInput = new System.Windows.Forms.ComboBox();
			this.TBInput = new System.Windows.Forms.TextBox();
			this.LInput = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CBUnit = new System.Windows.Forms.ComboBox();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.MainGrp.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(264, 17);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "精度";
			// 
			// CBSeido
			// 
			this.CBSeido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CBSeido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBSeido.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CBSeido.FormattingEnabled = true;
			this.CBSeido.Items.AddRange(new object[] {
            "小数点以下10桁まで",
            "小数点以下100桁まで",
            "小数点以下1000桁まで"});
			this.CBSeido.Location = new System.Drawing.Point(307, 14);
			this.CBSeido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.CBSeido.Name = "CBSeido";
			this.CBSeido.Size = new System.Drawing.Size(183, 28);
			this.CBSeido.TabIndex = 1;
			this.CBSeido.SelectedIndexChanged += new System.EventHandler(this.CBSeido_SelectedIndexChanged);
			// 
			// MainGrp
			// 
			this.MainGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainGrp.Controls.Add(this.CBOutput);
			this.MainGrp.Controls.Add(this.TBOutput);
			this.MainGrp.Controls.Add(this.LOutput);
			this.MainGrp.Controls.Add(this.CBInput);
			this.MainGrp.Controls.Add(this.TBInput);
			this.MainGrp.Controls.Add(this.LInput);
			this.MainGrp.Controls.Add(this.label2);
			this.MainGrp.Controls.Add(this.CBUnit);
			this.MainGrp.Location = new System.Drawing.Point(12, 50);
			this.MainGrp.Name = "MainGrp";
			this.MainGrp.Size = new System.Drawing.Size(479, 281);
			this.MainGrp.TabIndex = 2;
			this.MainGrp.TabStop = false;
			// 
			// CBOutput
			// 
			this.CBOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CBOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBOutput.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CBOutput.FormattingEnabled = true;
			this.CBOutput.Location = new System.Drawing.Point(7, 230);
			this.CBOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.CBOutput.MaxDropDownItems = 20;
			this.CBOutput.Name = "CBOutput";
			this.CBOutput.Size = new System.Drawing.Size(465, 28);
			this.CBOutput.TabIndex = 7;
			this.CBOutput.SelectedIndexChanged += new System.EventHandler(this.CBOutput_SelectedIndexChanged);
			// 
			// TBOutput
			// 
			this.TBOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TBOutput.Location = new System.Drawing.Point(6, 195);
			this.TBOutput.MaxLength = 0;
			this.TBOutput.Multiline = true;
			this.TBOutput.Name = "TBOutput";
			this.TBOutput.ReadOnly = true;
			this.TBOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TBOutput.Size = new System.Drawing.Size(467, 27);
			this.TBOutput.TabIndex = 6;
			this.TBOutput.Text = "1234.5678";
			this.TBOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBOutput_KeyPress);
			// 
			// LOutput
			// 
			this.LOutput.AutoSize = true;
			this.LOutput.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LOutput.Location = new System.Drawing.Point(7, 172);
			this.LOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LOutput.Name = "LOutput";
			this.LOutput.Size = new System.Drawing.Size(48, 20);
			this.LOutput.TabIndex = 5;
			this.LOutput.Text = "変換先";
			// 
			// CBInput
			// 
			this.CBInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CBInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBInput.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CBInput.FormattingEnabled = true;
			this.CBInput.Location = new System.Drawing.Point(7, 139);
			this.CBInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.CBInput.MaxDropDownItems = 20;
			this.CBInput.Name = "CBInput";
			this.CBInput.Size = new System.Drawing.Size(465, 28);
			this.CBInput.TabIndex = 4;
			this.CBInput.SelectedIndexChanged += new System.EventHandler(this.CBInput_SelectedIndexChanged);
			// 
			// TBInput
			// 
			this.TBInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TBInput.Location = new System.Drawing.Point(6, 104);
			this.TBInput.MaxLength = 2000;
			this.TBInput.Multiline = true;
			this.TBInput.Name = "TBInput";
			this.TBInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TBInput.Size = new System.Drawing.Size(467, 27);
			this.TBInput.TabIndex = 3;
			this.TBInput.Text = "1234.5678";
			this.TBInput.TextChanged += new System.EventHandler(this.TBInput_TextChanged);
			this.TBInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBInput_KeyPress);
			// 
			// LInput
			// 
			this.LInput.AutoSize = true;
			this.LInput.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LInput.Location = new System.Drawing.Point(7, 81);
			this.LInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LInput.Name = "LInput";
			this.LInput.Size = new System.Drawing.Size(48, 20);
			this.LInput.TabIndex = 2;
			this.LInput.Text = "変換元";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(7, 23);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(243, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "変換する単位の種類を選択してください";
			// 
			// CBUnit
			// 
			this.CBUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CBUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBUnit.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CBUnit.FormattingEnabled = true;
			this.CBUnit.Location = new System.Drawing.Point(7, 48);
			this.CBUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.CBUnit.MaxDropDownItems = 20;
			this.CBUnit.Name = "CBUnit";
			this.CBUnit.Size = new System.Drawing.Size(465, 28);
			this.CBUnit.TabIndex = 1;
			this.CBUnit.SelectedIndexChanged += new System.EventHandler(this.CBUnit_SelectedIndexChanged);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// UnitWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(503, 343);
			this.Controls.Add(this.MainGrp);
			this.Controls.Add(this.CBSeido);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "UnitWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "単位の変換";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UnitWin_FormClosed);
			this.Load += new System.EventHandler(this.UnitWin_Load);
			this.Shown += new System.EventHandler(this.UnitWin_Shown);
			this.Resize += new System.EventHandler(this.UnitWin_Resize);
			this.MainGrp.ResumeLayout(false);
			this.MainGrp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox CBSeido;
		private System.Windows.Forms.GroupBox MainGrp;
		private System.Windows.Forms.ComboBox CBOutput;
		private System.Windows.Forms.TextBox TBOutput;
		private System.Windows.Forms.Label LOutput;
		private System.Windows.Forms.ComboBox CBInput;
		private System.Windows.Forms.TextBox TBInput;
		private System.Windows.Forms.Label LInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox CBUnit;
		private System.Windows.Forms.Timer MainTimer;
	}
}
