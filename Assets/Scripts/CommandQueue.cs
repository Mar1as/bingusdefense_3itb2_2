using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue
{
    private static CommandQueue instance = new CommandQueue();

    public static CommandQueue Instance => instance;

    Queue<Command> queue = new Queue<Command>();

    public BuildingData building;

    private CommandQueue() { }

    public void EnqueueCommand(Command newCommand) { 
        queue.Enqueue(newCommand);
    }

    public void ExecuteNext()
    {
        if (queue.Count > 0)
        {
            var cmd = queue.Dequeue();
            cmd.Execute();
        }
    }
}
