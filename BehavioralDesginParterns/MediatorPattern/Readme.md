# Mediator Pattern

## 1. Mediator Pattern là gì?
Mediator Pattern là một Behavioral Design Pattern dùng để giảm sự phụ thuộc trực tiếp giữa các object, bằng cách đưa toàn bộ việc giao tiếp qua một đối tượng trung gian gọi là Mediator.

👉 Thay vì các object gọi trực tiếp nhau:
<pre>
A -> B -> C -> D
</pre>
👉 Thì sẽ chuyển thành:
<pre>
A -> Mediator <- B
         ↑
         C, D
</pre>

---

## 2. Vấn đề mà Mediator giải quyết
Khi hệ thống có nhiều object tương tác:

 - Quan hệ many-to-many → code rất rối
 - Khó maintain (sửa 1 class ảnh hưởng nhiều class khác)
 - Tight coupling (phụ thuộc chặt)

 👉 Mediator giúp:

 - Tập trung logic giao tiếp
 - Giảm coupling giữa các component

 ---

## 3. Cách triển khai Mediator Pattern
Thành phần chính:

### 1. Mediator (interface)

🎯 Vai trò
Định nghĩa cách các Colleague nói chuyện với nhau thông qua mediator

👉 Nó KHÔNG chứa logic
👉 Nó chỉ định nghĩa rule của communication

📌 Bản chất

Mediator giống như:

“Trung tâm điều phối, nhưng ở mức abstraction”

<pre>
public interface IMediator
{
    void Send(string message, Colleague sender);
}
</pre>

### 2. ConcreteMediator

🎯 Vai trò

👉 Đây là trái tim của pattern

 - Điều phối communication
 - Biết tất cả Colleague
 - Quyết định:
    - Ai nhận message
    - Khi nào gửi
    - Gửi như thế nào

 - 📌 Bản chất

ConcreteMediator = Centralized Control Logic

🧠 Nó thực sự làm gì?

Ví dụ:

<pre>
public class ChatMediator : IMediator
{
    private List<Colleague> users = new();

    public void Register(Colleague user)
    {
        users.Add(user);
    }

    public void Send(string message, Colleague sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Receive(message);
            }
        }
    }
}
</pre>

👉 Nó:

Nhận input từ 1 Colleague
Quyết định broadcast / routing

📌 Các kiểu logic thường thấy

1. Routing
<pre>
A → Mediator → B
</pre>

2. Broadcast
<pre>
A → Mediator → (B, C, D)
</pre>

3. Conditional logic

<pre>
if (type == ADMIN) → send to all
else → send to group
</pre>

---

Rủi ro lớn nhất

👉 God Object

Dấu hiệu:

- Class dài 500+ dòng
- Nhiều if-else phức tạp
- Biết quá nhiều thứ

---
Best Practice
Tách mediator theo domain:
 - ChatMediator
 - OrderMediator
 
Hoặc kết hợp với:
 - Strategy Pattern
 - Command Pattern

### 3. Colleague (abstract class)

🎯 Vai trò
 - Đại diện cho các object trong hệ thống
 - Không giao tiếp trực tiếp với nhau
 - Chỉ giao tiếp qua Mediator
 ---
 📌 Bản chất

Colleague = Participant trong hệ thống

---
🧠 Nó giữ gì?


<pre>
public abstract class Colleague
{
    protected IMediator mediator;

