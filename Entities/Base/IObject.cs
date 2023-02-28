using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content ; 
using System.Collections.Generic ;

namespace PrototypeRPG2D.Entities {


    // Direction

    public enum Direction {
        Up,
        Left,
        Down, 
        Right
    }


    public interface IObject {

        Vector2 position {get; set;}  
        Direction direction {get; set; }
        
        string texture {get; set;}

        void SetPos(Vector2 pos) ;
        void SetDirection(Direction dir) ;

        void LoadContent(ContentManager content) ; 
        void Draw(SpriteBatch spriteBatch) ; 

        void Update(GameTime gameTime) ;


    }
}