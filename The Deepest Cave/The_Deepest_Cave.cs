using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class The_Deepest_Cave : PhysicsGame
{
    Image Huone1 = LoadImage("Huone1");
    Image maa = LoadImage("maa");
    public override void Begin()
        //TODO: selvitä miksei toi toimi...
    {
        luohuone();
      
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
        void luohuone()
    {
        ColorTileMap Aloitus = ColorTileMap.FromLevelAsset("Huone1");

        Aloitus.SetTileMethod(Color.Blue, pelaaja1);
        Aloitus.SetTileMethod(Color.Azure, pelaaja2);
        Aloitus.SetTileMethod(Color.Black, Luohuone1);

        Aloitus.Execute(20, 20);
    }
        void pelaaja1(Vector Aloitus, double leveys, double korkeus)
    {
        PhysicsObject pelaaja = new PhysicsObject(100, 100);
        pelaaja.Shape = Shape.Circle;
        pelaaja.Color = Color.Red;
        pelaaja.Position = Aloitus;
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
    void pelaaja2(Vector Aloitus, double leveys, double korkeus)
    {
    PhysicsObject pelaaja2 = new PhysicsObject(80, 80);
    pelaaja2.Shape = Shape.Circle;
    pelaaja2.Color = Color.Blue;
    pelaaja2.Position = Aloitus;
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
    void Luohuone1(Vector Aloitus, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(20, 20);
        taso.Position = Aloitus;
        taso.Image = maa;
        taso.CollisionIgnoreGroup = 1;
        Add(taso);
    }
}
