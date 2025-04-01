using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfAppAgeenko.Models
{
    internal class database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=DBSRV\PH2024;Database=учебная_nikitinda;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");

        // Метод для открытия соединения с БД
        public void OpenConnection()
        {
            // Если состояние строки закрыто, открываем подключение
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        // Метод для закрытия соединения с БД
        public void CloseConnection()
        {
            // Если состояние строки открыто, закрываем его
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        // Метод для возвращения строки подключения
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public DataTable SelectData(string query)
        {
            // формируем команду, передаем в нее ваш запрос и ссылку на БД(строка подключения)
            SqlCommand sqlCommand = new SqlCommand(query, GetConnection());
            // Через адаптер передаем эту команду
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            // Создаем виртуальную таблицу – будет хранить результат запроса
            DataTable dataTable = new DataTable();
            // через адаптер заполняем эту таблицу
            adapter.Fill(dataTable);
            // и возвращаем ее
            return dataTable;
        }

    }
}
