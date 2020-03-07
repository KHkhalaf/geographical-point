using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace geographical_point.Models
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
