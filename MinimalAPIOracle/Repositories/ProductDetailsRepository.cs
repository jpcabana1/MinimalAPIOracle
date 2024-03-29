﻿using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Models;
using System.Data;
using System.Data.Common;

namespace MinimalAPIOracle.Repositories
{
    public class ProductDetailsRepository
    {
        private readonly RawQueryRepository _RawQueryRepository;

        private readonly string _queryProductDetails = "SELECT "
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

        public ProductDetailsRepository(RawQueryRepository rawQueryRepository)
        {
            _RawQueryRepository = rawQueryRepository;
        }
      
        public async Task<ICollection<ProductDetailsDAO>> GetProductDetailsAsync()
        {
            Func<DbDataReader, ProductDetailsDAO> handleData = (row) =>
            {
                var product = new ProductDetailsDAO();
                product.CustomerId = (decimal)row["customer_id"];
                product.OrderId = (decimal)row["order_id"];
                product.Status = (string)row["status"];
                product.UnitPrice = (decimal)row["unit_price"];
                product.Quantity = (decimal)row["quantity"];
                product.Description = (string)row["description"];
                return product;
            };

            return await _RawQueryRepository.ExecuteRawQuery(_queryProductDetails, handleData);

        }

        public async Task<ICollection<ProductDetailsDAO>> GetProductDetailsAsyncByCustomerId(long CustomerId)
        {
            Func<DbDataReader, ProductDetailsDAO> handleData = (row) =>
            {
                var product = new ProductDetailsDAO();
                product.CustomerId = (decimal)row["customer_id"];
                product.OrderId = (decimal)row["order_id"];
                product.Status = (string)row["status"];
                product.UnitPrice = (decimal)row["unit_price"];
                product.Quantity = (decimal)row["quantity"];
                product.Description = (string)row["description"];
                return product;
            };

            string query = _queryProductDetails + "WHERE "
                                                + "cus.customer_id = @customerId";


            var parameters = new Dictionary<string, object>();
            parameters.Add("customerId", CustomerId);

            string query2 = @"
                    SELECT 
                        cus.customer_id, 
                        ord.order_id,
                        ord.status,
                        ordi.unit_price,
                        ordi.quantity,
                        prod.description 
                    FROM CUSTOMERS cus 
                    INNER JOIN ORDERS ord
                        ON cus.customer_id = ord.customer_id
                    LEFT JOIN ORDER_ITEMS ordi
                        ON ord.order_id = ordi.order_id
                    INNER JOIN PRODUCTS prod
                        ON ordi.product_id = prod.product_id
                    WHERE
                        cus.customer_id = @customerId
                ";

            return await _RawQueryRepository.ExecuteRawQuery(query, handleData, parameters);

        }
    
    }
}
