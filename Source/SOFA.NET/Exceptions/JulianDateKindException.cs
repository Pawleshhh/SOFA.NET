using System.Runtime.Serialization;

namespace SOFA.NET;

public class JulianDateKindException : Exception
{

    public JulianDateKind? Expected { get; init; }
    public JulianDateKind? Actual { get; init; }

    public JulianDateKindException()
    {
    }

    public JulianDateKindException(JulianDateKind expected)
        : base(CreateMessage(expected))
    {
        Expected = expected;
    }

    public JulianDateKindException(JulianDateKind expected, JulianDateKind actual)
        : base(CreateMessage(expected, actual))
    {
        Expected = expected;
        Actual = actual;
    }

    public JulianDateKindException(string? message) : base(message)
    {
    }

    public JulianDateKindException(string? message, JulianDateKind expected) : base(message)
    {
        Expected = expected;
    }

    public JulianDateKindException(string? message, JulianDateKind expected, JulianDateKind actual) : base(message)
    {
        Expected = expected;
        Actual = actual;
    }

    public JulianDateKindException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public JulianDateKindException(string? message, JulianDateKind expected, Exception? innerException) : base(message, innerException)
    {
        Expected = expected;
    }

    public JulianDateKindException(string? message, JulianDateKind expected, JulianDateKind actual, Exception? innerException) : base(message, innerException)
    {
        Expected = expected;
        Actual = actual;
    }

    protected JulianDateKindException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    private static string CreateMessage(JulianDateKind expected)
    {
        return $"Unexpected Julian Date Kind. Expected {expected} value";
    }

    private static string CreateMessage(JulianDateKind expected, JulianDateKind actual)
    {
        return $"Unexpected Julian Date Kind. Expected {expected} value but got {actual} value";
    }

}
