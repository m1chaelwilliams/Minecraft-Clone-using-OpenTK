using Minecraft_Clone.Graphics;
using Minecraft_Clone.World;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone
{
    public class Game : GameWindow
    {

        List<Chunk> chunks;

        Camera camera;
        
        ShaderProgram program;


        int width, height;

        // random testing vars
        float rot = 0f;
        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.width = width;
            this.height = height;

            this.CenterWindow(new Vector2i(width, height));
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            this.width = e.Width;
            this.height = e.Height;
            GL.Viewport(0, 0, e.Width, e.Height);
            base.OnResize(e);
        }

        // load and unload
        protected override void OnLoad()
        {
            base.OnLoad();
            camera = new Camera(width, height, new Vector3(5,12,5));

            program = new ShaderProgram("Default.vert", "Default.frag");

            // --- CHUNK LOADING ---

            chunks = new List<Chunk>();

            for(int x = 0; x < 3; x++)
            {
                for(int z = 0; z < 3; z++)
                {
                    chunks.Add(new Chunk(new Vector3(x, 0, -z)));
                }
            }
            foreach(Chunk chunk in chunks)
            {
                chunk.GenerateChunk();
            }
            

            GL.Enable(EnableCap.DepthTest);

            GL.FrontFace(FrontFaceDirection.Cw);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
        }
        protected override void OnUnload()
        {
            base.OnUnload();
            foreach(Chunk chunk in chunks)
            {
                chunk.Delete();
            }
            
        }
        // rendering and updating
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            

            GL.ClearColor(new Color4(0.4f, 0.1f, 1.0f, 1f));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            //Matrix4 model = Matrix4.CreateRotationY(15f);
            Matrix4 model = Matrix4.Identity;
            rot += 0.0005f;
            //model += Matrix4.CreateTranslation(new Vector3(0, 0, -rot));

            Matrix4 view = camera.getViewMatrix();
            Matrix4 proj = camera.getProjectionMatrix();

            int modelLocation = GL.GetUniformLocation(program.ID, "model");
            int viewLocation = GL.GetUniformLocation(program.ID, "view");
            int projLocation = GL.GetUniformLocation(program.ID, "proj");

            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projLocation, true, ref proj);

            float aspectRatio = (float)width / height;

            Matrix4 scalingMatrix = Matrix4.CreateScale(1.0f, aspectRatio, 1.0f);

            int scalingMatrixLocation = GL.GetUniformLocation(program.ID, "scalingMatrix");
            GL.UniformMatrix4(scalingMatrixLocation, false, ref scalingMatrix);

            foreach (Chunk chunk in chunks)
            {
                chunk.Draw(program);
            }

            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            // camera movement
            KeyboardState input = KeyboardState;
            MouseState mouse = MouseState;
            CursorState = CursorState.Grabbed;

            camera.Update(input, mouse, args);
        }
    }
}
