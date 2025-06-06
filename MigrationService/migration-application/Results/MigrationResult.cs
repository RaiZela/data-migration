using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Results;

public class MigrationResult
{
    public string EntityType { get; set; }     
    public string InputData { get; set; }        
    public bool Success { get; set; }           
    public string ErrorMessage { get; set; }      
}
