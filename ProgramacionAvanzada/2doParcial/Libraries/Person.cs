namespace PA17F.shared;
using System.Xml.Serialization;

public class Person
{
   // Members

   public Person()
   {

   }
   public Person (decimal initialSalary)
   {
      Salary = initialSalary;
   }


   [XmlAttribute("fname")]
   public string? Name;
   [XmlAttribute("dob")]
   public DateTime DateOfBirth;
   protected decimal Salary {get;set;}
   [XmlAttribute("lname")]
   public string? LastName{get;set;}
   public HashSet<Person>? Children {get; set;}
}
