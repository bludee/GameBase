using System;

namespace Game
{
	public class EventNames
	{
		/// <summary>
		/// 过去一天,更改时间事件
		/// </summary>
		public static string ChangeDay="ChangeDay";

		/// <summary>
		/// 货币刷新
		/// </summary>
		public static string UpdateMoney="UpdateMoney";


		/// <summary>
		/// 更新任务情况,有任务的数量变更都需要触发
		/// </summary>
		public static string UpdateTask="UpdateTask";

		/// <summary>
		/// 开始移动
		/// </summary>
		public static string StarMove="StarMove";
		public static string EndMove="EndMove";


		/// <summary>
		/// 购买车子后
		/// </summary>
		public static string UpdateCar="UpdateCar";

		/// <summary>
		/// 修复车子
		/// </summary>
		public static string RepairCar="RepairCar";

	}
}

