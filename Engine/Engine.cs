namespace GamePlayground.Engine;

public sealed record Engine
{
    public WindowPtr Window { get; set; }
    public RendererPtr Renderer { get; set; }
}
