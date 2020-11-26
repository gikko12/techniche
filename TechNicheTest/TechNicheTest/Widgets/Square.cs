using System;
using System.ComponentModel;

namespace TechNicheTest.Widgets
{
    public class Square : Widget
    {
        public override String Type
        {
            get
            {
                return "Square";
            }
        }

        [Description("size")]
        public Int32 Width { get; set; }

        public Square(dynamic item)
        {
            this.Width = item.width;
            this.PositionX = item.positionX;
            this.PositionY = item.positionY;
        }
    }
}