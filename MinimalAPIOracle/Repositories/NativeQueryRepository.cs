using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Models;
using System.Data;
using System.Data.Common;

namespace MinimalAPIOracle.Repositories
{
    public class NativeQueryRepository
    {
        private readonly ModelContext _modelContext;

        readonly string _queryProductDetails = "SELECT "
                            + "    cus.customer_id, "
                            + "    ord.order_id, "
                            + "    ord.status,"
                            + "    ordi.unit_price, "
                            + "    ordi.quantity, "
                            + "    prod.description "
                            + "FROM CUSTOMERS cus "
                            + "INNER JOIN ORDERS ord "
                            + "    ON cus.customer_id = ord.customer_id "
                            + "LEFT JOIN ORDER_ITEMS ordi "
                            + "    ON ord.order_id = ordi.order_id "
                            + "INNER JOIN PRODUCTS prod "
                            + "    ON ordi.product_id = prod.product_id ";


        public NativeQueryRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<ICollection<ProductDetailsDAO>> GetProductDetails()
        {

            List<ProductDetailsDAO> products = new List<ProductDetailsDAO>();
            using (DbCommand command = _modelContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = _queryProductDetails;
                command.CommandType = CommandType.Text;
                _modelContext.Database.OpenConnection();

                using (DbDataReader result = await command.ExecuteReaderAsync())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(result);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        products.Add(ExtrackProductDetails(row));
                    }
                }
            }
            return products;
        }

        private ProductDetailsDAO ExtrackProductDetails(DataRow row)
        {
            ProductDetailsDAO product = new ProductDetailsDAO();
            product.CustomerId = (decimal)row["customer_id"];
            product.OrderId = (decimal)row["order_id"];
            product.Status = (string)row["status"];
            product.UnitPrice = (double)row["unit_price"];
            product.Quantity = (double)row["quantity"];
            product.Description = (string)row["description"];
            return product;
        }

    }
}
