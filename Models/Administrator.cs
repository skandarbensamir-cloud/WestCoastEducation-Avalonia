using System;

namespace WestCoastEducation.Models;

public class Administrator: EducationManager
{
public Administrator(string firstName, string lastName, string personIdentityNumber, string phoneNumber, string postalCode, string address, string city, string knowledgeArea, DateTime dateOfEmployment)
:base(firstName, lastName, personIdentityNumber, phoneNumber, postalCode, address, city, knowledgeArea, dateOfEmployment)
    {
        //“Administrator har inget extra, så allt skickas vidare till EducationManager via base.”
    }
}
