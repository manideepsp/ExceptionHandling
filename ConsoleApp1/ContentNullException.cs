namespace ConsoleApp1
{
    /// <inheritdoc/>
    /// <seealso cref="System.Exception"/>
    public class ContentNullException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentNullException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ContentNullException(string message) : base(message) { }
    }
}
