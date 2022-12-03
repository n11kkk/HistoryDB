using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    [Table("CalculatorHistory")]
    public class HistoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Expr { get; set; }
    }
}
