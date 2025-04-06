Exercise 1
// a regular class called Person
public class Person
{
    public string GetName()
    {
        return "Joseph";
    }
}

// a class that inherits from Person
public class Student : Person
{
    public string GetNumber()
    {
        return "0123456789";
    }
}

// the student instance automatically has the GetName() method!
Student student = new Student();
string name = student.GetName();
Console.WriteLine(name);

Exercise 2
// a parent class called Person
public class Person
{
    private string _name;

    public Person(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
}

// a child class called Student
public class Student : Person
{
    private string _number;

    // calling the parent constructor using "base"!
    public Student(string name, string number) : base(name)
    {
      _number = number;
    }

    public string GetNumber()
    {
        return _number;
    }
}

Student student = new Student("Brigham", "234");
string name = student.GetName();
string number = student.GetNumber();
Console.WriteLine(name);
Console.WriteLine(number);

Exercise 3
public class Student : Person
{
    private string _number;

    ...

    public string GetStudentInfo()
    {
        // ERROR! This line doesn't work, because _name is private in the base class
        return _name + " " + _number;
    }
}