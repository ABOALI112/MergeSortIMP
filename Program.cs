using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {


        /// <summary>
        /// mergesort is a divide and conquer algorithim that are founded on the concept of divide the input to 2 subproblem ,
        /// then sort each subproblem recursively before merging to the bigproblem.
        /// 
        /// mergesort(array)
        /// if array.length<=1then
        /// return array
        /// left = new array
        /// right=new array
        /// mid = array/2
        ///mergesort(left)
        ///mergesort(right)
        ///merge(left,right)
        /// </summary>
        /// <param name="args"></param>

        public static int[] mergesort(int[] array) {

            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length < 1)
            {
                return array;
            }
            // The exact midpoint of our array  
            int midpoint = (array.Length) / 2;
            left = new int[midpoint];
            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
            {
                right = new int[midpoint];
            }
            //if array has an odd number of elements, the right array will have one more element than left
            else
            {
                right = new int[midpoint + 1];
            }
            //populate left array
            for (int i = 0; i < midpoint; i++)
            {
                left[i] = array[i];
            }
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midpoint; i < array.Length; i++)
            {
                right[i] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = mergesort(left);
            //Recursively sort the right array
            right = mergesort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }


        //This method will be responsible for combining our two sorted arrays into one giant arraypublic static int[] merge(int left[],int right[])
        public static int[] merge(int[] left, int[] right)
        {
            int resultlength = left.Length + right.Length;
            int[] result = new int[resultlength];

            int leftindex = 0, rightindex = 0, indexresult = 0;

            //while either array still has an element
            while (leftindex < left.Length || rightindex<right.Length )
            {
                //if both arrays have elements 
                if ((leftindex < left.Length && rightindex < right.Length))
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[leftindex] <= right[rightindex])
                    {
                        result[rightindex] = left[leftindex];
                        leftindex++;
                        indexresult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexresult] = right[rightindex];
                        rightindex++;
                        indexresult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (leftindex < left.Length)
                {
                    result[indexresult] = left[leftindex];
                    leftindex++;
                    indexresult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (rightindex < right.Length)
                {
                    result[indexresult] = right[rightindex];
                    indexresult++;
                    rightindex++;
                }
            }
            return result;


        }

        }
       

    }
    
