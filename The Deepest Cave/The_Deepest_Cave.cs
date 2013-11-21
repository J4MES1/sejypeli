using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class The_Deepest_Cave : PhysicsGame
{
    Image maa = LoadImage("maa");
    public override void Begin()
        //TODO: selvitä miksei toi toimi...
    {
        LuoHuone();
      
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
        void LuoHuone()
    {
        ColorTileMap Aloitus = ColorTileMap.FromLevelAsset("huone1");

        Aloitus.SetTileMethod(Color.Blue, pelaaja1);
        Aloitus.SetTileMethod(Color.Azure, pelaaja2);
        Aloitus.SetTileMethod(Color.Black, Luohuone1);

        Aloitus.Execute(20, 20);
    }
        void pelaaja1(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject pelaaja = new PhysicsObject(10, 10);
        pelaaja.Color = Color.Red;
        pelaaja.Position = paikka;
        Add(pelaaja);

        Keyboard.Listen(Key.A, ButtonState.Down, pelaaja.Push, null, new Vector(-1000, 0));
        Keyboard.Listen(Key.D, ButtonState.Down, pelaaja.Push, null, new Vector(1000, 0));
        Keyboard.Listen(Key.W, ButtonState.Down, pelaaja.Push, null, new Vector(0, 1000));
        Keyboard.Listen(Key.S, ButtonState.Down, pelaaja.Push, null, new Vector(0, -1000));
        Keyboard.Listen(Key.W, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.S, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.A, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.D, ButtonState.Released, pelaaja.Stop, null);
 
    }
    void pelaaja2(Vector paikka, double leveys, double korkeus)
    {
    PhysicsObject pelaaja2 = new PhysicsObject(5, 5);
    pelaaja2.Color = Color.Blue;
    pelaaja2.Position = paikka;
    Add(pelaaja2);

    Keyboard.Listen(Key.Left, ButtonState.Down, pelaaja2.Push, null, new Vector(-1000, 0));
    Keyboard.Listen(Key.Right, ButtonState.Down, pelaaja2.Push, null, new Vector(1000, 0));
    Keyboard.Listen(Key.Up, ButtonState.Down, pelaaja2.Push, null, new Vector(0, 1000));
    Keyboard.Listen(Key.Down, ButtonState.Down, pelaaja2.Push, null, new Vector(0, -1000));
    Keyboard.Listen(Key.Up, ButtonState.Released, pelaaja2.Stop, null);
    Keyboard.Listen(Key.Down, ButtonState.Released, pelaaja2.Stop, null);
    Keyboard.Listen(Key.Left, ButtonState.Released, pelaaja2.Stop, null);
    Keyboard.Listen(Key.Right, ButtonState.Released, pelaaja2.Stop, null);
 
    }
    void Luohuone1(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(leveys, korkeus);
        taso.Position = paikka;
        taso.Image = maa;
        taso.CollisionIgnoreGroup = 1;
        Add(taso);
    }
}
