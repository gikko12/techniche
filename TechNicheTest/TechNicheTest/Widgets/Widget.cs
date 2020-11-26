using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TechNicheTest.Widgets
{
    public class Widget
    {
        private List<String> listOfWidgetProperties = new List<string>() {"Type", "PositionX", "PositionY"};

        public virtual String Type { get; set; }

        public Int32 PositionX { get; set; }

        public Int32 PositionY { get; set; }

        public String getProperties()
        {
            List<String> propertiesAndValues = new List<String>();

            foreach (var prop in this.GetType().GetProperties())
            {
                if (!listOfWidgetProperties.Contains(prop.Name))
                {
                    var value = prop.GetValue(this, null);

                    if (prop.PropertyType == typeof(Int32) && (value == null || value != null && (Int32) value < 0))
                    {
                        throw new Exception("Negative value.");
                    }

                    String propDescription = prop.GetCustomAttribute<DescriptionAttribute>() != null
                        ? prop.GetCustomAttribute<DescriptionAttribute>().Description
                        : prop.Name;

                    StringBuilder sb = new StringBuilder();
                    sb.Append(propDescription).Append(" = ").Append(value);
                    propertiesAndValues.Add(sb.ToString());
                }
            }

            return String.Join(" ", propertiesAndValues);
        }
    }
}