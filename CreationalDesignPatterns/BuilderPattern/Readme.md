# Builder Pattern

## 1.Builder Pattern là gì?

Builder Pattern là một trong những Creational Design Pattern (nhóm khởi tạo), dùng để tách quá trình xây dựng object phức tạp ra khỏi biểu diễn của nó, giúp cùng một quy trình build có thể tạo ra nhiều dạng object khác nhau.

## 2. Vấn đề Builder Pattern giải quyết

Giả sử có class:
<pre>
class House
{
    public string Wall;
    public string Door;
    public string Roof;
    public string Garage;
    public string SwimmingPool;
}
</pre>

Cách 1: Constructor truyền hết
<pre>
new House("brick", "wood", "tile", null, null);
</pre>

👉 Vấn đề:

 - Khó đọc (parameter hell)
 - Dễ sai thứ tự
 - Không rõ field nào optional

 Cách 2: Set property
 <pre>
 var house = new House();
house.Wall = "brick";
house.Door = "wood";
</pre>

👉 Vấn đề:

 - Object có thể ở trạng thái chưa hoàn chỉnh
 - Không đảm bảo tính consistency

 ##

 👉 Builder Pattern ra đời để:

Build object từng bước
Đảm bảo object luôn hợp lệ
Code dễ đọc hơn

## 3. Ý tưởng
👉 Thay vì:

<pre>
new House(...)
</pre>

👉 Ta làm:
<pre>
var house = new HouseBuilder()
    .BuildWall("brick")
    .BuildDoor("wood")
    .BuildRoof("tile")
    .Build();
</pre>


## 4. Các thành phần chính

1. Product
<pre>
class House { }
</pre>


2. Builder (interface/abstract)
<pre>
interface IHouseBuilder
{
    void BuildWall();
    void BuildDoor();
    void BuildRoof();
    House GetResult();
}
</pre>


3. ConcreteBuilder (các builder cụ thể)
<pre>
class NormalHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildWall() => _house.Wall = "Brick";
    public void BuildDoor() => _house.Door = "Wood";
    public void BuildRoof() => _house.Roof = "Tile";

    public House GetResult() => _house;
}
</pre>


4. Director (định nghĩa quy trình xây dựng)
<pre>
class Director
{
    public void Construct(IHouseBuilder builder)
    {
        builder.BuildWall();
        builder.BuildDoor();
        builder.BuildRoof();
    }
}
</pre>

## 5. Flow hoạt động

<pre>
Client → Director → Builder → Product
</pre>

 - Client chọn builder
 - Director điều khiển build process
 - Builder tạo object
 - Trả về Product

## 6. Fluent Builder (dạng phổ biến nhất)

Thực tế dev thường dùng kiểu này (fluent API):
<pre>
class HouseBuilder
{
    private House _house = new House();

    public HouseBuilder BuildWall(string wall)
    {
        _house.Wall = wall;
        return this;
    }

    public HouseBuilder BuildDoor(string door)
    {
        _house.Door = door;
        return this;
    }

    public House Build()
    {
        return _house;
    }
}
</pre>

👉 Sử dụng:

<pre>
var house = new HouseBuilder()
    .BuildWall("brick")
    .BuildDoor("wood")
    .Build();
</pre>

## 7. Immutable Builder (rất quan trọng trong Clean Code)

<pre>
class User
{
    public string Name { get; }
    public int Age { get; }

    private User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public class Builder
    {
        private string _name;
        private int _age;

        public Builder SetName(string name)
        {
            _name = name;
            return this;
        }

        public Builder SetAge(int age)
        {
            _age = age;
            return this;
        }

        public User Build()
        {
            return new User(_name, _age);
        }
    }
}
</pre>

## 8. Khi nào nên dùng

✅ Object có nhiều field (>= 4–5)

✅ Có nhiều optional fields

✅ Cần tạo object theo nhiều step

✅ Cần đảm bảo object luôn valid

✅ Constructor quá dài (code smell)


## 9. Khi nào KHÔNG nên dùng

❌ Object đơn giản (2–3 field)

❌ Không cần step-by-step

❌ Không cần validate phức tạp

👉 Nếu dùng → over-engineering

## 10. Ưu điểm

✔ Code dễ đọc (fluent API)

✔ Tránh constructor hell

✔ Tách logic build khỏi object

✔ Dễ mở rộng (OCP)

✔ Có thể tạo nhiều representation

## 11. Nhược điểm

❌ Tăng số class

❌ Code dài hơn

❌ Overkill nếu object đơn giản


