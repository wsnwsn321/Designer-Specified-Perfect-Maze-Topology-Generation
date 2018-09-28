using System.Collections.Generic;
using System.IO;
using static Research.Program;

namespace Research
{
    class Histogram
    {
        private struct length_v
        {
            public int length;
            public int second_info;
        }
        public static void generateHistogramFile()
        {

            //generating 1D
            StreamWriter file1 = new StreamWriter("1DHistogram/length.txt");
            StreamWriter file2 = new StreamWriter("1DHistogram/cluster_num.txt");
            StreamWriter file3 = new StreamWriter("1DHistogram/max_cluster.txt");
            StreamWriter file4 = new StreamWriter("1DHistogram/min_cluster.txt");
            StreamWriter file5 = new StreamWriter("1DHistogram/median_cluster.txt");
            StreamWriter file6 = new StreamWriter("1DHistogram/max_surface.txt");
            StreamWriter file7 = new StreamWriter("1DHistogram/min_surface.txt");
            StreamWriter file8 = new StreamWriter("1DHistogram/median_surface.txt");
            StreamWriter file9 = new StreamWriter("1DHistogram/max_compact.txt");
            StreamWriter file10 = new StreamWriter("1DHistogram/min_compact.txt");
            StreamWriter file11 = new StreamWriter("1DHistogram/median_compact.txt");

            SortedDictionary<int, int> Lengthsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> ClusterNumsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> ClusterMaxsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> ClusterMinsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> ClusterMediansorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> CompactMaxsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> CompactMinsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> CompactMediansorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> SurfaceMaxsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> SurfaceMinsorted = new SortedDictionary<int, int>();
            SortedDictionary<int, int> SurfaceMediansorted = new SortedDictionary<int, int>();


            foreach (var entry in Table)
            {
                if (Lengthsorted.ContainsKey(entry.Key.path_length))
                {
                    Lengthsorted[entry.Key.path_length]++;
                }
                else
                {
                    Lengthsorted.Add(entry.Key.path_length, 1);
                }

                if (ClusterNumsorted.ContainsKey(entry.Key.cluster_num))
                {
                    ClusterNumsorted[entry.Key.cluster_num]++;
                }
                else
                {
                    ClusterNumsorted.Add(entry.Key.cluster_num, 1);
                }

                //cluster size
                if (ClusterMaxsorted.ContainsKey(entry.Key.cluster_size_max))
                {
                    ClusterMaxsorted[entry.Key.cluster_size_max]++;
                }
                else
                {
                    ClusterMaxsorted.Add(entry.Key.cluster_size_max, 1);
                }

                if (ClusterMinsorted.ContainsKey(entry.Key.cluster_size_min))
                {
                    ClusterMinsorted[entry.Key.cluster_size_min]++;
                }
                else
                {
                    ClusterMinsorted.Add(entry.Key.cluster_size_min, 1);
                }

                if (ClusterMediansorted.ContainsKey(entry.Key.cluster_size_median))
                {
                    ClusterMediansorted[entry.Key.cluster_size_median]++;
                }
                else
                {
                    ClusterMediansorted.Add(entry.Key.cluster_size_median, 1);
                }


                //surface
                if (SurfaceMaxsorted.ContainsKey(entry.Key.surface_area_max))
                {
                    SurfaceMaxsorted[entry.Key.surface_area_max]++;
                }
                else
                {
                    SurfaceMaxsorted.Add(entry.Key.surface_area_max, 1);
                }

                if (SurfaceMinsorted.ContainsKey(entry.Key.surface_area_min))
                {
                    SurfaceMinsorted[entry.Key.surface_area_min]++;
                }
                else
                {
                    SurfaceMinsorted.Add(entry.Key.surface_area_min, 1);
                }

                if (SurfaceMediansorted.ContainsKey(entry.Key.surface_area_median))
                {
                    SurfaceMediansorted[entry.Key.surface_area_median]++;
                }
                else
                {
                    SurfaceMediansorted.Add(entry.Key.surface_area_median, 1);
                }

                //compact
                if (CompactMaxsorted.ContainsKey(entry.Key.compactness_max))
                {
                    CompactMaxsorted[entry.Key.compactness_max]++;
                }
                else
                {
                    CompactMaxsorted.Add(entry.Key.compactness_max, 1);
                }

                if (CompactMinsorted.ContainsKey(entry.Key.compactness_min))
                {
                    CompactMinsorted[entry.Key.compactness_min]++;
                }
                else
                {
                    CompactMinsorted.Add(entry.Key.compactness_min, 1);
                }

                if (CompactMediansorted.ContainsKey(entry.Key.compactness_median))
                {
                    CompactMediansorted[entry.Key.compactness_median]++;
                }
                else
                {
                    CompactMediansorted.Add(entry.Key.compactness_median, 1);
                }




            }

            using (file1)
                foreach (var entry in Lengthsorted)
                {
                    file1.WriteLine("{0},{1}", entry.Key, entry.Value);
                }

            using (file2)
                foreach (var entry in ClusterNumsorted)
                {
                    file2.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file3)
                foreach (var entry in ClusterMaxsorted)
                {
                    file3.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file4)
                foreach (var entry in ClusterMinsorted)
                {
                    file4.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file5)
                foreach (var entry in ClusterMediansorted)
                {
                    file5.WriteLine("{0},{1}", entry.Key, entry.Value);
                }

            using (file6)
                foreach (var entry in SurfaceMaxsorted)
                {
                    file6.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file7)
                foreach (var entry in SurfaceMinsorted)
                {
                    file7.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file8)
                foreach (var entry in SurfaceMediansorted)
                {
                    file8.WriteLine("{0},{1}", entry.Key, entry.Value);
                }

            using (file9)
                foreach (var entry in CompactMaxsorted)
                {
                    file9.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file10)
                foreach (var entry in CompactMinsorted)
                {
                    file10.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
            using (file11)
                foreach (var entry in CompactMediansorted)
                {
                    file11.WriteLine("{0},{1}", entry.Key, entry.Value);
                }


            //generating 2D
            StreamWriter twoD2 = new StreamWriter("2DHistogram/length-cluster_num.txt");
            StreamWriter twoD3 = new StreamWriter("2DHistogram/length-max_cluster.txt");
            StreamWriter twoD4 = new StreamWriter("2DHistogram/length-min_cluster.txt");
            StreamWriter twoD5 = new StreamWriter("2DHistogram/length-median_cluster.txt");
            StreamWriter twoD6 = new StreamWriter("2DHistogram/length-max_surface.txt");
            StreamWriter twoD7 = new StreamWriter("2DHistogram/length-min_surface.txt");
            StreamWriter twoD8 = new StreamWriter("2DHistogram/length-median_surface.txt");
            StreamWriter twoD9 = new StreamWriter("2DHistogram/length-max_compact.txt");
            StreamWriter twoD10 = new StreamWriter("2DHistogram/length-min_compact.txt");
            StreamWriter twoD11 = new StreamWriter("2DHistogram/length-median_compact.txt");

            Dictionary<length_v, int> length_cluster_num = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_max_size = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_min_size = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_median_size = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_max_surface = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_min_surface = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_median_surface = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_max_cp = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_min_cp = new Dictionary<length_v, int>();
            Dictionary<length_v, int> length_median_cp = new Dictionary<length_v, int>();
            foreach (var entry in Table)
            {
                length_v k_num = new length_v();
                k_num.length = entry.Key.path_length;
                k_num.second_info = entry.Key.cluster_num;

                length_v k_max_size = new length_v();
                k_max_size.length = entry.Key.path_length;
                k_max_size.second_info = entry.Key.cluster_size_max;

                length_v k_min_size = new length_v();
                k_min_size.length = entry.Key.path_length;
                k_min_size.second_info = entry.Key.cluster_size_min;

                length_v k_median_size = new length_v();
                k_median_size.length = entry.Key.path_length;
                k_median_size.second_info = entry.Key.cluster_size_median;

                length_v k_max_surf = new length_v();
                k_max_surf.length = entry.Key.path_length;
                k_max_surf.second_info = entry.Key.surface_area_max;

                length_v k_min_surf = new length_v();
                k_min_surf.length = entry.Key.path_length;
                k_min_surf.second_info = entry.Key.surface_area_min;

                length_v k_median_surf = new length_v();
                k_median_surf.length = entry.Key.path_length;
                k_median_surf.second_info = entry.Key.surface_area_median;

                length_v k_max_cp = new length_v();
                k_max_cp.length = entry.Key.path_length;
                k_max_cp.second_info = entry.Key.compactness_max;

                length_v k_min_cp = new length_v();
                k_min_cp.length = entry.Key.path_length;
                k_min_cp.second_info = entry.Key.compactness_min;

                length_v k_median_cp = new length_v();
                k_median_cp.length = entry.Key.path_length;
                k_median_cp.second_info = entry.Key.compactness_median;

                if (length_cluster_num.ContainsKey(k_num))
                {
                    length_cluster_num[k_num]++;
                }
                else
                {
                    length_cluster_num.Add(k_num, 1);
                }

                if (length_max_size.ContainsKey(k_max_size))
                {
                    length_max_size[k_max_size]++;
                }
                else
                {
                    length_max_size.Add(k_max_size, 1);
                }

                if (length_min_size.ContainsKey(k_min_size))
                {
                    length_min_size[k_min_size]++;
                }
                else
                {
                    length_min_size.Add(k_min_size, 1);
                }

                if (length_median_size.ContainsKey(k_median_size))
                {
                    length_median_size[k_median_size]++;
                }
                else
                {
                    length_median_size.Add(k_median_size, 1);
                }
                //surface
                if (length_max_surface.ContainsKey(k_max_surf))
                {
                    length_max_surface[k_max_surf]++;
                }
                else
                {
                    length_max_surface.Add(k_max_surf, 1);
                }

                if (length_min_surface.ContainsKey(k_min_surf))
                {
                    length_min_surface[k_min_surf]++;
                }
                else
                {
                    length_min_surface.Add(k_min_surf, 1);
                }

                if (length_median_surface.ContainsKey(k_median_surf))
                {
                    length_median_surface[k_median_surf]++;
                }
                else
                {
                    length_median_surface.Add(k_median_surf, 1);
                }

                //compactness
                if (length_max_cp.ContainsKey(k_max_cp))
                {
                    length_max_cp[k_max_cp]++;
                }
                else
                {
                    length_max_cp.Add(k_max_cp, 1);
                }

                if (length_min_cp.ContainsKey(k_min_cp))
                {
                    length_min_cp[k_min_cp]++;
                }
                else
                {
                    length_min_cp.Add(k_min_cp, 1);
                }

                if (length_median_cp.ContainsKey(k_median_cp))
                {
                    length_median_cp[k_median_cp]++;
                }
                else
                {
                    length_median_cp.Add(k_median_cp, 1);
                }


            }

            //write file
            string comma = "";
            using (twoD2)
                foreach (var entry in length_cluster_num)
                {
                    //twoD2.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, entry.Value);
                    twoD2.WriteLine("{0},{1},{2}", entry.Key.length,entry.Key.second_info, comma+entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD3)
                foreach (var entry in length_max_size)
                {
                    twoD3.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD4)
                foreach (var entry in length_min_size)
                {
                    twoD4.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD5)
                foreach (var entry in length_median_size)
                {
                    twoD5.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD6)
                foreach (var entry in length_max_surface)
                {
                    twoD6.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD7)
                foreach (var entry in length_min_surface)
                {
                    twoD7.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD8)
                foreach (var entry in length_median_surface)
                {
                    twoD8.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD9)
                foreach (var entry in length_max_cp)
                {
                    twoD9.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD10)
                foreach (var entry in length_min_cp)
                {
                    twoD10.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }

            comma = "";
            using (twoD11)
                foreach (var entry in length_median_cp)
                {
                    twoD11.WriteLine("{0},{1},{2}", entry.Key.length, entry.Key.second_info, comma + entry.Value);
                    comma += ",";
                }
        }
       
}
}
