using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 

using System.Collections.Generic ;
using PrototypeRPG2D.Entities ;
using PrototypeRPG2D.Maps ;


namespace PrototypeRPG2D.Maps {
    public class Map : IMap {
        public string name {get;set;}
        public List<IObject> allEntities {get; set;}
        public Texture2D background {get; set;}

        public Vector2 spawnPoint {get; set;}
        public Player player {get; set;}

         public Map(string name, Player player, List<IObject> allEntities, Texture2D background) {

            this.name = name ;
            this.allEntities = allEntities ;
            this.background = background ;

         }



        public List<IObject> GetEntities()
        {
            return allEntities ; 
        }
    }
}