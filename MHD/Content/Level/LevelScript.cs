using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHD.Content.Level
{

    public interface LevelScript
    {

        Root GetData();
      
        Gameplay.Objects.GameObject GetObject(string UID);

    }

}
