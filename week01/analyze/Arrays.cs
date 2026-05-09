using System;
using System.Collections.Generic;
public static class Arrays
{
    /// <summary>
    /// Produces multiples of a number
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: create result array
        double[] result = new double[length];

        // Step 2: fill array with multiples
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 3: return result
        return result;
    }

    /// <summary>
    /// Rotates list to the right
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: repeat rotation 'amount' times
        for (int a = 0; a < amount; a++)
        {
            // Step 2: store last element
            int last = data[data.Count - 1];

            // Step 3: shift elements right
            for (int i = data.Count - 1; i > 0; i--)
            {
                data[i] = data[i - 1];
            }

            // Step 4: place last at front
            data[0] = last;
        }
    }
}