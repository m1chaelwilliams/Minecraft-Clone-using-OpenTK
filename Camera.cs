using Minecraft_Clone.World;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone
{
    internal class Camera
    {
        // CONSTANTS
        private const float SPEED = 8f;
        private int SCREENWIDTH;
        private int SCREENHEIGHT;
        private const float SENSITIVITY = 4f;

        // movement
        public Vector3 playerPosition;
        public Vector3i playerChunkPosition;

        Vector3 up = Vector3.UnitY; // specifying the Y axis as the vertical
        Vector3 front = -Vector3.UnitZ;
        Vector3 right = Vector3.UnitX;
        Vector3 orientation = new Vector3(0f, 0f, -1f);

        // --- VIEW ROTATIONS ---
        // Rotation around the X axis (radians)
        private float pitch;
        // Rotation around the Y axis (radians)
        private float yaw = -MathHelper.PiOver2; // Without this, you would be started rotated 90 degrees right.

        private bool firstMove = true;

        private Vector2 lastPos;



        public Camera(int SCREENWIDTH, int SCREENHEIGHT, Vector3 playerPosition)
        {
            this.SCREENWIDTH = SCREENWIDTH;
            this.SCREENHEIGHT = SCREENHEIGHT;
            this.playerPosition = playerPosition;
            this.playerChunkPosition = (Vector3i)playerPosition / 25;
        }

        public void InputController(KeyboardState input, MouseState mouse, FrameEventArgs e)
        {
            // forward
            if (input.IsKeyDown(Keys.W))
            {
                playerPosition += front * SPEED * (float)e.Time;
            }
            // backward
            if (input.IsKeyDown(Keys.S))
            {
                playerPosition -= front * SPEED * (float)e.Time;
            }
            // left
            if (input.IsKeyDown(Keys.A))
            {
                playerPosition -= right * SPEED * (float)e.Time;
            }
            // right
            if (input.IsKeyDown(Keys.D))
            {
                playerPosition += right * SPEED * (float)e.Time;
            }
            // up
            if (input.IsKeyDown(Keys.Space))
            {
                playerPosition.Y += SPEED * (float)e.Time; //Up 
            }
            // down
            if (input.IsKeyDown(Keys.LeftShift))
            {
                playerPosition.Y -= SPEED * (float)e.Time; //Down
            }

            // camera rotation
            // Get the mouse state


            if (firstMove) // This bool variable is initially set to true.
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - lastPos.X;
                var deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                yaw += deltaX * SENSITIVITY * (float)e.Time;
                pitch -= deltaY * SENSITIVITY * (float)e.Time; // Reversed since y-coordinates range from bottom to top
            }

            UpdateVectors();
        }

        // updates the view rotation
        private void UpdateVectors()
        {
            // First, the front matrix is calculated using some basic trigonometry.
            front.X = MathF.Cos(pitch) * MathF.Cos(yaw);
            front.Y = MathF.Sin(pitch);
            front.Z = MathF.Cos(pitch) * MathF.Sin(yaw);

            // We need to make sure the vectors are all normalized, as otherwise we would get some funky results.
            front = Vector3.Normalize(front);

            // Calculate both the right and the up vector using cross product.
            // Note that we are calculating the right from the global up; this behaviour might
            // not be what you need for all cameras so keep this in mind if you do not want a FPS camera.
            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));
        }

        public Matrix4 getViewMatrix()
        {
            return Matrix4.LookAt(playerPosition, playerPosition + front, up);
        }

        public Matrix4 getProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), SCREENWIDTH / SCREENHEIGHT, 0.1f, 100.0f);
        }
        public void Update(KeyboardState input, MouseState mouse, FrameEventArgs e)
        {


            InputController(input, mouse, e);
        }

        // collision stuff


    }
}
