using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class MainMenuRepository
    {
        public void CreateDataBase(List<ITWorker> ItWorkersList, List<Team> Teams, List<Task> TasksList)
        {
            ITWorker myWorker1 = new ITWorker("Paco", "Jones", new DateTime(1990, 7, 12), 5, LevelWorker.Senior, new List<string> { "C#", "ASP.NET", "SQL" });
            ITWorker myWorker2 = new ITWorker("Elber", "Gadura", new DateTime(1998, 4, 9), 2, LevelWorker.Junior, new List<string> { "Python", "Java", "HTML" });
            ITWorker myWorker3 = new ITWorker("Rosa", "Melano", new DateTime(2000, 4, 26), 3, LevelWorker.Medium, new List<string> { "C++", "JavaScript", "php" });

            Task task1 = new Task("Task number 1", "C#", Status.ToDo);
            Task task2 = new Task("Task number 2", "Python", Status.Doing);
            Task task3 = new Task("Task number 3", "php", Status.Done);

            Team team1 = new Team("Team Paco");
            Team team2 = new Team("Team Elber");
            Team team3 = new Team("Team Rosa");

            ItWorkersList.Add(myWorker1);
            ItWorkersList.Add(myWorker2);
            ItWorkersList.Add(myWorker3);

            TasksList.Add(task1);
            TasksList.Add(task2);
            TasksList.Add(task3);

            Teams.Add(team1);
            Teams.Add(team2);
            Teams.Add(team3);
        }
    }
}
