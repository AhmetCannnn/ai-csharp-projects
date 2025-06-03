using System;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        // Bağlantı dizesi
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\path_to_your_database\your_database.accdb;Persist Security Info=False;";

        // Veritabanına bağlantı oluştur
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            try
            {
                // Bağlantıyı aç
                connection.Open();
                Console.WriteLine("Veritabanına bağlantı başarılı.");

                // SQL komutunu oluştur
                string sqlQuery = "SELECT * FROM YourTableName"; // Örnek: Veritabanındaki tabloyu sorgulamak
                OleDbCommand command = new OleDbCommand(sqlQuery, connection);

                // Veriyi almak için SqlDataReader kullanabiliriz
                OleDbDataReader reader = command.ExecuteReader();

                // Veriyi ekrana yazdır
                while (reader.Read())
                {
                    Console.WriteLine(reader["ColumnName"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}
