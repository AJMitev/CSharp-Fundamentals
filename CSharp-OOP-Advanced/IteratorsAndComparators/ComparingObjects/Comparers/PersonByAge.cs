namespace ComparingObjects.Comparers
{
    using System.Collections.Generic;

    public class PersonByAge : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}