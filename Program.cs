using GamePlayground.Engine;

static class Program
{
    [STAThread]
    static unsafe void Main(string[] args)
    {
        static void sdl_AppQuit_Func(nint appstate, SDL3.SDL.SDL_AppResult result)
        {
            // Your cleanup code here
            Console.WriteLine("SDL AppQuit called!");
        }

        static SDL3.SDL.SDL_AppResult sdl_AppIterate_Func(nint appstate)
        {
            // Your iteration code here
            Console.WriteLine("SDL AppIterate called!");
            return SDL3.SDL.SDL_AppResult.SDL_APP_CONTINUE;
        }

        static SDL3.SDL.SDL_AppResult sdl_AppEvent_Func(nint appstate, SDL3.SDL.SDL_Event* eventPtr)
        {
            if (eventPtr->type == (uint)SDL3.SDL.SDL_EventType.SDL_EVENT_QUIT)
            {
                Console.WriteLine("SDL Quit event received!");
                return SDL3.SDL.SDL_AppResult.SDL_APP_SUCCESS;
            }

            return SDL3.SDL.SDL_AppResult.SDL_APP_CONTINUE;
        }

        static SDL3.SDL.SDL_AppResult sDL_AppInit_Func(nint appstate, int argc, nint argv)
        {
            var initResult = new Engine().Initialize();

            return initResult;
        }

        var result = SDL3.SDL.SDL_EnterAppMainCallbacks(0, 0, sDL_AppInit_Func, sdl_AppIterate_Func, sdl_AppEvent_Func, sdl_AppQuit_Func);

        Console.WriteLine($"SDL App Result: {result}");
    }


    //using (var g = new FNAGame())
    //{
    //   g.Run();
    //}
}