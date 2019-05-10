using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game {
	public class NetworkManager : MonoBehaviour {
        private SocketClient socket;
        static readonly object m_lockObject = new object();
        static Queue<KeyValuePair<int, ByteBuffer>> mEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

        SocketClient SocketClient {
            get { 
                if (socket == null)
                    socket = new SocketClient();
                return socket;                    
            }
        }

        void Awake() {
            Init();
        }

        void Init() {
            SocketClient.OnRegister();
        }

        ///------------------------------------------------------------------------------------
        public static void AddEvent(int _event, ByteBuffer data) {
            lock (m_lockObject) {
                mEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
            }
        }

        /// <summary>
        /// ����Command�����ﲻ����ķ���˭��
        /// </summary>
        void Update() {
            if (mEvents.Count > 0) {
                while (mEvents.Count > 0) {
                    KeyValuePair<int, ByteBuffer> _event = mEvents.Dequeue();
					GEventCenter<int>.Inst.DispatchEvent(_event.Key,_event.Value);
                }
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public void SendConnect() {
            SocketClient.SendConnect();
        }

        /// <summary>
        /// ����SOCKET��Ϣ
        /// </summary>
		public void SendMessage(int msgId,byte[] bytes) {
			ByteBuffer buffer = new ByteBuffer ();
			buffer.WriteInt ((ushort)bytes.Length+4);
			buffer.WriteShort ((ushort)msgId);
			buffer.WriteBytes (bytes);
            SocketClient.SendMessage(buffer);
        }

        /// <summary>
        /// ��������
        /// </summary>
        new void OnDestroy() {
            SocketClient.OnRemove();
            Debug.Log("~NetworkManager was destroy");
        }



		public void OnRecvMessage(int id,ByteBuffer buffer)
		{}
    }
}