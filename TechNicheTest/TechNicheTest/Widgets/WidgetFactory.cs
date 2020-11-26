namespace TechNicheTest.Widgets
{
    public class WidgetFactory
    {
        public Widget GetWidget(string widgetType, dynamic widget)
        {
            switch (widgetType)
            {
                case "Rectangle":
                    return new Rectangle(widget);
                case "Square":
                    return new Square(widget);
                case "Ellipse":
                    return new Ellipse(widget);
                case "Circle":
                    return new Circle(widget);
                case "Textbox":
                    return new Textbox(widget);
                default:
                    return null;
            }
        }
    }
}