using System;
using System.Security.Cryptography.X509Certificates;
namespace WestCoastEducation.Models;

public class Person
{
//Properties
public string? FirstName {get; set;}
public string? LastName {get; set;}
public string? PersonIdentityNumber {get; set;}
public string? PhoneNumber {get; set;}
public Address? Address {get; set;} 


//Our Person Constructor.....
public Person(string firstName, string lastName, string personIdentityNumber, string phoneNumber, string postalCode, string address, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        PersonIdentityNumber = personIdentityNumber;
        PhoneNumber = phoneNumber;
        Address = new Address(city, address, postalCode);
        
    }
    public Person(){ }

    public override string ToString()
    {
        return $"Name:{FirstName}\nLastname:{LastName}\nContact information: {PhoneNumber}";
        
    }

}
