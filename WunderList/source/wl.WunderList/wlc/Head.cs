﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wl.body.datamodels;

namespace wlc
{
    class Head
    {
        private wl.body.Body body;

        public Head(wl.body.Body body)
        {
            this.body = body;
        }

        internal void Run(string[] args)
        {
            switch (args[0])
            {
                case "addList":
                    {
                        var listName = args[1];
                        var listId = body.AddList(listName);
                        Console.WriteLine(listId);
                    }
                    break;
                case "showLists":
                    IEnumerable<dynamic> taskLists = body.ShowLists();
                    foreach (var list in taskLists)
                    {
                        Console.WriteLine("{0} - {1} - ({2})", list.Id, list.Name, list.NumberOfTasks);
                    }
                    break;
                case "addTask":
                    {
                        var listId = args[1];
                        var taskName = args[2];
                        var taskId = body.AddTask(listId, taskName);
                        Console.WriteLine(taskId);
                    }
                    break;
                case "showTasks":
                    {
                        var listId = args[1];
                        var activityState = (ActivationStates)Enum.Parse(typeof(ActivationStates), args[2]);
                        IEnumerable<dynamic> tasks = body.ShowTasks(listId, activityState);
                        foreach (var task in tasks)
                        {
                            Console.WriteLine("{0} - {1} - Act:{2} - Imp:{3}", task.Id, task.Name, task.IsActive, task.IsImportant);
                        }
                    }
                    break;
                case "deactivateTask":
                    {
                        var taskId = args[1];
                        body.DeactivateTask(taskId);
                    }
                    break;
                case "moveTask":
                    {
                        var sourceId = args[1];
                        var destinationId = args[2];
                        body.MoveTask(sourceId, destinationId);
                    }
                    break;
                case "toggleImportance":
                    {
                        var taskId = args[1];
                        body.ToggleImportance(taskId);
                    }
                    break;
                case "activateTask":
                    {
                        var taskId = args[1];
                        body.ActivateTask(taskId);
                    }
                    break;
            }
        }
    }
}
