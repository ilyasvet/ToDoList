using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    static internal class DataListCommand
    {
        public static List<ToDoTask> ToDos = new List<ToDoTask>();
        public static void ShowToDoList()
        {
            for (int i = 0; i < ToDos.Count; i++)
            {
                Console.WriteLine($"{i+1} " + ToDos[i]);
            }
        }
        public static void AddToDoTask(string toDoDataTask)
        {
            ToDos.Add(new ToDoTask(toDoDataTask));
        }
        public static void SetEndTime(int taskNumber, DateTime endTime)
        {
            ToDos[taskNumber - 1].NeedToDo = endTime;
        }
        public static void DeleteTask(int taskNumber)
        {
            ToDos.RemoveAt(taskNumber - 1);
        }
    }
}
