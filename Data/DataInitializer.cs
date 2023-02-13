using ToDoList.Models;

namespace ToDoList.Data
{
    public class DataInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            if(context.ToDoLists.Any())
                return;
            
            var dumyToDo = new List<ToDoCard>
            {
                new ToDoCard
                {
                    Name = "wake up",
                    Discription = "if u dont get out of bed u won't be able to do anything",
                    Created = DateTime.Now
                },
                new ToDoCard
                {
                    Name = "wash ur face",
                    Discription = "ur ugly, at least wash ur face so u won't look uglyer",
                    Created = DateTime.Now
                },
                new ToDoCard
                {
                    Name = "eat something",
                    Discription = "I dont know about u but generally humans need to eat",
                    Created =DateTime.Now
                }
            };

            foreach(var dumy in dumyToDo)
                context.ToDoLists.Add(dumy);

            context.SaveChangesAsync();
        }
    }
}