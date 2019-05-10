using System;

namespace Game
{


	public class RandomUtil
	{
		private static System.Random random=new System.Random();
		public RandomUtil ()
		{
		}

		/// <summary>
		/// 不包含max值
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public static int Random(int min,int max)
		{
			int ranNum=random.Next(min,max);
			ranNum=Math.Max(ranNum,0);
			return ranNum;
		}

		public static int RandomMax(int min,int max)
		{
			int ran=random.Next(min,max+1);
			return ran;
		}

		public static int Random(int max)
		{
			return Random(0,max);
		}





	}


}

