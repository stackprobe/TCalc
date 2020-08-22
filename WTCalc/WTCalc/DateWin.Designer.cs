namespace WTCalc
{
	partial class DateWin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateWin));
			this.MainTab = new System.Windows.Forms.TabControl();
			this.Tab日付x2 = new System.Windows.Forms.TabPage();
			this.OutputDateX2 = new System.Windows.Forms.RichTextBox();
			this.BtnCalcDateX2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.EndDText = new System.Windows.Forms.TextBox();
			this.EndMText = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.EndYText = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.BgnDText = new System.Windows.Forms.TextBox();
			this.BgnMText = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.BgnYText = new System.Windows.Forms.TextBox();
			this.Tab日付x1 = new System.Windows.Forms.TabPage();
			this.OutputDateX1 = new System.Windows.Forms.RichTextBox();
			this.BtnCalcDateX1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.AddDText = new System.Windows.Forms.TextBox();
			this.AddMText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.AddYText = new System.Windows.Forms.TextBox();
			this.RadioSub = new System.Windows.Forms.RadioButton();
			this.RadioAdd = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DText = new System.Windows.Forms.TextBox();
			this.MText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.YText = new System.Windows.Forms.TextBox();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.MainTab.SuspendLayout();
			this.Tab日付x2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.Tab日付x1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTab
			// 
			this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTab.Controls.Add(this.Tab日付x2);
			this.MainTab.Controls.Add(this.Tab日付x1);
			this.MainTab.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainTab.Location = new System.Drawing.Point(12, 12);
			this.MainTab.Name = "MainTab";
			this.MainTab.SelectedIndex = 0;
			this.MainTab.Size = new System.Drawing.Size(688, 575);
			this.MainTab.TabIndex = 0;
			// 
			// Tab日付x2
			// 
			this.Tab日付x2.Controls.Add(this.OutputDateX2);
			this.Tab日付x2.Controls.Add(this.BtnCalcDateX2);
			this.Tab日付x2.Controls.Add(this.groupBox3);
			this.Tab日付x2.Controls.Add(this.groupBox2);
			this.Tab日付x2.Location = new System.Drawing.Point(4, 29);
			this.Tab日付x2.Name = "Tab日付x2";
			this.Tab日付x2.Padding = new System.Windows.Forms.Padding(3);
			this.Tab日付x2.Size = new System.Drawing.Size(680, 542);
			this.Tab日付x2.TabIndex = 1;
			this.Tab日付x2.Text = "2つの日付の差を計算";
			this.Tab日付x2.UseVisualStyleBackColor = true;
			// 
			// OutputDateX2
			// 
			this.OutputDateX2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputDateX2.Location = new System.Drawing.Point(6, 309);
			this.OutputDateX2.Name = "OutputDateX2";
			this.OutputDateX2.Size = new System.Drawing.Size(668, 227);
			this.OutputDateX2.TabIndex = 3;
			this.OutputDateX2.Text = "";
			// 
			// BtnCalcDateX2
			// 
			this.BtnCalcDateX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCalcDateX2.Location = new System.Drawing.Point(562, 276);
			this.BtnCalcDateX2.Name = "BtnCalcDateX2";
			this.BtnCalcDateX2.Size = new System.Drawing.Size(112, 27);
			this.BtnCalcDateX2.TabIndex = 2;
			this.BtnCalcDateX2.Text = "計算";
			this.BtnCalcDateX2.UseVisualStyleBackColor = true;
			this.BtnCalcDateX2.Click += new System.EventHandler(this.BtnCalcDateX2_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.EndDText);
			this.groupBox3.Controls.Add(this.EndMText);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.EndYText);
			this.groupBox3.Location = new System.Drawing.Point(6, 141);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(668, 129);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "終了";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(640, 95);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(22, 20);
			this.label10.TabIndex = 5;
			this.label10.Text = "日";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(640, 62);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(22, 20);
			this.label11.TabIndex = 3;
			this.label11.Text = "月";
			// 
			// EndDText
			// 
			this.EndDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EndDText.Location = new System.Drawing.Point(6, 92);
			this.EndDText.MaxLength = 200;
			this.EndDText.Name = "EndDText";
			this.EndDText.Size = new System.Drawing.Size(628, 27);
			this.EndDText.TabIndex = 4;
			this.EndDText.Text = "31";
			this.EndDText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.EndDText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndDText_KeyPress);
			// 
			// EndMText
			// 
			this.EndMText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EndMText.Location = new System.Drawing.Point(6, 59);
			this.EndMText.MaxLength = 200;
			this.EndMText.Name = "EndMText";
			this.EndMText.Size = new System.Drawing.Size(628, 27);
			this.EndMText.TabIndex = 2;
			this.EndMText.Text = "12";
			this.EndMText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.EndMText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndMText_KeyPress);
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(640, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(22, 20);
			this.label12.TabIndex = 1;
			this.label12.Text = "年";
			// 
			// EndYText
			// 
			this.EndYText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EndYText.Location = new System.Drawing.Point(6, 26);
			this.EndYText.MaxLength = 200;
			this.EndYText.Name = "EndYText";
			this.EndYText.Size = new System.Drawing.Size(628, 27);
			this.EndYText.TabIndex = 0;
			this.EndYText.Text = "2014";
			this.EndYText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.EndYText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndYText_KeyPress);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.BgnDText);
			this.groupBox2.Controls.Add(this.BgnMText);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.BgnYText);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(668, 129);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "開始";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(640, 95);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(22, 20);
			this.label7.TabIndex = 5;
			this.label7.Text = "日";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(640, 62);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 20);
			this.label8.TabIndex = 3;
			this.label8.Text = "月";
			// 
			// BgnDText
			// 
			this.BgnDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BgnDText.Location = new System.Drawing.Point(6, 92);
			this.BgnDText.MaxLength = 200;
			this.BgnDText.Name = "BgnDText";
			this.BgnDText.Size = new System.Drawing.Size(628, 27);
			this.BgnDText.TabIndex = 4;
			this.BgnDText.Text = "31";
			this.BgnDText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BgnDText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BgnDText_KeyPress);
			// 
			// BgnMText
			// 
			this.BgnMText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BgnMText.Location = new System.Drawing.Point(6, 59);
			this.BgnMText.MaxLength = 200;
			this.BgnMText.Name = "BgnMText";
			this.BgnMText.Size = new System.Drawing.Size(628, 27);
			this.BgnMText.TabIndex = 2;
			this.BgnMText.Text = "12";
			this.BgnMText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BgnMText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BgnMText_KeyPress);
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(640, 29);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(22, 20);
			this.label9.TabIndex = 1;
			this.label9.Text = "年";
			// 
			// BgnYText
			// 
			this.BgnYText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BgnYText.Location = new System.Drawing.Point(6, 26);
			this.BgnYText.MaxLength = 200;
			this.BgnYText.Name = "BgnYText";
			this.BgnYText.Size = new System.Drawing.Size(628, 27);
			this.BgnYText.TabIndex = 0;
			this.BgnYText.Text = "2014";
			this.BgnYText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BgnYText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BgnYText_KeyPress);
			// 
			// Tab日付x1
			// 
			this.Tab日付x1.Controls.Add(this.OutputDateX1);
			this.Tab日付x1.Controls.Add(this.BtnCalcDateX1);
			this.Tab日付x1.Controls.Add(this.label6);
			this.Tab日付x1.Controls.Add(this.label5);
			this.Tab日付x1.Controls.Add(this.AddDText);
			this.Tab日付x1.Controls.Add(this.AddMText);
			this.Tab日付x1.Controls.Add(this.label4);
			this.Tab日付x1.Controls.Add(this.AddYText);
			this.Tab日付x1.Controls.Add(this.RadioSub);
			this.Tab日付x1.Controls.Add(this.RadioAdd);
			this.Tab日付x1.Controls.Add(this.groupBox1);
			this.Tab日付x1.Location = new System.Drawing.Point(4, 29);
			this.Tab日付x1.Name = "Tab日付x1";
			this.Tab日付x1.Padding = new System.Windows.Forms.Padding(3);
			this.Tab日付x1.Size = new System.Drawing.Size(680, 542);
			this.Tab日付x1.TabIndex = 0;
			this.Tab日付x1.Text = "指定した日付の加算または減算";
			this.Tab日付x1.UseVisualStyleBackColor = true;
			// 
			// OutputDateX1
			// 
			this.OutputDateX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputDateX1.Location = new System.Drawing.Point(6, 303);
			this.OutputDateX1.Name = "OutputDateX1";
			this.OutputDateX1.Size = new System.Drawing.Size(668, 233);
			this.OutputDateX1.TabIndex = 10;
			this.OutputDateX1.Text = "";
			// 
			// BtnCalcDateX1
			// 
			this.BtnCalcDateX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCalcDateX1.Location = new System.Drawing.Point(562, 270);
			this.BtnCalcDateX1.Name = "BtnCalcDateX1";
			this.BtnCalcDateX1.Size = new System.Drawing.Size(112, 27);
			this.BtnCalcDateX1.TabIndex = 9;
			this.BtnCalcDateX1.Text = "計算";
			this.BtnCalcDateX1.UseVisualStyleBackColor = true;
			this.BtnCalcDateX1.Click += new System.EventHandler(this.BtnCalcDateX1_Click);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(652, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(22, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "日";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(652, 207);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 20);
			this.label5.TabIndex = 6;
			this.label5.Text = "月";
			// 
			// AddDText
			// 
			this.AddDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddDText.Location = new System.Drawing.Point(6, 237);
			this.AddDText.MaxLength = 200;
			this.AddDText.Name = "AddDText";
			this.AddDText.Size = new System.Drawing.Size(640, 27);
			this.AddDText.TabIndex = 7;
			this.AddDText.Text = "0";
			this.AddDText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AddDText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddDText_KeyPress);
			// 
			// AddMText
			// 
			this.AddMText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddMText.Location = new System.Drawing.Point(6, 204);
			this.AddMText.MaxLength = 200;
			this.AddMText.Name = "AddMText";
			this.AddMText.Size = new System.Drawing.Size(640, 27);
			this.AddMText.TabIndex = 5;
			this.AddMText.Text = "0";
			this.AddMText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AddMText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddMText_KeyPress);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(652, 174);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "年";
			// 
			// AddYText
			// 
			this.AddYText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddYText.Location = new System.Drawing.Point(6, 171);
			this.AddYText.MaxLength = 200;
			this.AddYText.Name = "AddYText";
			this.AddYText.Size = new System.Drawing.Size(640, 27);
			this.AddYText.TabIndex = 3;
			this.AddYText.Text = "0";
			this.AddYText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AddYText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddYText_KeyPress);
			// 
			// RadioSub
			// 
			this.RadioSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RadioSub.AutoSize = true;
			this.RadioSub.Location = new System.Drawing.Point(621, 141);
			this.RadioSub.Name = "RadioSub";
			this.RadioSub.Size = new System.Drawing.Size(53, 24);
			this.RadioSub.TabIndex = 2;
			this.RadioSub.Text = "減算";
			this.RadioSub.UseVisualStyleBackColor = true;
			// 
			// RadioAdd
			// 
			this.RadioAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RadioAdd.AutoSize = true;
			this.RadioAdd.Checked = true;
			this.RadioAdd.Location = new System.Drawing.Point(562, 141);
			this.RadioAdd.Name = "RadioAdd";
			this.RadioAdd.Size = new System.Drawing.Size(53, 24);
			this.RadioAdd.TabIndex = 1;
			this.RadioAdd.TabStop = true;
			this.RadioAdd.Text = "加算";
			this.RadioAdd.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.DText);
			this.groupBox1.Controls.Add(this.MText);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.YText);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(668, 129);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "変換元";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(640, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "日";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(640, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "月";
			// 
			// DText
			// 
			this.DText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DText.Location = new System.Drawing.Point(6, 92);
			this.DText.MaxLength = 200;
			this.DText.Name = "DText";
			this.DText.Size = new System.Drawing.Size(628, 27);
			this.DText.TabIndex = 4;
			this.DText.Text = "31";
			this.DText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.DText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DText_KeyPress);
			// 
			// MText
			// 
			this.MText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MText.Location = new System.Drawing.Point(6, 59);
			this.MText.MaxLength = 200;
			this.MText.Name = "MText";
			this.MText.Size = new System.Drawing.Size(628, 27);
			this.MText.TabIndex = 2;
			this.MText.Text = "12";
			this.MText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MText_KeyPress);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(640, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "年";
			// 
			// YText
			// 
			this.YText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.YText.Location = new System.Drawing.Point(6, 26);
			this.YText.MaxLength = 200;
			this.YText.Name = "YText";
			this.YText.Size = new System.Drawing.Size(628, 27);
			this.YText.TabIndex = 0;
			this.YText.Text = "2014";
			this.YText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.YText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YText_KeyPress);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// DateWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(712, 599);
			this.Controls.Add(this.MainTab);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DateWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "日付の計算";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DateWin_FormClosed);
			this.Load += new System.EventHandler(this.DateWin_Load);
			this.Shown += new System.EventHandler(this.DateWin_Shown);
			this.MainTab.ResumeLayout(false);
			this.Tab日付x2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.Tab日付x1.ResumeLayout(false);
			this.Tab日付x1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl MainTab;
		private System.Windows.Forms.TabPage Tab日付x1;
		private System.Windows.Forms.TabPage Tab日付x2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox DText;
		private System.Windows.Forms.TextBox MText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox YText;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox AddDText;
		private System.Windows.Forms.TextBox AddMText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox AddYText;
		private System.Windows.Forms.RadioButton RadioSub;
		private System.Windows.Forms.RadioButton RadioAdd;
		private System.Windows.Forms.RichTextBox OutputDateX1;
		private System.Windows.Forms.Button BtnCalcDateX1;
		private System.Windows.Forms.Button BtnCalcDateX2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox EndDText;
		private System.Windows.Forms.TextBox EndMText;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox EndYText;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox BgnDText;
		private System.Windows.Forms.TextBox BgnMText;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox BgnYText;
		private System.Windows.Forms.RichTextBox OutputDateX2;
		private System.Windows.Forms.Timer MainTimer;
	}
}
