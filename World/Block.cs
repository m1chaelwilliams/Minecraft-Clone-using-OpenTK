using Minecraft_Clone.Graphics;
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

namespace Minecraft_Clone.World
{
    internal class Block
    {
        public Vector3 position;
        public BlockType ID;

        // temporary implimentation
        Dictionary<string, FaceData> faces;

        public List<Vector3> AddTransformedVertices(List<Vector3> vertices)
        {
            List<Vector3> newVerts = new List<Vector3>();
            foreach(Vector3 vert in vertices)
            {
                newVerts.Add(vert + position);
            }
            return newVerts;
        }

        public Block(BlockType blockType, Vector3 position)
        {
            this.position = position;
            ID = blockType;

            if(blockType != BlockType.EMPTYBLOCK)
            {
                faces = new Dictionary<string, FaceData>
                {
                    {"front",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["front"]),
                            uv = TextureData.textures[blockType]["front"],
                            brightness = new List<float>
                            {
                                0.6f, 0.6f, 0.6f, 0.6f
                            }
                        }
                    },

                    {"right",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["right"]),
                            uv = TextureData.textures[blockType]["right"],
                            brightness = new List<float>
                            {
                                0.6f, 0.6f, 0.6f, 0.6f
                            }
                        }
                    },

                    {"left",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["left"]),
                            uv = TextureData.textures[blockType]["left"],
                            brightness = new List<float>
                            {
                                0.6f, 0.6f, 0.6f, 0.6f
                            }
                        }
                    },

                    {"back",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["back"]),
                            uv = TextureData.textures[blockType]["back"],
                            brightness = new List<float>
                            {
                                0.6f, 0.6f, 0.6f, 0.6f
                            }
                        }
                    },

                    {"top",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["top"]),
                            uv = TextureData.textures[blockType]["top"],
                            brightness = new List<float>
                            {
                                1f,1f,1f,1f
                            }
                        }
                    },

                    {"bottom",
                        new FaceData
                        {
                            vertices = AddTransformedVertices(BlockData.faceDataRaw["bottom"]),
                            uv = TextureData.textures[blockType]["bottom"],
                            brightness = new List<float>
                            {
                                0.4f, 0.4f, 0.4f, 0.4f
                            }
                        }
                    },
                };
            } else
            {
                faces = new Dictionary<string, FaceData>();
            }
        }

        public FaceData AddFace(string faceName)
        {
            return faces[faceName];
        }
    }
}
