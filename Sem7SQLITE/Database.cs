using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Sem7SQLITE
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection ();
    }
}
