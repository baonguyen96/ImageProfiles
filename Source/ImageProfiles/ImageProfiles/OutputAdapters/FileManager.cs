using System;
using System.IO;
using System.Threading;

namespace ImageProfiles.OutputAdapters
{
	class FileManager
	{
		private static readonly Lazy<FileManager> Lazy = new Lazy<FileManager>(
			() => new FileManager(), LazyThreadSafetyMode.ExecutionAndPublication);

		public static FileManager Instance => Lazy.Value;

		private readonly string _fileName;

		private FileManager()
		{
			Directory.CreateDirectory("./ImageReports");
			_fileName = $"./ImageReports/ImageReport_{DateTime.Now.ToString("yyyyMMddhhmmss")}.csv";
		}

		public void WriteLine(string line)
		{
			using (var sw = new StreamWriter(_fileName, true))
			{
				sw.WriteLine(line);
			}
		}
	}
}
