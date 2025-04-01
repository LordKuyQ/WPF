using System;

namespace WpfAppAgeenko
{
    public class Проект
    {
        public long id { get; set; }
        public DateTime дата_начала { get; set; }
        public DateTime? дата_конца { get; set; }
        public long? цена { get; set; }
    }

    public class Площадь
    {
        public long id { get; set; }
        public long? координаты { get; set; }
        public long? площадь { get; set; }
    }

    public class Профиль
    {
        public long id { get; set; }
        public long длина { get; set; }
        public long? высота { get; set; }
        public string описание { get; set; }
    }

    public class Пункты_наблюд
    {
        public long id { get; set; }
        public long x { get; set; }
        public long y { get; set; }
    }

    public class Измерения
    {
        public long id { get; set; }
        public long давление { get; set; }
        public string описание { get; set; }
    }


}
