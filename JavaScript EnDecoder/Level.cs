using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JavaScript_EnDecoder
{
    class Level
    {
        private Dictionary<Vector3,Block> LevelDesign = new Dictionary<Vector3,Block>();
        public Level()
        {
            
        }
        public void setTile(int x, int y, int z, int ID)
        {
            var vec = (from vector in LevelDesign.Keys where vector.x == x && vector.y == y && vector.z == z select vector).FirstOrDefault();
            if (vec == null)
            {
                LevelDesign.Add(new Vector3(x, y, z), new Block(ID, 0));
                StaticUtils.log("Set Block of ID " + ID + " at position " + x + ", " + y + ", " + z);
                return;
            }
            else
            {
                LevelDesign[vec].ID = ID;
                LevelDesign[vec].Data = 0;
                StaticUtils.log("Set Block of ID " + ID + " at position " + x + ", " + y + ", " + z);
                return;
            }
            
        }
        public int getTile(int x, int y, int z)
        {
            
            var vec = (from vector in LevelDesign.Keys where vector.x == x && vector.y == y && vector.z == z select vector).FirstOrDefault();
            if(vec == null){
                LevelDesign.Add(new Vector3(x, y, z),new Block(0, 0));
                StaticUtils.log("Got Block of ID 0 at position " + x + ", " + y + ", " + z);
                return 0;
            }
            StaticUtils.log("Got Block of ID " + LevelDesign[vec].ID + " at position " + x + ", " + y + ", " + z);
            
            return LevelDesign[vec].ID;
        }
        public int getData(int x, int y, int z)
        {
            
            var vec = (from vector in LevelDesign.Keys where vector.x == x && vector.y == y && vector.z == z select vector).FirstOrDefault();
            if (vec == null)
            {
                LevelDesign.Add(new Vector3(x, y, z), new Block(0, 0));
                StaticUtils.log("Got Data of Block 0 at position " + x + ", " + y + ", " + z + ". Id is 0");
                
                return 0;

            }
            StaticUtils.log("Got Data of Block " + LevelDesign[vec].ID + " at position " + x + ", " + y + ", " + z + ". Id is " + LevelDesign[vec].Data);
            
            return LevelDesign[vec].Data;
            
        }

    }
}
