using GamePlayground.Engine;

static class Program
{
    [STAThread]
    static unsafe void Main(string[] args)
    {
        new Engine().ConfigSDL();
    }


    //using (var g = new FNAGame())
    //{
    //   g.Run();
    //}
}