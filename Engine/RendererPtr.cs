namespace GamePlayground.Engine;

public readonly record struct RendererPtr
{
    public required nint RendererReference { get; init; }
}
