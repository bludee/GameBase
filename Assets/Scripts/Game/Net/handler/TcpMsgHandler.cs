using System;
namespace Game
{
	/// <summary>
	/// tcp通信的消息注册和分发,一般是在socket中想一个队列中插入消息,然后在mono脚本中update检测是否有详细,然后dispath,socket是异步的 ,直接抛消息会报错
	/// </summary>
	public class TcpMsgHandler
	{

		/// <summary>
		/// 注册消息
		/// </summary>
		public static void InitMsgHandler()
		{
			GEventCenter<Int16>.Inst.AddEventListener (1001,onRecv_1001);
		}


		/// <summary>
		/// 分发消息
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void onRecv_1001(GEvent msg)
		{
			
		}

	}
}

