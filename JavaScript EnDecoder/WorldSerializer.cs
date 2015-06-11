using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JavaScript_EnDecoder
{
	[Serializable]
	class WorldSerializer
	{
		private Dictionary<Vector3, Block> __World;
		private List<Item> Items;
		private List<Block> customBlocks;
		public WorldSerializer(Dictionary<Vector3, Block> v1, List<Item> v2, List<Block> v3)
		{

			__World = v1;
			Items = v2;
			customBlocks = v3;
		}

		public void updateWorld(Dictionary<Vector3, Block> v1, List<Item> v2, List<Block> v3)
		{

			__World = v1;
			Items = v2;
			customBlocks = v3;
		}

		public Stream serialize()
		{
			var IOStream = new MemoryStream();
			var Serializer = new BinaryFormatter();
			Serializer.Serialize(IOStream, this);
			return IOStream;
		}

		public static object Deserialize(Stream Input)
		{
			
			var Serializer = new BinaryFormatter();
			try
			{
				return Serializer.Deserialize(Input) as WorldSerializer;
			}
			catch(Exception e)
			{
				return e.ToString();
			}
			
		}

		public Dictionary<Vector3, Block> getLevel()
		{
			
			return __World;
		}
	}
}
