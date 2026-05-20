/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO rules). When GetNextPerson is called, the next person
/// is removed, returned, and then placed back into the queue if they still have turns left.
/// This allows each person to take turns in a circular way. A turns value of 0 or less
/// means the person has infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// My method to add a person with a specific number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// My overload method to allow adding a person without specifying turns.
    /// This is used in my tests and defaults the person to infinite turns.
    /// </summary>
    public void AddPerson(string name)
    {
        var person = new Person(name, 0);
        _people.Enqueue(person);
    }

    /// <summary>
    /// My method to get the next person in the queue and handle their turns logic.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // If turns are 0 or less, the person has infinite turns and is added back
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Reduce the number of remaining turns
            person.Turns--;

            // Only add the person back if they still have turns left
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    /// <summary>
    /// My method to display the queue as a string
    /// </summary>
    public override string ToString()
    {
        return _people.ToString();
    }
}