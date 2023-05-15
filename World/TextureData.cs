using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Clone.World
{
    internal class TextureData
    {

        public static Dictionary<BlockType, Dictionary<string, List<Vector2>>> textures = new Dictionary<BlockType, Dictionary<string, List<Vector2>>>
        {
            {BlockType.DIRT,
            new Dictionary<string, List<Vector2>>
            {
                {"front", new List<Vector2>() 
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    } 
                },
                {"back", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                },
                {"left", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                },
                {"right", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                },
                {"top", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                },
                {"bottom", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                }
            }
            },

            {BlockType.GRASS,
            new Dictionary<string, List<Vector2>>
            {
                {"front", new List<Vector2>()
                    {
                    new Vector2(3f/16f, 1f),
                    new Vector2(4f/16f, 1f),
                    new Vector2(4f/16f, 15f/16f),
                    new Vector2(3f/16f, 15f/16f)
                    }
                },
                {"back", new List<Vector2>()
                    {
                    new Vector2(3f/16f, 1f),
                    new Vector2(4f/16f, 1f),
                    new Vector2(4f/16f, 15f/16f),
                    new Vector2(3f/16f, 15f/16f)
                    }
                },
                {"left", new List<Vector2>()
                    {
                    new Vector2(3f/16f, 1f),
                    new Vector2(4f/16f, 1f),
                    new Vector2(4f/16f, 15f/16f),
                    new Vector2(3f/16f, 15f/16f)
                    }
                },
                {"right", new List<Vector2>()
                    {
                    new Vector2(3f/16f, 1f),
                    new Vector2(4f/16f, 1f),
                    new Vector2(4f/16f, 15f/16f),
                    new Vector2(3f/16f, 15f/16f)
                    }
                },
                {"top", new List<Vector2>()
                    {
                    new Vector2(7f/16f, 14f/16f),
                    new Vector2(8f/16f, 14f/16f),
                    new Vector2(8f/16f, 13f/16f),
                    new Vector2(7f/16f, 13f/16f)
                    }
                },
                {"bottom", new List<Vector2>()
                    {
                    new Vector2(2f/16f, 1f),
                    new Vector2(3f/16f, 1f),
                    new Vector2(3f/16f, 15f/16f),
                    new Vector2(2f/16f, 15f/16f)
                    }
                }
            }
            }
        };        
    }
}
