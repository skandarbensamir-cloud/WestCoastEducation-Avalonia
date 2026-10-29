using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using WestCoastEducationAvalonia.Enums;
namespace WestCoastEducationAvalonia.Models;


public class Course
{
//RestDb ger varje kurs ett unikt id i fältet "_id".
//Det behövs för att kunna radera och uppdatera rätt kurs.
[JsonPropertyName("_id")]
//Properties...
public string CourseNumber{get; set;}
public int Length {get; set;}
public string CourseTitle{get; set;}
public DateTime StartDate {get; set;}
public DateTime EndDate {get; set;}
public CourseType CourseType{get; set;} //Denna property refererar till vår enum...
 
//Constructor ...
public Course(string courseTitle, int length, DateTime startDate, DateTime endDate, CourseType courseType, string courseNumber)
    {
        CourseTitle = courseTitle;
        Length = length;
        StartDate = startDate;
        EndDate = endDate;
        CourseType = courseType; 
        CourseNumber = courseNumber;
    }

    public override string ToString()
    {
        return $"CourseNumber: {CourseNumber}\nCourse: {CourseTitle}\nRemote or on-site: {CourseType}";
    }

    public List<Student> Students {get; set;} = new List<Student>();

    public Teacher? Teacher{get; set;}
    public void AddStudent(Student student)
    {
        foreach(Student existing in Students)
        {
           if(existing.PersonIdentityNumber == student.PersonIdentityNumber)
            {
                Console.WriteLine("Student is already registered in this course");
                return;
            }
            
        }
            
        
        
     Students.Add(student);
    }

    public void ListStudents()
    {
        foreach(Student exsisting in Students)
        {
            Console.WriteLine(exsisting);
            
        }
    }

    


    
}

