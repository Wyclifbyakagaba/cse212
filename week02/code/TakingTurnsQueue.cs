using System;
using System.Collections.Generic;

namespace week02;

public class TakingTurnsQueue
{
    private Queue<string> _queue = new Queue<string>();

    // Returns number of people in queue
    public int Length
    {
        get { return _queue.Count; }
    }

    // Adds a person to the queue
    public void AddPerson(string person)
    {
        _queue.Enqueue(person);
    }

    // Gets next person and moves them to the back
    public string GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        string person = _queue.Dequeue();
        _queue.Enqueue(person);

        return person;
    }
}