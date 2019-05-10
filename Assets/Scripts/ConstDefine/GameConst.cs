using System;
using System.Collections.Generic;

namespace Game
{
	public class GameConst
	{



		private static GameTemp  config;


		public GameConst ()
		{
		}


		public static void Init()
		{
		}


		/// <summary>
		/// 标准移动速度
		/// </summary>
		public static int SimpleCarSpeed{
			get{
				return Config ().stdCarSpeed;

			}
		}

		/// <summary>
		/// 时间转换比例,单位 秒
		/// </summary>
		public static int TimeRatio{
			get{ 
				return Config ().secPerDay;
			}
		}


		/// <summary>
		/// 价格变化等级区分值
		/// </summary>
		/// <value>The sp need.</value>
		public static int SpNeed{
			get{ 
				return Config ().spNeed;
			}
		}


		/// <summary>
		/// 需求物品刷新天数
		/// </summary>
		/// <value>The need reload days.</value>
		public static int NeedReloadDays{
			get{ 
				return Config ().needReloadDays;
			}
		}

		/// <summary>
		/// 需求数量范围
		/// </summary>
		/// <value>The need number.</value>
		public static int[] NeedNum{
			get{
				return Config ().needNum;
			}
		}


		private static GameTemp Config()
		{
//			if (config == null) {
//				config = AppMain.Inst.ConfigMgr.GameConfig.Get(1);
//			}
			return config;
		}


	}
}

