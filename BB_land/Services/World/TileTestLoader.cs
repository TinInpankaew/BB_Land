using System;
using System.Collections.Generic;
using BB_land.World;
using BB_land.World.Tiles;

namespace BB_land.Services.World
{
    internal class TileTestLoader : ITileLoader
    {
        private readonly Random rnd;
        private readonly List<ICollisionObject> collisionObjects;
        public int[,] results = new int[15,15];
        //    private int[][] ArrayOfBlock;


        //     public int[][] ArrOfBlock1 { get => ArrOfBlock; set => ArrOfBlock = value; }

        public TileTestLoader()
        {
            rnd = new Random();
            collisionObjects = new List<ICollisionObject>();
        }

        public IList<TileGraphic> LoadGraphicTiles(string mapName)
        {
            var list = new List<TileGraphic>();
            list.AddRange(GenerateGrass());
            list.AddRange(GenerateBushes());
            return list;
        }

        public IList<ICollisionObject> LoadCollisionTiles(string mapName)
        {
            return collisionObjects;
        }
       

        private IEnumerable<TileGraphic> GenerateGrass()
        {
            var list = new List<TileGraphic>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    list.Add(new TileGraphic
                    {
                        AnimationSpeed = 1000,
                        TextureName = "Tiles/main_tile",
                        TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 16*rnd.Next(0, 5),
                                TextureYPosition = 0
                            }
                        },
                        XTilePosition = x,
                        YTilePosition = y,
                        ZTilePosition = 0
                    });
                }
            }
            return list;
        }

        private IEnumerable<TileGraphic> GenerateBushes()
        {
            var list = new List<TileGraphic>();
            
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    var type = rnd.Next(0, 3);
                    //ฟังก์ชั่นแอดขอบ
                    if (x == 0 || x == 14 || y == 0 || y == 14)
                    {
                        collisionObjects.Add(new TileCollison{XTilePosition = x, YTilePosition = y});
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                            {
                                new TileFrame
                                {
                                    TextureXPosition = 16,
                                    TextureYPosition = 32
                                }
                            },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                        results[x, y] = 1;
                        //                this.ArrOfBlock1[x][y] = 0;
                        //ฟังก์ชั่นแอดต้นไม้ข้างใน
                    }else if ((x % 2) == 0 && (y % 2) == 0)
                    {
                        collisionObjects.Add(new TileCollison { XTilePosition = x, YTilePosition = y });
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                            {
                                new TileFrame
                                {
                                    TextureXPosition = 16,
                                    TextureYPosition = 32
                                }
                            },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                        results[x, y] = 1;
                        //              this.ArrOfBlock1[x][y] = 0;                    
                    }else if (((3 <= x && x <= 11) || (3 <= y && y <= 11)) && type<=1)
                    {
                        collisionObjects.Add(new TileCollison { XTilePosition = x, YTilePosition = y });
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 200,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                            {
                                new TileFrame
                                {
                                    TextureXPosition = 0,
                                    TextureYPosition = 16
                                },
                                new TileFrame
                                {
                                    TextureXPosition = 16,
                                    TextureYPosition = 16
                                },
                                new TileFrame
                                {
                                    TextureXPosition = 32,
                                    TextureYPosition = 16
                                },
                                new TileFrame
                                {
                                    TextureXPosition = 48,
                                    TextureYPosition = 16
                                }

                            },

                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                        results[x, y] = 0;
                    }
                    
                }
            }
            return list;
        }

    }
}

/*     
 *     
 *     (x != 2 && x!= 1 && y != 1 && y!= 2) ||  (x != 14 && x!= 13 && y != 1 && y!= 2) || (x != 2 && x!= 1 && y != 14 && y!= 13) || (x != 14 && x!= 13 && y != 14 && y!= 13)
 *     
 *     private IEnumerable<TileGraphic> GenerateBushes()
        {
            var list = new List<TileGraphic>();
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    var chance = rnd.Next(0, 100);
                    if (chance < 80)
                        continue;
                    collisionObjects.Add(new TileCollison{ XTilePosition = x, YTilePosition = y});
                    var type = rnd.Next(0, 2);
                   if (type == 0) type++; 
                    {
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 0,
                                TextureYPosition = 32
                            }
                        },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                    }
                    if (type == 1)
                    {
                        list.Add(new TileGraphic
                        {
                            AnimationSpeed = 1000,
                            TextureName = "Tiles/main_tile",
                            TileFrames = new List<TileFrame>
                        {
                            new TileFrame
                            {
                                TextureXPosition = 16,
                                TextureYPosition = 32
                            }
                        },
                            XTilePosition = x,
                            YTilePosition = y,
                            ZTilePosition = 0
                        });
                    }
                }
            }
            return list;
        }*/
