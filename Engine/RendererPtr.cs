namespace GamePlayground.Engine;

public readonly ref struct RendererPtr
{
    public required nint RendererReference { get; init; }
}
