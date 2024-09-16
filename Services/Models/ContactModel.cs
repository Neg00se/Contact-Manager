namespace Services.Models;
public class ContactModel
{
    public string Name { get; set; }

    public DateOnly Dob { get; set; }

    public bool Married { get; set; }

    public string Phone { get; set; }

    public decimal Salary { get; set; }
}
