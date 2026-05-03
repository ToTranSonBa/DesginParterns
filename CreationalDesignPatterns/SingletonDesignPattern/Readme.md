# Singleton Design

## 1. Design Pattern là gì?
Singleton đảm bảo rằng:

 - Một class chỉ có duy nhất 1 instance
 - Cung cấp global access point tới instance đó

👉 Hiểu đơn giản:

> “Trong toàn bộ hệ thống, chỉ có 1 object được phép tồn tại”

---

## 2. Khi nào cần Singleton? (WHY)
Có những resource mà:

- Tạo nhiều instance là sai logic
- Hoặc tốn tài nguyên

Ví dụ:

 - Logger (ghi log)
 - Config (đọc config)
 - Cache
 - Connection pool
 - Thread pool

👉 Nếu có 2 logger → log bị phân tán
👉 Nếu có 2 config manager → inconsistency

---

## 3. Cách triển khai Singleton (HOW)

3.1 Basic (KHÔNG thread-safe ❌)

<pre>
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}
</pre>
❗ Problem:

 - Nếu multi-thread → có thể tạo nhiều instance

---

3.2 Thread-safe (lock)
<pre>

public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();
    private Singleton() { }
    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Singleton();
            }
            return _instance;
        }
    }
}
</pre>

👉 Fix được race condition
❗ Nhưng:

 - Lock mỗi lần gọi → performance kém
 
---

3.3 Double-checked locking (tốt hơn)

<pre>
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
}
</pre>

👉 Giảm số lần lock

---

3.4 Best practice trong C# (Lazy<T> ✅)
<pre>
public class Singleton
{
    private static readonly Lazy<Singleton> _instance =
        new Lazy<Singleton>(() => new Singleton());

    private Singleton() { }

    public static Singleton Instance => _instance.Value;
}
</pre>
👉 Ưu điểm:

 - Thread-safe
 - Lazy loading
 - Code clean
 
---

3.5 Eager Initialization
<pre>

public class Singleton
{
    private static readonly Singleton _instance = new Singleton();
    private Singleton() { }
    public static Singleton Instance => _instance;
}
</pre>

👉 Ưu:

 - Simple, thread-safe

❗ Nhược:

 - Tạo object ngay từ đầu → có thể waste resource
 
---

## 4. Khi nào NÊN dùng Singleton
### ✔ 1. Resource dùng chung toàn hệ thống
 - Logging system
 - Config manager
 - Cache manager

### ✔ 2. Stateless service
👉 Không cần nhiều instance

###✔ 3. Khi cần kiểm soát chặt lifecycle
 - Chỉ tạo 1 lần
 - Không cho bên ngoài new
---
