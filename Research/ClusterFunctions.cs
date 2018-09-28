using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research;
using static Research.Program;

namespace Research
{
    public class ClusterFunctions
    {
        public static void Recursive_neighbour(Cell c, List<Cell> collection, List<Cell> Cell_No)
        {
            int number = c.number;
            int[] neighbour = { number - 1, number + 1, number - 5, number + 5 };
            for (int i = 0; i < neighbour.Length; i++)
            {
                if (Boundary_check(number, neighbour[i]))
                {
                    c = Cell_No[neighbour[i]];
                    if (c.visited == 0&&c.added==0)
                    {
                        c.added = 1;
                        collection.Add(c);
                        Cell_No[neighbour[i]] = c;
                        Recursive_neighbour(c, collection, Cell_No);
                    }
                }
            }
            
        }

        public static void Calculate_Surface_Area(List<Cell> Dup_Collection, List<Cell> Cell_No, int Curren_Cluster_num)
        {
            int dup = 0;
            int collection_size = Dup_Collection.Count;
            while (Dup_Collection.Count != 0)
            {
                Cell c = Dup_Collection[0];
                Dup_Collection.Remove(c);
                int number = c.number;
                int[] neighbour = { number - 1, number + 1, number - 5, number + 5 };
                for (int i = 0; i < neighbour.Length; i++)
                {
                    if (Boundary_check(number, neighbour[i]))
                    {
                        c = Cell_No[neighbour[i]];
                        if(Dup_Collection.Any(Cell => Cell.number == c.number)){
                            dup++;
                        }
                    }
                }
            }
            surface_area[Curren_Cluster_num] = collection_size*4-dup*2; 
        }

        public static void Compactness(List<Cell> Collection, int[,] grid, int current_cluster)
        {
            int i_max=0, i_min=0, j_max=0, j_min=0;
            int initial = Collection[0].number;
            for(int i = 0; i < dimensional; i++)
            {
                for (int j = 0; j < dimensional; j++)
                {
                    if (grid[i, j] == initial)
                    {
                        i_max = i;
                        i_min = i;
                        j_max = j;
                        j_min = j;
                    }
                }
            }

           for(int k = 1; k < Collection.Count; k++)
            {
                int candidate = Collection[k].number;
                for (int i = 0; i < dimensional; i++)
                {
                    for (int j = 0; j < dimensional; j++)
                    {
                        if (grid[i, j] == candidate)
                        {
                            if (i > i_max)
                                i_max = i;
                            if (i < i_min)
                                i_min = i;
                            if (j > j_max)
                                j_max = j;
                            if (j < j_min)
                                j_min = j;
                        }
                    }
                }
            }
            int width = (j_max - j_min) + 1;
            int height = (i_max - i_min) + 1;
            int area = width * height;
            compactness[current_cluster] = Collection.Count / (float)area;
        }


        public static void SideCheck(List<Cell> collection, List<Cell> Cell_No)
        {
            int side = 0;
            Cell c = collection[0];
            int position = c.number % 5;
            for(int i = position; i < c.number; i = i + 5)
            {
                if (Cell_No[i].visited == 1)
                {
                    side++;
                }
            }
            //to the right
            if (side % 2 == 0)
            {
                c.side = 1;
                Cell_No[c.number] = c;
            }
            //to the left
            else
            {
                c.side = -1;
                Cell_No[c.number] = c;
            }
        }

        //get min from an array
        public static int Get_Min(int[] array)
        {
            if (array.Length != 0)
            {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }

                }
                return min;
            }
            else
            {
                return 0;
            }
            
        }
        public static float Get_Min(float[] array)
        {
            if (array.Length != 0)
            {
                float min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }

                }
                return min;
            }
            else
            {
                return 0;
            }

        }
        //get max from an array
        public static int Get_Max(int[] array)
        {
            if (array.Length != 0)
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }

                }
                return max;
            }
            else
            {
                return 0;
            }
           
        }
        public static float Get_Max(float[] array)
        {
            if (array.Length != 0)
            {
                float max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }

                }
                return max;
            }
            else
            {
                return 0;
            }
        }

        //get median from an array
        public static int Get_Median(int[] array)
        {
            if (array.Length != 0)
            {
            Array.Sort(array);
            int median;
            if (array.Length % 2 == 0)
                median = (array[array.Length / 2] + array[array.Length / 2 - 1]) / 2;
            else
                median = array[array.Length / 2];
            return median;
            }
            else
            {
                return 0;
            }
        }
        public static float Get_Median(float[] array)
        {
            if (array.Length != 0)
            {
                Array.Sort(array);
                float median;
                if (array.Length % 2 == 0)
                    median = (array[array.Length / 2] + array[array.Length / 2 - 1]) / 2;
                else
                    median = array[array.Length / 2];
                return median;
            }
            else
            {
                return 0;
            }
        }



        //check the boundary condition
        public static bool Boundary_check(int num, int next_num)
        {
            bool in_bound = true;
            //first column
            if (num % dimensional == 0)
            {
                if (next_num == num - 1)
                {
                    in_bound = false;
                }
            }

            //second column
            if (num % dimensional == 4)
            {
                if (next_num == num + 1)
                {
                    in_bound = false;
                }
            }
            //first row
            if (num < dimensional)
            {
                if (next_num == num - dimensional)
                {
                    in_bound = false;
                }
            }
            //last row
            if (num > grid_num-1 - dimensional)
            {
                if (next_num == num + dimensional)
                {
                    in_bound = false;
                }
            }

            return in_bound;
        }
    }


}
