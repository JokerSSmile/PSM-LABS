using System.Collections.Generic;

namespace LW3
{
    public class Notepad
    {
        private HashSet<string> _names;
        private Dictionary<string, int> _prefixesCount;

        public Notepad()
        {
            _names = new HashSet<string>();
            _prefixesCount = new Dictionary<string, int>();
        }

        /// <summary>
        /// Добавляет имя и просчитывает префиксы
        /// </summary>
        /// <param name="name"></param>
        public void Add( string name )
        {
            // если такое имя уже было - ничего не делаем
            if ( _names.Add( name ) )
            {
                for ( int i = 1; i <= name.Length; ++i )
                {
                    // для каждого префикса имени инкрементируем (или создаем) значения в словаре с количеством данных префиксов
                    var key = name.Substring( 0, i );
                    if ( !_prefixesCount.ContainsKey( key ) )
                    {
                        _prefixesCount.Add( key, 1 );
                        continue;
                    }

                    _prefixesCount[ key ] = ++_prefixesCount[ key ];
                }
            }
        }

        /// <summary>
        /// Поиск имен с заданным префиксом по словарю со всеми значениями инкрементов
        /// </summary>
        /// <param name="namePrefix"></param>
        /// <returns></returns>
        public int Find( string namePrefix )
        {
            _prefixesCount.TryGetValue( namePrefix, out int namesWithPrefixCount );
            return namesWithPrefixCount;
        }
    }
}
