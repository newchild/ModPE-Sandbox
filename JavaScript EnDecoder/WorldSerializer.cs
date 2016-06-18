using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JavaScript_EnDecoder
{
    //does this need changing for the new LevelDB format?
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

		public void serialize(string path)
		{
			var IOStream = new FileStream(path, FileMode.Create);
			var Serializer = new BinaryFormatter();
			Serializer.Serialize(IOStream, this);
			IOStream.Close();
		}

		public static object Deserialize(string path)
		{
			WorldSerializer retVal;
			var Serializer = new BinaryFormatter();
			var IOStream = new FileStream(path, FileMode.Open);
			try
			{
				retVal = Serializer.Deserialize(IOStream) as WorldSerializer;
			}
			catch(Exception e)
			{
				return e.ToString();
			}
			IOStream.Close();
			return retVal;


		}

		public Dictionary<Vector3, Block> getLevel()
		{
			
			return __World;
		}
	}
}
