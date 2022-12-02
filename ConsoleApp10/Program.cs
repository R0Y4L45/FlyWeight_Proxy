public interface OfficeInternetAccess
{
    public void grantInternetAccess();
}


public class RealInternetAccess : OfficeInternetAccess
{
    private string employeeName;
    public RealInternetAccess(String empName)
    {
        employeeName = empName;
    }
    public void grantInternetAccess()
    {
        Console.WriteLine("Internet Access granted for employee: "+ employeeName);
    }
}


public class ProxyInternetAccess : OfficeInternetAccess
{
    private string employeeName;
    private RealInternetAccess realaccess;
    public ProxyInternetAccess(string employeeName)
    {
        employeeName = employeeName;
    }
    public void grantInternetAccess()
    {
        if (getRole(employeeName) > 4)
        {
            realaccess = new RealInternetAccess(employeeName);
            realaccess.grantInternetAccess();
        }
        else
        {
            Console.WriteLine("No Internet access granted. Your job level is below 5");
        }
    }
    public int getRole(string emplName)
    {
        // Check role from the database based on Name and designation  
        // return job level or job designation.  
        return 9;
    }
}



public class ProxyPatternClient
{
    public static void Main()
    {
        OfficeInternetAccess access = new ProxyInternetAccess("Aslan Akbey");
        access.grantInternetAccess();
    }
}
