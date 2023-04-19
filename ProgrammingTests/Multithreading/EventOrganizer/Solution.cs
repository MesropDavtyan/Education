using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventOrganizer
{
    public class Solution
    {
        bool isTriggered = false;
        List<Task> taskList = new List<Task>();

        object locker = new object();

        public void SubmitTask(Task task)
        {
            lock (locker)
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
            lock (locker)
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
