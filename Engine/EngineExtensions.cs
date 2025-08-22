namespace GamePlayground.Engine;

public static class EngineExtensions
{

    public static unsafe void ConfigSDL(this Engine engine)
    {
        void sdl_AppQuit_Func(nint appstate, SDL3.SDL.SDL_AppResult result)
        {
            // Your cleanup code here
            Console.WriteLine("SDL AppQuit called!");
        }

        SDL3.SDL.SDL_AppResult sdl_AppIterate_Func(nint appstate)
        {
            // Your iteration code here
            Console.WriteLine("SDL AppIterate called!");
            return SDL3.SDL.SDL_AppResult.SDL_APP_CONTINUE;
        }

        SDL3.SDL.SDL_AppResult sdl_AppEvent_Func(nint appstate, SDL3.SDL.SDL_Event* eventPtr)
        {
            if (eventPtr->type == (uint)SDL3.SDL.SDL_EventType.SDL_EVENT_QUIT)
            {
                Console.WriteLine("SDL Quit event received!");
                return SDL3.SDL.SDL_AppResult.SDL_APP_SUCCESS;
            }

            return SDL3.SDL.SDL_AppResult.SDL_APP_CONTINUE;
        }

        SDL3.SDL.SDL_AppResult sDL_AppInit_Func(nint appstate, int argc, nint argv)
        {
            var initResult = engine
                .Initialize();
            //TODO add next steps

            return initResult;
        }

        var result = SDL3.SDL.SDL_EnterAppMainCallbacks(0, 0, sDL_AppInit_Func, sdl_AppIterate_Func, sdl_AppEvent_Func, sdl_AppQuit_Func);
    }

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
