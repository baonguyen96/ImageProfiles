using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImageProfiles.OutputAdapters
{
	class FileManager
	{
		private static readonly Lazy<FileManager> Lazy = new Lazy<FileManager>(
			() => new FileManager(), LazyThreadSafetyMode.ExecutionAndPublication);

		public static FileManager Instance => Lazy.Value;

		private bool _needToWriteHeader;

		private readonly string _fileName;

//		private List<string> Lines;
		
		private FileManager()
		{
			Directory.CreateDirectory("./ImageReports");
			_fileName = $"./ImageReports/ImageReport_{DateTime.Now.ToString("yyyyMMddhhmmss")}.csv";
			_needToWriteHeader = true;
//			Lines = new List<string>();
		}

		public void WriteHeader(string header)
		{
			if (_needToWriteHeader)
			{
				using (var sw = new StreamWriter(_fileName, true))
				{
					sw.WriteLine(header);
				}

				_needToWriteHeader = false;
			}
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
