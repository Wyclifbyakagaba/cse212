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
    /// Add a person with a specified number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        Person person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Add a person with infinite turns.
    /// </summary>
    public void AddPerson(string name)
    {
        Person person = new Person(name, 0);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Remove and return the next person in the queue.
    /// Re-add the person if they still have turns remaining
    /// or if they have infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Infinite turns
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Reduce remaining turns
            person.Turns--;

            // Re-add only if turns remain
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    /// <summary>
    /// Return queue contents as a string.
    /// </summary>
    public override string ToString()
    {
        return _people.ToString();
    }
}