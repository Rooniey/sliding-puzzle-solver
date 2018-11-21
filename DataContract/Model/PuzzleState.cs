namespace DataContract.Model
{
    public class PuzzleState
    {
        public byte DimensionX { get; set; }
        public byte DimensionY { get; set; }
        public byte[] State { get; set; }
    }
}