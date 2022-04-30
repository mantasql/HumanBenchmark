using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    private string databaseName = "URI=file:HumanBenchmark.db";
    //private string loggedInUser;

    void Start()
    {
        CreateDB();
        //CreateUser("Mantas", "Slaptazodis");
        GetUsers();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS USERS (username VARCHAR(20), password VARCHAR(20));";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public bool CreateUser(string username, string password)
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();

            if (DoesUserExist(connection, username)) { connection.Close(); return false; }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO USERS (username, password) VALUES ('" + username + "', '" + password + "');";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        return true;
    }

    public bool DeleteUser(string username)
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM USERS WHERE username = '" + username + "';";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        return true;
    }

    public void GetUsers()
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM USERS";

                using (System.Data.IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Username: " + reader["username"] + ", Password: " + reader["password"]);
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }
    }

    public bool DoesUserExist(SqliteConnection sqlLiteConnection, string username)
    {
        using (var command = sqlLiteConnection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM USERS WHERE username = '" + username + "';";

            using (System.Data.IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (username.Equals(reader["username"]))
                    {
                        Debug.Log("User with such username '" + reader["username"] + "' already exists!");
                        reader.Close();
                        return true;
                    }
                }

                reader.Close();
            }

            return false;
        }
    }

    public bool DoesUserExist(string username)
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();
            bool result = DoesUserExist(connection, username);
            connection.Close();

            return result;
        }
    }

    public bool VerifyLogin(string username, string password)
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM USERS WHERE username = '{username}' AND password = '{password}';";
                using (System.Data.IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (username.Equals(reader["username"]))
                        {
                            PlayerPrefs.SetString("loggedInUser", username);
                            connection.Close();
                            reader.Close();
                            return true;
                        }
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }

        return false;
    }

    public string GetLoggedInUser()
    {
        return PlayerPrefs.GetString("loggedInUser");
    }
}
