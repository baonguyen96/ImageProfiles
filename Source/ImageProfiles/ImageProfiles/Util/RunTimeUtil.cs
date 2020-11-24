using System;
using System.IO;

namespace ImageProfiles.Util
{
	public class RunTimeUtil
	{
		private static string checkpointFile = @"cp.txt";

		public static DateTime? GetLastRunTime()
		{
			DateTime? lastRunTime;

			try
			{
				using (StreamReader sr = new StreamReader(checkpointFile))
				{
					lastRunTime = DateTime.Parse(sr.ReadLine());
				}
			}
			catch (Exception)
			{
				lastRunTime = null;
			}

			return lastRunTime;
		}

		public static void StoreRunTime(DateTime runDate)
		{
			using(StreamWriter wr = new StreamWriter(checkpointFile))
			{
				wr.WriteLine(runDate);
			}
		}
	}
}
