using System;

namespace LW3
{
    class Program
    {
        static void Main( string[] args )
        {
            var notepad = new Notepad();
            var inputString = String.Empty;
            Console.WriteLine( GetHelpText() );
            while ( ( inputString = Console.ReadLine() ) != "exit" )
            {
                var inputItems = inputString.Split();
                if ( inputItems.Length != 2 )
                {
                    Console.WriteLine( GetHelpText() );
                }
                else
                {
                    if ( inputItems[ 0 ].ToLower() == "add" )
                    {
                        notepad.Add( inputItems[ 1 ] );
                    }
                    else if ( inputItems[ 0 ].ToLower() == "find" )
                    {
                        var foundCount = notepad.Find( inputItems[ 1 ] );
                        Console.WriteLine( foundCount );
                    }
                }
            }
        }

        public static string GetHelpText()
        {
            return "To add user write \"Add <name>\", to find count write \"Find <name>\". To exit write \"Exit\"";
        }
    }
}
