using System;

namespace BinaryTools
{
	public class VoxData
	{
		string type;
		int version;
		int numModels = 1;
		public VoxData(BinaryReader _br)
		{
			type = _br.GetString(4);
			version = _br.GetValue(4);
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

	class Chunk
	{
		internal string chunkId;
		internal int nLen;
		internal int mLen;
		internal Chunk(BinaryReader _br)
		{
			chunkId = _br.GetString(4);
			nLen = _br.GetValue(4);
			mLen = _br.GetValue(4);
		}
		public string ChunkId
		{
			get{return chunkId;}
		}
	}

	class ChunkMain : Chunk
	{
		string nContent;
		public ChunkMain(BinaryReader _br) : base(_br)
		{
			nContent = _br.GetString(nLen);
		}
	}
}
