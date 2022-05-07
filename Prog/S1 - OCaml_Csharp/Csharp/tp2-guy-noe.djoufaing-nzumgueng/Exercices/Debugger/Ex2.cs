namespace Debugger
{
	public class Ex2
	{
		public static int Exo2()
		{
			
			/*
				- on cree un tableau de 10 entiers
				* la condition du for est fausse car est uint init a 0 et en decrementant, on tombe sur 4294967295
				* On ne compte que les nombres impairs
			 */
			int[] array = new int[10];
			
			for (uint i = 0; i < Misc.GetLength(array); i++)
				array[i] = (int) i;
			
			int res = 0;
			for (uint i = Misc.GetLength(array) - 1; i > 0; i--)
				if((array[i]%2) != 0)
					res += array[i];
			
			return res;
		}
	}
}

