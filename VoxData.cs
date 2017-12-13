using System;

namespace BinaryTools
{
	public class VoxData
	{
		string type;
		int version;
		public VoxData(BinaryReader _bs)
		{
			type = _bs.GetString(4);
			version = _bs.GetValue(4);
		}
		public string Type
		{
			get{return type;}
		}
		public int Version
		{
			get{return version;}
		}
	}
}
