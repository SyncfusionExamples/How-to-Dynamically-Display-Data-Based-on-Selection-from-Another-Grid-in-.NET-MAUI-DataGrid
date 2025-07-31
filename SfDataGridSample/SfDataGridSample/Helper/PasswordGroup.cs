using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class PasswordGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public PasswordGroup(int id, string name)
        {
            Id = id;
            Name = name;
            IsSelected = false;
        }
    }

}
