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

namespace Minecraft_Clone.Graphics
{
    internal class VAO
    {
        public int ID;
        public VAO()
        {
            ID = GL.GenVertexArray();
            GL.BindVertexArray(ID); // bind vao to current context
        }

        public void linkToVAO(int location, int size, VBO vbo, int stride = 0, int startingOffset = 0)
        {
            vbo.Bind();
            GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, stride, startingOffset);
            GL.EnableVertexAttribArray(location);
        }

        public void Bind()
        {
            GL.BindVertexArray(ID);
        }
        public void Unbind()
        {
            GL.BindVertexArray(0);
        }
        public void Delete()
        {
            GL.DeleteVertexArray(ID);
        }
    }
}
