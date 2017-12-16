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
		public void MoveCursor(int _cursor)
		{
			cursor = _cursor;
		}
		public void SeekCursor(int _delta)
		{
			cursor += _delta;
		}
		public int Cursor
		{
			get{return cursor;}
		}
		public int GetValueWithoutSeek(int _size)
		{
			int _result = GetValue(_size);
			SeekCursor(-_size);
			return _result;
		}
		public string GetStringWithoutSeek(int _size)
		{
			string _result = GetString(_size);
			SeekCursor(-_size);
			return _result;
		}
	}
}
