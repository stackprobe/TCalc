namespace WTCalc
{
	partial class MainWin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.DisplayArea = new System.Windows.Forms.RichTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.アプリケーションAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.基数RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進03ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進05ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進06ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進07ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進08ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進09ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.進16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.精度BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.桁1000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.計算PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.中止AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ツールTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.単位の変換UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.日付の計算DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.FigA = new System.Windows.Forms.Button();
			this.FigB = new System.Windows.Forms.Button();
			this.FigC = new System.Windows.Forms.Button();
			this.FigD = new System.Windows.Forms.Button();
			this.FigE = new System.Windows.Forms.Button();
			this.FigF = new System.Windows.Forms.Button();
			this.BtnMC = new System.Windows.Forms.Button();
			this.BtnMR = new System.Windows.Forms.Button();
			this.BtnMS = new System.Windows.Forms.Button();
			this.BtnMPlus = new System.Windows.Forms.Button();
			this.BtnMMinus = new System.Windows.Forms.Button();
			this.BtnBS = new System.Windows.Forms.Button();
			this.BtnCE = new System.Windows.Forms.Button();
			this.BtnC = new System.Windows.Forms.Button();
			this.BtnSign = new System.Windows.Forms.Button();
			this.BtnRoot = new System.Windows.Forms.Button();
			this.Fig7 = new System.Windows.Forms.Button();
			this.Fig8 = new System.Windows.Forms.Button();
			this.Fig9 = new System.Windows.Forms.Button();
			this.BtnDiv = new System.Windows.Forms.Button();
			this.BtnPower = new System.Windows.Forms.Button();
			this.Fig4 = new System.Windows.Forms.Button();
			this.Fig5 = new System.Windows.Forms.Button();
			this.Fig6 = new System.Windows.Forms.Button();
			this.BtnMul = new System.Windows.Forms.Button();
			this.BtnInverse = new System.Windows.Forms.Button();
			this.Fig1 = new System.Windows.Forms.Button();
			this.Fig2 = new System.Windows.Forms.Button();
			this.Fig3 = new System.Windows.Forms.Button();
			this.BtnSub = new System.Windows.Forms.Button();
			this.BtnEq = new System.Windows.Forms.Button();
			this.Fig0 = new System.Windows.Forms.Button();
			this.BtnPeriod = new System.Windows.Forms.Button();
			this.BtnAdd = new System.Windows.Forms.Button();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DisplayArea
			// 
			this.DisplayArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DisplayArea.BackColor = System.Drawing.Color.White;
			this.DisplayArea.Location = new System.Drawing.Point(12, 29);
			this.DisplayArea.Name = "DisplayArea";
			this.DisplayArea.Size = new System.Drawing.Size(355, 120);
			this.DisplayArea.TabIndex = 1;
			this.DisplayArea.Text = "";
			this.DisplayArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリケーションAToolStripMenuItem,
            this.設定SToolStripMenuItem,
            this.計算PToolStripMenuItem,
            this.ツールTToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(377, 26);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// アプリケーションAToolStripMenuItem
			// 
			this.アプリケーションAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了XToolStripMenuItem});
			this.アプリケーションAToolStripMenuItem.Name = "アプリケーションAToolStripMenuItem";
			this.アプリケーションAToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.アプリケーションAToolStripMenuItem.Text = "アプリケーション(&A)";
			// 
			// 終了XToolStripMenuItem
			// 
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
			// 
			// 設定SToolStripMenuItem
			// 
			this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基数RToolStripMenuItem,
            this.精度BToolStripMenuItem});
			this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
			this.設定SToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
			this.設定SToolStripMenuItem.Text = "設定(&S)";
			// 
			// 基数RToolStripMenuItem
			// 
			this.基数RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.進02ToolStripMenuItem,
            this.進03ToolStripMenuItem,
            this.進04ToolStripMenuItem,
            this.進05ToolStripMenuItem,
            this.進06ToolStripMenuItem,
            this.進07ToolStripMenuItem,
            this.進08ToolStripMenuItem,
            this.進09ToolStripMenuItem,
            this.進10ToolStripMenuItem,
            this.進11ToolStripMenuItem,
            this.進12ToolStripMenuItem,
            this.進13ToolStripMenuItem,
            this.進14ToolStripMenuItem,
            this.進15ToolStripMenuItem,
            this.進16ToolStripMenuItem});
			this.基数RToolStripMenuItem.Name = "基数RToolStripMenuItem";
			this.基数RToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.基数RToolStripMenuItem.Text = "基数(&R)";
			// 
			// 進02ToolStripMenuItem
			// 
			this.進02ToolStripMenuItem.Name = "進02ToolStripMenuItem";
			this.進02ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進02ToolStripMenuItem.Text = "2進(&B)";
			this.進02ToolStripMenuItem.Click += new System.EventHandler(this.進02ToolStripMenuItem_Click);
			// 
			// 進03ToolStripMenuItem
			// 
			this.進03ToolStripMenuItem.Name = "進03ToolStripMenuItem";
			this.進03ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進03ToolStripMenuItem.Text = "3進";
			this.進03ToolStripMenuItem.Click += new System.EventHandler(this.進03ToolStripMenuItem_Click);
			// 
			// 進04ToolStripMenuItem
			// 
			this.進04ToolStripMenuItem.Name = "進04ToolStripMenuItem";
			this.進04ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進04ToolStripMenuItem.Text = "4進";
			this.進04ToolStripMenuItem.Click += new System.EventHandler(this.進04ToolStripMenuItem_Click);
			// 
			// 進05ToolStripMenuItem
			// 
			this.進05ToolStripMenuItem.Name = "進05ToolStripMenuItem";
			this.進05ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進05ToolStripMenuItem.Text = "5進";
			this.進05ToolStripMenuItem.Click += new System.EventHandler(this.進05ToolStripMenuItem_Click);
			// 
			// 進06ToolStripMenuItem
			// 
			this.進06ToolStripMenuItem.Name = "進06ToolStripMenuItem";
			this.進06ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進06ToolStripMenuItem.Text = "6進";
			this.進06ToolStripMenuItem.Click += new System.EventHandler(this.進06ToolStripMenuItem_Click);
			// 
			// 進07ToolStripMenuItem
			// 
			this.進07ToolStripMenuItem.Name = "進07ToolStripMenuItem";
			this.進07ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進07ToolStripMenuItem.Text = "7進";
			this.進07ToolStripMenuItem.Click += new System.EventHandler(this.進07ToolStripMenuItem_Click);
			// 
			// 進08ToolStripMenuItem
			// 
			this.進08ToolStripMenuItem.Name = "進08ToolStripMenuItem";
			this.進08ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進08ToolStripMenuItem.Text = "8進(&O)";
			this.進08ToolStripMenuItem.Click += new System.EventHandler(this.進08ToolStripMenuItem_Click);
			// 
			// 進09ToolStripMenuItem
			// 
			this.進09ToolStripMenuItem.Name = "進09ToolStripMenuItem";
			this.進09ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進09ToolStripMenuItem.Text = "9進";
			this.進09ToolStripMenuItem.Click += new System.EventHandler(this.進09ToolStripMenuItem_Click);
			// 
			// 進10ToolStripMenuItem
			// 
			this.進10ToolStripMenuItem.Name = "進10ToolStripMenuItem";
			this.進10ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進10ToolStripMenuItem.Text = "10進(&D)";
			this.進10ToolStripMenuItem.Click += new System.EventHandler(this.進10ToolStripMenuItem_Click);
			// 
			// 進11ToolStripMenuItem
			// 
			this.進11ToolStripMenuItem.Name = "進11ToolStripMenuItem";
			this.進11ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進11ToolStripMenuItem.Text = "11進";
			this.進11ToolStripMenuItem.Click += new System.EventHandler(this.進11ToolStripMenuItem_Click);
			// 
			// 進12ToolStripMenuItem
			// 
			this.進12ToolStripMenuItem.Name = "進12ToolStripMenuItem";
			this.進12ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進12ToolStripMenuItem.Text = "12進";
			this.進12ToolStripMenuItem.Click += new System.EventHandler(this.進12ToolStripMenuItem_Click);
			// 
			// 進13ToolStripMenuItem
			// 
			this.進13ToolStripMenuItem.Name = "進13ToolStripMenuItem";
			this.進13ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進13ToolStripMenuItem.Text = "13進";
			this.進13ToolStripMenuItem.Click += new System.EventHandler(this.進13ToolStripMenuItem_Click);
			// 
			// 進14ToolStripMenuItem
			// 
			this.進14ToolStripMenuItem.Name = "進14ToolStripMenuItem";
			this.進14ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進14ToolStripMenuItem.Text = "14進";
			this.進14ToolStripMenuItem.Click += new System.EventHandler(this.進14ToolStripMenuItem_Click);
			// 
			// 進15ToolStripMenuItem
			// 
			this.進15ToolStripMenuItem.Name = "進15ToolStripMenuItem";
			this.進15ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進15ToolStripMenuItem.Text = "15進";
			this.進15ToolStripMenuItem.Click += new System.EventHandler(this.進15ToolStripMenuItem_Click);
			// 
			// 進16ToolStripMenuItem
			// 
			this.進16ToolStripMenuItem.Name = "進16ToolStripMenuItem";
			this.進16ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.進16ToolStripMenuItem.Text = "16進(&H)";
			this.進16ToolStripMenuItem.Click += new System.EventHandler(this.進16ToolStripMenuItem_Click);
			// 
			// 精度BToolStripMenuItem
			// 
			this.精度BToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.桁0ToolStripMenuItem,
            this.桁10ToolStripMenuItem,
            this.桁30ToolStripMenuItem,
            this.桁100ToolStripMenuItem,
            this.桁300ToolStripMenuItem,
            this.桁1000ToolStripMenuItem});
			this.精度BToolStripMenuItem.Name = "精度BToolStripMenuItem";
			this.精度BToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.精度BToolStripMenuItem.Text = "精度_小数点以下？桁まで(&B)";
			// 
			// 桁0ToolStripMenuItem
			// 
			this.桁0ToolStripMenuItem.Name = "桁0ToolStripMenuItem";
			this.桁0ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁0ToolStripMenuItem.Text = "0桁(&N)";
			this.桁0ToolStripMenuItem.Click += new System.EventHandler(this.桁0ToolStripMenuItem_Click);
			// 
			// 桁10ToolStripMenuItem
			// 
			this.桁10ToolStripMenuItem.Name = "桁10ToolStripMenuItem";
			this.桁10ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁10ToolStripMenuItem.Text = "10桁";
			this.桁10ToolStripMenuItem.Click += new System.EventHandler(this.桁10ToolStripMenuItem_Click);
			// 
			// 桁30ToolStripMenuItem
			// 
			this.桁30ToolStripMenuItem.Name = "桁30ToolStripMenuItem";
			this.桁30ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁30ToolStripMenuItem.Text = "30桁(&D)";
			this.桁30ToolStripMenuItem.Click += new System.EventHandler(this.桁30ToolStripMenuItem_Click);
			// 
			// 桁100ToolStripMenuItem
			// 
			this.桁100ToolStripMenuItem.Name = "桁100ToolStripMenuItem";
			this.桁100ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁100ToolStripMenuItem.Text = "100桁";
			this.桁100ToolStripMenuItem.Click += new System.EventHandler(this.桁100ToolStripMenuItem_Click);
			// 
			// 桁300ToolStripMenuItem
			// 
			this.桁300ToolStripMenuItem.Name = "桁300ToolStripMenuItem";
			this.桁300ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁300ToolStripMenuItem.Text = "300桁";
			this.桁300ToolStripMenuItem.Click += new System.EventHandler(this.桁300ToolStripMenuItem_Click);
			// 
			// 桁1000ToolStripMenuItem
			// 
			this.桁1000ToolStripMenuItem.Name = "桁1000ToolStripMenuItem";
			this.桁1000ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.桁1000ToolStripMenuItem.Text = "1000桁";
			this.桁1000ToolStripMenuItem.Click += new System.EventHandler(this.桁1000ToolStripMenuItem_Click);
			// 
			// 計算PToolStripMenuItem
			// 
			this.計算PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中止AToolStripMenuItem});
			this.計算PToolStripMenuItem.Name = "計算PToolStripMenuItem";
			this.計算PToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
			this.計算PToolStripMenuItem.Text = "計算(&K)";
			// 
			// 中止AToolStripMenuItem
			// 
			this.中止AToolStripMenuItem.Name = "中止AToolStripMenuItem";
			this.中止AToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.中止AToolStripMenuItem.Text = "中止_Process.Kill(&K)";
			this.中止AToolStripMenuItem.Click += new System.EventHandler(this.中止AToolStripMenuItem_Click);
			// 
			// ツールTToolStripMenuItem
			// 
			this.ツールTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.単位の変換UToolStripMenuItem,
            this.日付の計算DToolStripMenuItem});
			this.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem";
			this.ツールTToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
			this.ツールTToolStripMenuItem.Text = "ツール(&T)";
			// 
			// 単位の変換UToolStripMenuItem
			// 
			this.単位の変換UToolStripMenuItem.Name = "単位の変換UToolStripMenuItem";
			this.単位の変換UToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.単位の変換UToolStripMenuItem.Text = "単位の変換(&U)";
			this.単位の変換UToolStripMenuItem.Click += new System.EventHandler(this.単位の変換UToolStripMenuItem_Click);
			// 
			// 日付の計算DToolStripMenuItem
			// 
			this.日付の計算DToolStripMenuItem.Name = "日付の計算DToolStripMenuItem";
			this.日付の計算DToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.日付の計算DToolStripMenuItem.Text = "日付の計算(&D)";
			this.日付の計算DToolStripMenuItem.Click += new System.EventHandler(this.日付の計算DToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
			this.statusStrip1.Location = new System.Drawing.Point(0, 463);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(377, 23);
			this.statusStrip1.TabIndex = 36;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// Status
			// 
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(28, 18);
			this.Status.Text = "----";
			// 
			// FigA
			// 
			this.FigA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigA.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigA.Location = new System.Drawing.Point(11, 155);
			this.FigA.Name = "FigA";
			this.FigA.Size = new System.Drawing.Size(54, 45);
			this.FigA.TabIndex = 2;
			this.FigA.Text = "a";
			this.FigA.UseVisualStyleBackColor = true;
			this.FigA.Click += new System.EventHandler(this.FigA_Click);
			this.FigA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// FigB
			// 
			this.FigB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigB.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigB.Location = new System.Drawing.Point(11, 206);
			this.FigB.Name = "FigB";
			this.FigB.Size = new System.Drawing.Size(54, 45);
			this.FigB.TabIndex = 8;
			this.FigB.Text = "b";
			this.FigB.UseVisualStyleBackColor = true;
			this.FigB.Click += new System.EventHandler(this.FigB_Click);
			this.FigB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// FigC
			// 
			this.FigC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigC.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigC.Location = new System.Drawing.Point(11, 257);
			this.FigC.Name = "FigC";
			this.FigC.Size = new System.Drawing.Size(54, 45);
			this.FigC.TabIndex = 14;
			this.FigC.Text = "c";
			this.FigC.UseVisualStyleBackColor = true;
			this.FigC.Click += new System.EventHandler(this.FigC_Click);
			this.FigC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// FigD
			// 
			this.FigD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigD.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigD.Location = new System.Drawing.Point(11, 308);
			this.FigD.Name = "FigD";
			this.FigD.Size = new System.Drawing.Size(54, 45);
			this.FigD.TabIndex = 20;
			this.FigD.Text = "d";
			this.FigD.UseVisualStyleBackColor = true;
			this.FigD.Click += new System.EventHandler(this.FigD_Click);
			this.FigD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// FigE
			// 
			this.FigE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigE.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigE.Location = new System.Drawing.Point(11, 359);
			this.FigE.Name = "FigE";
			this.FigE.Size = new System.Drawing.Size(54, 45);
			this.FigE.TabIndex = 26;
			this.FigE.Text = "e";
			this.FigE.UseVisualStyleBackColor = true;
			this.FigE.Click += new System.EventHandler(this.FigE_Click);
			this.FigE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// FigF
			// 
			this.FigF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FigF.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FigF.Location = new System.Drawing.Point(11, 410);
			this.FigF.Name = "FigF";
			this.FigF.Size = new System.Drawing.Size(54, 45);
			this.FigF.TabIndex = 31;
			this.FigF.Text = "f";
			this.FigF.UseVisualStyleBackColor = true;
			this.FigF.Click += new System.EventHandler(this.FigF_Click);
			this.FigF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMC
			// 
			this.BtnMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMC.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMC.Location = new System.Drawing.Point(71, 155);
			this.BtnMC.Name = "BtnMC";
			this.BtnMC.Size = new System.Drawing.Size(54, 45);
			this.BtnMC.TabIndex = 3;
			this.BtnMC.Text = "MC";
			this.BtnMC.UseVisualStyleBackColor = true;
			this.BtnMC.Click += new System.EventHandler(this.BtnMC_Click);
			this.BtnMC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMR
			// 
			this.BtnMR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMR.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMR.Location = new System.Drawing.Point(131, 155);
			this.BtnMR.Name = "BtnMR";
			this.BtnMR.Size = new System.Drawing.Size(54, 45);
			this.BtnMR.TabIndex = 4;
			this.BtnMR.Text = "MR";
			this.BtnMR.UseVisualStyleBackColor = true;
			this.BtnMR.Click += new System.EventHandler(this.BtnMR_Click);
			this.BtnMR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMS
			// 
			this.BtnMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMS.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMS.Location = new System.Drawing.Point(191, 155);
			this.BtnMS.Name = "BtnMS";
			this.BtnMS.Size = new System.Drawing.Size(54, 45);
			this.BtnMS.TabIndex = 5;
			this.BtnMS.Text = "MS";
			this.BtnMS.UseVisualStyleBackColor = true;
			this.BtnMS.Click += new System.EventHandler(this.BtnMS_Click);
			this.BtnMS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMPlus
			// 
			this.BtnMPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMPlus.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMPlus.Location = new System.Drawing.Point(251, 155);
			this.BtnMPlus.Name = "BtnMPlus";
			this.BtnMPlus.Size = new System.Drawing.Size(54, 45);
			this.BtnMPlus.TabIndex = 6;
			this.BtnMPlus.Text = "M+";
			this.BtnMPlus.UseVisualStyleBackColor = true;
			this.BtnMPlus.Click += new System.EventHandler(this.BtnMPlus_Click);
			this.BtnMPlus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMMinus
			// 
			this.BtnMMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMMinus.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMMinus.Location = new System.Drawing.Point(311, 155);
			this.BtnMMinus.Name = "BtnMMinus";
			this.BtnMMinus.Size = new System.Drawing.Size(54, 45);
			this.BtnMMinus.TabIndex = 7;
			this.BtnMMinus.Text = "M-";
			this.BtnMMinus.UseVisualStyleBackColor = true;
			this.BtnMMinus.Click += new System.EventHandler(this.BtnMMinus_Click);
			this.BtnMMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnBS
			// 
			this.BtnBS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnBS.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnBS.Location = new System.Drawing.Point(71, 206);
			this.BtnBS.Name = "BtnBS";
			this.BtnBS.Size = new System.Drawing.Size(54, 45);
			this.BtnBS.TabIndex = 9;
			this.BtnBS.Text = "←";
			this.BtnBS.UseVisualStyleBackColor = true;
			this.BtnBS.Click += new System.EventHandler(this.BtnBS_Click);
			this.BtnBS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnCE
			// 
			this.BtnCE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnCE.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCE.Location = new System.Drawing.Point(131, 206);
			this.BtnCE.Name = "BtnCE";
			this.BtnCE.Size = new System.Drawing.Size(54, 45);
			this.BtnCE.TabIndex = 10;
			this.BtnCE.Text = "CE";
			this.BtnCE.UseVisualStyleBackColor = true;
			this.BtnCE.Click += new System.EventHandler(this.BtnCE_Click);
			this.BtnCE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnC
			// 
			this.BtnC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnC.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnC.Location = new System.Drawing.Point(191, 206);
			this.BtnC.Name = "BtnC";
			this.BtnC.Size = new System.Drawing.Size(54, 45);
			this.BtnC.TabIndex = 11;
			this.BtnC.Text = "C";
			this.BtnC.UseVisualStyleBackColor = true;
			this.BtnC.Click += new System.EventHandler(this.BtnC_Click);
			this.BtnC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnSign
			// 
			this.BtnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnSign.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnSign.Location = new System.Drawing.Point(251, 206);
			this.BtnSign.Name = "BtnSign";
			this.BtnSign.Size = new System.Drawing.Size(54, 45);
			this.BtnSign.TabIndex = 12;
			this.BtnSign.Text = "±";
			this.BtnSign.UseVisualStyleBackColor = true;
			this.BtnSign.Click += new System.EventHandler(this.BtnSign_Click);
			this.BtnSign.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnRoot
			// 
			this.BtnRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnRoot.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnRoot.Location = new System.Drawing.Point(311, 206);
			this.BtnRoot.Name = "BtnRoot";
			this.BtnRoot.Size = new System.Drawing.Size(54, 45);
			this.BtnRoot.TabIndex = 13;
			this.BtnRoot.Text = "√";
			this.BtnRoot.UseVisualStyleBackColor = true;
			this.BtnRoot.Click += new System.EventHandler(this.BtnRoot_Click);
			this.BtnRoot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig7
			// 
			this.Fig7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig7.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig7.Location = new System.Drawing.Point(71, 257);
			this.Fig7.Name = "Fig7";
			this.Fig7.Size = new System.Drawing.Size(54, 45);
			this.Fig7.TabIndex = 15;
			this.Fig7.Text = "7";
			this.Fig7.UseVisualStyleBackColor = true;
			this.Fig7.Click += new System.EventHandler(this.Fig7_Click);
			this.Fig7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig8
			// 
			this.Fig8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig8.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig8.Location = new System.Drawing.Point(131, 257);
			this.Fig8.Name = "Fig8";
			this.Fig8.Size = new System.Drawing.Size(54, 45);
			this.Fig8.TabIndex = 16;
			this.Fig8.Text = "8";
			this.Fig8.UseVisualStyleBackColor = true;
			this.Fig8.Click += new System.EventHandler(this.Fig8_Click);
			this.Fig8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig9
			// 
			this.Fig9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig9.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig9.Location = new System.Drawing.Point(191, 257);
			this.Fig9.Name = "Fig9";
			this.Fig9.Size = new System.Drawing.Size(54, 45);
			this.Fig9.TabIndex = 17;
			this.Fig9.Text = "9";
			this.Fig9.UseVisualStyleBackColor = true;
			this.Fig9.Click += new System.EventHandler(this.Fig9_Click);
			this.Fig9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnDiv
			// 
			this.BtnDiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnDiv.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnDiv.Location = new System.Drawing.Point(251, 257);
			this.BtnDiv.Name = "BtnDiv";
			this.BtnDiv.Size = new System.Drawing.Size(54, 45);
			this.BtnDiv.TabIndex = 18;
			this.BtnDiv.Text = "÷";
			this.BtnDiv.UseVisualStyleBackColor = true;
			this.BtnDiv.Click += new System.EventHandler(this.BtnDiv_Click);
			this.BtnDiv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnPower
			// 
			this.BtnPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnPower.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnPower.Location = new System.Drawing.Point(311, 257);
			this.BtnPower.Name = "BtnPower";
			this.BtnPower.Size = new System.Drawing.Size(54, 45);
			this.BtnPower.TabIndex = 19;
			this.BtnPower.Text = "^x";
			this.BtnPower.UseVisualStyleBackColor = true;
			this.BtnPower.Click += new System.EventHandler(this.BtnPower_Click);
			this.BtnPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig4
			// 
			this.Fig4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig4.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig4.Location = new System.Drawing.Point(71, 308);
			this.Fig4.Name = "Fig4";
			this.Fig4.Size = new System.Drawing.Size(54, 45);
			this.Fig4.TabIndex = 21;
			this.Fig4.Text = "4";
			this.Fig4.UseVisualStyleBackColor = true;
			this.Fig4.Click += new System.EventHandler(this.Fig4_Click);
			this.Fig4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig5
			// 
			this.Fig5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig5.Location = new System.Drawing.Point(131, 308);
			this.Fig5.Name = "Fig5";
			this.Fig5.Size = new System.Drawing.Size(54, 45);
			this.Fig5.TabIndex = 22;
			this.Fig5.Text = "5";
			this.Fig5.UseVisualStyleBackColor = true;
			this.Fig5.Click += new System.EventHandler(this.Fig5_Click);
			this.Fig5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig6
			// 
			this.Fig6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig6.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig6.Location = new System.Drawing.Point(191, 308);
			this.Fig6.Name = "Fig6";
			this.Fig6.Size = new System.Drawing.Size(54, 45);
			this.Fig6.TabIndex = 23;
			this.Fig6.Text = "6";
			this.Fig6.UseVisualStyleBackColor = true;
			this.Fig6.Click += new System.EventHandler(this.Fig6_Click);
			this.Fig6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnMul
			// 
			this.BtnMul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnMul.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnMul.Location = new System.Drawing.Point(251, 308);
			this.BtnMul.Name = "BtnMul";
			this.BtnMul.Size = new System.Drawing.Size(54, 45);
			this.BtnMul.TabIndex = 24;
			this.BtnMul.Text = "×";
			this.BtnMul.UseVisualStyleBackColor = true;
			this.BtnMul.Click += new System.EventHandler(this.BtnMul_Click);
			this.BtnMul.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnInverse
			// 
			this.BtnInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnInverse.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnInverse.Location = new System.Drawing.Point(311, 308);
			this.BtnInverse.Name = "BtnInverse";
			this.BtnInverse.Size = new System.Drawing.Size(54, 45);
			this.BtnInverse.TabIndex = 25;
			this.BtnInverse.Text = "1/x";
			this.BtnInverse.UseVisualStyleBackColor = true;
			this.BtnInverse.Click += new System.EventHandler(this.BtnInverse_Click);
			this.BtnInverse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig1
			// 
			this.Fig1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig1.Location = new System.Drawing.Point(71, 359);
			this.Fig1.Name = "Fig1";
			this.Fig1.Size = new System.Drawing.Size(54, 45);
			this.Fig1.TabIndex = 27;
			this.Fig1.Text = "1";
			this.Fig1.UseVisualStyleBackColor = true;
			this.Fig1.Click += new System.EventHandler(this.Fig1_Click);
			this.Fig1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig2
			// 
			this.Fig2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig2.Location = new System.Drawing.Point(131, 359);
			this.Fig2.Name = "Fig2";
			this.Fig2.Size = new System.Drawing.Size(54, 45);
			this.Fig2.TabIndex = 28;
			this.Fig2.Text = "2";
			this.Fig2.UseVisualStyleBackColor = true;
			this.Fig2.Click += new System.EventHandler(this.Fig2_Click);
			this.Fig2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig3
			// 
			this.Fig3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig3.Location = new System.Drawing.Point(191, 359);
			this.Fig3.Name = "Fig3";
			this.Fig3.Size = new System.Drawing.Size(54, 45);
			this.Fig3.TabIndex = 29;
			this.Fig3.Text = "3";
			this.Fig3.UseVisualStyleBackColor = true;
			this.Fig3.Click += new System.EventHandler(this.Fig3_Click);
			this.Fig3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnSub
			// 
			this.BtnSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnSub.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnSub.Location = new System.Drawing.Point(251, 360);
			this.BtnSub.Name = "BtnSub";
			this.BtnSub.Size = new System.Drawing.Size(54, 45);
			this.BtnSub.TabIndex = 30;
			this.BtnSub.Text = "－";
			this.BtnSub.UseVisualStyleBackColor = true;
			this.BtnSub.Click += new System.EventHandler(this.BtnSub_Click);
			this.BtnSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnEq
			// 
			this.BtnEq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnEq.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnEq.Location = new System.Drawing.Point(311, 359);
			this.BtnEq.Name = "BtnEq";
			this.BtnEq.Size = new System.Drawing.Size(54, 96);
			this.BtnEq.TabIndex = 35;
			this.BtnEq.Text = "=";
			this.BtnEq.UseVisualStyleBackColor = true;
			this.BtnEq.Click += new System.EventHandler(this.BtnEq_Click);
			this.BtnEq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// Fig0
			// 
			this.Fig0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Fig0.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Fig0.Location = new System.Drawing.Point(71, 410);
			this.Fig0.Name = "Fig0";
			this.Fig0.Size = new System.Drawing.Size(114, 45);
			this.Fig0.TabIndex = 32;
			this.Fig0.Text = "0";
			this.Fig0.UseVisualStyleBackColor = true;
			this.Fig0.Click += new System.EventHandler(this.Fig0_Click);
			this.Fig0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnPeriod
			// 
			this.BtnPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnPeriod.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnPeriod.Location = new System.Drawing.Point(191, 410);
			this.BtnPeriod.Name = "BtnPeriod";
			this.BtnPeriod.Size = new System.Drawing.Size(54, 45);
			this.BtnPeriod.TabIndex = 33;
			this.BtnPeriod.Text = ".";
			this.BtnPeriod.UseVisualStyleBackColor = true;
			this.BtnPeriod.Click += new System.EventHandler(this.BtnPeriod_Click);
			this.BtnPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// BtnAdd
			// 
			this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnAdd.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnAdd.Location = new System.Drawing.Point(251, 410);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(54, 45);
			this.BtnAdd.TabIndex = 34;
			this.BtnAdd.Text = "+";
			this.BtnAdd.UseVisualStyleBackColor = true;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			this.BtnAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllButtons_KeyPress);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 486);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.BtnPeriod);
			this.Controls.Add(this.Fig0);
			this.Controls.Add(this.BtnEq);
			this.Controls.Add(this.BtnSub);
			this.Controls.Add(this.Fig3);
			this.Controls.Add(this.Fig2);
			this.Controls.Add(this.Fig1);
			this.Controls.Add(this.BtnInverse);
			this.Controls.Add(this.BtnMul);
			this.Controls.Add(this.Fig6);
			this.Controls.Add(this.Fig5);
			this.Controls.Add(this.Fig4);
			this.Controls.Add(this.BtnPower);
			this.Controls.Add(this.BtnDiv);
			this.Controls.Add(this.Fig9);
			this.Controls.Add(this.Fig8);
			this.Controls.Add(this.Fig7);
			this.Controls.Add(this.BtnRoot);
			this.Controls.Add(this.BtnSign);
			this.Controls.Add(this.BtnC);
			this.Controls.Add(this.BtnCE);
			this.Controls.Add(this.BtnBS);
			this.Controls.Add(this.BtnMMinus);
			this.Controls.Add(this.BtnMPlus);
			this.Controls.Add(this.BtnMS);
			this.Controls.Add(this.BtnMR);
			this.Controls.Add(this.BtnMC);
			this.Controls.Add(this.FigF);
			this.Controls.Add(this.FigE);
			this.Controls.Add(this.FigD);
			this.Controls.Add(this.FigC);
			this.Controls.Add(this.FigB);
			this.Controls.Add(this.FigA);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.DisplayArea);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWin";
			this.Text = "電卓";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox DisplayArea;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem アプリケーションAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 基数RToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進02ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進03ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進04ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進05ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進06ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進07ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進08ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進09ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進11ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進12ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進13ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進14ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進15ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 進16ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 精度BToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 桁10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 桁30ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 桁100ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 計算PToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 中止AToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel Status;
		private System.Windows.Forms.Button FigA;
		private System.Windows.Forms.Button FigB;
		private System.Windows.Forms.Button FigC;
		private System.Windows.Forms.Button FigD;
		private System.Windows.Forms.Button FigE;
		private System.Windows.Forms.Button FigF;
		private System.Windows.Forms.Button BtnMC;
		private System.Windows.Forms.Button BtnMR;
		private System.Windows.Forms.Button BtnMS;
		private System.Windows.Forms.Button BtnMPlus;
		private System.Windows.Forms.Button BtnMMinus;
		private System.Windows.Forms.Button BtnBS;
		private System.Windows.Forms.Button BtnCE;
		private System.Windows.Forms.Button BtnC;
		private System.Windows.Forms.Button BtnSign;
		private System.Windows.Forms.Button BtnRoot;
		private System.Windows.Forms.Button Fig7;
		private System.Windows.Forms.Button Fig8;
		private System.Windows.Forms.Button Fig9;
		private System.Windows.Forms.Button BtnDiv;
		private System.Windows.Forms.Button BtnPower;
		private System.Windows.Forms.Button Fig4;
		private System.Windows.Forms.Button Fig5;
		private System.Windows.Forms.Button Fig6;
		private System.Windows.Forms.Button BtnMul;
		private System.Windows.Forms.Button BtnInverse;
		private System.Windows.Forms.Button Fig1;
		private System.Windows.Forms.Button Fig2;
		private System.Windows.Forms.Button Fig3;
		private System.Windows.Forms.Button BtnSub;
		private System.Windows.Forms.Button BtnEq;
		private System.Windows.Forms.Button Fig0;
		private System.Windows.Forms.Button BtnPeriod;
		private System.Windows.Forms.Button BtnAdd;
		private System.Windows.Forms.Timer MainTimer;
		private System.Windows.Forms.ToolStripMenuItem 桁0ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 桁300ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 桁1000ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ツールTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 日付の計算DToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 単位の変換UToolStripMenuItem;
	}
}

