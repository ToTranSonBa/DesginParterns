# Command Pattern

## 1.Command Pattern là gì?

Command Pattern là một trong những Behavioral Design Pattern, dùng để đóng gói một request (yêu cầu) thành một object, từ đó bạn có thể truyền, lưu trữ, undo/redo hoặc queue các request một cách linh hoạt.

## 2.Ý tưởng cốt lõi

Thay vì gọi trực tiếp:
<pre>
light.TurnOn();
</pre>

→ bạn tạo một object đại diện cho hành động đó:

<pre>
var command = new TurnOnLightCommand(light);
command.Execute();
</pre>

## 3. Cấu trúc của Command Pattern

<image src="./command_pattern_uml_diagram.jpg" width="600" />

Các thành phần chính:

1. Command (interface / abstract)
<pre>
public interface ICommand
{
    void Execute();
}
</pre>

2. ConcreteCommand (các command cụ thể)
<pre>
public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}
</pre>


3. Receiver (đối tượng thực thi logic)
<pre>
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}
</pre>

4. Invoker (người gọi command)
<pre>
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}
</pre>

5. Client (nơi setup)
<pre>
var light = new Light();

ICommand turnOn = new TurnOnLightCommand(light);

var remote = new RemoteControl();
remote.SetCommand(turnOn);

remote.PressButton();
</pre>

## 4. Luồng hoạt động

1. Client tạo Receiver
2. Client tạo ConcreteCommand (gắn Receiver vào)
3. Client đưa command cho Invoker
4. Invoker gọi Execute()
5. Command gọi logic trong Receiver

👉 Invoker không biết logic bên trong

## 5. Ưu điểm

✔ 1. Loose coupling (tách rời)

Invoker không cần biết:

 - object nào xử lý
 - xử lý như thế nào

 ✔ 2. Dễ mở rộng (Open/Closed Principle)

 Thêm command mới → không sửa code cũ

 ✔ 3. Hỗ trợ Undo / Redo
 Có thể thêm:
 <pre>
 void Undo();
</pre>

✔ 4. Dễ implement Queue / Log / Macro

 - Queue command
 - Ghi log
 - Gom nhiều command thành 1 macro


## 6. Nhược điểm

❌ 1. Tăng số lượng class

Mỗi hành động → 1 class

→ project nhỏ sẽ bị overkill


❌ 2. Code phức tạp hơn

So với gọi trực tiếp:

<pre>
light.TurnOn();
</pre>
→ phải đi qua nhiều lớp


## 7. Khi nào nên dùng Command Pattern?

1. Undo / Redo

 - Editor (Word, Photoshop)
 - Game

2. Queue / Delay / Retry

 - Job queue
 - Background task

 3. Tách UI và Business Logic

 Ví dụ:

 - Button → không gọi logic trực tiếp
 - chỉ gọi command

 4. Logging / Auditing

Ghi lại tất cả hành động

5. Macro Command (gộp nhiều hành động)

<pre>
public class MacroCommand : ICommand
{
    private List<ICommand> _commands;

    public void Execute()
    {
        foreach (var cmd in _commands)
        {
            cmd.Execute();
        }
    }
}
</pre>

---

## Invoker trong Command Pattern là:
👉 Đối tượng chịu trách nhiệm gọi (trigger) Command, nhưng không biết logic bên trong command làm gì.

Hiểu đơn giản

Invoker giống như:

 - 🔘 Button (nút bấm)
 - 🎮 Remote control
 - ⌨️ Keyboard shortcut

👉 Nó chỉ biết:
“Khi có sự kiện → gọi Execute()”

##

Vai trò chính của Invoker

 - Nhận command
 - Lưu command (có thể)
 - Gọi command.Execute()

👉 Không chứa business logic

##
<pre>

</pre>