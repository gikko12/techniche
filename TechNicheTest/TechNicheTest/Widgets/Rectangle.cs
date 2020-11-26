using System;
using System.ComponentModel;

namespace TechNicheTest.Widgets
{
    public class Rectangle : Widget
    {
        public override String Type
        {
            get
            {
                return "Rectangle";
            }
        }
        
        [Description("width")]
        public Int32 Width { get; set; }
        
        [Description("height")]
        public Int32 Height { get; set; }

        public Rectangle(dynamic item)
        {
            this.Width = item.width;
            this.Height = item.height;
            this.PositionX = item.positionX;
            this.PositionY = item.positionY;
        }
    }
}