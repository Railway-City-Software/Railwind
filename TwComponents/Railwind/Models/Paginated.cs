namespace Railwind.Models;

public class Paginated<T>
{
    public T Data { get; set; }
    public int PageNumber { get; set; }
}