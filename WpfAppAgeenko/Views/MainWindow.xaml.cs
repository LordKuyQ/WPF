using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppAgeenko.Models;
using System.Data;
using System;

namespace WpfAppAgeenko
{
    public partial class MainWindow : Window
    {
        public List<Проект> проекты { get; set; }
        public List<Площадь> площади { get; set; }
        public List<Профиль> профили { get; set; }
        public List<Пункты_наблюд> пунктыНаблюдения { get; set; }
        public List<Измерения> измерения { get; set; }

        database DB = new database();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            DB.OpenConnection();

            проекты = DB.SelectData("SELECT * FROM Проект").AsEnumerable()
                .Select(row => new Проект
                {
                    id = row.Field<long>("id"),  
                    дата_начала = row.Field<DateTime>("дата_начала"),
                    дата_конца = row.Field<DateTime?>("дата_конца"),
                    цена = row.Field<long?>("цена")  
                }).ToList();

            площади = DB.SelectData("SELECT * FROM Площадь").AsEnumerable()
                .Select(row => new Площадь
                {
                    id = row.Field<long>("id"),  
                    координаты = row.Field<long?>("координаты"),  
                    площадь = row.Field<long?>("площадь")  
                }).ToList();

            профили = DB.SelectData("SELECT * FROM Профиль").AsEnumerable()
                .Select(row => new Профиль
                {
                    id = row.Field<long>("id"),  
                    длина = row.Field<long>("длина"),  
                    высота = row.Field<long?>("высота"),  
                    описание = row.Field<string>("описание")
                }).ToList();

            пунктыНаблюдения = DB.SelectData("SELECT * FROM Пункты_наблюд").AsEnumerable()
                .Select(row => new Пункты_наблюд
                {
                    id = row.Field<long>("id"),  
                    x = row.Field<long>("x"),  
                    y = row.Field<long>("y")  
                }).ToList();

            измерения = DB.SelectData("SELECT * FROM Измерения").AsEnumerable()
                .Select(row => new Измерения
                {
                    id = row.Field<long>("id"),  
                    давление = row.Field<long>("давление"),  
                    описание = row.Field<string>("описание")
                }).ToList();

            DB.CloseConnection();
        }
    }

}
