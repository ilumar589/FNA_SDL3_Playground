namespace GamePlayground.Engine;

public readonly record struct WindowPtr
{
    public required nint WindowReference { get; init; }
}
