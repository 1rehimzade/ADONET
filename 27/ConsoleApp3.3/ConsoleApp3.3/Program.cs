public class Employee
{
    public string Name { get; set; }
    private double _salary;

    public double Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public Employee GetPromotion()
    {
        Salary += 100;
        return this;
    }
}

public class Assistant : Employee
{
    public Assistant(string name, double salary) : base(name, salary) { }

    public void GetFeedback(bool isSuccessful)
    {
        if (isSuccessful)
        {
            GetPromotion();
        }
    }
}
