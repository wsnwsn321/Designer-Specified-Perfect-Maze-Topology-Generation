using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Research.Program;

namespace Research
{
    public class PostProcessing
    {
        public static void getPathVector()
        {
            Key k = new Key();
            Console.WriteLine("enter your desired path length: ");
            k.path_length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired number of clusters: ");
            k.cluster_num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired max cluster size: ");
            k.cluster_size_max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired min cluster size: ");
            k.cluster_size_min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired median cluster size: ");
            k.cluster_size_median = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired max surface area: ");
            k.surface_area_max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired min surface area: ");
            k.surface_area_min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired median surface area: ");
            k.surface_area_median = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired max compactness: ");
            k.compactness_max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired min compactness: ");
            k.compactness_min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your desired median compactness: ");
            k.compactness_median = Convert.ToInt32(Console.ReadLine());
            var keys = from entry in keyTable
                       where 
                        (entry.Value.path_length == k.path_length||k.path_length==-1)&&
                        (entry.Value.cluster_num == k.cluster_num ||k.cluster_num == -1)&&
                        (entry.Value.cluster_size_max == k.cluster_size_max || k.cluster_size_max == -1) &&
                        (entry.Value.cluster_size_min == k.cluster_size_min || k.cluster_size_min == -1) &&
                        (entry.Value.cluster_size_median == k.cluster_size_median || k.cluster_size_median == -1) &&
                        (entry.Value.surface_area_max == k.surface_area_max || k.surface_area_max == -1) &&
                        (entry.Value.surface_area_min == k.surface_area_min || k.surface_area_min == -1) &&
                        (entry.Value.surface_area_median == k.surface_area_median || k.surface_area_median == -1) &&
                        (entry.Value.compactness_max == k.compactness_max || k.compactness_max == -1) &&
                        (entry.Value.compactness_min == k.compactness_min || k.compactness_min == -1) &&
                        (entry.Value.compactness_median == k.compactness_median || k.compactness_median == -1)
                       select entry.Key;

            StreamWriter file2 = new StreamWriter("UserDefinedPath.txt");
            foreach (var key in keys)
            {
                for (int i = 0; i < key.Count; i++)
                {
                    file2.Write(key[i] + ";");
                }
                file2.WriteLine();
            }
                

        }
        
            
    }
            
}

