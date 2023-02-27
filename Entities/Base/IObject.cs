using Microsoft.Xna.Framework;

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

        void SetPos(Vector2 pos) ;
        void SetDirection(Direction dir) ;
        
        void Draw() ; 

        void Update() ;


    }
}