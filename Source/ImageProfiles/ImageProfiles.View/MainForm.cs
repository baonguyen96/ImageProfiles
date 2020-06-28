using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProfiles.View
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			HandleOnLoad();
		}
		
		private async void ExecuteButton_Click(object sender, EventArgs e)
		{
			await Execute(sender, e);
		}

		private void RootDirectoryInput_Click(object sender, EventArgs e)
		{
			SetRootDirectory(sender, e);
		}
	}
}
