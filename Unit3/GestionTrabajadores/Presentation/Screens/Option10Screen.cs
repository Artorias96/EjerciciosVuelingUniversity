using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option10Screen
    {
        public void Start(List<Task> TasksList, List<ITWorker> ItWorkersList)
        {
            Console.Clear();
            Console.WriteLine("What task you want to assign?: (Select the number of task)");

            foreach (var item in TasksList.Where(e => e.assigned == false))
            {
                Console.WriteLine($"Task:{item.IdTask} \n" +
                    $"Task description: {item.Description}\n");
            }

            var answerTask = Convert.ToInt32(Console.ReadLine());

            if (answerTask == 0)
            {
                Console.WriteLine("You need to choose the number of the task");

            }

            Task taskValue = TasksList.FirstOrDefault(e => e.IdTask == answerTask);



            Console.WriteLine("Select the ID of the worker: ");

            foreach (var item in ItWorkersList)
            {
                Console.WriteLine($"ID Worker:{item.ItWorkerId} \n" +
                    $"Worker name: {item.Name}\n");
            }

            var answerWor = Convert.ToInt32(Console.ReadLine());

            if (answerWor == 0)
            {
                Console.WriteLine("Error, Choose Id number of worker");
            }

            ITWorker workerVal = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWor);

            taskValue.Worker = workerVal;

            workerVal.TaskWorker = taskValue;

            taskValue.assigned = true;


            if (taskValue.StatusTask != Status.Done && workerVal.TechKnowledges.Contains(taskValue.Technology))
            {


                Console.WriteLine($"---------- Task Description Selected ----------");

                taskValue.ShowValues();

                Console.WriteLine("---------- Worker Description of task assigned ----------");

                workerVal.ShowValues();

            }
            else Console.WriteLine("The worker need to Know the tech of the task, and the task cant be in State Done");
        }
    }
}
