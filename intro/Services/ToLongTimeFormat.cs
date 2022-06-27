using System;

namespace intro.Services
{
    //Класс, который преобразует значение текущего объекта DateTime
    //в его эквивалентное строковое представление длинной даты.
    public class ToLongTimeFormat : IDateTime
    {
        public string date(string date)
        {
            date = DateTime.Now.ToLongDateString();
            return date;
        }

        public string time(string time)
        {
            time = DateTime.Now.ToLongTimeString();
            return time;
        }
    }
}
