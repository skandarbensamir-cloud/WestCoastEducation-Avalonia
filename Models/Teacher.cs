using System;
using System.Collections.Generic;


namespace WestCoastEducationAvalonia.Models;

public class Teacher: Person //Ärver från Person...
{
    public string KnowledgeArea {get; set;} = "";
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
