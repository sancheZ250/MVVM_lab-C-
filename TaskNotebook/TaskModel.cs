namespace TaskNotebook
{
    public class TaskModel
    {
        public string Name { get; set; }

        public TaskModel(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name; // Позволяет корректно отображать имя задачи в ListBox
        }
    }
}
