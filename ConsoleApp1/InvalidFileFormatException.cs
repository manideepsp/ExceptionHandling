namespace ConsoleApp1
{
    /// <inheritdoc/>
    /// <seealso cref="System.Exception"/>
    public class InvalidFileFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileFormatException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidFileFormatException(string message) : base(message) { }
    }
}
