namespace DupperFundamental.Lambda;

public class Program
{
    public delegate void SayHello(Action callback);
    
    public void Main(string[] args)
    {
        /*
         * Lambda Expression
         * Didefinisikan dalam bahasa pemrograman adalah anonymous function, yang artinya method/function tanpa nama
         *
         * 2 tips lambda espression yang digunakan di C#
         * - lambda expression: dimana body nya sebagai expression
         * - Statement lambda: dimana memiliki block code sebagai bodynya
         */

        // =========================== Anonymous Function / lamda espression ===========================
        var square = (int x) => x * x;
        Console.WriteLine(square(10));

        // =========================== Statement lambda ===========================
        var sayHello = () =>
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Halo Dunia");
        };
        sayHello();
        
        // =========================== Dengan callback ===========================
        // SayHello sayHelloCallback = (Action callback) =>         // => bisa seperti ini karena dobuat global dengan delegate
        var sayHelloCallback = (Action callback) =>    // => defaultnya seperti ini 
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Call callback function in sayHelloCallback function");
            callback();
        };

        var callback = () =>
        {
            Console.WriteLine("This is callback function");
        };

        sayHelloCallback(callback);
    }
}