using System;

namespace LW2
{
    class Program
    {
        static void Main( string[] args )
        {
            var word1 = "day";
            var word2 = "Today";

            var text = "Today is very good and sunny  day and  tomorrow will be very good day too";
            var calculator = new WordDistanceCalculator( text, word1, word2 );
            calculator.Calculate();

            Console.WriteLine( "Min distance = " + calculator.MinDistance );
            Console.WriteLine( "Max distance = " + calculator.MaxDistance );
        }
    }
}
