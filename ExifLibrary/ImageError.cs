namespace ExifLibrary
{
    /// <summary>
    /// Represents error severity.
    /// </summary>
    public enum Severity
    {
        Info,
        Warning,
        Error,
    }

    /// <summary>
    /// Represents errors or warnings generated while reading/writing image files.
    /// </summary>
    public class ImageError
    {

        /// <summary>
        /// Gets the severity of the error.
        /// </summary>
        public Severity Severity { get;}

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageError"/> class.
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="message"></param>
        public ImageError(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
