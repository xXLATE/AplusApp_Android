using System;
using System.Collections.Generic;
using System.Text;

namespace App5XamarinMob.db
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}