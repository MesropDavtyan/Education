using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventOrganizer
{
    public class Solution
    {
        bool isTriggered = false;
        List<Task> taskList = new List<Task>();

        object obj1 = new object();
        object obj2 = new object();

        public void SubmitTask(Task task)
        {
            lock (obj1)
            {
                if (isTriggered)
                {
                    task.Start();
                }
                else
                {
                    taskList.Add(task);
                }
            }
        }

        public void Trigger()
        {
            lock (obj2)
            {
                isTriggered = true;
                foreach (var task in taskList)
                {
                    task.Start();
                }
            }
        }
    }
}
