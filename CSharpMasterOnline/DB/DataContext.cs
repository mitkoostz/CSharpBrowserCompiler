using CSharpMasterOnline.DB.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSharpMasterOnline.DB
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("CSharpMaster")
        {
            Database.SetInitializer( new MyInitializer());
        }

        public virtual DbSet<Challenge> Challenges { get; set; }


    

    }
     

    public class MyInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Challenge ch = new Challenge()
            {
                Name = "Solve Me First",
                Section = "Warmup",
                Condition = @"

Given an array of integers, find the sum of its elements.

Input Format

The first line contains an integer, denoting the size of the array. 
The second line contains  space-separated integers representing the array's elements.

Output Format

Print the sum of the array's elements as a single integer.

",
                Difficulty = "easy",
                InitialCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int simpleArraySum(int n, int[] ar) {
        // Complete this function
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = simpleArraySum(n, ar);
        Console.WriteLine(result);
    }
}",
                SampleInput =
                @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Solve Me First\input.txt",

                SampleOutput =
                @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Solve Me First\output.txt",

                SampleInput2 =
                @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Solve Me First\input2.txt",
                SampleOutput2 =
                @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Solve Me First\output2.txt",


            };

            Challenge ch2 = new Challenge()
            {
                Name = "A Very Big Sum",
                Section = "Warmup",
                Condition = @"
Calculate and print the sum of the elements in an array, keeping in mind that some of those integers may be quite large.

<b>Input Format</b>

The first line of the input consists of an integer . 
The next line contains  space-separated integers contained in the array.

<b>Output Format</b>

Print the integer sum of the elements in the array.
",
                Difficulty = "easy",
                InitialCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static long aVeryBigSum(int n, long[] ar) {
        // Complete this function

    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        long[] ar = Array.ConvertAll(ar_temp,Int64.Parse);
        long result = aVeryBigSum(n, ar);
        Console.WriteLine(result);
    }
}",
                SampleInput =
    @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\A Very Big Sum\input.txt",

                SampleOutput =
    @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\A Very Big Sum\output.txt",

                SampleInput2 =
    @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\A Very Big Sum\input2.txt",
                SampleOutput2 =
     @"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\A Very Big Sum\output2.txt",


            };

            Challenge ch3 = new Challenge()
            {
                Name = "Plus Minus",
                Section = "Warmup",
                Condition = @"
Given an array of integers, calculate the fractions of its elements that are positive, negative, and are zeros. Print the decimal value of each fraction on a new line.

<b>Input Format</b>

The first line contains an integer , <b>n</b> , denoting the size of the array. 
The second line contains <b>n</b> space-separated integers describing an array of numbers .

<b>Output Format</b>

You must print the following <b>3</b> lines:

A decimal representing of the fraction of positive numbers in the array compared to its size.
A decimal representing of the fraction of negative numbers in the array compared to its size.
A decimal representing of the fraction of zeros in the array compared to its size.

Results must be with precision 6 numbers as a Sample - <b>0.500000</b>
",
                Difficulty = "easy",
                InitialCode = @"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

         static void plusMinus(int[] arr)
        {
            // Complete this function           
        }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        plusMinus(arr);
    }
}",
                SampleInput =
@"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Plus Minus\input.txt",

                SampleOutput =
@"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Plus Minus\output.txt",

                SampleInput2 =
@"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Plus Minus\input2.txt",
                SampleOutput2 =
@"D:\My Pojects C#\CSharpMaster\CSharpMasterOnline\Challenges\Plus Minus\output2.txt",


            };



            context.Challenges.Add(ch);
            context.Challenges.Add(ch2);
            context.Challenges.Add(ch3);


            context.SaveChanges();
            
        }
    }
}