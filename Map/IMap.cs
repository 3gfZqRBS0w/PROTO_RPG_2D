using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ;


// Gestion de la caméra 
using Comora ; 

using System.Collections.Generic ;

using PrototypeRPG2D.Entities ;
using PrototypeRPG2D.Maps ; 


namespace PrototypeRPG2D.Maps {

    public struct MapSize {
        public Vector2 MinPoint {get;}
        public  Vector2 MaxPoint {get;}    

        public MapSize(Vector2 MinP, Vector2 MaxP) {
            MinPoint = MinP ;
            MaxPoint = MaxP ; 
            }    
        }
    public interface IMap {

        string name {get; set;}
        List<IObject> Entities {get; set;}
        Player player {get; set;}
        Vector2 spawnPoint {get; set;}
        MapSize mapSize {get; set;}
        Camera camera {get; set;}

        List<TileMap> tilemaps {get; set;}  


        bool Debug {get; set;}
        List<IObject> GetEntities() ;



        void LoadContent(ContentManager content) ; 
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics) ; 
        void Update(GameTime gameTime) ;

    }
}
