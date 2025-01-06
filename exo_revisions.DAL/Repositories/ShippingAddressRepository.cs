using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class ShippingAddressRepository : IShippingAddressRepository
{
    private readonly NpgsqlConnection _connection;

    public ShippingAddressRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<ShippingAddress> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""first_name"" AS ""FirstName"",
                ""last_name"" AS ""LastName"",
                ""address_line1"" AS ""AddressLine1"",
                ""address_line2"" AS ""AddressLine2"",
                ""city"" AS ""City"",
                ""postal_code"" AS ""PostalCode"",
                ""country"" AS ""Country"",
                ""phone_number"" AS ""PhoneNumber"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""shipping_addresses"";
        ";
        return _connection.Query<ShippingAddress>(query);
    }

    public ShippingAddress? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""first_name"" AS ""FirstName"",
                ""last_name"" AS ""LastName"",
                ""address_line1"" AS ""AddressLine1"",
                ""address_line2"" AS ""AddressLine2"",
                ""city"" AS ""City"",
                ""postal_code"" AS ""PostalCode"",
                ""country"" AS ""Country"",
                ""phone_number"" AS ""PhoneNumber"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""shipping_addresses""
            WHERE
                ""id"" = @Id;
        ";
        return _connection.QuerySingleOrDefault<ShippingAddress>(query);
    }

    public int Create(ShippingAddress shippingAddress)
    {
        const string query = @"
                INSERT INTO ""shipping_addresses"" (
                   ""first_name"",
                   ""last_name"",
                   ""address_line1"",
                   ""address_line2"",
                   ""city"",
                   ""postal_code"",
                   ""country"",
                   ""phone_number""
                   )
                VALUES (
                    @FirstName,
                    @LastName,
                    @AddressLine1,
                    @AddressLine2,
                    @City,
                    @PostalCode,
                    @Country,
                    @PhoneNumber
                    )
                RETURNING ""id"" AS ""Id"";
        ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
        });

        return resultId;
    }

    public bool Update(ShippingAddress shippingAddress)
    {
        const string query = @"
            UPDATE ""shipping_addresses"" SET
                ""first_name"" = @FirstName,
                ""last_name"" = @LastName,
                ""address_line1"" = @AddressLine1,
                ""address_line2"" = @AddressLine2,
                ""city"" = @City,
                ""postal_code"" = @PostalCode,
                ""country"" = @Country,
                ""phone_number"" = @PhoneNumber
            WHERE ""id"" = @Id;
            ";
        int affectedRows = _connection.Execute(query, new
        {
            Id = shippingAddress.Id,
            FirstName = shippingAddress.FirstName,
            LastName = shippingAddress.LastName,
            AddressLine1 = shippingAddress.AddressLine1,
            AddressLine2 = shippingAddress.AddressLine2,
            City = shippingAddress.City,
            PostalCode = shippingAddress.PostalCode,
            Country = shippingAddress.Country,
            PhoneNumber = shippingAddress.PhoneNumber,
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""shipping_addresses"" WHERE ""id"" = @Id";
        int affectedRows = _connection.Execute(query, new {Id = id});
        return affectedRows > 0;
    }
}