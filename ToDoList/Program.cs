using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Program
    {
        static void Main()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream fs = new FileStream("ToDoDataList.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    DataListCommand.ToDos = formatter.Deserialize(fs) as List<ToDoTask>;
                }
                catch
                {
                    Console.WriteLine("Тут пока пусто");
                }
            }

            Dictionary<string, CommandInfo> commandsDictionary = new Dictionary<string, CommandInfo>();
            commandsDictionary.Add("show", new ShowCommand());
            commandsDictionary.Add("delete", new DeleteCommand());
            commandsDictionary.Add("set", new SetCommand());
            commandsDictionary.Add("add", new AddCommand());

            while (true)
            {
                string command = Console.ReadLine();
                if(command == "exit")
                {
                    break;
                }
                List<string> args = command.Split('|').ToList();
                string commandWord = args[0].ToLower();
                args.RemoveAt(0);
                try
                {
                    commandsDictionary[commandWord].Execute(args);
                }
                catch
                {
                    Console.WriteLine("Команда введена неверно");
                }
            }
            using (Stream fs = new FileStream("ToDoDataList.bin", FileMode.Create, FileAccess.Write))
            {
                try
                {
                    formatter.Serialize(fs, DataListCommand.ToDos);
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так");
                }
            }
        }
    }
}
