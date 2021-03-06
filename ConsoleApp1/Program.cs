﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new int[] { 1, 3, 6, 4, 1, 2 };

            //Console.Write(solution(A));
            //BinaryGap(100);
            //int[] A = new int[] { 3, 8, 9, 7, 6 };
            //ArrayRotation(A, 3);

            //int[] A = new int[] { 9, 3, 9, 3, 9, 7, 9 };
            //OddOccuranceINArray(A);

            //FrogJumb(10, 90, 30);
            int[] A = new int[] { -1000,1000};
            //TapeEquilibrium(A);


            var myArray = GenerateRandomArray();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Summ(myArray);

            //Sum(new int[] { -1000, 1000});
            // Console.WriteLine(PassingCars(new int[] {0,1,0,1,1 }));
            // repeatingChar("hellooaa");
            // MaximumWordCount("Forget  CVs..Save time . x x");
            //Console.WriteLine(PascalTriangle(80));
            //ParseRomanNumerals("MCMLXI");
            //jumpingOnClouds(new int[] { 0,0,1,0,0,1,0});
            repeatedString("kmretasscityylpdhuwjirnqimlkcgxubxmsxpypgzxtenweirknjtasxtvxemtwxuarabssvqdnktqadhyktagjxoanknhgilnm", 736778906400);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();

        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            //remove nigative values

            A = A.Where(x => x > 0).ToArray();
            int min = A.Min();
            if (min > 1)
                return 1;

            A = A.OrderBy(x => x).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] + 1 != A[i + 1])
                    return A[i] + 1;
            }
            return 0;
        }

        public static int BinaryGap(int input)
        {
            string binaryNumberString = Convert.ToString(input,2);
            Console.WriteLine("binary value "+binaryNumberString);
            string[] strArray = binaryNumberString.Split('1');
            int gapLength = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
                if (strArray[i].Length == 0)
                    continue;
                if (i == (strArray.Length - 1))
                    continue;

                if (strArray[i].Length > gapLength)
                    gapLength = strArray[i].Length;

                Console.WriteLine("gap length " + gapLength.ToString());

            }
            Console.ReadKey();
            return gapLength;

        }

        public static int[] ArrayRotation(int[] inputArray,int inputInt)
        {
            //A = [3, 8, 9, 7, 6]
            //K = 3
            int[] tempArray = new int[inputArray.Length];
            for (int idx = 0; idx < inputInt; idx++)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (i == inputArray.Length - 1)
                    {
                        tempArray[0] = inputArray[i];
                        break;
                    }
                    tempArray[i + 1] = inputArray[i];
                }
                tempArray.CopyTo(inputArray,0);
            }
            return inputArray;
            
        }

        public static int OddOccuranceINArray(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return inputArray[0];

            if (inputArray.Length == 2)
                throw new InvalidOperationException();

            List<int> tempArray = new List<int>();
            int FirstInt = inputArray[0];
            bool matchFound = false;
           // int tempArrayIndex = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == FirstInt)
                {
                    matchFound = true;
                    continue;
                }
                    

                //if (tempArrayIndex == tempArray.Length - 1) //match not found, don't proceed and return the first int in this case 
                //    return FirstInt;

                tempArray.Add( inputArray[i]);
               
            }
            if (matchFound)
                //if not found call self again
                return OddOccuranceINArray(tempArray.ToArray());
            else return FirstInt;
        }

       public static int FrogJumb(int X,int Y, int D)
        {
            //X=10,Y=90,D=30
            if (X >= Y || D == 0)
                return 0;
            //int jumb = 1;
            Y = Y - X;
            //get multiple rest
            var rest = Y % D;
            if(rest > 0)
            {
                Y = Y - rest;
                //return Y / X;
                return (Y / D) + 1;
            }
            
                return (Y / D);
            
            //int temp = X + D;
            //if (temp > Y)
            //    return jumb;
            //while(temp < Y)
            //{
            //    temp = temp + D;
            //    jumb++;
            //}
            //return jumb;
        }

        public static int MissingElement (int[] A)
        {

            if (A.Length == 0)
                return 1;
            if (A.Length == 1)
            {
                if (A[0] > 1)
                    return 1;
                else
                    return 2;
            }
            A = A.OrderBy(x => x).ToArray();
            if (A[0] != 1) return 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (i == A.Length - 1)
                    continue;
                if (A[i] + 1 != A[i + 1])
                    return A[i] + 1;
            }
            return A[A.Length-1]+1;
        }

        public static int TapeEquilibrium(int[] A)
        {
            int minDef = int.MaxValue;
            //int sumAll = A.Sum();
            for (int i = 0; i < A.Length; i++)
            {
                // int firstPart = 0;
                // int secondPart = 0;
                if (i == A.Length - 1)
                    continue;
                int[] firstArr = new int[i + 1];
                firstArr= A.Take(i + 1).ToArray();
                int[] secondArray = new int[A.Length - 1 - i];
                secondArray = A.Skip(i + 1).ToArray();
                int firstPart = firstArr.Sum();
                int secondPart = secondArray.Sum();
                if (minDef > Math.Abs(firstPart - secondPart)) minDef = Math.Abs(firstPart - secondPart);
                if (minDef <= 1) break;
            }
            return minDef;
        }

        public static int Summ(int[] myArray)
        {
            if (myArray.Length < 2 || myArray.Length > 100000)
                return 0;

            int[] another = new int[myArray.Length - 1];

            int currentNum = 0;
            for (int x = 0; x < myArray.Length; x++)
            {
                if (myArray[x] >= -1000 && myArray[x] <= 1000)
                {

                    if (x == myArray.Length - 1)
                        break;

                    currentNum += myArray[x];

                    int otherNumSum = 0;


                    for (int i = x + 1; i < myArray.Length; i++)
                    {
                        otherNumSum += myArray[i];
                    }

                    another[x] = Math.Abs(otherNumSum - currentNum);
                }
            }

            return another.Min();
        }


        public static  int Sum(int[] A)
        {
            int sumRight = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sumRight += A[i];
            }

            int sumLeft = 0;
            int min = int.MaxValue;
            for (int P = 1; P < A.Length; P++)
            {
                int currentP = A[P - 1];
                sumLeft += currentP;
                sumRight -= currentP;

                int diff = Math.Abs(sumLeft - sumRight);
                if (diff < min)
                {
                    min = diff;
                }
            }
            return min;
        }

        private static int[] GenerateRandomArray()
        {
            int Min = -1;
            int Max = 1;

            // this declares an integer array with 5 elements
            // and initializes all of them to their default value
            // which is zero
            int[] test2 = new int[100000];

            Random randNum = new Random();
            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = randNum.Next(Min, Max);
            }
            return test2;
        }

        public static long PassingCars(int[] A)
        {
            long passingCarsCount = 0;

            int zeros = 0;
            //int ones = 0;
            bool limitExceed = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (passingCarsCount > 1000000000)
                {
                    limitExceed = true;
                    break;
                }
                if (A[i]==0)
                {
                    zeros++;
                   // if(ones > 0)ones--;
                }
                else
                {
                    //ones++;
                    passingCarsCount += zeros;
                   
                }
                    
            }
            if (limitExceed)
                return -1;
            else
                return passingCarsCount;
        }

        public static String repeatingChar(String S)
        {
            int[] occurrences = new int[26];
            foreach (char ch in S)
            {
                occurrences[(int)ch - 'a']++;
            }

            char best_char = 'a';
            int best_res = 0;

            for (int i = 0; i < 26; i++)
            {
                if (occurrences[i] > best_res)
                {
                    best_char = (char)('a' + i);
                    best_res = occurrences[i];
                }
            }

            return best_char.ToString();
        }

        public static int MaximumWordCount(String S)
        {
            //Three spliters ./?/!
            string[] strArray = S.Split(new char[] { '.', '?', '!' });
            int maxWordCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] words = strArray[i].Split(' ');
                int wordsCount = words.Length;
                for (int idx = 0; idx < words.Length; idx++)
                {
                    if (words[idx].Length == 0)
                        wordsCount--;
                }
                if (wordsCount > maxWordCount)
                {
                    maxWordCount = words.Length;
                }
            }
            return maxWordCount;
        }

        public static string FindElement(int[] arr,int k)
        {
            for (int i = 0; i < arr.Count(); i++)
        {
                if (arr[i] == k)
                    return "YES";
            }

            return "No";
        }

        public static int PascalTriangle(int input)
        {
            if (input == 0)
                return 1;
            int total = 1;

            for (int i = 1; i <= input; i++)
            {
                total = total * 2;
                if (total > (int.MaxValue / 2) & (i < input - 1)) // if the current round is not the final and the next value will be more that int max value
                    return -1;
            }
            return total;
        }

        public static int ParseRomanNumerals(string input)
        {
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'M')
                    numbers[i] = 1000;
                if (input[i] == 'D')
                    numbers[i] = 500;
                if (input[i] == 'C')
                    numbers[i] = 100;
                if (input[i] == 'L')
                    numbers[i] = 50;
                if (input[i] == 'X')
                    numbers[i] = 10;
                if (input[i] == 'V')
                    numbers[i] = 5;
                if (input[i] == 'I')
                    numbers[i] = 1;

            }
            int total = 0;

        for (int idx = 0; idx < numbers.Length; idx++)
            {
                total += numbers[idx];
                if (idx >0)  
                {
                    if (numbers[idx - 1] < numbers[idx])
                    {
                        total = total - numbers[idx]-numbers[idx-1];
                        total += numbers[idx] - numbers[idx - 1];
                    }
                }
            }
            return total;
        }
        public static int MaxDepth(TreeNode root)
        {
            int depthLeft = 0;
            int depthRight = 0;
            if (root.left != null)
                depthLeft = getLeft(root, depthLeft);

            if (root.right != null)
                depthRight = getRight(root, depthRight);

            if (depthRight > depthLeft)
                return depthRight;
            else return depthLeft;
        }
        private static int getLeft(TreeNode Node,int count)
        {
            count++;
            if (Node.left != null)
                return count + getLeft(Node.left, count);
            else
                return count;
        }
        private static int getRight(TreeNode Node, int count)
        {
            count++;
            if (Node.right != null)
                return count + getRight(Node.right, count);
            else
                return count;

        }

        public static int sockMerchant(int n, int[] ar)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < ar.Length; i++)
            {
                if(ht.ContainsKey(ar[i]))
                {
                    int temp = (int)ht[ar[i]];
                    temp++;
                    ht[ar[i]] = temp;
                }
                else
                {
                    ht.Add(ar[i], 1);
                }
            }
            int socksCount = 0 ;
            foreach (int item in ht.Keys)
            {
                if ((int)ht[item] == 1)
                    continue;
                int def = (int)ht[item] % 2;
                if ( def == 0)
                {
                    socksCount += (int)ht[item] / 2;
                }
                else
                {
                    socksCount += ((int)ht[item]-def) / 2;
                }
            }
            return socksCount;
        }
        public static int countingValleys(int n, string s)
        {
            int valliesCount = 0;
            int seaLevel = 0;
            int prevStep = 0;
            foreach (char step in s)
            {
                prevStep = seaLevel;
                if (step == 'D')
                    seaLevel--;
                else if (step == 'U')
                    seaLevel++;

                if(prevStep == 0 && seaLevel<0)
                    {
                    valliesCount++;
                }

            }
            return valliesCount;

        }

        public static int jumpingOnClouds(int[] c)
        {

            int jumbsCount = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (i == c.Length - 1)
                {
                   // jumbsCount++;
                    continue;
                }
                if (i == c.Length - 2)
                {
                    jumbsCount++;
                    continue;
                }
                if (c[i + 2] == 0)
                {

                    i++;
                }
                jumbsCount++;

            }
            return jumbsCount;
        }

        public static long repeatedString(string s, long n)
        {
            if (s.Length == 1 && s == "a")
                return n;
            StringBuilder str = new StringBuilder();
            str.Append(s);
            while (str.ToString().Length <= n)
            {
                str.Append(s);
            }
            s = s.Substring(0, (int)n);

            char[] chars =s.ToCharArray().Where(x=>x=='a').ToArray();
            return chars.Length;
        }

        public static int removeDuplicates(int[] nums)  // remove duplicates from sorted array "In Place"
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            ListNode current = head;

            int currentIndex = 0;
            while (current.next != null)
            {
                currentIndex++;
                if (n == currentIndex - 2)
                {
                    current.val = current.next.val;
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }

    }
   
      
   
    //Definition for a binary tree node.
    public class TreeNode
    {
   public int val;
   public TreeNode left;
   public TreeNode right;
   public TreeNode(int x) { val = x; }
   }
    
 // Definition for singly-linked list.
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 

}
