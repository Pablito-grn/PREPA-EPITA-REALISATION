using System;

namespace Debugger
{
	public class Ex3
	{
		/// <summary>
		/// Sort an array and returns true.
		/// </summary>
		/// <returns>array is sorted.</returns>
		public static bool Exo3()
		{
			int[] array = { 10, 239, 42, 1056, 42, 784, 8192 };
			
			for (uint i = 1; i < Misc.GetLength(array); i++) 
			{
				SubFunction1(array, i - 1, array[i]);
			}
			
			return SubFunction2(array);
		}

		
		
		/// <summary>
		/// BONUS: Try to explain me?
		///explication
		/// 
		///La fonction effectue un test entre la valeur i et la valeur i-1 du tableau si val(i-1) > val(i) on les interverti dans le tableau et on recommence l'operation avec i-2 et i-1
		///
		/// 
		/// </summary>
		/// <param name="arr">an array of integers.</param>
		/// <param name="count">an unsigned integer.</param>
		/// <param name="val">an integer.</param>
		private static void SubFunction1(int[] arr, uint count, int val)
		{
			uint i = count+1;
			int stock = 0;
			
			while ((i > 0) && (arr[i-1] > val))
			{
				stock = arr[i - 1];
				arr[i - 1] = arr[i];
				arr[i] = stock; 
				--i;
			}
		}

		
		
		
		/// <summary>
		/// Checks if the array <paramref name="arr"/> is sorted.
		/// </summary>
		/// <param name="arr">an array of integers.</param>
		/// <returns>true if the array is sorted, false if not.</returns>
		private static bool SubFunction2(int[] arr)
		{	
			bool test = true;
			uint i = Misc.GetLength(arr);

			for (int j = 1; j < i; j++)
			{
				if (arr[j - 1] > arr[j])
					test = false;

			}
			return test;
		}
	}
}

