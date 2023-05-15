using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone.Graphics
{
    internal class Texture
    {
        public int ID;
        public Texture(TextureUnit textureLocation, string textureFilename)
        {

            // generate texture ID
            ID = GL.GenTexture();
            // activate it in the texture unit
            GL.ActiveTexture(textureLocation);
            GL.BindTexture(TextureTarget.Texture2D, ID);

            // texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            // load image
            StbImage.stbi_set_flip_vertically_on_load(1);
            ImageResult texture = ImageResult.FromStream(File.OpenRead("../../../res/" + textureFilename), ColorComponents.RedGreenBlueAlpha);

            // give openGL the texture data
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, texture.Data);
            // unbind the texture
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
        public void Use()
        {
            GL.BindTexture(TextureTarget.Texture2D, ID);
        }
        public void Delete()
        {
            GL.DeleteTexture(ID);
        }
    }
}
