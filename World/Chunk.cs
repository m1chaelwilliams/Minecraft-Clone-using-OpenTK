using Minecraft_Clone.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone.World
{
    internal class Chunk
    {
        private static readonly int CHUNKSIZE = 10;


        List<uint> indices;
        uint indexCount;

        FaceData faces;

        VAO? vao;
        VBO? vbo;
        VBO? texVBO;
        VBO? brightnessVBO;
        EBO? ebo;


        Block[,,] chunkBlocks;
        Vector3 chunkPos;

        // TEMPORARY
        Texture texture;
        public Chunk(Vector3 chunkPos)
        {
            this.chunkPos = chunkPos;

            indices = new List<uint>();
            chunkBlocks = new Block[CHUNKSIZE, CHUNKSIZE, CHUNKSIZE];

            faces = new FaceData
            {
                vertices = new List<Vector3>(),
                uv = new List<Vector2>(),
                brightness = new List<float>()
            };

            // TEMP
            texture = new Texture(TextureUnit.Texture0, "atlas.png");



            Random rand = new Random();
            for (int x = 0; x < 10; x++)
            {
                for (int z = 0; z < 10; z++)
                {
                    int height = rand.Next(5, 10);
                    for (int y = 0; y < 10; y++)
                    {
                        if(y <= height)
                        {
                            if(y < height)
                            {
                                chunkBlocks[x, y, z] = new Block(BlockType.DIRT, new Vector3(x+ (chunkPos.X*CHUNKSIZE), y + (chunkPos.Y * CHUNKSIZE), z + (chunkPos.Z * CHUNKSIZE)));
                            } else
                            {
                                chunkBlocks[x, y, z] = new Block(BlockType.GRASS, new Vector3(x + (chunkPos.X * CHUNKSIZE), y + (chunkPos.Y * CHUNKSIZE), z + (chunkPos.Z * CHUNKSIZE)));
                            }
                            
                        } else
                        {
                            chunkBlocks[x, y, z] = new Block(BlockType.EMPTYBLOCK, new Vector3(x + (chunkPos.X * CHUNKSIZE), y + (chunkPos.Y * CHUNKSIZE), z + (chunkPos.Z * CHUNKSIZE)));
                        }
                    }
                }
            }


        }

        public void GenerateChunk()
        {
            int faceCount = 0;

            for (int x = 0;x < CHUNKSIZE; x++)
            {
                for(int z = 0;z < CHUNKSIZE; z++)
                {
                    for(int y = 0;y < CHUNKSIZE; y++)
                    {

                        if (chunkBlocks[x, y, z].ID != BlockType.EMPTYBLOCK)
                        {
                            // front face
                            if (z < CHUNKSIZE-1)
                            {
                                if(chunkBlocks[x, y, z + 1].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "front");
                                    faceCount++;
                                }
                            } else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "front");
                                faceCount++;
                            }


                            // back face
                            if(z > 0)
                            {
                                if(chunkBlocks[x, y, z - 1].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "back");
                                    faceCount++;
                                }
                            } else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "back");
                                faceCount++;
                            }


                            // left face
                            if(x > 0)
                            {
                                if(chunkBlocks[x - 1, y, z].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "left");
                                    faceCount++;
                                }
                            } else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "left");
                                faceCount++;
                            }


                            // right face
                            if (x < CHUNKSIZE-1)
                            {
                                if(chunkBlocks[x + 1, y, z].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "right");
                                    faceCount++;
                                }
                            }
                            else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "right");
                                faceCount++;
                            }


                            // top face
                            if (y < CHUNKSIZE - 1)
                            {
                                if(chunkBlocks[x, y + 1, z].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "top");
                                    faceCount++;
                                }
                            }
                            else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "top");
                                faceCount++;
                            }
                            // bottom face
                            if (y > 0)
                            {
                                if(chunkBlocks[x, y - 1, z].ID == BlockType.EMPTYBLOCK)
                                {
                                    IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "bottom");
                                    faceCount++;
                                }
                            }
                            else
                            {
                                IntegrateFaceIntoChunk(chunkBlocks[x, y, z], "bottom");
                                faceCount++;
                            }
                        }
                    }
                }
            }

            AddFaceIndices(faceCount);
            BuildChunk();
        }

        public void IntegrateFaceIntoChunk(Block block, string face)
        {
            faces.vertices.AddRange(block.AddFace(face).vertices);
            faces.uv.AddRange(block.AddFace(face).uv);
            faces.brightness.AddRange(block.AddFace(face).brightness);
        }

        public List<Vector3> Transform(List<Vector3> verts, Vector3 transformation)
        {
            List<Vector3> newVert = new List<Vector3>();
            foreach(Vector3 v in verts)
            {
                newVert.Add(v+transformation);
            }
            return newVert;
        }

        public void AddFaceIndices(int amount)
        {
            for(int i = 0;i < amount;i++)
            {
                indices.Add(0 + indexCount);
                indices.Add(1 + indexCount);
                indices.Add(2 + indexCount);
                indices.Add(2 + indexCount);
                indices.Add(3 + indexCount);
                indices.Add(0 + indexCount);

                indexCount += 4;
            }
        }
        public void UpdateChunk()
        {

        }

        public void BuildChunk()
        {
            vao = new VAO();

            vbo = new VBO(faces.vertices);
            texVBO = new VBO(faces.uv);
            brightnessVBO = new VBO(faces.brightness);

            vao.linkToVAO(0, 3, vbo);
            vao.linkToVAO(1, 2, texVBO);
            vao.linkToVAO(2, 1, brightnessVBO);

            vao.Unbind();

            ebo = new EBO(indices);
        }

        public void Draw(ShaderProgram shader)
        {
            shader.Activate();

            vao.Bind();
            ebo.Bind();

            texture.Use();

            GL.DrawElements(PrimitiveType.Triangles, indices.Count, DrawElementsType.UnsignedInt, 0);

            vao.Unbind();
            ebo.Unbind();
            
        }

        public void Delete()
        {
            vao.Delete();
            vbo.Delete();
            texVBO.Delete();
            ebo.Delete();
            texture.Delete();
        }
    }
}
