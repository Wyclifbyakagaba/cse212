using System;
using System.Collections.Generic;public static class Arrays
{
    ///<summary>
    /// produces multiple copies of a list and numbers
    /// </summary>
    public static double[] multiplesof(double number, int length)
    {
        //step 1:create result array
      double[] result = new double[length];
      //step 2: fill the result array with multiples of the number
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
     //step 3: return the result array
        return result;
    }
    
        /// <summary>
        ///  rotates a list to the right positions
        /// </summary>
      
      public static void  RotateListRight(List<int>data, int amount)
    {
        //step 1:repeat rotation 'amount' times
         for (int a=0; a < amount; a++)
        {
            //step 2: store last element in a temporary variable
            int last = data[data.Count - 1];

              //step 3:shift all elements to the right
              for (int i = data.Count - 1; i > 0; i--)
         {
                data[i] = data[i - 1];
            }
               //step 4: place the last element at the beginning of the list
               data[0] = last;
               
    }
    
    
     } }