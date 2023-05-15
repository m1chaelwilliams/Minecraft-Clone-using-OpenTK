﻿using OpenTK.Graphics.OpenGL4;
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
    internal class VBO
    {

        public int ID;
        public VBO(float[] data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            Unbind();
        }
        // constructor for sending a List of vectors
        public VBO(List<Vector3> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector3.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
            Unbind();
        }

        public VBO(List<Vector2> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector2.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
            Unbind();
        }
        // constructor for sending a list of floats
        public VBO(List<float> data)
        {
            ID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * sizeof(float), data.ToArray(), BufferUsageHint.StaticDraw);
            Unbind();
        }
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        }
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        public void Delete()
        {
            GL.DeleteBuffer(ID);
        }
    }
}
