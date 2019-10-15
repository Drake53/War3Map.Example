using War3Map.Example.Source.Lua;

using static War3Api.Common;

namespace War3Map.Example.Source
{
    internal static class PerlinExample
    {
        public static void Run()
        {
            PerlinNoise.Init();
            var terrainTypes = new[] { FourCC("Ldrt"), FourCC("Ldro"), FourCC("Lgrs"), FourCC("Ldrg"), FourCC("Lrok") };

            var map = GetWorldBounds();
            var minx = GetRectMinX(map);
            var maxx = GetRectMaxX(map);
            var miny = GetRectMinY(map);
            var maxy = GetRectMaxY(map);
            RemoveRect(map);

            for (var x = minx; x <= maxx; x += 128)
            {
                for (var y = miny; y <= maxy; y += 128)
                {
                    const float scale = 0.001f;
                    var result = PerlinNoise.Noise(x * scale, y * scale);

                    int terrainType;
                    if (result < 0.1f)
                        terrainType = 0;
                    else if (result < 0.2f)
                        terrainType = 1;
                    else if (result < 0.25f)
                        terrainType = 2;
                    else if (result < 0.5f)
                        terrainType = 3;
                    else
                        terrainType = 4;

                    SetTerrainType(x, y, terrainTypes[terrainType], 0, 1, 0);
#if DEBUG
                    if ((x > -500 && x < 500) && (y > -500 && y < 500))
                    {
                        var tag = CreateTextTag();
                        var location = Location(x, y);
                        War3Api.Blizzard.CreateTextTagLocBJ(R2S(result), location, 0f, 10f, 100f, 100f, 100f, 0f);
                        RemoveLocation(location);
                    }
#endif
                }
            }
        }
    }
}