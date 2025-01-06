using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NpgsqlConnection _connection;

    public UserRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public User? Login(string email)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""password"" AS ""Password""
            FROM
                ""users""
            WHERE
                ""email"" = @Email
        ";
        return _connection.QueryFirstOrDefault<User>(query, new {Email = email});
    }
}