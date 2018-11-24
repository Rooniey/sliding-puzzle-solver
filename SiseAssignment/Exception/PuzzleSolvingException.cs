namespace SiseAssignment.Exception
{
    public class PuzzleSolvingException : System.Exception
    {
        public PuzzleSolvingException()
        {
        }

        public PuzzleSolvingException(string message) : base(message)
        {
        }

        public PuzzleSolvingException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
