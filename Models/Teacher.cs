using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;



namespace WestCoastEducationAvalonia.Models;

public class Teacher: Person //Ärver från Person...
{
    public string KnowledgeArea {get; set;} = "";
    [JsonPropertyName("_id")]
    public string? Id {get; set;}
    public  List<KnowledgeArea> KnowledgeAreas {get; set;} = new List<KnowledgeArea>();

    //Vi gör om häftet till text som sk visas i listan som exemeplvis C# eller Azure
    public string KnowledgeAreaText
    {
        get
        {
            var names = new List<string>();
            foreach (var area in KnowledgeAreas)
            {
               names.Add(area.Name);
            }
            return string.Join(", ", names);
        }
    }
    public List<Course> Courses{get; set;} = new List<Course>();
    
    public Teacher(string firstName, string lastName, string personIdentityNumber, string phoneNumber, string postalCode, string address, string city, string knowledgeArea)
    
    :base(firstName, lastName, personIdentityNumber, phoneNumber, postalCode, address, city)
    {
        KnowledgeArea = knowledgeArea;
    }

  public void AddCourse(Course course)
    {
        foreach(Course existing in Courses)
        {
            if(existing.CourseNumber == course.CourseNumber)
            {
                Console.WriteLine("Course is already assigned to this teacher");
                return;
            }
            
            
        }
            Courses.Add(course);
    }

      public void ListCourses()
    {
        foreach(Course exsisting in Courses)
        {
            Console.WriteLine(exsisting);
            
        }
    }

    public override string ToString()
    {
        return base.ToString() 
        + $"\nKnowledge area:{KnowledgeArea}";
    }

    public Teacher(){ }

}
