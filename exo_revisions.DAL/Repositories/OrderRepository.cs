using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly NpgsqlConnection _connection;

    public OrderRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Order> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""order_date"" AS ""OrderDate"",
                ""status"" AS ""Status"",
                ""total_amount"" AS ""TotalAmount"",
                ""shipping_address_id"" AS ""ShippingAddressId""
            FROM
                ""orders"";
        ";
        return _connection.Query<Order>(query);
    }

    public Order? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""order_date"" AS ""OrderDate"",
                ""status"" AS ""Status"",
                ""total_amount"" AS ""TotalAmount"",
                ""shipping_address_id"" AS ""ShippingAddressId""
            FROM
                ""orders""
            WHERE
                ""id"" = @Id;
        ";
        return _connection.QuerySingleOrDefault<Order>(query, new {Id = id});
    }

    public Order? GetByEmail(string email)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""order_date"" AS ""OrderDate"",
                ""status"" AS ""Status"",
                ""total_amount"" AS ""TotalAmount"",
                ""shipping_address_id"" AS ""ShippingAddressId""
            FROM
                ""orders""
            WHERE
                ""email"" = @Email;
        ";
        return _connection.QuerySingleOrDefault<Order>(query, new {Email = email});
    }

    public IEnumerable<Order> GetAllByEmail(string email)
    {
        const string query = @"
        SELECT
            ""id"" AS ""Id"",
            ""email"" AS ""Email"",
            ""order_date"" AS ""OrderDate"",
            ""status"" AS ""Status"",
            ""total_amount"" AS ""TotalAmount"",
            ""shipping_address_id"" AS ""ShippingAddressId""
        FROM
            ""orders""
        WHERE
            ""email"" = @Email;
    ";

        return _connection.Query<Order>(query, new { Email = email });
    }

    public int Create(Order order)
    {
        const string query = @"
                INSERT INTO ""orders"" (
                   ""email"",
                   ""order_date"",
                   ""status"",
                   ""total_amount"",
                   ""shipping_address_id""
                   )
                VALUES (
                    @Email,
                    @OrderDate,
                    @Status,
                    @TotalAmount,
                    @ShippingAddressId
                    )
                RETURNING ""id"" AS ""Id"";
        ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId
        });

        return resultId;
    }

    public bool Update(Order order)
    {
        const string query = @"
            UPDATE ""orders"" SET
                ""email"" = @Email,
                ""order_date"" = @OrderDate,
                ""status"" = @Status,
                ""total_amount"" = @TotalAmount,
                ""shipping_address_id"" = @ShippingAddressId
            WHERE ""id"" = @Id;
            ";
        int affectedRows = _connection.Execute(query, new
        {
            Id = order.Id,
            Email = order.Email,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddressId = order.ShippingAddressId
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""orders"" WHERE ""id"" = @Id";
        int affectedRows = _connection.Execute(query, new {Id = id});
        return affectedRows > 0;
    }
}