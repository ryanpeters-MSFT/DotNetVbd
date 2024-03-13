var person = new Person
{
    Name = "Ryan" // required field for compilation
};

#pragma warning disable SomethingNew

person.SomethingNew();

#pragma warning restore SomethingNew