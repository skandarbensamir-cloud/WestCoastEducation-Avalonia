using System;

namespace WestCoastEducation.Models;

public class EducationManager:Teacher//Ärver från teacher...
{
 public DateTime DateOfEmployment{get; set;}
 public EducationManager(string firstName, string lastName, string personIdentityNumber, string phoneNumber, string postalCode, string address, string city, string knowledgeArea, DateTime dateOfEmployment)
 :base(firstName, lastName, personIdentityNumber, phoneNumber, postalCode, address, city, knowledgeArea)
    {
        DateOfEmployment = dateOfEmployment;
    }

    public override string ToString()
    {
        return base.ToString()
        +$"\nDate of employment:{DateOfEmployment}";
    }
    
}
