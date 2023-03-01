using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 
using System.Collections.Generic ;

using PrototypeRPG2D.Entities ;
using PrototypeRPG2D.Maps ; 


namespace PrototypeRPG2D.Maps {

    struct MapSize {
        Vector2 MinPoint {get;}
        Vector2 MaxPoint {get;}    
        
        }
    public interface IMap {

        string name {get; set;}
        List<IObject> allEntities {get; set;}
        Texture2D background {get; set;}
        Player player {get; set;}
        Vector2 spawnPoint {get; set;}
        MapSize mapSize ;

        List<IObject> GetEntities() ;


    }
}
