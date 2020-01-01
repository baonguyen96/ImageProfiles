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
			this.Panel = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.LeftPanel = new System.Windows.Forms.Panel();
			this.DirectoryLabel = new System.Windows.Forms.Label();
			this.DirectoryPathInput = new System.Windows.Forms.TextBox();
			this.Panel.SuspendLayout();
			this.LeftPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.ColumnCount = 2;
			this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.83784F));
			this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.16216F));
			this.Panel.Controls.Add(this.textBox1, 1, 0);
			this.Panel.Controls.Add(this.LeftPanel, 0, 0);
			this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel.Location = new System.Drawing.Point(0, 0);
			this.Panel.Name = "Panel";
			this.Panel.RowCount = 1;
			this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.Panel.Size = new System.Drawing.Size(925, 536);
			this.Panel.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(278, 3);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(644, 530);
			this.textBox1.TabIndex = 0;
			// 
			// LeftPanel
			// 
			this.LeftPanel.Controls.Add(this.DirectoryPathInput);
			this.LeftPanel.Controls.Add(this.DirectoryLabel);
			this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftPanel.Location = new System.Drawing.Point(3, 3);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.Size = new System.Drawing.Size(269, 530);
			this.LeftPanel.TabIndex = 1;
			// 
			// DirectoryLabel
			// 
			this.DirectoryLabel.AutoSize = true;
			this.DirectoryLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.DirectoryLabel.Location = new System.Drawing.Point(0, 0);
			this.DirectoryLabel.Name = "DirectoryLabel";
			this.DirectoryLabel.Size = new System.Drawing.Size(75, 13);
			this.DirectoryLabel.TabIndex = 0;
			this.DirectoryLabel.Text = "Root Directory";
			// 
			// DirectoryPathInput
			// 
			this.DirectoryPathInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DirectoryPathInput.Location = new System.Drawing.Point(0, 13);
			this.DirectoryPathInput.Name = "DirectoryPathInput";
			this.DirectoryPathInput.Size = new System.Drawing.Size(269, 20);
			this.DirectoryPathInput.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 536);
			this.Controls.Add(this.Panel);
			this.Name = "MainForm";
			this.Text = "Image Profiles";
			this.Panel.ResumeLayout(false);
			this.Panel.PerformLayout();
			this.LeftPanel.ResumeLayout(false);
			this.LeftPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel Panel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel LeftPanel;
		private System.Windows.Forms.Label DirectoryLabel;
		private System.Windows.Forms.TextBox DirectoryPathInput;
	}
}

