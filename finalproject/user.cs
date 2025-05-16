namespace finalproject;
abstract class User
{
    public string Name { get; set; }
    protected User(string name)
    {
        Name = name;
    }
}
