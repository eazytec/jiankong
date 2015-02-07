using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DTcms.Common
{
   public static  class Log
    {
        static Object obj = new object();
        public static void AddLog(string LogName, string Content, bool addtime)
        {
            LogName = LogName.Replace("/", "");
            lock (obj)
            {
                try
                {
                    StreamWriter w = null;
                    if (!File.Exists(LogName))
                    {
                        File.CreateText(LogName).Close();
                    }
                    using (w = File.AppendText(LogName))
                    {
                        SetLog(Content, w, addtime);
                        w.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        private static void SetLog(string Content, TextWriter w, bool addtime)
        {
            if (addtime) w.WriteLine(DateTime.Now.ToString() + " " + Content);
            else w.WriteLine(Content);
            w.Flush();
        }
    }
}
