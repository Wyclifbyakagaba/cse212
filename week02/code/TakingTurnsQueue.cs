/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO rules). When GetNextPerson is called, the next person
/// is removed, returned, and then placed back into the queue if they still have turns left.
/// This ensures each person gets turns in a circular manner. A turns value of 0 or less
/// means the person has infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// My method to add people with a specific number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// My overload method to support adding a person without specifying turns
    /// (defaults to infinite turns)
    /// </summary>
    public void AddPerson(string name)
    {
        var person = new Person(name, 0);
        _people.Enqueue(person);
    }

    /// <summary>
    /// My method to get the next person in the queue and handle their turns
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // If turns are 0 or less, the person has infinite turns
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Reduce the number of remaining turns
            person.Turns--;

            // Only re-add the person if they still have turns left
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}