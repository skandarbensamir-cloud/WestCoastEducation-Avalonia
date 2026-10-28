using System;
namespace WestCoastEducation.Models;

public class Student : Person //Ärver från person....
{

public Student(string firstName, string lastName, string personIdentityNumber, string phoneNumber, string postalCode, string address, string city)

:base(firstName, lastName, personIdentityNumber, phoneNumber, postalCode, address, city)
    {
        
    }
public Student(){ }
    
    
}
