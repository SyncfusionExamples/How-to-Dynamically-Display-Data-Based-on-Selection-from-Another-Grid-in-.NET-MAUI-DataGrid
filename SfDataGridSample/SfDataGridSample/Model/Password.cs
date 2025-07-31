using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class Password
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Value { get; set; }
        public int GroupId { get; set; }

        public Password(int id, string title, string username, string value, int groupId)
        {
            Id = id;
            Title = title;
            Username = username;
            Value = value;
            GroupId = groupId;
        }
    }

}
