using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class MusicService
{
    private string connectionString = "Server=DESKTOP-I3VRN68;Database=PLAYLISTS;Integrated Security=True;";

    public void CreateMusic(string name, int duration, int categoryID, int artistID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Musics (Name, Duration, CategoryID, ArtistID) VALUES (@Name, @Duration, @CategoryID, @ArtistID)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Music GetMusicById(int musicID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Musics WHERE MusicID = @MusicID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@MusicID", musicID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Music
                        {
                            MusicID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Duration = reader.GetInt32(2),
                            CategoryID = reader.GetInt32(3),
                            ArtistID = reader.GetInt32(4),
                        };
                    }
                }
            }
        }
        return null;
    }

    public void DeleteMusic(int musicID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Musics WHERE MusicID = @MusicID";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@MusicID", musicID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Music> GetAllMusic()
    {
        List<Music> musicList = new List<Music>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Musics";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        musicList.Add(new Music
                        {
                            MusicID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Duration = reader.GetInt32(2),
                            CategoryID = reader.GetInt32(3),
                            ArtistID = reader.GetInt32(4),
                        });
                    }
                }
            }
        }
        return musicList;
    }
}

public class ArtistService
{
    private string connectionString = "Server=DESKTOP-I3VRN68;Database=PLAYLISTS;Integrated Security=True;";

    public void CreateArtist(string name, string surname, DateTime birthday, string gender)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Artists (Name, Surname, Birthday, Gender) VALUES (@Name, @Surname, @Birthday, @Gender)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Artist GetArtistById(int artistID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Artists WHERE ArtistID = @ArtistID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Artist
                        {
                            ArtistID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Birthday = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                        };
                    }
                }
            }
        }
        return null;
    }

    public void DeleteArtist(int artistID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Artists WHERE ArtistID = @ArtistID";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Artist> GetAllArtists()
    {
        List<Artist> artistList = new List<Artist>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Artists";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artistList.Add(new Artist
                        {
                            ArtistID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Birthday = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                        });
                    }
                }
            }
        }
        return artistList;
    }
}

public class Music
{
    public int MusicID { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int CategoryID { get; set; }
    public int ArtistID { get; set; }
}

public class Artist
{
    public int ArtistID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; }
}

class Program
{
    static void Main()
    {
        
        ArtistService artistService = new ArtistService();
        MusicService musicService = new MusicService();

     
    }
}
