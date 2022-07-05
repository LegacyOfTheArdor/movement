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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity;
		private Vector2 Acceleration;
		private float MaxSpeed = 100;


		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
			Velocity = new Vector2(0, 0);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Acceleration = new Vector2(40, 30);
			Move(deltaTime);
			WrapEdges();
			if(Velocity.Length() > MaxSpeed)
			{
				Acceleration = new Vector2(0, 0);
			}
		}

		// your own private methods
		protected void Move(float deltaTime)
		{
			// Motion 101. Apply the rules.
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// Reset acceleration
			Acceleration *= 0.0f;
		}

		private void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				Position.X = 0;
			}
			if (Position.Y > scr_height)
			{
				Position.Y = 0;
			}
		}

	}
}
