using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Homework8
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            var other = (Student)obj;
            return other.Age == Age && other.FirstName == FirstName && other.LastName == LastName;
        }
    }
    
    public class Book
    {
        public int AuthorId { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Book(int authorId, string name, int price)
        {
            AuthorId = authorId;
            Name = name;
            Price = price;
        }
    }

    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void ProjectionOperatorsTest()
        {
            var textLines = new List<string>()
            {
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Yeah, hey"
            };

            var expectedWords = new List<string>() { "dangerous", "hello", "hey", "how", "it", "less", "lights", "low",
                "out", "s", "the", "with", "yeah" };

            var actualWords =
                textLines.SelectMany(
                    i => i.Split(new char[] { ' ', ',', ';', '\'', '.' }, StringSplitOptions.RemoveEmptyEntries))
                    .Select(i => i.ToLower())
                    .Distinct()
                    .OrderBy(i => i)
                    .ToList();

            Assert.That(actualWords, Is.EqualTo(expectedWords));
        }

        [Test]
        public void SortingTests()
        {
            var students = new List<Student>()
            {
                new Student("Мария", "Телятникова", 20),
                new Student("Максим", "Кузнецов", 20),
                new Student("Наталья", "Петрова", 20),
                new Student("Василий", "Кузнецов", 20),
                new Student("Иван", "Иванов", 20),
                new Student("Иван", "Иванов", 19),
            };

            var expectedSortedStudents = new List<Student>()
            {
                
                new Student("Иван", "Иванов", 20),
                new Student("Иван", "Иванов", 19),
                new Student("Василий", "Кузнецов", 20),
                new Student("Максим", "Кузнецов", 20),
                new Student("Наталья", "Петрова", 20),
                new Student("Мария", "Телятникова", 20),
            };

            var actualSortedStudents =
                students.OrderBy(student => student.LastName)
                    .ThenBy(student => student.FirstName)
                    .ThenByDescending(student => student.Age)
                    .ToList();

            Assert.That(actualSortedStudents, Is.EqualTo(expectedSortedStudents));
        }

        [Test]
        public void GroupingTest()
        {
            var text = "Each Easter Eddie eats eighty Easter eggs.";
            var expectedFrequencyDictionary = new List<Tuple<string, int>>()
            {
                Tuple.Create("easter", 2),
                Tuple.Create("each", 1), 
                Tuple.Create("eats", 1),
                Tuple.Create("eddie", 1),
                Tuple.Create("eggs", 1),
                Tuple.Create("eighty", 1),
            };

            var actualFrequencyDictionary = Regex.Split(text, @"\W+")
                .Where(word => word != "")
                .Select(word => word.ToLower())
                .GroupBy(word => word)
                .Select(group => Tuple.Create(-group.Count(), group.Key))
                .OrderBy(i => i)
                .Select(i => Tuple.Create(i.Item2, -1 * i.Item1)).ToArray();

            Assert.That(actualFrequencyDictionary, Is.EqualTo(expectedFrequencyDictionary));
        }

        [Test]
        public void ConversionsTest()
        {
            var names = new List<string>() {"Masha", "Dasha", "Pavel", "Sasha", "Denis", "Olya", "Max", "Las"};

            var expectedDictionary = new Dictionary<int, List<string>>()
            {
                {5, new List<string>(){"Dasha", "Denis", "Masha", "Pavel", "Sasha"}},
                {4, new List<string>(){"Olya"}},
                {3, new List<string>(){"Las", "Max"}}
            };

            var actualDictionary = names.GroupBy(name => name.Length)
                                        .ToDictionary(group => group.Key, group => group.ToList().OrderBy(i => i));

            Assert.That(actualDictionary, Is.EqualTo(expectedDictionary));
        }

        [Test]
        public void JoiningTest()
        {
            var authors = new List<Author>()
            {
                new Author(1, "George Martin"),
                new Author(2, "Victor Hugo"),
                new Author(3, "Margaret Mitchell"),
                new Author(4, "JK Rowling"),
                new Author(5, "John Tolkien")
            };

            var books = new List<Book>()
            {
                new Book(4, "Harry Potter and the Deathly Hallows", 500),
                new Book(5, "Hobbit", 600),
                new Book(10, "War and Peace", 700)
            };

            var expectedResult = new List<Tuple<string, string>>()
            {
                Tuple.Create("Harry Potter and the Deathly Hallows", "JK Rowling"),
                Tuple.Create("Hobbit", "John Tolkien" )
            };

            var actualResult =
                books.Join(authors, b => b.AuthorId, c => c.Id, (v, k) => Tuple.Create(v.Name, k.Name)).OrderBy(i => i).ToList();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
