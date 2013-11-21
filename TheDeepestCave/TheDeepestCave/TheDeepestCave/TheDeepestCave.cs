using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class TheDeepestCave : PhysicsGame
{
    PlasmaCannon pelaajan1ase;
    PhysicsObject pelaaja;
    PhysicsObject ammus;
    private Image[] jelokavelee = LoadImages("jelo1", "jelo2");
    PhysicsObject vihu;
    IntMeter elamat;

    Image taustakuva = LoadImage("tausta");
    Image reunat1 = LoadImage("maa");
    Image jelo = LoadImage("jelo");
    Image Joel = LoadImage("joel");

    public override void Begin()
    {
        Level.Background.Image = taustakuva;
        Level.Background.TileToLevel();
        LuoHuone();
        tykki();
        tormays();
        Viholliset();


        
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void LuoHuone()
    {
        Camera.ZoomToLevel(2.5);
        ColorTileMap Aloitus = ColorTileMap.FromLevelAsset("huone1");

        Aloitus.SetTileMethod(Color.Violet, pelaaja1);
        //Aloitus.SetTileMethod(Color.Azure, pelaaja2);
        Aloitus.SetTileMethod(Color.Black, reunat);

        Aloitus.Execute(35, 28);
    }
    void pelaaja1(Vector paikka, double leveys, double korkeus)
    {
        pelaaja = new PhysicsObject(60, 60);
        pelaaja.Image = jelo;
        pelaaja.Position = paikka;
        pelaaja.CanRotate = false;
        pelaaja.Restitution = 0.0;
        pelaaja.IgnoresPhysicsLogics = true;
        pelaaja.Animation = new Animation(jelokavelee);
        pelaaja.Animation.Start();
        pelaaja.Animation.FPS = 3;


        Add(pelaaja);

        Keyboard.Listen(Key.A, ButtonState.Down, liikutapelaajaa, null, new Vector(-400, 0));
        Keyboard.Listen(Key.D, ButtonState.Down, liikutapelaajaa, null, new Vector(400, 0));
        Keyboard.Listen(Key.W, ButtonState.Down, liikutapelaajaa, null, new Vector(0, 400));
        Keyboard.Listen(Key.S, ButtonState.Down, liikutapelaajaa, null, new Vector(0, -400));
        Keyboard.Listen(Key.W, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.S, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.D, ButtonState.Released, pelaaja.Stop, null);
        Keyboard.Listen(Key.A, ButtonState.Released, pelaaja.Stop, null);
    }   
  
    
    //void pelaaja2(Vector paikka, double leveys, double korkeus)
    //{
    //PhysicsObject pelaaja2 = new PhysicsObject(70, 70);
    //pelaaja2.Image = Joel;
    //pelaaja2.CanRotate = false;
    //pelaaja2.Restitution = 0.0;
    //pelaaja2.Position = paikka;
    //Add(pelaaja2);

    //Keyboard.Listen(Key.Left, ButtonState.Down, pelaaja2.Push, null, new Vector(-400, 0));
    //Keyboard.Listen(Key.Right, ButtonState.Down, pelaaja2.Push, null, new Vector(400, 0));
    //Keyboard.Listen(Key.Up, ButtonState.Down, pelaaja2.Push, null, new Vector(0, 400));
    //Keyboard.Listen(Key.Down, ButtonState.Down, pelaaja2.Push, null, new Vector(0, -400));
    //Keyboard.Listen(Key.Up, ButtonState.Released, pelaaja2.Stop, null);
    //Keyboard.Listen(Key.Down, ButtonState.Released, pelaaja2.Stop, null);
    //Keyboard.Listen(Key.Left, ButtonState.Released, pelaaja2.Stop, null);
    //Keyboard.Listen(Key.Right, ButtonState.Released, pelaaja2.Stop, null);

    // }
    void liikutapelaajaa(Vector liike)
    {
        pelaaja.Push(liike);
    }
    void reunat(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject reunat = PhysicsObject.CreateStaticObject(leveys, korkeus);
        reunat.Position = paikka;
        reunat.Image = reunat1;
        reunat.CollisionIgnoreGroup = 1;
        Add(reunat);
    }
    void elamat1()
    {
        elamat = new IntMeter(3);
        elamat.Value = 3;
        AddCollisionHandler(ammus, vihu, CollisionHandler.AddMeterValue(elamat, -1));
        elamat.MinValue = 0;
        elamat.LowerLimit += vihollisenelamat;
        

    }
     void vihollisenelamat()
    {
        //elamalaskuri = new IntMeter(vihunterveys);

        //AddCollisionHandler(ammus, "vihu", CollisionHandler.AddMeterValue(elamalaskuri, -1));


       // vihunterveys--;
        //if (vihunterveys <= 0)
            vihu.Destroy();
    }
    void tykki()
    {
        pelaajan1ase = new PlasmaCannon(20, 5);

        pelaajan1ase.InfiniteAmmo = true;
        pelaajan1ase.ProjectileCollision = Ammusosui;
        ammus = pelaajan1ase.Shoot();


        pelaaja.Add(pelaajan1ase);
        if (ammus != null)
        {
            ammus.Size *= 3;
        }

        Mouse.ListenMovement(0.1, tahtaa, "tähtää");
        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Ammuaseella, "ammu", pelaaja);
        Add(pelaajan1ase);
    }
    void tahtaa(AnalogState hiirenliike)
    {
        Vector suunta = (Mouse.PositionOnWorld - pelaaja.AbsolutePosition).Normalize();
        pelaajan1ase.Angle = suunta.Angle;
    }
    void Ammusosui(PhysicsObject ammus, PhysicsObject vihu)
    {
        ammus.Destroy();
    }
    void Ammuaseella(PhysicsObject pelaaja)
    {
        PhysicsObject ammus = pelaajan1ase.Shoot();
        if (ammus != null)
        {
            ammus.Size *= 3;
        }
    }

    void tormays()
    {
        //AddCollisionHandler(ammus, vihu, kuolema);
    }
    
    void Viholliset()
    {
        vihu = new PhysicsObject(50, 50);
        vihu.Shape = Shape.Circle;
        vihu.X = RandomGen.NextInt(-300, 300);
        vihu.Y = RandomGen.NextInt(-300, 300);

        Add(vihu);


    }
   // void kuolema(PhysicsObject ammus, PhysicsObject vihu)
    //{//}
    //class vihollinen : PhysicsObject
    //{
    //  private IntMeter elamalaskuri = new IntMeter(3, 0, 3);
    //public IntMeter Elamalaskuri { get { return elamalaskuri; } }

    //public vihollinen(double leveys, double korkeus)
    //  : base(leveys, korkeus)
    //{
    //  elamalaskuri.LowerLimit += delegate { this.Destroy(); };
    //}
    //}
}
