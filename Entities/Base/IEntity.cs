using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic ; 

namespace PrototypeRPG2D.Entities {


    public enum TextureTypes {

        WalkDown,
        WalkUP,
        WalkRight,
        WalkLeft
    }


    public interface IEntity : IObject {
        double speed {get;}
        int radius {get;}
        int life {get;}
        bool isdead {get;}

        Dictionary<TextureTypes, string> Textures {get;}  

        
        void Kill() ;
        void Spawn() ; 

    }
}