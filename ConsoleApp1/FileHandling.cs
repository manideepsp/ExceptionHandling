namespace ConsoleApp1
{
    
   
    /// <summary>
    /// The file handling.
    /// </summary>
    internal class FileHandling
    {
        /// <summary>
        /// Handle file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="access">The access.</param>
        /// <returns></returns>
        public static void HandleFile(string filePath, FileMode mode = FileMode.Open, FileAccess access = FileAccess.ReadWrite)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, mode, access))
                {
                    if (!(Path.GetExtension(filePath) == ".txt")) // Checks for correct file format
                    {
                        throw new InvalidFileFormatException("Invalid file format detected.");
                    }

                    // To read from file
                    string content = read(fileStream);

                    // Checks if content is null and throws exception
                    if (content == null)
                    {
                        throw new ContentNullException("File content is null");
                    }
                    else
                    {
                        // Perform operation on input read from file
                        string line = performOperation(content);

                        // To write to file
                        write(line, fileStream);
                    }
                }
            }

            ///
            /// Invalid format exception handling, custom exception
            ///
            catch (InvalidFileFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ///
            /// ArgumentException
            /// 
            catch (ArgumentException ex)
            {
                Console.WriteLine($"""
                    {ex.Message}, {ex}
                    """);
                if (ex.Message == "Stream was not writable.")
                {
                    Console.WriteLine("Do you want to open file with write permissions ? y/n: ");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        HandleFile(filePath, FileMode.Open, FileAccess.ReadWrite);
                    }
                }
            }

            ///
            /// FileNotFoundException Handling
            ///
            catch (FileNotFoundException)
            {
                Console.Write("""
                                  FileNotFound
                                  Enter the new file path:
                                  """);
                string newFilePath = Console.ReadLine();

                HandleFile(newFilePath, FileMode.Open, FileAccess.Read);
            }

            ///
            /// IOException
            /// 
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ///
            /// To catch anyother exceptions
            /// 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Read From file
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <returns>A string.</returns>
        public static string read(FileStream fileStream)
        {
            StreamReader streamReader = new StreamReader(fileStream);
            return streamReader.ReadToEnd();
        }
        /// <summary>
        /// Perform operation.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>A string.</returns>
        public static string performOperation(string content)
        {
            Console.WriteLine(content);
            List<int> inpList = new List<int>();
            try
            {
                inpList = content.Split(",").Select(int.Parse).ToList();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            int result = 0;
            foreach (var item in inpList)
            {
                result += item;
            }
            return result.ToString();
        }
        /// <summary>
        /// Write to file
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="fileStream">The file stream.</param>
        /// <returns></returns>
        public static void write(string line, FileStream fileStream)
        {
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write("," + line);
            streamWriter.Flush();

            Console.WriteLine("\nContent");
        }
    }
}
