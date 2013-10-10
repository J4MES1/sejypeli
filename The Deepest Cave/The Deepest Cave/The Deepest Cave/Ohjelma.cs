using System;

static class Ohjelma
{
#if WINDOWS || XBOX
    static void Main(string[] args)
    {
        using (The_Deepest_Cave game = new The_Deepest_Cave())
        {
#if !DEBUG
            game.IsFullScreen = true;
#endif
            game.Run();
        }
    }
#endif
}
