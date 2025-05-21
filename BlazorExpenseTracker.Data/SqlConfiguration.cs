using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data
{
    public class SqlConfiguration
    {    
        public SqlConfiguration(string connectionString) => ConnectionString = connectionString; //lambda para asignar valor
        public string ConnectionString { get; } //es una prop de solo lectura solo se asigna en el constructor su valor
    }
}
