using Newtonsoft.Json;
using System.Collections.Generic;

namespace JavaScript_EnDecoder
{
	class WorldSerializer
	{
		public Dictionary<string, Block> __World;
		public List<Item> Items;
		public List<Block> customBlocks;
		public WorldSerializer(Dictionary<Vector3, Block> v1, List<Item> v2, List<Block> v3)
		{
			__World = new Dictionary<string, Block>();
            foreach (var vector in v1.Keys)
			{
				__World.Add(JsonConvert.SerializeObject(vector), v1[vector]);
			}
			
			Items = v2;
			customBlocks = v3;
		}

		public void updateWorld(Dictionary<Vector3, Block> v1, List<Item> v2, List<Block> v3)
		{
			__World = new Dictionary<string, Block>();
			foreach (var vector in v1.Keys)
			{
				__World.Add(JsonConvert.SerializeObject(vector), v1[vector]);
			};
		
			Items = v2;
			customBlocks = v3;
		}

		public string serialize()
		{
			return JsonConvert.SerializeObject(this);
		}

		public static WorldSerializer loadFromJson(string JSONString)
		{
			return JsonConvert.DeserializeObject<WorldSerializer>(JSONString);
		}

		public Dictionary<Vector3, Block> getLevel()
		{
			var retWorld = new Dictionary<Vector3, Block>();
			foreach (var vector in __World.Keys)
			{
				retWorld.Add(JsonConvert.DeserializeObject<Vector3>(vector), __World[vector]);
			}
			return retWorld;
		}
	}
}
