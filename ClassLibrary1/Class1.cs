using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Class1
    {
        static List<string> list1 = new List<string>();
        static List<string> list2 = new List<string>();
        public void Actions()
        {

            string name = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo($@"{name}");

            DirectoryInfo[] diArr = di.GetDirectories();

            foreach (DirectoryInfo dri in diArr)
            {
                Console.WriteLine(dri.FullName);
                list1.Add(dri.FullName);
            }
            int b = 0;
            while (b < 15)
            {
                foreach (string i in list2)
                {
                    list1.Add(i);
                }
                foreach (string i in list1)
                {
                    try
                    {
                        Task task = new Task(Actions);
                        task.Start();
                        Ac(i);
                    }
                    catch (Exception) { return; }
                }
            }
        }

        public static void Ac(string way)
        {
            DirectoryInfo direct = new DirectoryInfo(way);

            DirectoryInfo[] diArray = direct.GetDirectories();

            if (diArray == null)
            {
                return;
            }
            else
            {
                foreach (DirectoryInfo driy in diArray)
                {
                    if (way == way + "\\" + driy.Name)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            way = way + "\\" + driy.Name;
                            Console.WriteLine(way);
                            list2.Add(way);
                        }
                        catch (Exception) { return; }
                    }
                }
            }
        }
    }
}
