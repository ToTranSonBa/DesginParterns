using State.Implements;

class Program
{
    static void Main()
    {
        var vm = new VendingMachine();

        vm.PressButton();

        vm.InsertCoin();

        vm.PressButton();
    }
}