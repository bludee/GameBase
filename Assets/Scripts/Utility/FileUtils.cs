using System;
using System.IO;


namespace Game
{
	/// <summary>
	/// 本地文件操作工具类
	/// </summary>
	public class FileUtils
	{
		public FileUtils ()
		{
		}

		public static void CreateOrUpdateFile(string path,string name,byte[] con,int len)
		{
			DirectoryInfo dic = new DirectoryInfo (path);
			if (!dic.Exists) {
				dic.Create ();
			}
			Stream stream=null;
			FileInfo t = new FileInfo (path+"//"+name);
			if (t.Exists) {
				File.Delete (path + "//" + name);
			} 
			stream = t.Create ();
			stream.Write (con,0,len);
			stream.Close ();
			stream.Dispose ();
		}

		/// <summary>
		/// 将byte数组转换为文件并保存到指定地址
		/// </summary>
		/// <param name="buff">byte数组</param>
		/// <param name="savepath">保存地址</param>
		public static void SaveBytes2File(byte[] buff, string savepath)
		{
			if (File.Exists(savepath))
			{
				File.Delete(savepath);
			}
			FileStream fs = new FileStream(savepath, FileMode.CreateNew);
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write(buff, 0, buff.Length);
			bw.Close();
			fs.Close();
		}


		/// <summary>
		/// 读取一个文件 转换成byte[]
		/// </summary>
		/// <returns>The bytes.</returns>
		/// <param name="path">Path.</param>
		public static byte[] LoadFile2Bytes(string path)
		{
			if(!File.Exists(path))
			{
				return new byte[0];
			}

			FileInfo fi = new FileInfo(path);
			byte[] buff = new byte[fi.Length];

			FileStream fs = fi.OpenRead();
			fs.Read(buff, 0, Convert.ToInt32(fs.Length));
			fs.Close();

			return buff;
		}
	}
}

