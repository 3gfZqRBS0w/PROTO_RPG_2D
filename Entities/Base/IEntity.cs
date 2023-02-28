using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic ;


namespace PrototypeRPG2D.Entities {


    public enum TextureTypes {
        OnSite, 
        WalkDown,
        WalkUP,
        WalkRight,
        WalkLeft
    }


    public interface IEntity : IObject {
        double speed {get; set;}
        int radius {get; set;}
        int life {get; set;}
        bool isdead {get; set;}
        bool isMoving {get; set;}

        SpriteAnimation anim {get; set;}
        SpriteAnimation[] animations {get; set; }



        /* 
        On implémente pas la texture 
        */
        string IObject.texture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        Dictionary<TextureTypes, Texture2D> Textures {get;}  

        
        void Kill() ;
        void Spawn() ; 

    }
}