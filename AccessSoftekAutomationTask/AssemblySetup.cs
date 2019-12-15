using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using AccessSoftekCore.WebDriver;
using NUnit.Framework;

// Base Setup Configuration for all assemblies
public class AssemblySetup
{
    /// <summary>
    /// Runs once after executing all the tests in the assembly
    /// </summary>
    [OneTimeTearDown]
    public void RunAfterAllTests()
    {
        var ids = WebDriverFactory.ChromeIds;

        foreach (var id in ids)
        {
            var childs = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + id).Get();

            foreach (var proc in childs)
            {
                var processlist = Process.GetProcesses();
                var pr = processlist.FirstOrDefault(p => p.Id == Convert.ToInt32(proc["ProcessID"]));
                try
                {
                    pr?.Kill();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error during killing the chromedriver.exe with message:{e.Message}");
                }
            }

            // kill main chromedriver.exe
            Process.GetProcesses().FirstOrDefault(p => p.Id == id)?.Kill();
        }
    }
}