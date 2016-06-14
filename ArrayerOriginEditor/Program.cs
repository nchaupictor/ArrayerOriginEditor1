using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayerOriginEditor
{
    class Program
    {
        static void Main()
        {
            //Enter new origin positions 
            Console.WriteLine("Enter new X position: ");
            double newX = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Y position: ");
            double newY = double.Parse(Console.ReadLine());

            //Open all files
            List<string> HEP = new List<string> { "HEP_5x3_A1_Print", "HEP_1x2_D1_Print", "HEP_2x2_D4_Print" };
            List<string> TRH = new List<string> { "TRH_5x3_A1_Print", "TRH_1x2_D1_Print", "TRH_1x2_D5_Print" };
            List<string> ENA = new List<string> { "ENA_5x5_A1_Print"};
            List<string> SEP = new List<string> { "SEP_5x1_A1_Print", "SEP_1x2_B5_Print", "SEP_5x2_D1_Print" };
            List<string> RA = new List<string> { "RA_5x1_A1_Print", "RA_3x2_B1_Print", "RA_1x4_B5_Print" };
            List<string> RD = new List<string> { "R&D_Print" };
            
            //Constants
            string origX = "arrayOriginX:";
            string origY = "arrayOriginY:";

            double dist = 2.1;
            double dist2 = 0.7;

            //Position vectors
            double[] HEPposX = new double[] { newX, newX,                 newX + dist };
            double[] HEPposY = new double[] { newY, newY + dist,          newY + dist };
            double[] TRHposX = new double[] { newX, newX,                 newX + dist + dist2};
            double[] TRHposY = new double[] { newY, newY + dist,          newY + dist };
            double[] SEPposX = new double[] { newX, newX + dist + dist2,  newX        };
            double[] SEPposY = new double[] { newY, newY + dist2,         newY + dist };
            double[] RAposX = new double[]  { newX, newX,                 newX + dist + dist2};
            double[] RAposY = new double[]  { newY, newY + dist2,         newY + dist2};

            //Replace lines and resave files
            for (int i = 0; i < HEP.Count; i++)
            {

                List<string> HEPlines = new List<string>(File.ReadAllLines(HEP[i]));
                List<string> TRHlines = new List<string>(File.ReadAllLines(TRH[i]));
                List<string> SEPlines = new List<string>(File.ReadAllLines(SEP[i]));
                List<string> RAlines = new List<string>(File.ReadAllLines(RA[i]));
                List<string> ENAlines = new List<string>(File.ReadAllLines(ENA[0]));
                List<string> RDlines = new List<string>(File.ReadAllLines(RD[0]));

                int lineIndex = HEPlines.FindIndex(line => line.StartsWith(origX));
                if (lineIndex != -1)
                {
                    //Change values
                    HEPlines[lineIndex] = string.Format("{0} {1};", origX, HEPposX[i]);
                    HEPlines[lineIndex + 1] = string.Format("{0} {1};", origY, HEPposY[i]);
                    File.WriteAllLines(HEP[i], HEPlines);

                    TRHlines[lineIndex] = string.Format("{0} {1};", origX, TRHposX[i]);
                    TRHlines[lineIndex + 1] = string.Format("{0} {1};", origY, TRHposY[i]);
                    File.WriteAllLines(TRH[i], TRHlines);

                    SEPlines[lineIndex] = string.Format("{0} {1};", origX, SEPposX[i]);
                    SEPlines[lineIndex + 1] = string.Format("{0} {1};", origY, SEPposY[i]);
                    File.WriteAllLines(SEP[i], SEPlines);

                    RAlines[lineIndex] = string.Format("{0} {1};", origX, RAposX[i]);
                    RAlines[lineIndex + 1] = string.Format("{0} {1};", origY, RAposY[i]);
                    File.WriteAllLines(RA[i], RAlines);

                    if (i == 0)
                    {
                        ENAlines[lineIndex] = string.Format("{0} {1};", origX, newX);
                        ENAlines[lineIndex + 1] = string.Format("{0} {1};", origY, newY);
                        File.WriteAllLines(ENA[i], ENAlines);

                        RDlines[lineIndex] = string.Format("{0} {1};", origX, newX);
                        RDlines[lineIndex + 1] = string.Format("{0} {1};", origY, newY);
                        File.WriteAllLines(RD[i], RDlines);
                    }                 
                }
                else
                {
                    Console.WriteLine("Error! Text not read successfully");
                }
            }
            Console.WriteLine("Origin Values Successfully Updated!");
            Console.WriteLine("Press enter to quit");
            Console.Read();
        }
    }
}





