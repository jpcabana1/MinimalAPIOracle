using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Models;
using System.Data;

namespace MinimalAPIOracle.Repositories
{
    public class NativeQueryRepository
    {
        private ModelContext _modelContext;

        string _queryProductDetails = "SELECT "
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

        public ICollection<ProductDetailsDAO> GetProductDetails()
        {

            List<ProductDetailsDAO> products = new List<ProductDetailsDAO>();
            using (var command = _modelContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = _queryProductDetails;
                command.CommandType = CommandType.Text;
                _modelContext.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(result);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ProductDetailsDAO product = new ProductDetailsDAO();
                        product.CustomerId = (decimal)row["customer_id"];
                        product.OrderId = (decimal)row["order_id"];
                        product.Status = (string)row["status"];
                        product.UnitPrice = (double)row["unit_price"];
                        product.Quantity = (double)row["quantity"];
                        product.Description = (string)row["description"];
                        products.Add(product);                       
                    }
                }
            }
            return products;
        }

     
    }
}
