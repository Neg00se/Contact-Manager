namespace Data.Entities;

public class Contact
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateOnly Dob { get; set; }

    public bool Married { get; set; }

    public string Phone { get; set; }

    public decimal Salary { get; set; }
}
