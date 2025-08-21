namespace GamePlayground.Engine;

public static class EngineExtensions
{
    public static SDL3.SDL.SDL_AppResult Initialize(this Engine engine)
    {
        if (!SDL3.SDL.SDL_Init(SDL3.SDL.SDL_InitFlags.SDL_INIT_VIDEO))
        {
            SDL3.SDL.SDL_Log("Failed to initialize SDL: " + SDL3.SDL.SDL_GetError());
            return SDL3.SDL.SDL_AppResult.SDL_APP_FAILURE;
        }

        var windowReference = SDL3.SDL.SDL_CreateWindow(
            "Game Playground",
            800, 600,
            SDL3.SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP
        );

        if (windowReference == IntPtr.Zero)
        {
            SDL3.SDL.SDL_Log("Failed to create window: " + SDL3.SDL.SDL_GetError());
            SDL3.SDL.SDL_Quit();
            return SDL3.SDL.SDL_AppResult.SDL_APP_FAILURE;
        }

        engine.Window = new WindowPtr
        {
            WindowReference = windowReference
        };

        var renderer = SDL3.SDL.SDL_CreateRenderer(
            windowReference,
            string.Empty
        );

        if (renderer == IntPtr.Zero)
        {
            SDL3.SDL.SDL_Log("Failed to create renderer: " + SDL3.SDL.SDL_GetError());
            SDL3.SDL.SDL_DestroyWindow(windowReference);
            SDL3.SDL.SDL_Quit();
            return SDL3.SDL.SDL_AppResult.SDL_APP_FAILURE;
        }

        engine.Renderer = new RendererPtr
        {
            RendererReference = renderer
        };

        return SDL3.SDL.SDL_AppResult.SDL_APP_CONTINUE;
    }
}
