namespace castledice_game_data_logic.Errors;

[Serializable]
public sealed class ErrorData
{
    public ErrorType ErrorType { get; }
    public string Message { get; }

    public ErrorData(ErrorType errorType, string message)
    {
        ErrorType = errorType;
        Message = message;
    }

    private bool Equals(ErrorData other)
    {
        return ErrorType == other.ErrorType && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is ErrorData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)ErrorType, Message);
    }
}