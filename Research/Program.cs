using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research
{
    public class Program
    {
        //decide the dimension of the grid
        public static int dimensional = 5;
        public static int grid_num = dimensional * dimensional;
        public static int[,] grid = new int[dimensional,dimensional];
        //a list storing the path vector
        public static List<int> path_vec = new List<int>();
        //the number of the cluster
        public static int cluster_number;
        //the array stores the area of the clusters
        public static int[] surface_area;
        //the array stores the compactness of the clusters
        public static float[] compactness;
        //the hashtable to store the key values
        public static Dictionary<List<int>, Key> keyTable = new Dictionary<List<int>, Key>();
        //dictionary
        public static Dictionary<Key, int> Table = new Dictionary<Key, int>();
        //key values that's in the dictionary
        public struct Key
        {
            public int cluster_num;
            public int compactness_min;
            public int compactness_max;
            public int compactness_median;
            public int surface_area_min;
            public int surface_area_max;
            public int surface_area_median;
            public int cluster_size_min;
            public int cluster_size_max;
            public int cluster_size_median;
            public int path_length;
        }
        public struct Cell
        {
            public int number;
            public int visited;
            public int added;
            public int side;
        }
        public static List<Cell> Cell_No = new List<Cell>();
        public static List<List<Cell>> Clusters = new List<List<Cell>>(); 
        static void Main(string[] args)
        {
            //create the map
            int k = 0;
            for(int i = 0; i < dimensional; i++)
            {
                for(int j = 0; j < dimensional; j++)
                {
                    grid[i,j] = k;
                    k++;
                }
            }

            //create the grid
            for(int i = 0; i < grid_num; i++)
            {
                Cell c = new Cell();
                c.number = i;
                c.visited = 0;
                c.added = 0;
                c.side = 0;
                Cell_No.Add(c);
            }


            BinaryFileProcessor.ProcessPathData();

            int total = 0;
            StreamWriter file = new StreamWriter("ClusterInfo-PathAmount.txt");
            file.WriteLine("The data are written in the following sequence:");
            file.WriteLine("path_length; cluster_number; max_cluster_size; min_cluster_size; median_cluster_size; max_surface_area; min_surface_area; median_surface_area; max_compactness; min_compactness; median_compactness : number_of_pathes");
            using (file)

                foreach (var entry in Table)
                {
                    file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}:{11}", entry.Key.path_length, entry.Key.cluster_num, entry.Key.cluster_size_max, entry.Key.cluster_size_min, entry.Key.cluster_size_median, entry.Key.surface_area_max, entry.Key.surface_area_min, entry.Key.surface_area_median, entry.Key.compactness_max, entry.Key.compactness_min, entry.Key.compactness_median, entry.Value);
                }

            StreamWriter file2 = new StreamWriter("AllPathVector.txt");
            using (file2)

                foreach (var entry in keyTable)
                {
                    for(int i = 0; i < entry.Key.Count; i++)
                    {
                        file2.Write(entry.Key[i] + ",");
                    }
                    file2.WriteLine();
                    total++;
                }
            //Console.WriteLine(total);

            //PostProcessing.getPathVector();
            Histogram.generateHistogramFile();


        }
    }
}
