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
    internal class ShaderProgram
    {
        public int ID;
        public ShaderProgram(String vertexFilename, String fragFilename)
        {


            int vertexShader = CreateNewShader(ShaderType.VertexShader, vertexFilename);
            int fragmentShader = CreateNewShader(ShaderType.FragmentShader, fragFilename);

            ID = CreateNewProgram(vertexShader, fragmentShader);

            // error handling
            int status;
            GL.GetProgram(ID, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
            {
                string log = GL.GetProgramInfoLog(ID);
                Console.WriteLine($"Shader program link error: {log}");
            }
        }

        private int CreateNewShader(ShaderType shaderType, String filename)
        {
            int newShader = GL.CreateShader(shaderType);
            GL.ShaderSource(newShader, LoadShaderSource(filename));
            GL.CompileShader(newShader);
            return newShader;
        }

        private int CreateNewProgram(int vertexShader, int fragmentShader)
        {
            int shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentShader);
            GL.LinkProgram(shaderProgram);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            return shaderProgram;
        }

        public void Activate()
        {
            GL.UseProgram(ID);
        }

        public void Delete()
        {
            GL.DeleteProgram(ID);
        }

        // Function to load a text file and return its contents as a string
        public static string LoadShaderSource(string filePath)
        {
            string shaderSource = "";

            try
            {
                using (StreamReader reader = new StreamReader("../../../Shaders/" + filePath))
                {
                    shaderSource = reader.ReadToEnd();
                }
                // Console.WriteLine(shaderSource);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load shader source file: " + e.Message);
            }

            return shaderSource;
        }
    }
}
