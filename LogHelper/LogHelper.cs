using System;
using System.IO;

public class LogHelper
{
    public string Location { get { return @"D:\\ShopProjectSV.txt"; } }
    public LogHelper()
    {
        //public void Log(Exception)

        if (!File.Exists(Location))
        {
            File.Create(Location);
        }
    }

    public void LogError(Exception ee)
    {
        using (StreamWriter writer = new StreamWriter(Location, true))
        {
            writer.WriteLine("Message : " + ee.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ee.StackTrace + "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
        }
    }
}
