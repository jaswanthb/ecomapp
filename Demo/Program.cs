
Dictionary<string, int> d1 = new Dictionary<string, int>();

Dictionary<int, Customer> d2 = new Dictionary<int, Customer>();

List<KeyValuePair<int, string>> k1 = new List<KeyValuePair<int, string>>();

List<KeyValuePair<string, Customer>> k2 = new List<KeyValuePair<string, Customer>>();


List<string> l1 = new List<string>();
List<int> l2 = new List<int>();
List<Customer> l3 = new List<Customer>();

Customer c = null;

var cId = c?.CustId;


Console.WriteLine("abc");

Console.ReadLine();

class Customer
{
    public int CustId { get; set; }
    public string CustomerName { get; set; }
}