using System.Collections.Generic ;
using PrototypeRPG2D.Entities ;


namespace PROTO_RPG_2D.Map {
    public class Map {
        public string name ;
        public List<IObject> Entities ;

         public Map() {
            Entities = new() ;
         }

         public virtual void Initialize() {

         }
    }
}