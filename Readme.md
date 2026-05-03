# Design Partern

## 1. Design Partern là gì?
 Design Pattern (mẫu thiết kế) là các “cách giải quyết đã được chuẩn hóa” cho những vấn đề lặp đi lặp lại trong thiết kế phần mềm. Nó không phải là code cụ thể, mà là ý tưởng / khuôn mẫu để có thể áp dụng linh hoạt.

 ---
 ## 2. Tại sao cần Design Partern?

### 2.1 Giải quyết các vấn đề lặp lại (proven solutions)

Trong thực tế, dev thường gặp các vấn đề giống nhau:

- Tạo object phức tạp
- Giảm phụ thuộc giữa các class
- Thay đổi logic runtime
- Xử lý event giữa nhiều object

👉 Design Pattern là những cách giải đã được kiểm chứng (best practice), không cần phải nghiên cứu và thiết kế lại.

---
### 2.2 Giảm coupling (phụ thuộc chặt)

Không dùng pattern, code thường kiểu:
<pre>
var payment = new PaypalService();
payment.Pay();
</pre>

👉 Class bị phụ thuộc cứng vào PaypalService

Khi đổi sang Stripe? → phải sửa code

---

Dùng pattern (ví dụ Strategy + DI):
<pre>
IPaymentService payment;
payment.Pay();
</pre>

👉 Có thể thay đổi implementation mà không sửa logic chính

---

### 2.3 Dễ mở rộng (Open/Closed Principle)

Nguyên lý OOP quan trọng:

👉 “Mở để mở rộng, đóng để sửa”

Ví dụ không dùng pattern:

<pre>
if(type == "A") ...
else if(type == "B") ...
else if(type == "C") ...
</pre>

---

Dùng Strategy Pattern:
- Thêm class mới
- Không sửa code cũ

👉 Code scale tốt hơn rất nhiều

---

### 2.4 Tăng khả năng maintain (bảo trì)

Code không có pattern thường:

- Logic dính chặt
- Khó đọc
- Khó debug

---

Code có pattern:

- Rõ trách nhiệm từng class
- Dễ đọc hơn
- Dễ test

---

### 2.5 Giúp thiết kế hệ thống tốt hơn (quan trọng nhất)

Design Pattern giúp bạn:

- Nhìn vấn đề ở level architecture
- Không chỉ là “viết code chạy được”
- Mà là “viết code sống lâu”

---

## 3. Khi nào KHÔNG nên dùng Design Pattern?

Đừng lạm dụng. Nếu:

- Project nhỏ
- Logic đơn giản
- Không cần mở rộng

👉 Dùng pattern = over-engineering (quá phức tạp)

---

## 4. Phân loại Design Pattern

Có 3 nhóm chính:

### 1. Creational (tạo đối tượng)

👉 Tập trung vào cách tạo object

Các pattern tiêu biểu:

 - Singleton
    - Chỉ có 1 instance duy nhất
    - Ví dụ: config, logger
 
 - Factory Method
   - Tạo object thông qua method thay vì new trực tiếp
   - Giúp loose coupling

 - Abstract Factory
   - Tạo họ các object liên quan
   - Ví dụ: UI theme (Dark/Light → button, textbox...)

 - Builder
   - Xây dựng object phức tạp từng bước
   - Ví dụ: tạo object có nhiều field optional

 - Prototype
   - Tạo object bằng cách clone
   - Dùng khi object tạo tốn chi phí

### 2. Structural (cấu trúc)
👉 Tập trung vào cách tổ chức class/object

Các pattern tiêu biểu:
 - Adapter
   - Chuyển interface này → interface khác
   - Ví dụ: dùng API cũ trong hệ thống mới

 - Decorator
   - Thêm chức năng vào object mà không sửa class gốc
   - Ví dụ: logging, caching

 - Facade
   - Tạo interface đơn giản cho hệ thống phức tạp
   - Ví dụ: gọi 1 method thay vì nhiều service

 - Composite
    - Tổ chức object dạng cây (tree)
    - Ví dụ: file system (folder + file)

 - Proxy
    - Đứng trung gian kiểm soát truy cập
    - Ví dụ: lazy loading, auth

 - Bridge
    - Tách abstraction và implementation
    - Giúp thay đổi độc lập

 - Flyweight
    - Tối ưu bộ nhớ bằng cách chia sẻ object

### 3. Behavioral Patterns (Hành vi)

👉 Tập trung vào cách object giao tiếp với nhau

Các pattern tiêu biểu:

 - Observer
    - 1 thay đổi → nhiều object nhận thông báo
    - Ví dụ: event, pub/sub
 - Strategy
    - Thay đổi thuật toán runtime
    - Ví dụ: nhiều cách tính giá, chọn runtime

 - Command
    - Đóng gói request thành object
    - Dùng cho undo/redo

 - State
    - Object thay đổi hành vi theo trạng thái
    - Ví dụ: order (Pending → Paid → Shipped)

 - Template Method
    - Định nghĩa khung xử lý, subclass override chi tiết

 - Mediator
    - Giảm coupling giữa nhiều object
    - Có “trung gian” điều phối

 - Chain of Responsibility
    - Xử lý request qua chuỗi handler
    - Ví dụ: middleware

 - Iterator
    - Duyệt collection mà không lộ cấu trúc

 - Memento
    - Lưu và restore trạng thái

 - Visitor
    - Thêm hành vi vào object mà không sửa class
