using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnittingHelp.Models
{
    [Table("ProjectSave")]
    public class ProjectDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Project_pic { get; set; }
        public string Pattern_pic { get; set; }
        public string Notes { get; set; }
        public string Pattern_url { get; set; }
        public int TimerProject { get; set; }
        public int Rows { get; set; }
    }
}
