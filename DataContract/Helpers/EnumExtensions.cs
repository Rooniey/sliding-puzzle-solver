namespace DataContract.Helpers
{
    public static class EnumExtensions
    {
        public static string ToShortString(this MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    return "L";
                case MoveDirection.Down:
                    return "D";
                case MoveDirection.Right:
                    return "R";
                case MoveDirection.Up:
                    return "U";
                default:
                    return "";
            }
        }
    }
}
