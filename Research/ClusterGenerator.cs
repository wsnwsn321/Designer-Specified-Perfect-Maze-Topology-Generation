using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Research.Program;

namespace Research
{
    public class ClusterGenerator
    {
        public static void ClusterGeneration()
        {
            Key k = new Key();
            //generate the clusters
            for (int i = 0; i < grid_num; i++)
            {
                List<Cell> collection = new List<Cell>();
                Cell c = Cell_No[i];
                if (c.visited == 0 && c.added == 0)
                {
                    c.added = 1;
                    Cell_No[i] = c;
                    collection.Add(c);
                    ClusterFunctions.Recursive_neighbour(c, collection, Cell_No);
                    Clusters.Insert(cluster_number, collection);
                    cluster_number++;
                    collection = new List<Cell>();
                }

            }
            k.cluster_num = cluster_number;
            int[] k_cluster_size = new int[cluster_number];
            int[] k_surface_area = new int[cluster_number];
            float[] k_compactness = new float[cluster_number];
            for (int i = 0; i < cluster_number; i++)
            {
                k_cluster_size[i] = Clusters[i].Count;
            }
            k.cluster_size_min = ClusterFunctions.Get_Min(k_cluster_size);
            k.cluster_size_max = ClusterFunctions.Get_Max(k_cluster_size);
            k.cluster_size_median = ClusterFunctions.Get_Median(k_cluster_size);

            //calculate the surface area (how many grid sides around the surface)
            surface_area = new int[cluster_number];
            for (int i = 0; i < cluster_number; i++)
            {
                List<Cell> Collection = Clusters[i];
                List<Cell> Dup_Collection = new List<Cell>(Collection);
                ClusterFunctions.Calculate_Surface_Area(Dup_Collection, Cell_No, i);
            }
            //print the info
            for (int j = 0; j < surface_area.Length; j++)
            {
                //Console.WriteLine("cluster " + j + " surface area: " + surface_area[j]);
                k_surface_area[j] = surface_area[j];
            }
            k.surface_area_min = ClusterFunctions.Get_Min(k_surface_area);
            k.surface_area_max = ClusterFunctions.Get_Max(k_surface_area);
            k.surface_area_median = ClusterFunctions.Get_Median(k_surface_area);
            



            //decide the compactness of clusters
            compactness = new float[cluster_number];
            for (int i = 0; i < cluster_number; i++)
            {
                List<Cell> collection = Clusters[i];
                ClusterFunctions.Compactness(collection, grid, i);
            }
            //print the info
            for (int j = 0; j < compactness.Length; j++)
            {
                //Console.WriteLine("cluster "+j+" compact: "+compactness[j]);
                k_compactness[j] = compactness[j];
            }
            k.compactness_min = (int)Math.Round(ClusterFunctions.Get_Min(k_compactness)*1000);
            //Console.WriteLine("compact min: " + k.compactness_min);
            k.compactness_max = (int)Math.Round(ClusterFunctions.Get_Max(k_compactness)*1000);
            if (k.compactness_max != 1)
            {
                //Console.WriteLine("compact max: " + k.compactness_max);
            }
            k.compactness_median = (int)Math.Round(ClusterFunctions.Get_Median(k_compactness) * 1000);
            //Console.WriteLine("compact median: " + k.compactness_max);

            //decide the sides of each cluster
            for (int i = 0; i < cluster_number; i++)
            {
                List<Cell> collection = Clusters[i];
                ClusterFunctions.SideCheck(collection, Cell_No);
  
            }
            k.path_length = path_vec.Count;
            keyTable.Add(path_vec, k);
            if (!Table.ContainsKey(k))
            {
                Table.Add(k, 1);
            }
            else
            {
                Table[k]++;
            }

        }
    }
}
