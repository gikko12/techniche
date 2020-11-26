using System;
using System.ComponentModel;

namespace TechNicheTest.Widgets
{
    public class Textbox : Widget
    {
        public override String Type
        {
            get
            {
                return "Textbox";
            }
        }

        [Description("width")]
        public Int32 Width { get; set; }
        
        [Description("height")]
        public Int32 Height { get; set; }

        [Description("text")]
        public String Text { get; set; }

        public Textbox(dynamic item)
        {
            this.Width = item.width;
            this.Height = item.height;
            this.Text = item.text;
            this.PositionX = item.positionX;
            this.PositionY = item.positionY;
        }
    }
}