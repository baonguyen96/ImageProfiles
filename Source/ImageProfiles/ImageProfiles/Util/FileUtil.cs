using System.IO;
using System.Linq;

namespace ImageProfiles.Util
{
	class FileUtil
	{
		public static int GetFileCounter(string fileName)
		{
			var name = Path.GetFileNameWithoutExtension(fileName);
			var digitPart = new string(name.Where(char.IsDigit).ToArray());
			return int.Parse(digitPart);
		}
	}
}
