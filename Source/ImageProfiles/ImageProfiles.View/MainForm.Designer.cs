namespace ImageProfiles.View
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.OutputTextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.RootDirectoryInput = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.OutputMode_Console = new System.Windows.Forms.RadioButton();
			this.OutputMode_FlatFile = new System.Windows.Forms.RadioButton();
			this.OutputMode_Database = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.ExecuteButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.ProgressCounter = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(925, 536);
			this.panel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ProgressBar);
			this.splitContainer1.Panel1.Controls.Add(this.ProgressCounter);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.ExecuteButton);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.RootDirectoryInput);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.OutputTextbox);
			this.splitContainer1.Size = new System.Drawing.Size(919, 530);
			this.splitContainer1.SplitterDistance = 306;
			this.splitContainer1.TabIndex = 0;
			// 
			// OutputTextbox
			// 
			this.OutputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputTextbox.Location = new System.Drawing.Point(0, 0);
			this.OutputTextbox.Multiline = true;
			this.OutputTextbox.Name = "OutputTextbox";
			this.OutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputTextbox.Size = new System.Drawing.Size(609, 530);
			this.OutputTextbox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.label1.Size = new System.Drawing.Size(75, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Root Directory";
			// 
			// RootDirectoryInput
			// 
			this.RootDirectoryInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.RootDirectoryInput.Location = new System.Drawing.Point(3, 26);
			this.RootDirectoryInput.Name = "RootDirectoryInput";
			this.RootDirectoryInput.Size = new System.Drawing.Size(300, 20);
			this.RootDirectoryInput.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(3, 46);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
			this.label2.Size = new System.Drawing.Size(69, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "Output Mode";
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox1.Controls.Add(this.OutputMode_Database);
			this.groupBox1.Controls.Add(this.OutputMode_FlatFile);
			this.groupBox1.Controls.Add(this.OutputMode_Console);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 74);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
			this.groupBox1.Size = new System.Drawing.Size(300, 76);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// OutputMode_Console
			// 
			this.OutputMode_Console.AutoSize = true;
			this.OutputMode_Console.Checked = true;
			this.OutputMode_Console.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_Console.Location = new System.Drawing.Point(0, 13);
			this.OutputMode_Console.Name = "OutputMode_Console";
			this.OutputMode_Console.Size = new System.Drawing.Size(300, 17);
			this.OutputMode_Console.TabIndex = 0;
			this.OutputMode_Console.TabStop = true;
			this.OutputMode_Console.Text = "Console";
			this.OutputMode_Console.UseVisualStyleBackColor = true;
			this.OutputMode_Console.CheckedChanged += new System.EventHandler(this.OutputMode_Console_CheckedChanged);
			// 
			// OutputMode_FlatFile
			// 
			this.OutputMode_FlatFile.AutoSize = true;
			this.OutputMode_FlatFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_FlatFile.Location = new System.Drawing.Point(0, 30);
			this.OutputMode_FlatFile.Name = "OutputMode_FlatFile";
			this.OutputMode_FlatFile.Size = new System.Drawing.Size(300, 17);
			this.OutputMode_FlatFile.TabIndex = 1;
			this.OutputMode_FlatFile.Text = "Flat File";
			this.OutputMode_FlatFile.UseVisualStyleBackColor = true;
			// 
			// OutputMode_Database
			// 
			this.OutputMode_Database.AutoSize = true;
			this.OutputMode_Database.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_Database.Location = new System.Drawing.Point(0, 47);
			this.OutputMode_Database.Name = "OutputMode_Database";
			this.OutputMode_Database.Size = new System.Drawing.Size(300, 17);
			this.OutputMode_Database.TabIndex = 2;
			this.OutputMode_Database.Text = "Database";
			this.OutputMode_Database.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(3, 150);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label3.Size = new System.Drawing.Size(0, 18);
			this.label3.TabIndex = 5;
			// 
			// ExecuteButton
			// 
			this.ExecuteButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExecuteButton.Location = new System.Drawing.Point(3, 168);
			this.ExecuteButton.Name = "ExecuteButton";
			this.ExecuteButton.Size = new System.Drawing.Size(300, 23);
			this.ExecuteButton.TabIndex = 6;
			this.ExecuteButton.Text = "Execute";
			this.ExecuteButton.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(3, 191);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label4.Size = new System.Drawing.Size(0, 18);
			this.label4.TabIndex = 7;
			// 
			// ProgressCounter
			// 
			this.ProgressCounter.AutoSize = true;
			this.ProgressCounter.Dock = System.Windows.Forms.DockStyle.Left;
			this.ProgressCounter.Location = new System.Drawing.Point(3, 209);
			this.ProgressCounter.Name = "ProgressCounter";
			this.ProgressCounter.Size = new System.Drawing.Size(85, 13);
			this.ProgressCounter.TabIndex = 8;
			this.ProgressCounter.Text = "ProgressCounter";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.ProgressBar.Location = new System.Drawing.Point(88, 209);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(215, 15);
			this.ProgressBar.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 536);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Image Profiles";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox OutputTextbox;
		private System.Windows.Forms.TextBox RootDirectoryInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton OutputMode_Database;
		private System.Windows.Forms.RadioButton OutputMode_FlatFile;
		private System.Windows.Forms.RadioButton OutputMode_Console;
		private System.Windows.Forms.Button ExecuteButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.Label ProgressCounter;
	}
}

