using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone.World
{
    public struct FaceData
    {
        public List<Vector3> vertices;
        public List<Vector2> uv;
        public List<float> brightness;
    }
    public enum BlockType
    {
        EMPTYBLOCK,
        DIRT,
        GRASS
    }
    public struct BlockData
    {
        public static readonly Dictionary<string, List<Vector3>> faceDataRaw = new Dictionary<string, List<Vector3>>
        {
            {"front",
                new List<Vector3>()
                {
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f)
                }
            },
            {"right",
                new List<Vector3>()
                {
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f)
                }
            },
            {"left",
                new List<Vector3>()
                {
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f)
                }
            },
            {"back",
                new List<Vector3>()
                {
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                }
            },
            {"top",
                new List<Vector3>()
                {
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                }
            },
            {"bottom",
                new List<Vector3>()
                {
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                }
            }
        };
    }


}
