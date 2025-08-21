namespace GamePlayground.Engine;

public static class WindowPtrExtensions
{
    public static bool IsWindowSet(this WindowPtr windowPtr)
    {
        return windowPtr.WindowReference != IntPtr.Zero;
    }
}
