using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Research.Program;


namespace Research
{
    public class BinaryFileProcessor
    {
        public static void ProcessPathData()
        {
            FileStream fs = new FileStream("pathEnumSetFile_5.bin", FileMode.Open);
            StreamWriter btd = new StreamWriter("BinaryToDecimal.txt");
            BinaryReader br = new BinaryReader(fs);
            int gg = 0;
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                gg++;
                int numbericVEBP = br.ReadInt32();
                int numbericHEBP = br.ReadInt32();
                String VEBP = Convert.ToString(numbericVEBP, 2).PadLeft(20,'0');
                String HEBP = Convert.ToString(numbericHEBP, 2).PadLeft(20, '0');
                btd.WriteLine(VEBP);
                btd.WriteLine(HEBP);
                //deal with VEBP
                for(int i = 0; i < VEBP.Length; i++)
                {
                    if (VEBP[VEBP.Length - 1 - i] == '1')
                    {
                        int grid_num = 5 * (i % 4) + (i / 4);
                        Cell c = Cell_No[grid_num];
                        if (c.visited != 1)
                        {
                            c.visited = 1;
                            path_vec.Add(c.number);
                        }
                        Cell_No[grid_num] = c;
                        if (grid_num < 20)
                        {
                            c = Cell_No[grid_num+5];
                            if (c.visited != 1)
                            {
                                c.visited = 1;
                                path_vec.Add(c.number);
                            }
                            Cell_No[grid_num+5] = c;
                        }
                    }
                }

                //deal with HEBP
                for (int i = 0; i < HEBP.Length; i++)
                {
                    if (HEBP[HEBP.Length - 1 - i] == '1')
                    {
                        int grid_num = 5 * (i / 4) + (i % 4);
                        Cell c = Cell_No[grid_num];
                        if (c.visited != 1)
                        {
                            c.visited = 1;
                            path_vec.Add(c.number);
                        }
                        Cell_No[grid_num] = c;
                        if (grid_num %5!=4)
                        {
                            c = Cell_No[grid_num + 1];
                            if (c.visited != 1)
                            {
                                c.visited = 1;
                                path_vec.Add(c.number);
                            }
                            Cell_No[grid_num + 1] = c;
                        }
                    }
                }




                //generate clusters
                ClusterGenerator.ClusterGeneration();
                for(int i = 0; i < path_vec.Count; i++)
                {
                    btd.Write(path_vec[i]+",");

                }
                btd.WriteLine();
                //save the data into a hash table


                //clean up data after each path
                Cell_No = new List<Cell>();
                for (int i = 0; i < grid_num; i++)
                {
                    Cell c = new Cell();
                    c.number = i;
                    c.visited = 0;
                    c.added = 0;
                    c.side = 0;
                    Cell_No.Add(c);
                }
                Clusters = new List<List<Cell>>();
                cluster_number = 0;
                path_vec = new List<int>();

            }



        }
    }
}