    public Colleague(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
</pre>

👉 Đây là điểm quan trọng:

 - Nó phụ thuộc vào abstraction, không phải implementation
 - Cho phép thay mediator dễ dàng
 ---
📌 Tại sao cần abstract class?
 - Tránh duplicate code
 - Chuẩn hóa cách dùng mediator
 - 
 ---

### 4. ConcreteColleague
🎯 Vai trò
 - Thực hiện hành vi cụ thể
 - Gửi request đến Mediator
 - Nhận response từ Mediator

📌 Bản chất

ConcreteColleague = UI component / service / module thực tế

---
🧠 Nó làm 2 việc chính:
<pre>
public class User : Colleague
{
    public string Name { get; set; }

    public User(IMediator mediator, string name) : base(mediator)
    {
        Name = name;
    }

    public void Send(string message)
    {
        mediator.Send($"{Name}: {message}", this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} received: {message}");
    }
}
</pre>

1. Gửi request

<pre>
public void Send(string message)
{
    mediator.Send(message, this);
}
</pre>

2. Nhận response

<pre>
public void Receive(string message)
{
    Console.WriteLine(message);
}
</pre>

🧠 Khi nào Receive() được gọi?

👉 Receive() KHÔNG bao giờ được gọi trực tiếp bởi Colleague khác

Nó chỉ được gọi khi:

> Mediator quyết định gửi message đến Colleague đó


🔁 Flow đầy đủ (từng bước)

Giả sử:
<pre>
user1.Send("Hello");
</pre>

🟢 Bước 1: Colleague gửi message

<pre>
public void Send(string message)
{
    mediator.Send($"{Name}: {message}", this);
}
</pre>

👉 Lúc này:

 - user1 KHÔNG gọi user2
 - Nó chỉ gọi Mediator

 🟡 Bước 2: Mediator xử lý

 <pre>
 public void Send(string message, Colleague sender)
{
    foreach (var user in users)
    {
        if (user != sender)
        {
            user.Receive(message); // 👈 GỌI Ở ĐÂY
        }
    }
}
</pre>
👉 Mediator:

 - Nhận message
 - Quyết định gửi cho ai
 - Và chính nó gọi Receive()

 🔴 Bước 3: Colleague nhận message

<pre>
public void Receive(string message)
{
    Console.WriteLine($"{Name} received: {message}");
}
</pre>
👉 Đây là lúc Receive() được gọi

---

⚠️ Sai lầm phổ biến

❌ Nhét business logic vào Colleague
❌ Gọi trực tiếp nhau

### 5. Client🎯 Vai trò

 - Khởi tạo Mediator
 - Tạo Colleague
 - Register các Colleague vào Mediator

<pre>
var mediator = new ChatMediator();

var user1 = new User(mediator, "A");
var user2 = new User(mediator, "B");

mediator.Register(user1);
mediator.Register(user2);

user1.Send("Hello");
</pre>
---

## 4. Cách hoạt động
1. Các object (Colleague) không gọi trực tiếp nhau
2. Khi cần giao tiếp → gọi Mediator
3. Mediator quyết định:
    - Gửi cho ai
    - Gửi như thế nào

👉 Mediator trở thành trung tâm điều phối

---

## 5. Khi nào nên dùng?
Nên dùng khi:
1. Nhiều object giao tiếp phức tạp
    - UI components (button, textbox, checkbox)
    - Chat system
    - Workflow system

 2. Quan hệ many-to-many

    - Form có 10 control → mỗi control phụ thuộc nhau

 3. Muốn giảm coupling
    - Tránh class biết quá nhiều class khác

 4. Logic giao tiếp thay đổi thường xuyên
    - Chỉ cần sửa Mediator


---

## 6. Khi KHÔNG nên dùng

❌ 1. Hệ thống đơn giản

2–3 class → dùng trực tiếp dễ hơn

❌ 2. Mediator trở nên quá lớn (God Object)

Chứa quá nhiều logic → khó maintain

---

## 7. Ưu điểm

✔ 1. Giảm coupling mạnh

Object không cần biết nhau

✔ 2. Dễ maintain

Logic giao tiếp tập trung 1 chỗ

✔ 3. Dễ mở rộng

Thêm Colleague mới không ảnh hưởng nhiều

✔ 4. Tuân thủ SRP (Single Responsibility)

Tách logic giao tiếp khỏi business logic

---

## 8. Nhược điểm

❌ 1. Mediator dễ thành "God Class"

Tất cả logic dồn vào đây

❌ 2. Khó debug hơn

Flow không trực tiếp (phải qua mediator)

❌ 3. Tăng complexity ban đầu

Thêm abstraction


