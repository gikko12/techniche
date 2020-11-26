using System;
using System.ComponentModel;

namespace TechNicheTest.Widgets
{
    public class Ellipse : Widget
    {
        public override String Type
        {
            get
            {
                return "Ellipse";
            }
        }
        
        [Description("diameterH")]
        public Int32 HorizontalDiameter { get; set; }
        
        [Description("diameterV")]
        public Int32 VerticalDiameter { get; set; }

        public Ellipse(dynamic item)
        {
            this.HorizontalDiameter = item.horizontalDiameter;
            this.VerticalDiameter = item.verticalDiameter;
            this.PositionX = item.positionX;
            this.PositionY = item.positionY;
        }
    }
}