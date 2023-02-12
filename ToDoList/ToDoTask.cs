using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    [Serializable]
    internal class ToDoTask
    {
        private const int STRING_LENGHT = 36;
        public DateTime CreationTime { get; } = DateTime.Now;
        public DateTime NeedToDo { get; set; }

        private string _toDoData;
        public string ToDoData
        {
            get => _toDoData;
            set
            {
                int pos = STRING_LENGHT;
                _toDoData = value;
                while (pos < _toDoData.Length)
                {
                    _toDoData = _toDoData.Insert(pos, "\n");
                    pos += STRING_LENGHT;
                }
            }
        }

        public ToDoTask(string toDoData)
        {
            ToDoData = toDoData;
        }

        public override string ToString()
        {
            return $"===============Задача===============\n" +
                $"{ToDoData}\n" +
                $"Creation time: {CreationTime}\n" +
                $"Need to do by {NeedToDo.ToShortDateString()}\n\n";
        }
    }
}
