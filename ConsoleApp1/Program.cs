using Microsoft.Win32.SafeHandles;

namespace ConsoleApp1
{
    /// <summary>
    /// Program class contains main method
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        public static void Main()
        {
            FileHandling.HandleFile(Paths.inputsFilePath,FileMode.Open, FileAccess.Read);

            //FileHandling.HandleFile(Paths.nonExistentFilePath, FileMode.Open, FileAccess.Read);

            //FileHandling.HandleFile(Paths.inputsFilePath, FileMode.Open, FileAccess.Write);
        }
    }
}