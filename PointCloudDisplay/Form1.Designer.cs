namespace PointCloudDisplay
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.投影方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正交投影ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.透视投影ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本图形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.球体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三角形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模型变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绕竖直方向旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复为初始方向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.绕水平方向旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复初始方向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.点云着色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沿X轴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沿Y轴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沿Z轴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纯色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.glControl1 = new OpenTK.GLControl();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.投影方式ToolStripMenuItem,
            this.基本图形ToolStripMenuItem,
            this.模型变换ToolStripMenuItem,
            this.点云着色ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(71, 26);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 投影方式ToolStripMenuItem
            // 
            this.投影方式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.正交投影ToolStripMenuItem,
            this.透视投影ToolStripMenuItem});
            this.投影方式ToolStripMenuItem.Name = "投影方式ToolStripMenuItem";
            this.投影方式ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.投影方式ToolStripMenuItem.Text = "投影方式";
            // 
            // 正交投影ToolStripMenuItem
            // 
            this.正交投影ToolStripMenuItem.Name = "正交投影ToolStripMenuItem";
            this.正交投影ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.正交投影ToolStripMenuItem.Text = "正交投影";
            this.正交投影ToolStripMenuItem.Click += new System.EventHandler(this.正交投影ToolStripMenuItem_Click);
            // 
            // 透视投影ToolStripMenuItem
            // 
            this.透视投影ToolStripMenuItem.Name = "透视投影ToolStripMenuItem";
            this.透视投影ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.透视投影ToolStripMenuItem.Text = "透视投影";
            this.透视投影ToolStripMenuItem.Click += new System.EventHandler(this.透视投影ToolStripMenuItem_Click);
            // 
            // 基本图形ToolStripMenuItem
            // 
            this.基本图形ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.球体ToolStripMenuItem,
            this.三角形ToolStripMenuItem});
            this.基本图形ToolStripMenuItem.Name = "基本图形ToolStripMenuItem";
            this.基本图形ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.基本图形ToolStripMenuItem.Text = "基本图形";
            // 
            // 球体ToolStripMenuItem
            // 
            this.球体ToolStripMenuItem.Name = "球体ToolStripMenuItem";
            this.球体ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.球体ToolStripMenuItem.Text = "球体";
            this.球体ToolStripMenuItem.Click += new System.EventHandler(this.球体ToolStripMenuItem_Click);
            // 
            // 三角形ToolStripMenuItem
            // 
            this.三角形ToolStripMenuItem.Name = "三角形ToolStripMenuItem";
            this.三角形ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.三角形ToolStripMenuItem.Text = "三角形";
            this.三角形ToolStripMenuItem.Click += new System.EventHandler(this.三角形ToolStripMenuItem_Click);
            // 
            // 模型变换ToolStripMenuItem
            // 
            this.模型变换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绕竖直方向旋转ToolStripMenuItem,
            this.绕水平方向旋转ToolStripMenuItem});
            this.模型变换ToolStripMenuItem.Name = "模型变换ToolStripMenuItem";
            this.模型变换ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.模型变换ToolStripMenuItem.Text = "模型变换";
            // 
            // 绕竖直方向旋转ToolStripMenuItem
            // 
            this.绕竖直方向旋转ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复为初始方向ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.绕竖直方向旋转ToolStripMenuItem.Name = "绕竖直方向旋转ToolStripMenuItem";
            this.绕竖直方向旋转ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.绕竖直方向旋转ToolStripMenuItem.Text = "绕竖直方向旋转";
            // 
            // 恢复为初始方向ToolStripMenuItem
            // 
            this.恢复为初始方向ToolStripMenuItem.Name = "恢复为初始方向ToolStripMenuItem";
            this.恢复为初始方向ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.恢复为初始方向ToolStripMenuItem.Text = "恢复初始方向";
            this.恢复为初始方向ToolStripMenuItem.Click += new System.EventHandler(this.恢复为初始方向ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem2.Text = "30°";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem3.Text = "45°";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem4.Text = "90°";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // 绕水平方向旋转ToolStripMenuItem
            // 
            this.绕水平方向旋转ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复初始方向ToolStripMenuItem,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.绕水平方向旋转ToolStripMenuItem.Name = "绕水平方向旋转ToolStripMenuItem";
            this.绕水平方向旋转ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.绕水平方向旋转ToolStripMenuItem.Text = "绕水平方向旋转";
            // 
            // 恢复初始方向ToolStripMenuItem
            // 
            this.恢复初始方向ToolStripMenuItem.Name = "恢复初始方向ToolStripMenuItem";
            this.恢复初始方向ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.恢复初始方向ToolStripMenuItem.Text = "恢复初始方向";
            this.恢复初始方向ToolStripMenuItem.Click += new System.EventHandler(this.恢复初始方向ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem8.Text = "30°";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem9.Text = "45°";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenuItem10.Text = "90°";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // 点云着色ToolStripMenuItem
            // 
            this.点云着色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.沿X轴ToolStripMenuItem,
            this.沿Y轴ToolStripMenuItem,
            this.沿Z轴ToolStripMenuItem,
            this.纯色ToolStripMenuItem});
            this.点云着色ToolStripMenuItem.Name = "点云着色ToolStripMenuItem";
            this.点云着色ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.点云着色ToolStripMenuItem.Text = "点云着色";
            // 
            // 沿X轴ToolStripMenuItem
            // 
            this.沿X轴ToolStripMenuItem.Name = "沿X轴ToolStripMenuItem";
            this.沿X轴ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.沿X轴ToolStripMenuItem.Text = "沿X轴";
            this.沿X轴ToolStripMenuItem.Click += new System.EventHandler(this.沿X轴ToolStripMenuItem_Click);
            // 
            // 沿Y轴ToolStripMenuItem
            // 
            this.沿Y轴ToolStripMenuItem.Name = "沿Y轴ToolStripMenuItem";
            this.沿Y轴ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.沿Y轴ToolStripMenuItem.Text = "沿Y轴";
            this.沿Y轴ToolStripMenuItem.Click += new System.EventHandler(this.沿Y轴ToolStripMenuItem_Click);
            // 
            // 沿Z轴ToolStripMenuItem
            // 
            this.沿Z轴ToolStripMenuItem.Name = "沿Z轴ToolStripMenuItem";
            this.沿Z轴ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.沿Z轴ToolStripMenuItem.Text = "沿Z轴";
            this.沿Z轴ToolStripMenuItem.Click += new System.EventHandler(this.沿Z轴ToolStripMenuItem_Click);
            // 
            // 纯色ToolStripMenuItem
            // 
            this.纯色ToolStripMenuItem.Name = "纯色ToolStripMenuItem";
            this.纯色ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.纯色ToolStripMenuItem.Text = "纯色";
            this.纯色ToolStripMenuItem.Click += new System.EventHandler(this.纯色ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 420);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(175, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(167, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(25, 260);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(113, 19);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "分层显示/32";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(25, 234);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(105, 19);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "分层显示/8";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(25, 208);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(105, 19);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "分层显示/4";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 182);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "分层显示/1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(9, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消鼠标选点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(9, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "颜色设定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.glControl1);
            this.splitContainer2.Size = new System.Drawing.Size(621, 420);
            this.splitContainer2.SplitterDistance = 323;
            this.splitContainer2.TabIndex = 0;
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(621, 323);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseClick);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 投影方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正交投影ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 透视投影ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本图形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 球体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三角形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点云着色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沿X轴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沿Y轴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沿Z轴ToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem 纯色ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ToolStripMenuItem 模型变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绕竖直方向旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 绕水平方向旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem 恢复为初始方向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复初始方向ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
    }
}

