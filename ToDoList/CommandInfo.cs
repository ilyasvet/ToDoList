using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal abstract class CommandInfo
    {
        public abstract void Execute(List<string> _params);
    }
    class ShowCommand : CommandInfo
    {
        public override void Execute(List<string> _params)
        {
            DataListCommand.ShowToDoList();
        }
    }
    class DeleteCommand : CommandInfo
    {
        public override void Execute(List<string> _params)
        {
            DataListCommand.DeleteTask(int.Parse(_params[0]));
        }
    }
    class AddCommand : CommandInfo
    {
        public override void Execute(List<string> _params)
        {
            DataListCommand.AddToDoTask(_params[0]);
        }
    }
    class SetCommand : CommandInfo
    {
        public override void Execute(List<string> _params)
        {
            string[] numbers = _params[1].Split('.');
            int day = int.Parse(numbers[0]);
            int mounth = int.Parse(numbers[1]);
            int year = int.Parse(numbers[2]);
            DateTime dateTime = new DateTime(year, mounth, day);
            DataListCommand.SetEndTime(int.Parse(_params[0]), dateTime);
        }
    }
}
