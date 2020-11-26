using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TechNicheTest.Widgets;

namespace TechNicheTest.FileSystem
{
    public class FileHandling
    {
        
        public static void PrintMaterials()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"Output\output.txt");

            try
            {
                List<Widget> listOfWidgets = new List<Widget>();

                FileHandling.LoadJson(listOfWidgets);

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("----------------------------------------------------------------");
                    sw.WriteLine("Bill of Materials");
                    sw.WriteLine("----------------------------------------------------------------");
                    foreach (var widget in listOfWidgets)
                    {
                        if (widget.PositionX < 0 || widget.PositionX > 1000 ||
                            widget.PositionY < 0 || widget.PositionY > 1000)
                        {
                            throw new Exception("Invalid position.");
                        }

                        sw.WriteLine("{0} ({1}, {2}) {3}", widget.Type, widget.PositionX, widget.PositionY,
                            widget.getProperties());
                    }

                    sw.WriteLine("----------------------------------------------------------------");
                }

                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Trace.TraceError(Ex.Message);

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("+++++Abort+++++");
                }

                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }
        
        private static void LoadJson(List<Widget> listOfWidgets)
        {
            using (StreamReader r = new StreamReader("Data/widgets.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                if (array == null) return;
                
                WidgetFactory factory = new WidgetFactory();

                foreach (var item in array)
                {
                    listOfWidgets.Add(factory.GetWidget(item.type, item));
                }
            }
        }
    }
}