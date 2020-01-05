using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ImageProfiles.Representations;
// ReSharper disable LocalizableElement

namespace ImageProfiles.View
{
	public partial class MainForm
	{
		private void HandleOnLoad()
		{
			ProgressCounter.Visible = false;
			ProgressBar.Visible = false;
		}

		private void HandleException(string errorMessage, Exception exception)
		{
			if (exception == null)
			{
				MessageBox.Show(@"Error", errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
			else
			{
				MessageBox.Show(@"Error", exception.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SetRootDirectory(object sender, EventArgs eventArgs)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				var result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					RootDirectoryInput.Text = fbd.SelectedPath;
				}
				else
				{
					HandleException("Cannot determine directory", null);
				}
			}
		}

		private void Execute(object sender, EventArgs eventArgs)
		{
			var start = DateTime.Now;
			OutputTextbox.Text = $"Start:    {start}\r\n\r\n";

			try
			{
				var directoryInfo = new DirectoryInfo(RootDirectoryInput.Text);
				var directories = ImageProfiles.Program.GetOriginalDirectories(directoryInfo);
				var modeAsString = OutputModes.Controls.OfType<RadioButton>()
					.First(button => button.Checked)
					.Text.Replace(" ", "");
				var mode = (RepresentationFactory.RepresentationMode) 
					Enum.Parse(typeof(RepresentationFactory.RepresentationMode), modeAsString);
				var representation = RepresentationFactory.GetRepresentation(mode);
				var step = 0;
				var maxLength = directories.Count.ToString().Length;
				var size = directories.Count;

				ProgressCounter.Visible = true;
				ProgressBar.Visible = true;
				ProgressBar.Value = 0;
				ProgressBar.Maximum = directories.Count;

				foreach (var directory in directories)
				{
					OutputTextbox.Text += $"{directory.FullName}\r\n";
					OutputTextbox.Refresh();

					ImageProfiles.Program.ProcessDirectory(directory, representation);

					step++;
					ProgressCounter.Text = $"[{step.ToString($"D{maxLength}")} / {size.ToString($"D{maxLength}")}]";
					ProgressCounter.Refresh();
					ProgressBar.Increment(1);
				}
			}
			catch (Exception exception)
			{
				HandleException(null, exception);
			}
			finally
			{
				var end = DateTime.Now;
				var duration = end - start;

				OutputTextbox.Text += $"\r\nEnd:      {end}\r\n";
				OutputTextbox.Text += $"Run time: {duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";
			}
		}
	}
}