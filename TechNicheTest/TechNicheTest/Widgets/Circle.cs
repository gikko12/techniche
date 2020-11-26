using System;
using System.ComponentModel;

namespace TechNicheTest.Widgets
{
    public class Circle : Widget
    {
        public override String Type
        {
            get { return "Circle"; }
        }

        [Description("size")]
        public Int32 Diameter { get; set; }

        public Circle(dynamic item)
        {
            this.Diameter = item.diameter;
            this.PositionX = item.positionX;
            this.PositionY = item.positionY;
        }
    }
}