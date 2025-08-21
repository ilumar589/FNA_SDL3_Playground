namespace GamePlayground.Engine;

public readonly ref struct WindowPtr
{
    public required nint WindowReference { get; init; }
}
