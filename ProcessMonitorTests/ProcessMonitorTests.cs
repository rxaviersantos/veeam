using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;

[TestFixture]
public class ProcessMonitorTests
{
    [Test]
    public void TestMonitorUtility()
    {

        var processo = "notepad";
        var dura��oM�xima = 1;
        var frequ�nciaMonitoramento = 1;

 
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                CreateNoWindow = true
            }
        };
        process.Start();

        Thread.Sleep(2000);

        var monitorThread = new Thread(() =>
        {
            Program.Main(new[] { processo, dura��oM�xima.ToString(), frequ�nciaMonitoramento.ToString() });
        });

        monitorThread.Start();

        Thread.Sleep(5000);

        Assert.IsFalse(Process.GetProcessesByName("notepad").Length > 0);


        monitorThread.Abort();
        process.CloseMainWindow();
        process.Close();
    }
}
