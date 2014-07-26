using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHD.Content.Level
{

    public interface ILevelScript
    {

        Data.Root GetData();

        Data.Object GetObject(string UID);

    }

}
