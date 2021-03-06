﻿namespace ImageProfiles.View
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
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ProgressCounter = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ExecuteButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.OutputModes = new System.Windows.Forms.GroupBox();
			this.OutputMode_Database = new System.Windows.Forms.RadioButton();
			this.OutputMode_FlatFile = new System.Windows.Forms.RadioButton();
			this.OutputMode_Console = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.RootDirectoryInput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.OutputTextbox = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.OutputModes.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(1233, 660);
			this.panel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(4, 4);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ProgressBar);
			this.splitContainer1.Panel1.Controls.Add(this.ProgressCounter);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.ExecuteButton);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.OutputModes);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.RootDirectoryInput);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.OutputTextbox);
			this.splitContainer1.Size = new System.Drawing.Size(1225, 652);
			this.splitContainer1.SplitterDistance = 407;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.ProgressBar.Location = new System.Drawing.Point(119, 258);
			this.ProgressBar.Margin = new System.Windows.Forms.Padding(4);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(284, 18);
			this.ProgressBar.TabIndex = 9;
			// 
			// ProgressCounter
			// 
			this.ProgressCounter.AutoSize = true;
			this.ProgressCounter.Dock = System.Windows.Forms.DockStyle.Left;
			this.ProgressCounter.Location = new System.Drawing.Point(4, 258);
			this.ProgressCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ProgressCounter.Name = "ProgressCounter";
			this.ProgressCounter.Size = new System.Drawing.Size(115, 17);
			this.ProgressCounter.TabIndex = 8;
			this.ProgressCounter.Text = "ProgressCounter";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(4, 235);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label4.Size = new System.Drawing.Size(0, 23);
			this.label4.TabIndex = 7;
			// 
			// ExecuteButton
			// 
			this.ExecuteButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExecuteButton.Location = new System.Drawing.Point(4, 207);
			this.ExecuteButton.Margin = new System.Windows.Forms.Padding(4);
			this.ExecuteButton.Name = "ExecuteButton";
			this.ExecuteButton.Size = new System.Drawing.Size(399, 28);
			this.ExecuteButton.TabIndex = 6;
			this.ExecuteButton.Text = "Execute";
			this.ExecuteButton.UseVisualStyleBackColor = true;
			this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(4, 184);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label3.Size = new System.Drawing.Size(0, 23);
			this.label3.TabIndex = 5;
			// 
			// OutputModes
			// 
			this.OutputModes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.OutputModes.Controls.Add(this.OutputMode_Database);
			this.OutputModes.Controls.Add(this.OutputMode_FlatFile);
			this.OutputModes.Controls.Add(this.OutputMode_Console);
			this.OutputModes.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputModes.Location = new System.Drawing.Point(4, 90);
			this.OutputModes.Margin = new System.Windows.Forms.Padding(0);
			this.OutputModes.Name = "OutputModes";
			this.OutputModes.Padding = new System.Windows.Forms.Padding(0);
			this.OutputModes.Size = new System.Drawing.Size(399, 94);
			this.OutputModes.TabIndex = 3;
			this.OutputModes.TabStop = false;
			// 
			// OutputMode_Database
			// 
			this.OutputMode_Database.AutoSize = true;
			this.OutputMode_Database.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_Database.Location = new System.Drawing.Point(0, 57);
			this.OutputMode_Database.Margin = new System.Windows.Forms.Padding(4);
			this.OutputMode_Database.Name = "OutputMode_Database";
			this.OutputMode_Database.Size = new System.Drawing.Size(399, 21);
			this.OutputMode_Database.TabIndex = 2;
			this.OutputMode_Database.Text = "Database";
			this.OutputMode_Database.UseVisualStyleBackColor = true;
			// 
			// OutputMode_FlatFile
			// 
			this.OutputMode_FlatFile.AutoSize = true;
			this.OutputMode_FlatFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_FlatFile.Location = new System.Drawing.Point(0, 36);
			this.OutputMode_FlatFile.Margin = new System.Windows.Forms.Padding(4);
			this.OutputMode_FlatFile.Name = "OutputMode_FlatFile";
			this.OutputMode_FlatFile.Size = new System.Drawing.Size(399, 21);
			this.OutputMode_FlatFile.TabIndex = 1;
			this.OutputMode_FlatFile.Text = "Flat File";
			this.OutputMode_FlatFile.UseVisualStyleBackColor = true;
			// 
			// OutputMode_Console
			// 
			this.OutputMode_Console.AutoSize = true;
			this.OutputMode_Console.Checked = true;
			this.OutputMode_Console.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputMode_Console.Location = new System.Drawing.Point(0, 15);
			this.OutputMode_Console.Margin = new System.Windows.Forms.Padding(4);
			this.OutputMode_Console.Name = "OutputMode_Console";
			this.OutputMode_Console.Size = new System.Drawing.Size(399, 21);
			this.OutputMode_Console.TabIndex = 0;
			this.OutputMode_Console.TabStop = true;
			this.OutputMode_Console.Text = "Console";
			this.OutputMode_Console.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(4, 55);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
			this.label2.Size = new System.Drawing.Size(90, 35);
			this.label2.TabIndex = 2;
			this.label2.Text = "Output Mode";
			// 
			// RootDirectoryInput
			// 
			this.RootDirectoryInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.RootDirectoryInput.Location = new System.Drawing.Point(4, 33);
			this.RootDirectoryInput.Margin = new System.Windows.Forms.Padding(4);
			this.RootDirectoryInput.Name = "RootDirectoryInput";
			this.RootDirectoryInput.Size = new System.Drawing.Size(399, 22);
			this.RootDirectoryInput.TabIndex = 1;
			this.RootDirectoryInput.Text = "D:\\Bao\\Pictures\\Photography\\Travel";
			this.RootDirectoryInput.Click += new System.EventHandler(this.RootDirectoryInput_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.label1.Size = new System.Drawing.Size(99, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Root Directory";
			// 
			// OutputTextbox
			// 
			this.OutputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputTextbox.Location = new System.Drawing.Point(0, 0);
			this.OutputTextbox.Margin = new System.Windows.Forms.Padding(4);
			this.OutputTextbox.Multiline = true;
			this.OutputTextbox.Name = "OutputTextbox";
			this.OutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputTextbox.Size = new System.Drawing.Size(813, 652);
			this.OutputTextbox.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1233, 660);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4);
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
			this.OutputModes.ResumeLayout(false);
			this.OutputModes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox OutputTextbox;
		private System.Windows.Forms.TextBox RootDirectoryInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox OutputModes;
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

