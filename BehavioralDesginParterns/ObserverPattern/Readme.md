# Observer Pattern

## 1. Observer Pattern là gì?

Observer Pattern định nghĩa mối quan hệ 1-n (one-to-many) giữa các object, khi object chính (Subject) thay đổi trạng thái, tất cả các object phụ thuộc (Observer) sẽ được notify tự động.

## 2. Ví dụ

--- 
📰 Ví dụ: Báo chí
Subject = Tòa soạn báo
Observers = Người đăng ký đọc báo

Khi có tin mới:
→ Tòa soạn phát hành
→ Tất cả subscriber nhận được

---

📱 Ví dụ: Notification system
Subject: App (Facebook, Shopee)
Observer: User

Khi có event:
→ push notification đến tất cả user đã subscribe

## 3. Khi nào nên dùng?

Dùng khi bạn có:
✔ 1. Quan hệ 1 → N
 - Một object thay đổi → nhiều object cần update

✔ 2. Muốn loose coupling
 - Subject không cần biết cụ thể Observer là ai

✔ 3. Event-driven system
 - UI events
 - Message queue
 - Domain events (DDD)

## 4. Khi KHÔNG nên dùng

❌ 1. Quá nhiều observer → khó debug
 - Notification chain phức tạp

❌ 2. Performance sensitive
 - Notify hàng loạt → tốn tài nguyên

❌ 3. Circular dependency
 - Observer update lại Subject → loop vô hạn

## 5. Cấu trúc chuẩn
<pre>
Subject
 ├── attach(observer)
 ├── detach(observer)
 └── notify()

Observer
 └── update()
</pre>

## 6. UML đơn giản
<pre>
        Subject
     +-----------+
     | +attach() |
     | +detach() |
     | +notify() |
     +-----------+
            |
            | 1
            |
            | *
      +-----------+
      | Observer  |
      | +update() |
      +-----------+
</pre>

## 7. Code C# đầy đủ
7.1 Interface
<pre>
public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
</pre>

7.2 Concrete Subject
<pre>
public class NewsAgency : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _news;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void SetNews(string news)
    {
        _news = news;
        Notify();
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_news);
        }
    }
}
</pre>

7.3 Concrete Observer
<pre>
public class Subscriber : IObserver
{
    private string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_name} received: {message}");
    }
}
</pre>

7.4 Usage
<pre>
class Program
{
    static void Main()
    {
        var agency = new NewsAgency();

        var user1 = new Subscriber("User A");
        var user2 = new Subscriber("User B");

        agency.Attach(user1);
        agency.Attach(user2);

        agency.SetNews("New product released!");
    }
}
</pre>

## 8. Flow hoạt động
<pre>
SetNews()
   ↓
Notify()
   ↓
Loop observers
   ↓
Observer.Update()
</pre>

## 9. Biến thể quan trọng
9.1 Push vs Pull

✔ Push (thường dùng)
<pre>
Update(string message)
</pre>
→ Subject push data xuống

--- 

✔ Pull
<pre>
Update()
</pre>
→ Observer tự hỏi Subject

9.2 Event-based

Trong .NET, Observer = event + delegate
<pre>
public class Publisher
{
    public event Action<string> OnMessage;

    public void Publish(string message)
    {
        OnMessage?.Invoke(message);
    }
}
</pre>
<pre>
var pub = new Publisher();

pub.OnMessage += msg => Console.WriteLine("A: " + msg);
pub.OnMessage += msg => Console.WriteLine("B: " + msg);

pub.Publish("Hello");
</pre>
👉 Đây chính là Observer pattern “ẩn”

9.3 Reactive (Rx)

> IObservable<T>

> Observer<T>

Dùng trong:

 - Stream data
 - Async event

## 10. Ưu điểm
✔ Loose coupling
 - Subject không biết observer cụ thể

✔ Open/Closed Principle
 - Thêm observer không sửa code cũ

✔ Reusable
 - Tách biệt logic rõ ràn

## 11. Nhược điểm

❌ Memory leak

- Quên detach observer

❌ Debug khó

- Flow không tuyến tính

❌ Performance

- Notify nhiều observer

## 14. Ứng dụng thực tế

🔥 UI

 - Button click

 - Data binding

🔥 Backend

 - Domain events (DDD)

 - Logging system

 - Cache invalidation

🔥 System design

 - Kafka

 - RabbitMQ
