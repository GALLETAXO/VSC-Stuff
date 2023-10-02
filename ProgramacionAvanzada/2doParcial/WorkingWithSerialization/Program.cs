using System.Xml.Serialization; // XmlSerializer
using PA17F.shared;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory; 

List<Person> people = new()
{
    new(3000M)
    {
        Name = "Isaac",
        LastName = "Chavez",
        DateOfBirth = new (year: 2005, month: 03, day: 2)
    },

    new(4000M)
    {
        Name = "Carolina",
        LastName = "Prian",
        DateOfBirth = new(year: 2006, month: 05, day: 14)

    },

    new(2000M)
    {
        Name = "Samantha",
        LastName = "Valadez",
        DateOfBirth = new(year: 2006, month: 05, day: 14)

    },

    new(8000M)
    {
        Name = "Juan",
        LastName = "Torres",
        DateOfBirth = new(year: 2001, month: 03, day: 25),
        Children = new()
        {
            new(0M)
            {
                Name = "Juanito",
                LastName = "Cholico",
                DateOfBirth = new(year: 2023, month: 10, day: 1)

            },
            
            new(0M)
            {
                Name = "Tamara",
                LastName = "Cholico",
                DateOfBirth = new(year: 2021, month: 9, day: 2)

            },
        }

    },

    
};



// the xml serializer NEEDS to Know what 

XmlSerializer xs = new (type:people.GetType());

string path = Combine(CurremtDirectory, "people.xml");

using(FileStream stream = File.Create(path))
{
    // serialize the object
    xs.serialize(stream,people);
}

WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
WriteLine();
WriteLine(File.ReadAllText(path));

WriteLine();
using (FileStream xmlLoad = File.open(path,FileMode.Open))
{
    //deserialize
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine($"{p.Name} has {p.Children?.Count} children.");
        }



    }
}

