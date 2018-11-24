using System.ComponentModel;

namespace DataContract
{
    public enum MoveDirection
    {
        [Description("")]
        None,

        [Description("L")]
        Left,

        [Description("U")]
        Up,

        [Description("R")]
        Right,

        [Description("D")]
        Down
    }

}
