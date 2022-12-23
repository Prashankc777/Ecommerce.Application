using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Infrastructure
{
    public interface IConnectionFactory
    {
        SqlConnection GetConnection { get; }
    }
    internal class ConnectionFactory :IConnectionFactory
    {
        private readonly IConfiguration Configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public SqlConnection GetConnection
        {
            get
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection") as string;
                return new SqlConnection(connectionString);
            }
        }

    }
}
