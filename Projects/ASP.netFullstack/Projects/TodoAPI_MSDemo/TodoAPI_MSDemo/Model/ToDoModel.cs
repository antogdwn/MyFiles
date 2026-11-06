namespace TodoAPI_MSDemo.Model
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }

    }
}
