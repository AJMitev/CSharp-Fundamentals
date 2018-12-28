namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sortedPeople = new SortedSet<Person>();
            var peopleByHashSet = new HashSet<Person>();

            while (n-- > 0)
            {
                string[] args= Console.ReadLine().Split();

                Person p = new Person(args[0], int.Parse(args[1]));

                sortedPeople.Add(p);
                peopleByHashSet.Add(p);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(peopleByHashSet.Count);
        }
    }
}
