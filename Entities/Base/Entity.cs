using Microsoft.Xna.Framework ; 

namespace PrototypeRPG2D.Entities {
    public class Entity : IEntity {


        public Vector2 position {get; set;}
        public Direction direction {get; set;}
        public double speed {get; set;}

        public  int radius {get; set;}
        public int life {get; set;}
        public bool isdead {get; set;}

        public virtual void SetPos(Vector2 dest) {
            position = dest ; 
        }

        public virtual void SetDirection(Direction nouvelleDestination) {
            direction = nouvelleDestination ; 
        }

        public virtual void Kill() {

            isdead = true ; 
        }

        public virtual void Spawn() {
            isdead = false ;
        }


        public virtual void Draw() {

        }

        public virtual void Update() {
            
        }
    }
}

