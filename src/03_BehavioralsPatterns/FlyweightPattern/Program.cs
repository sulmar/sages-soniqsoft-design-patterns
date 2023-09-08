using System.Collections.Generic;

Console.WriteLine("Hello Flyweight Pattern!");

PointService pointService = new PointService();

var points = pointService.GetAll();

foreach (var point in points)
{
    point.Draw();
}

public class Point
{
    public int X { get; } // 4 bytes
    public int Y { get; } // 4 bytes
    public PointIcon Icon { get; }

    public Point(int x, int y, PointIcon icon)
    {
        this.X = x;
        this.Y = y;
        this.Icon = icon;
    }

    public void Draw() => Console.WriteLine($"{Icon.Type} at ({X},{Y}) {Icon.Icon.Length} bytes");
}

public class PointService
{
    private readonly IEnumerable<Point> points;

    public PointService(PointIconFactory pointIconFactory)
    {
        points = new List<Point>
         {
             new Point(10, 20, pointIconFactory.Get(PointType.Cafe),
             new Point(20, 40, pointIconFactory.Get(PointType.Cafe),
             new Point(25, 35, pointIconFactory.Get(PointType.Hotel),
         };        
    }

    public IEnumerable<Point> GetAll()
    {
        return points;
    }
}

public class PointIcon
{
    public PointType Type { get; } // 4 bytes
    public byte[] Icon { get; }  // 2 kb

    public PointIcon(PointType type, byte[] icon)
    {
        this.Type = type;
        this.Icon = icon;
    }
}

public enum PointType
{
    Cafe,
    Hotel
}

// Flyweight Factory
public class PointIconFactory
{
    private readonly Dictionary<PointType, PointIcon> icons = new();

    public PointIcon Get(PointType type)
    {
        if (!icons.ContainsKey(type))
        {
            string filename = $"{type}.png".ToLower();
            var icon = new PointIcon(type, File.ReadAllBytes(filename);
            // cafe.png
            // hotel.png

            icons.Add(type, icon);
        }

        return icons[type];
    }
}
