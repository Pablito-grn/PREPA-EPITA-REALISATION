using System;

namespace Debugger
{
	public class Ex1
	{
		public static uint Exo1()
		{
			uint sum = 0;
			uint count = 500;
			while (count > 0)
			{
				bool divided = Misc.IsDivisorOf((int) count, 42);
				if (divided)
					sum += count;

				count--;
			}
			
			return sum;
		}
	}
}

