using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
    class Pointer : SpriteNode
    {
        // your private fields here (add Velocity, Acceleration, and MaxSpeed)
        Vector2 velocity = new Vector2 (5, 5);
        Vector2 acceleration = new Vector2 (0,0);

        // constructor + call base constructor
        public Pointer() : base("resources/spaceship.png")
        {
            Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
            Color = Color.YELLOW;
        }

        // Update is called every frame
        public override void Update(float deltaTime)
        {
            PointToMouse(deltaTime);
            BounceEdges();
        }

        // your own private methods
        private void PointToMouse(float deltaTime)
        {
            // Or just implement it in Example 110 Follower

            Vector2 mouse = Raylib.GetMousePosition();
            // Console.WriteLine(mouse);

            Vector2 v = mouse - Position; 

            Vector2 nv = Vector2.Normalize(v);

            Rotation += deltaTime * Math.PI;  // correct!!

            // TODO implement
            // Position += Velocity * deltaTime;
             Position += velocity * deltaTime;
             velocity += acceleration * deltaTime;
             acceleration = nv * 1000;
             Rotation = Math.Atan2(velocity.Y, velocity.X);
        }

        private void BounceEdges()
        {
            float scr_width = Settings.ScreenSize.X;
            float scr_height = Settings.ScreenSize.Y;
            float spr_width = TextureSize.X;
            float spr_heigth = TextureSize.Y;

            // TODO implement...
            if (Position.X > scr_width)
            {
                // ...
            }
        }

    }
}
