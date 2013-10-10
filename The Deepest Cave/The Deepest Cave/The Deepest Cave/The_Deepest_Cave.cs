using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class The_Deepest_Cave : PhysicsGame
{
    public override void Begin()
    {

        pelaaja1();
        pelaaja2();
        reunat();

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void pelaaja1()
    {
        PhysicsObject pelaaja = new PhysicsObject(100, 100);
        pelaaja.Shape = Shape.Circle;
        pelaaja.Color = Color.Red;
        pelaaja.X = pelaaja.X + 300;
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
    void pelaaja2()
    {
    PhysicsObject pelaaja2 = new PhysicsObject(80, 80);
    pelaaja2.Shape = Shape.Circle;
    pelaaja2.Color = Color.Blue;
    pelaaja2.X = pelaaja2.X - 300;
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
    void reunat()
    {
        Level.CreateBorders();
    }

}
