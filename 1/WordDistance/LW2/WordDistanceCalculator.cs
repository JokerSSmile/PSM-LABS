using System;
using System.Collections.Generic;
using System.Linq;

namespace LW2
{
    public class WordDistanceCalculator
    {
        private List<int> _firstWordPositions;
        private List<int> _secondWordPositions;

        private string _word1;
        private string _word2;
        private string[] _splittedWords;

        public int MinDistance { get; private set; }
        public int MaxDistance { get; private set; }

        public WordDistanceCalculator( string text, string word1, string word2 )
        {
            _word1 = word1.ToLower();
            _word2 = word2.ToLower();
            // разобъем текст по словам
            _splittedWords = text.Split( new char[ 0 ], StringSplitOptions.RemoveEmptyEntries ).Select( w => w.ToLower() ).ToArray();
        }

        /// <summary>
        /// Рассчитаем все данные
        /// </summary>
        public void Calculate()
        {
            FillWordsPositions();
            MaxDistance = FindMaxDistance();
            MinDistance = FindMinDistance();
        }

        /// <summary>
        /// Распарсив входящую строку заполним позиции требуемых слов
        /// </summary>
        private void FillWordsPositions()
        {
            _firstWordPositions = new List<int>();
            _secondWordPositions = new List<int>();

            for ( int i = 0; i < _splittedWords.Length; ++i )
            {
                var word = _splittedWords[ i ].ToLower();
                if ( word == _word1 )
                {
                    _firstWordPositions.Add( i );
                }
                else if ( word == _word2 )
                {
                    _secondWordPositions.Add( i );
                }
            }
        }

        /// <summary>
        /// Найдем минимальную позицию как наибольшую дистанцию между найденными позициями
        /// </summary>
        /// <returns> Максимальное количество слов между заданными словами, либо -1, если какого то из слов не найдено </returns>
        private int FindMaxDistance()
        {
            if ( _firstWordPositions.Count == 0 || _secondWordPositions.Count == 0 )
            {
                return -1;
            }

            var firstDfference = Math.Abs( _firstWordPositions.Min() - _secondWordPositions.Max() );
            var secondDfference = Math.Abs( _secondWordPositions.Min() - _firstWordPositions.Max() );
            return Math.Max( firstDfference, secondDfference ) - 1;
        }

        /// <summary>
        /// Пройдемся по всем найденным позициям и найдем минимальное расстояние
        /// </summary>
        /// <returns> Минимальное количество слов между заданными словами, либо -1, если какого то из слов не найдено </returns>
        private int FindMinDistance()
        {
            if ( _firstWordPositions.Count == 0 || _secondWordPositions.Count == 0 )
            {
                return -1;
            }

            var minDistance = Int32.MaxValue;
            foreach ( var firstWordPosition in _firstWordPositions )
            {
                foreach ( var secondWordPosition in _secondWordPositions )
                {
                    var currentDistance = Math.Abs( secondWordPosition - firstWordPosition );
                    if ( currentDistance == 0 )
                    {
                        return 0;
                    }

                    if ( currentDistance < minDistance )
                    {
                        minDistance = currentDistance;
                    }
                }
            }

            return minDistance - 1;
        }
    }
}
