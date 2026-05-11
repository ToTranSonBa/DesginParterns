# Prototype Pattern

## 1. Định nghĩa

Prototype Pattern cho phép tạo ra các đối tượng mới bằng cách sao chép (clone) từ một đối tượng hiện có (gọi là Prototype), thay vì tạo mới bằng từ khóa new.

Nó giúp tránh việc phải biết chính xác lớp cụ thể và giảm chi phí khởi tạo khi việc tạo đối tượng phức tạp hoặc tốn kém.

## 2. Mục đích (Intent)

- Tạo đối tượng mà không cần chỉ rõ lớp cụ thể của nó.
- Giảm chi phí tạo đối tượng khi quá trình khởi tạo phức tạp (database, network, tính toán nặng...).
- Cho phép tạo các biến thể của đối tượng một cách linh hoạt.

## 3. Vấn đề mà Pattern giải quyết

Giả sử bạn có một đối tượng phức tạp đã được cấu hình sẵn (có nhiều thuộc tính, trạng thái, dữ liệu con...). Nếu dùng new, bạn phải thiết lập lại tất cả từ đầu. Prototype cho phép clone và chỉ chỉnh sửa những phần cần thay đổi.

## 4. Cấu trúc (Structure)

- Prototype: Interface hoặc Abstract Class khai báo phương thức clone().
- Concrete Prototype: Các lớp cụ thể triển khai clone().
- Client: Sử dụng prototype để clone ra các đối tượng mới.
- Prototype Registry (tùy chọn): Một kho lưu trữ các prototype sẵn, client lấy ra theo tên hoặc ID.

## 5. Ưu điểm (Advantages)

- Giảm chi phí tạo đối tượng phức tạp.
- Giảm số lượng lớp con (subclass) so với Factory Method.
- Dễ dàng thêm/xóa các loại đối tượng tại runtime.
- Cho phép tạo đối tượng mà không biết chính xác lớp (hữu ích khi làm việc với thư viện bên thứ ba).
- Hỗ trợ shallow copy và deep copy linh hoạt.

## 6. Nhược điểm (Disadvantages)

- Việc implement clone() phức tạp với đối tượng có nhiều tham chiếu (circular references).
- Khó debug khi có nhiều lớp clone nhau.
- Mỗi lớp phải triển khai clone riêng → vi phạm nguyên tắc DRY nếu không cẩn thận.
- Shallow copy có thể gây lỗi không mong muốn nếu không hiểu rõ.

## 7. Khi nào nên sử dụng?

- Khi chi phí tạo đối tượng cao (file, network, DB query...).
- Khi hệ thống cần tạo nhiều đối tượng giống nhau nhưng có sự khác biệt nhỏ.
- Khi lớp của đối tượng được xác định ở runtime.
- Khi muốn tránh hệ thống phân cấp lớp (class hierarchy) quá lớn.
- Trong game development (clone enemy, item, level...).

## 8. Triển khai chi tiết

1. Triển khai cơ bản sử dụng Interface

<pre>

using System;
// Prototype Interface
public interface IPrototype
{
    IPrototype Clone();           // Shallow hoặc Deep copy
    IPrototype DeepClone();       // Deep copy rõ ràng
    void Display();
}

// Abstract Class (khuyến khích dùng)
public abstract class Shape : IPrototype
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }

    public abstract void Display();

    // Shallow Copy
    public virtual IPrototype Clone()
    {
        return (IPrototype)this.MemberwiseClone();
    }

    // Deep Copy
    public abstract IPrototype DeepClone();
}

</pre>

2. Concrete Prototypes

<pre>
public class Circle : Shape
{
    public int Radius { get; set; }
    public Point Center { get; set; } = new Point();

    public Circle()
    {
        Type = "Circle";
        Color = "Red";
        Radius = 10;
        Center.X = 0;
        Center.Y = 0;
    }

    public override void Display()
    {
        Console.WriteLine($"[Circle] Id={Id}, Type={Type}, Color={Color}, " +
                         $"Radius={Radius}, Center=({Center.X}, {Center.Y})");
    }

    public override IPrototype DeepClone()
    {
        Circle clone = (Circle)this.MemberwiseClone(); // Shallow trước
        clone.Center = new Point { X = this.Center.X, Y = this.Center.Y }; // Deep cho reference type
        return clone;
    }
}

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<string> Tags { get; set; } = new List<string>(); // Reference type

    public Rectangle()
    {
        Type = "Rectangle";
        Color = "Blue";
        Width = 20;
        Height = 15;
        Tags.Add("Shape");
        Tags.Add("Rectangle");
    }

    public override void Display()
    {
        Console.WriteLine($"[Rectangle] Id={Id}, Type={Type}, Color={Color}, " +
                         $"Size={Width}x{Height}, Tags=({string.Join(", ", Tags)})");
    }

    public override IPrototype DeepClone()
    {
        Rectangle clone = (Rectangle)this.MemberwiseClone();
        clone.Tags = new List<string>(this.Tags); // Deep copy List
        return clone;
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
</pre>

3. Prototype Registry (Cache)

<pre>
public static class ShapeCache
{
    private static readonly Dictionary<string, Shape> _cache = new Dictionary<string, Shape>();

    public static void LoadCache()
    {
        // Circle prototype
        Circle circle = new Circle();
        circle.Id = "C1";
        _cache.Add(circle.Id, circle);

        // Rectangle prototype
        Rectangle rect = new Rectangle();
        rect.Id = "R1";
        _cache.Add(rect.Id, rect);
    }

    public static Shape GetShape(string id)
    {
        if (_cache.TryGetValue(id, out Shape shape))
        {
            return (Shape)shape.DeepClone(); // Luôn dùng DeepClone để an toàn
        }
        return null;
    }

    public static void AddPrototype(string id, Shape shape)
    {
        _cache[id] = shape;
    }
}
</pre>


4. Client Code & Demo

<pre>
class Program
{
    static void Main(string[] args)
    {
        ShapeCache.LoadCache();

        Console.WriteLine("=== Prototype Pattern Demo ===\n");

        // Lấy prototype và clone
        Shape circle1 = ShapeCache.GetShape("C1");
        Shape circle2 = ShapeCache.GetShape("C1");

        circle2.Id = "C2";
        circle2.Color = "Green";
        ((Circle)circle2).Radius = 50;
        ((Circle)circle2).Center.X = 100;
        ((Circle)circle2).Center.Y = 200;

        Shape rect1 = ShapeCache.GetShape("R1");
        Shape rect2 = ShapeCache.GetShape("R1");

        rect2.Id = "R2";
        rect2.Color = "Yellow";
        ((Rectangle)rect2).Width = 100;
        ((Rectangle)rect2).Height = 60;
        ((Rectangle)rect2).Tags.Add("Modified"); // Kiểm tra Deep Copy

        Console.WriteLine("Original prototypes (không bị thay đổi):");
        ShapeCache.GetShape("C1").Display();
        ShapeCache.GetShape("R1").Display();

        Console.WriteLine("\nCloned objects:");
        circle1.Display();
        circle2.Display();
        rect1.Display();
        rect2.Display();

        Console.ReadKey();
    }
}
</pre>
