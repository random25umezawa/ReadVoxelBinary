using System;
using System.Text;

namespace BinaryTools
{
	public class BinaryReader
	{
		int bufferSize = 1<<16;
		int cursor;
		byte[] buffer;
		StringBuilder sb;
		System.IO.FileStream fs;
		public BinaryReader()
		{
			buffer = new Byte[bufferSize];
			sb = new StringBuilder(1<<8);
		}
		public BinaryReader(string _filename)
		{
			buffer = new Byte[bufferSize];
			sb = new StringBuilder(1<<8);
			Init(_filename);
		}
		public void Init(string _filename)
		{
			fs = new System.IO.FileStream
			(
				_filename,
				System.IO.FileMode.Open,
				System.IO.FileAccess.Read
			);
			cursor = 0;
			ReadBuffer();
		}
		public bool ReadBuffer()
		{
			int readSize = fs.Read(buffer,0,buffer.Length);
			if(readSize == 0)
			{
				fs.Close();
				return false;
			}
			return true;
		}
		public int GetValue(int _size)
		{
			int _result = 0;
			for(int i = 0; i < _size; i++)
			{
				_result |= (((int)buffer[cursor])<<(i*8));
				cursor++;
			}
			return _result;
		}
		public string GetString(int _size)
		{
			sb.Clear();
			for(int i = 0; i < _size; i++)
			{
				sb.Append((char)buffer[cursor]);
				cursor++;
			}
			return sb.ToString();
		}
	}
}
