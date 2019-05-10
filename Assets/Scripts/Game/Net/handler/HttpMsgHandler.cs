using System;
namespace Game
{
	/// <summary>
	/// http通信的消息注册和分发
	/// </summary>
	public class HttpMsgHandler
	{
		/// <summary>
		/// 注册消息
		/// </summary>
		public static void InitMsgHandler()
		{
			GEventCenter<Int16>.Inst.AddEventListener (11001,onRecv_11001);
		}


		/// <summary>
		/// 分发消息
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void onRecv_11001(GEvent msg)
		{

		}
		public HttpMsgHandler ()
		{
		}
	}
}

