using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CoreServer
{
    public sealed class GlobalObject
    {
        private static readonly Lazy<GlobalObject>
            lazy = new Lazy<GlobalObject>(() => new GlobalObject());

        public static GlobalObject Instance { get { return lazy.Value; } }

        public Dictionary<string, object> fileIndex = new Dictionary<string, object>();
        private GlobalObject()
        {

        }
    }
}
