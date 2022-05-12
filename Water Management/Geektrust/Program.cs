using System;
using System.IO;

namespace Geektrust
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputData = File.ReadAllLines(@"sample_input/input1.txt");
                int apartmentType = 0, guests = 0;
                int[] ratio = new int[2];
                foreach (string line in inputData)
                {
                    if (line.StartsWith("ALLOT_WATER"))
                    {
                        string[] arr = line.Split(' ');
                        apartmentType = int.Parse(arr[1]);
                        string[] strRatio = (arr[2].Split(':'));
                        ratio = Array.ConvertAll(strRatio, int.Parse);
                    }
                    else if (line.StartsWith("ADD_GUESTS"))
                    {
                        string[] arr = line.Split(' ');
                        guests += int.Parse(arr[1]);
                    }
                }

                int corporateWater = 0, borewellWater = 0, corporateAndBorewellWater = 0, tankWater = 0, totalWater = 0;
                int corporateBill = 0, borewellBill = 0, tankBill = 0, totalBill = 0;

                if (apartmentType == 2)
                    corporateAndBorewellWater = 900;
                else
                    corporateAndBorewellWater = 1500;

                corporateWater = ratio[0] * (corporateAndBorewellWater / (ratio[0] + ratio[1]));
                borewellWater = ratio[1] * (corporateAndBorewellWater / (ratio[0] + ratio[1]));

                corporateBill = corporateWater * 1;
                borewellBill = (int)(borewellWater * 1.5);

                tankWater = guests * 10 * 30;
                tankBill = CalculateTankBill(tankWater);

                totalWater = corporateAndBorewellWater + tankWater;
                totalBill = CalculateTotalBill(corporateBill, borewellBill, tankBill);

                Console.WriteLine(totalWater + " " + totalBill);

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static int CalculateTankBill(int tankWater)
        {
            int tankBill = 0, slab1 = 0, slab2 = 0, slab3 = 0, slab4 = 0;

            if (tankWater <= 500)
            {
                tankBill = tankWater * 2;
            }
            else if (tankWater > 500 && tankWater <= 1500)
            {
                slab1 = 500;
                slab2 = tankWater - slab1;

                tankBill = slab1 * 2 + slab2 * 3;
            }
            else if (tankWater > 1500 && tankWater <= 3000)
            {
                slab1 = 500;
                slab2 = 1000;
                slab3 = tankWater - (slab1 + slab2);

                tankBill = slab1 * 2 + slab2 * 3 + slab3 * 5;
            }
            else
            {
                slab1 = 500;
                slab2 = 1000;
                slab3 = 1500;
                slab4 = tankWater - (slab1 + slab2 + slab3);

                tankBill = slab1 * 2 + slab2 * 3 + slab3 * 5 + slab4 * 8;
            }

            return tankBill;
        }

        public static int CalculateTotalBill(int corporateBill, int borewellBill, int tankBill)
        {
            int totalBill = corporateBill + borewellBill + tankBill;

            return totalBill;
        }
    }
}
