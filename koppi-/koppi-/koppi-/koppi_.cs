using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class koppi_ : PhysicsGame
{
    IntMeter pistelaskuri;
    IntMeter elamalaskuri;
    int level = 1;
    int omenoitailmassa = 1;

    public override void Begin()
    {
        LuoPisteLaskuri();
        Luoelamalaskuri();
        uusiomena(level);



        Level.CreateLeftBorder();
        Level.CreateRightBorder();
        PhysicsObject pohja =
            Level.CreateBottomBorder();
        AddCollisionHandler(pohja, PutosiMaahan);

        Gravity = new Vector(0.0, -100.0);

        //Ole Hiljaa!

        IsMouseVisible = true;
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void Omenaa(PhysicsObject klikattuOmena)
    {
        klikattuOmena.Destroy();
        pistelaskuri.AddValue(100);
        omenoitailmassa = omenoitailmassa - 1;

    }

    void uusiomena(int level)
    {
        for (int i = 0; i < level; i++)
        {
            PhysicsObject omena = new PhysicsObject(50, 50);
            omena.Shape = Shape.Circle;
            omena.Color = Color.Red;
            GameObject lehti = new GameObject(20, 20);
            omena.Y = Screen.Top;
            lehti.Shape = Shape.Heart;
            lehti.Color = Color.DarkGreen;
            Add(omena);
            lehti.Y = 30;
            omena.Add(lehti);
            Mouse.ListenOn(omena, MouseButton.Left,
                ButtonState.Pressed, Omenaa,
                "Omenaa Klikattu", omena);
            Keyboard.Listen(Key.R, ButtonState.Pressed, Nollaa, "nollaa");

            omena.Hit(RandomGen.NextVector(50, 100));
            
        }
         
    }

    void LuoPisteLaskuri()
    {
        pistelaskuri = new IntMeter(0);

        Label pistenaytto = new Label();
        pistenaytto.X = Screen.Left + 100;
        pistenaytto.Y = Screen.Top - 100;
        pistenaytto.TextColor = Color.Black;
        pistenaytto.Color = Color.White;
        pistenaytto.Title = "Pisteet";

        pistenaytto.BindTo(pistelaskuri);
        Add(pistenaytto);

        
    }
    void Nollaa()
    {
        pistelaskuri.Reset();
        elamalaskuri.Reset();
    }


    void PutosiMaahan(
    PhysicsObject maa,
    PhysicsObject omena)
    {

        if (omena.Color != Color.Black)
        {
            elamalaskuri.AddValue(-1);
            omena.Color = Color.Black;
            omenoitailmassa = omenoitailmassa -1;
        }

        omena.Color = Color.Black;
    }
   void Luoelamalaskuri()
   {
       elamalaskuri = new IntMeter(3, 0, 5);

       Label elamanaytto = new Label();
       elamanaytto.BindTo(elamalaskuri);
       elamanaytto.X = Screen.Right - 50.0;
       elamanaytto.Y = Screen.Top - 50.0;
       Add(elamanaytto);
   }

}


