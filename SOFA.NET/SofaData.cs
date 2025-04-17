namespace SOFA.NET;

public class SofaData<T>
{

    public SofaData(T data, string warning = "")
    {
        Data = data;
        Warning = warning;
    }

    public SofaData()
    {
        
    }

    public T Data { get; init; } = default!;

    public string Warning { get; init; } = string.Empty;

    public bool HasWarning() => !string.IsNullOrEmpty(Warning);
}
