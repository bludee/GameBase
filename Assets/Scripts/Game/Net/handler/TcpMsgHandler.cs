﻿using System;
namespace Game
{
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

