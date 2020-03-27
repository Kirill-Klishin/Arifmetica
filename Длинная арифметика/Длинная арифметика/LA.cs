using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Длинная_арифметика
{
    class LA
    {
        public static int Incorrect_value(string value)
        {
            while (true)
            {
                try
                {
                    Convert.ToInt32(value);
                    break;
                }
                catch
                {
                    Console.WriteLine("Данные введены некорректно, введите снова");
                    value = Console.ReadLine();
                }
            }
            return (Convert.ToInt32(value));
        }
        public static string Addition(string num1, string num2)
        {
            string Summ_string = "";
            int num1_size = num1.Length;
            int num2_size = num2.Length;
            if (num1_size > num2_size) { while (num1_size != num2_size) { num2 = "0" + num2; num2_size++; } }
            if (num2_size > num1_size) { while (num1_size != num2_size) { num1 = "0" + num1; num1_size++; } }
            //while (num1_size % 9 != 0) { num1 = "0" + num1; num1_size++; };
            //while (num2_size % 9 != 0) { num2 = "0" + num2; num2_size++; };
            int block1_size = num1_size ;
            int block2_size = num2_size ;
            int[] Num1_blocks = new int[block1_size + 2];
            int[] Num2_blocks = new int[block2_size + 2];
            int[] Summ = new int[block1_size + 2];
            try
            {
                int n = num1_size;
            for (int i = 0; i < block1_size; i++)
                {
                    string block = num1.Substring(n-1, 1);
                    Num1_blocks[i] = Convert.ToInt32(block);
                    n --;
                }
            n = num2_size;
                for (int i = 0; i < block1_size; i++)
                {
                    string block = num2.Substring(n-1, 1);
                    Num2_blocks[i] = Convert.ToInt32(block);
                    n--;
                }
                
                int transfer = 0;
                for (int i = 0; i < Summ.Length; i++)
                {
                    Summ[i] = (Num1_blocks[i] + Num2_blocks[i] + transfer) % 10;
                    double T = (Num1_blocks[i] + Num2_blocks[i] + transfer);
                    transfer = Convert.ToInt32(Math.Truncate(T / 10));
                    Summ_string = Summ[i] + Summ_string;
                }
            }
            catch { Summ_string = "Неверое значение"; }
            return (Summ_string);
        }
        public static string Subtraction(string num1, string num2)
        {
            bool minus = false;
            string Diff_string = "";
            int num1_size = num1.Length;
            int num2_size = num2.Length;
            if (num2_size > num1_size) { minus = true; }
            if (num1_size > num2_size) { while (num1_size != num2_size) { num2 = "0" + num2; num2_size++; } }
            if (num2_size > num1_size) { while (num1_size != num2_size) { num1 = "0" + num1; num1_size++; } }
            int block1_size = num1_size;
            int block2_size = num2_size;
            int[] Num1_blocks = new int[block1_size + 1];
            int[] Num2_blocks = new int[block2_size + 1];
            try
            {
                int n = num1_size - 1;
                for (int i = 0; i < block1_size; i++)
                {
                    string block = num1.Substring(n,1);
                    Num1_blocks[i] = Convert.ToInt32(block);
                    n--;
                }
            n = num2_size - 1;
            for (int i = 0; i < block2_size; i++)
                {
                    string block = num2.Substring(n, 1);
                    Num2_blocks[i] = Convert.ToInt32(block);
                    n--;
                }
                for (int j = Num1_blocks.Length - 1; j >= 0; j--)
                {
                    if (Num1_blocks[j] > Num2_blocks[j]) { break; }
                    if (Num1_blocks[j] < Num2_blocks[j]) { minus = true; break; }
                }
                if (minus == true)
                {
                    for (int i = 0; i < Num1_blocks.Length - 1; i++)
                    {
                        Num1_blocks[i] ^= Num2_blocks[i];
                        Num2_blocks[i] ^= Num1_blocks[i];
                        Num1_blocks[i] ^= Num2_blocks[i];
                    }
                }
                int blockDiff_size = block1_size;
                int[] Diff = new int[blockDiff_size + 1];
                int transfer = 0;
                for (int i = 0; i < blockDiff_size; i++)
                {
                    Diff[i] = (Num1_blocks[i] - Num2_blocks[i] - transfer + 10) % 10;
                    int T = (Num1_blocks[i] - Num2_blocks[i] - transfer);
                    if (T < 0) { transfer = 1; }
                    else { transfer = 0; }
                    Diff_string = Diff[i] + Diff_string; 
                }
                if (minus == true) { Diff_string = "-" + Diff_string; }
            }
            catch { Diff_string = "Неверное значение"; }
            return (Diff_string);
        }
        public static string Multiplication(string num1, string num2)
        {
            
            
                string Mult_string = "";
                int num1_size = num1.Length;
                int num2_size = num2.Length;
                //while (num1_size % 4 != 0) { num1 = "0" + num1; num1_size++; };
                //while (num2_size % 4 != 0) { num2 = "0" + num2; num2_size++; };
                int block1_size = num1_size ;
                int block2_size = num2_size ;
                int[] Num1_blocks = new int[block1_size + 1];
                int[] Num2_blocks = new int[block2_size + 1];
            try
            {
                int n = num1_size;
                for (int i = 0; i < block1_size; i++)
                {
                    string block = num1.Substring(n-1, 1);
                    Num1_blocks[i] = Convert.ToInt32(block);
                    n--;
                }
                n = num2_size;
                for (int i = 0; i < block2_size; i++)
                {
                    string block = num2.Substring(n-1, 1);
                    Num2_blocks[i] = Convert.ToInt32(block);
                    n--;
                }
                int[] Mult = new int[block1_size + block2_size + 1];
                int residue = 0;
                double T = 0;
                for (int i = 0; i < block2_size; i++)
                {
                    int transfer = 0;
                    for (int j = 0; j < block1_size; j++)
                    {
                        T = Mult[j + i] + transfer + Num1_blocks[j] * Num2_blocks[i];
                        Mult[j + i] = Convert.ToInt32(T) % 10;
                        transfer = Convert.ToInt32(Math.Truncate(T / 10));
                        //Console.WriteLine(Mult[i + j] + "   " + transfer);
                        residue = i + j;
                    }
                    Mult[residue + 1] = transfer;
                }
                for (int i = 0; i < Mult.Length; i++) { Mult_string = Mult[i] + Mult_string; }
            }
            catch { Mult_string = "Неверное значение"; }
                return (Mult_string);
            
        }
        public static void Division(string num1, string num2)
        {
            int num2_size = num2.Length;
            int num1_size = num1.Length;
            if (num2 == "0")
            {
                Console.WriteLine("нельзя делить на 0");
            }
            else
            {
                if (num1_size >= num2_size)
                {
                    char[] Num1 = num1.ToCharArray();
                    string Div = "";
                    string N = num1.Substring(0, num2_size);
                    string num1_mini = N;
                    //Console.WriteLine(num1);
                    //Console.WriteLine(num2);
                    //Console.WriteLine(N);
                    try
                    {
                        for (int i = num2_size; i <= num1.Length; i++)
                        {
                            int mini_Div = -1;
                            while (!num1_mini.Contains("-"))
                            {
                                N = num1_mini;
                                num1_mini = Subtraction(N, num2);
                                mini_Div++;
                                //Console.WriteLine(mini_Div);
                            }
                            Div = Div + Convert.ToString(mini_Div);
                            num1_mini = N + Num1[i];
                            //Console.WriteLine(N);
                        }
                    }
                    catch
                    {
                        Console.WriteLine(">>Результат:" + Div);
                        Console.WriteLine(">>Остаток:" + N);
                    }
                }
                else { Console.WriteLine("Результат:0\n" + "Остаток:" + num1); }
            }
        }
    }
}



