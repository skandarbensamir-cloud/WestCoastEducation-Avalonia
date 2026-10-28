namespace WestCoastEducation.Models;

public class Address
{
public string City {get; set;}
public string Street {get; set;}
public string PostalCode {get; set;} 

//Constructor...
public Address(string city, string street, string postalCode)
    {
        City = city;
        Street = street;
        PostalCode = postalCode;
    }
}
