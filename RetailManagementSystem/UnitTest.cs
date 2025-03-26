using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using System.Reflection;
using RetailManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RetailManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace RetailManagementSystem
{
    [TestFixture]
    public class Tests : IDisposable
    {
        public static List<String> failMessage = new List<String>();
        public static String failureMsg = "";
        public static int failcnt = 1;
        public int totalTestcases = 0;

        public int userport;
        public string appURL;
        RestClient client;

        Assembly assem;
        String assemblyName = "RetailManagementSystem";

        [OneTimeSetUp]
        public void Setup()
        {
            //IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //DbContextOptions<RetailContext> options = new DbContextOptionsBuilder<RetailContext>()
            //.UseSqlServer(configuration.GetConnectionString("DBConnection"))
            //.Options;

            //userport = Int32.Parse(Environment.GetEnvironmentVariable("userport"));
            //client = new RestClient("http://localhost:" + userport);
            client = new RestClient("http://localhost:5056");

            String msg = "";

            try
            {
                assem = Assembly.Load(assemblyName);
            }
            catch (Exception e)
            {
                Assert.Fail(msg + "Could not Load Assembly");
            }
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (totalTestcases > 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    foreach (string line in failMessage)
                    {
                        //Console.WriteLine("line " + line);
                        file.WriteLine(line);
                    }
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    file.WriteLine("error");
                }
            }
            //_driver.Quit();
            //_driver.Dispose();
        }

        public void ExceptionCatch(string functionName, string catchMsg, string msg, string msg_name, string exceptionMsg = "")
        {
            failMessage.Add(functionName);

            if (msg == "")
            {
                msg = exceptionMsg + (exceptionMsg != "" ? " - " : "") + catchMsg + "\n";
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
            }
            else
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

            failureMsg += msg_name;
            failcnt++;
            Assert.Fail(msg);
        }

        IRestResponse response = null;

        [Test, Order(1)]
        public void Test1_Check_Properties_Product()
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Product");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("Name", "String");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Name", propertyType: "String");
                }

                IsFound = tb.HasProperty("Price", "Decimal");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Price", propertyType: "decimal");
                }
               
                IsFound = tb.HasProperty("OrderItems", "ICollection`1");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "OrderItems", propertyType: "ICollection<OrderItem>");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(2)]
        public void Test2_Check_Properties_Customer()
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Customer");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("Name", "String");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Name", propertyType: "String");
                }

                IsFound = tb.HasProperty("Orders", "ICollection`1");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Orders", propertyType: "ICollection<Order>");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(3)]
        public void Test3_Check_Properties_Order()
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Order");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("OrderDate", "DateTime");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "OrderDate", propertyType: "DateTime");
                }

                IsFound = tb.HasProperty("CustomerId", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "CustomerId", propertyType: "int");
                }

                IsFound = tb.HasProperty("Customer", "Customer");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Customer", propertyType: "Customer");
                }

                IsFound = tb.HasProperty("OrderItems", "ICollection`1");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "OrderItems", propertyType: "ICollection<OrderItem>"); 
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(4)]
        public void Test4_Check_Properties_OrderItem()
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "OrderItem");
            try
            {
                var IsFound = tb.HasProperty("OrderId", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "OrderId", propertyType: "int");
                }

                IsFound = tb.HasProperty("Order", "Order");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Order", propertyType: "Order");
                }

                IsFound = tb.HasProperty("ProductId", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "ProductId", propertyType: "int");
                }

                IsFound = tb.HasProperty("Product", "Product");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Product", propertyType: "Product");
                }

                IsFound = tb.HasProperty("Quantity", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Quantity", propertyType: "int");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }        

        [Test, Order(5)]
        public void Test5_Check_DataAnnotations_Product() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Product");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }

        [Test, Order(6)]
        public void Test6_Check_DataAnnotations_Customer() 
        {
            totalTestcases++; 
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Customer");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }

        [Test, Order(7)]
        public void Test7_Check_DataAnnotations_Order() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Models", "Order");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }           
        [Test, Order(8)]
        public void Test8_Check_Methods_IProduct() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Interfaces", "IProduct");
            try
            {
                var IsFound = tb.HasMethod("AddProduct", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "RetailManagementSystem.Models.Product" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "AddProduct", methodType: "Task<bool>", new string[] { "Product" }, "IProduct");
                }

                IsFound = tb.HasMethod("UpdateProductPrice", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "System.Int32", "System.Decimal" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "UpdateProductPrice", methodType: "Task<bool>", new string[] { "int","decimal" }, "IProduct");
                }

                IsFound = tb.HasMethod("DeleteProduct", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "System.Int32" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "DeleteProduct", methodType: "Task<bool>", new string[] { "int" }, "IProduct");
                }

                IsFound = tb.HasMethod("GetProductWithHighestOrderQuantity", "System.Threading.Tasks.Task`1[RetailManagementSystem.Models.Product]", new string[] {  });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetProductWithHighestOrderQuantity", methodType: "Task<Product>", new string[] { }, "IProduct");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(9)]
        public void Test9_Check_Methods_ICustomer() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Interfaces", "ICustomer");
            try
            {

                var IsFound = tb.HasMethod("GetCustomersWithRecentOrders", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[RetailManagementSystem.Models.Customer]]", new string[] { "System.DateTime" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetCustomersWithRecentOrders", methodType: "Task<IEnumerable<Customer>>", new string[] { "DateTime" }, "ICustomer");
                }

                IsFound = tb.HasMethod("GetCustomerWithHighestOrderCount", "System.Threading.Tasks.Task`1[RetailManagementSystem.Models.Customer]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetCustomerWithHighestOrderCount", methodType: "Task<Customer>", new string[] { }, "ICustomer");
                }

                IsFound = tb.HasMethod("GetCustomerWithMostSpentAmount", "System.Threading.Tasks.Task`1[RetailManagementSystem.Models.Customer]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetCustomerWithMostSpentAmount", methodType: "Task<Customer>", new string[] { }, "ICustomer");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(10)]
        public void Test10_Check_Methods_IOrder() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("RetailManagementSystem", "RetailManagementSystem.Interfaces", "IOrder");
            try
            {

                var IsFound = tb.HasMethod("GetOrdersByCustomer", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[RetailManagementSystem.Models.Order]]", new string[] { "System.Int32" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetOrdersByCustomer", methodType: "Task<IEnumerable<Order>>", new string[] { "int" }, "IOrder");
                }

                IsFound = tb.HasMethod("GetOrdersInDateRange", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[RetailManagementSystem.Models.Order]]", new string[] { "System.DateTime", "System.DateTime" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetOrdersInDateRange", methodType: "Task<IEnumerable<Order>>", new string[] { "DateTime", "DateTime" }, "IOrder");
                }

                IsFound = tb.HasMethod("GetOrderWithHighestTotalAmount", "System.Threading.Tasks.Task`1[RetailManagementSystem.Models.Order]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetOrderWithHighestTotalAmount", methodType: "Task<Order>", new string[] { }, "IOrder");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(11)]
        public void Test11_CheckForInheritance_ProductRepository() 
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "ProductRepository";

            Type repClass = assem.GetType("RetailManagementSystem.Repositories.ProductRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("IProduct") == null)
                    {
                        msg += className + " Class is NOT inherting the 'IProduct' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(12)]
        public void Test12_CheckForInheritance_CustomerRepository()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "CustomerRepository";

            Type repClass = assem.GetType("RetailManagementSystem.Repositories.CustomerRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("ICustomer") == null)
                    {
                        msg += className + " Class is NOT inherting the 'ICustomer' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(13)]
        public void Test13_CheckForInheritance_OrderRepository()
        {
            totalTestcases++;
            String msg = ""; 
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "OrderRepository";

            Type repClass = assem.GetType("RetailManagementSystem.Repositories.OrderRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("IOrder") == null)
                    {
                        msg += className + " Class is NOT inherting the 'IOrder' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(34)]
        public void Test14_AddProduct_StatusCodeTest() 
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/AddProduct", Method.POST);

                request.AddJsonBody(new
                {
                    id = 5,
                    name = "mouse",
                    price = 499.99,
                    orderItems = new object[] { }
                });

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/AddProduct' is NOT correct.\n";
                }

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/AddProduct' is NOT correct when the Product is already exists.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Product/AddProduct' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(35)]
        public void Test15_AddProduct_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/AddProduct", Method.POST);

                request.AddJsonBody(new
                {
                    id = 6,
                    name = "keyboard",
                    price = 600.99,
                    orderItems = new object[] { }
                });

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllProducts", Method.GET);
                response = client.Execute(requestActual);

                //var responseActual = JsonConvert.DeserializeObject<List<Course>>(response.ISSN);

                List<Product> responseActual = new JsonDeserializer().Deserialize<List<Product>>(response);

                if (responseActual.Count > 0)
                {
                    if (response.StatusCode != HttpStatusCode.OK || (!response.Content.Contains("6") ||
                        !response.Content.Contains("keyboard") || !response.Content.Contains("600.99")))
                    {
                        msg += "POST service is not working correctly. Check logic in 'AddProduct'.\n";
                    }
                }
                else msg += "POST service is not working correctly. Check logic in 'AddProduct'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'AddProduct' POST service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(36)]
        public void Test16_UpdateProductPrice_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/UpdateProductPrice/2/700.00", Method.PUT);                

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/UpdateProductPrice/{id}/{price}' is NOT correct when the Product is available.\n";
                }

                RestRequest request1 = new RestRequest("api/Product/UpdateProductPrice/1011/500.00", Method.PUT);                

                response = client.Execute(request1);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/UpdateProductPrice/{id}/{price}' is NOT correct when the Product is unavailable.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Product/UpdateProductPrice/{id}/{price}' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(37)]
        public void Test17_UpdateProductPrice_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/UpdateProductPrice/2/450.00", Method.PUT);              

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllProducts", Method.GET);
                response = client.Execute(requestActual);

                if (!response.Content.Contains("2") || !response.Content.Contains("450.00") || !response.Content.Contains("Smartphone"))
                {
                    msg += "Put service is not working correctly. Check logic in 'UpdateProductPrice'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'UpdateProductPrice' PUT service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(38)]
        public void Test18_DeleteProduct_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/DeleteProduct/4", Method.DELETE);

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/DeleteProduct/{id}' is NOT correct when the id is available.\n";
                }

                RestRequest request1 = new RestRequest("api/Product/DeleteProduct/112", Method.DELETE);

                response = client.Execute(request1);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/DeleteProduct/{id}' is NOT correct when the id is unavailable.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Product/DeleteProduct/{id}' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(39)]
        public void Test19_DeleteProduct_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/DeleteProduct/3", Method.DELETE);

                response = client.Execute(request);

                RestRequest requestActual = new RestRequest("api/Test/GetAllProducts", Method.GET);
                response = client.Execute(requestActual);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK || content.Contains("3") || content.Contains("Headphones"))
                {
                    msg += "DELETE service is not working correctly. Check logic in 'DeleteProduct'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'DeleteProduct' DELETE service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(20)] 
        public void Test20_GetProductWithHighestOrderQuantity_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/highest-order-quantity", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Product/highest-order-quantity' is NOT correct.\n";
                }               

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Product/highest-order-quantity' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(21)]
        public void Test21_GetProductWithHighestOrderQuantity_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Product/highest-order-quantity", Method.GET);

                response = client.Execute(request);

                List<Product> responseActual = new JsonDeserializer().Deserialize<List<Product>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Laptop") || !response.Content.Contains("1200"))
                        msg += "Get service is not working correctly. Check logic in 'GetProductWithHighestOrderQuantity'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetProductWithHighestOrderQuantity'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetProductWithHighestOrderQuantity' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }
         
        [Test, Order(22)]
        public void Test22_GetCustomersWithRecentOrders_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/recent-orders", Method.GET);
                request.AddQueryParameter("sinceDate", "2024-07-03");

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/recent-orders' is NOT correct when the Customers are available.\n";
                }

                RestRequest request1 = new RestRequest("api/Customer/recent-orders", Method.GET);
                request1.AddQueryParameter("sinceDate", "2025-07-03"); 

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/recent-orders' is NOT correct when the Customers are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/recent-orders' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(23)] 
        public void Test23_GetCustomersWithRecentOrders_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/recent-orders", Method.GET);
                request.AddQueryParameter("sinceDate", "2024-07-03");

                response = client.Execute(request);

                List<Customer> responseActual = new JsonDeserializer().Deserialize<List<Customer>>(response);

                if (responseActual.Count == 2)
                {
                    if (!response.Content.Contains("Alice Johnson") || !response.Content.Contains("Charlie Brown"))
                        msg += "Get service is not working correctly. Check logic in 'GetCustomersWithRecentOrders'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetCustomersWithRecentOrders'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetCustomersWithRecentOrders' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(24)] 
        public void Test24_GetCustomerWithHighestOrderCount_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/highest-order-count", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/highest-order-count' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/highest-order-count' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(25)] 
        public void Test25_GetCustomerWithHighestOrderCount_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/highest-order-count", Method.GET);

                response = client.Execute(request);

                List<Customer> responseActual = new JsonDeserializer().Deserialize<List<Customer>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Alice Johnson") || !response.Content.Contains("1"))
                        msg += "Get service is not working correctly. Check logic in 'GetCustomerWithHighestOrderCount'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetCustomerWithHighestOrderCount'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetCustomerWithHighestOrderCount' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(26)] 
        public void Test26_GetCustomerWithMostSpentAmount_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/most-spent", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/most-spent' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Customer/most-spent' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(27)] 
        public void Test27_GetCustomerWithMostSpentAmount_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Customer/most-spent", Method.GET);

                response = client.Execute(request);

                List<Customer> responseActual = new JsonDeserializer().Deserialize<List<Customer>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Charlie Brown") || !response.Content.Contains("3"))
                        msg += "Get service is not working correctly. Check logic in 'GetCustomerWithMostSpentAmount'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetCustomerWithMostSpentAmount'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetCustomerWithMostSpentAmount' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(28)] 
        public void Test28_GetOrdersByCustomer_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/by-customer/3", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-customer/{customerId}' is NOT correct when the orders are available.\n";
                }

                RestRequest request1 = new RestRequest("api/Order/by-customer/7", Method.GET);

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-customer/{customerId}' is NOT correct when the orders are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-customer/3' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(29)]  
        public void Test29_GetOrdersByCustomer_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/by-customer/3", Method.GET);

                response = client.Execute(request);

                List<Order> responseActual = new JsonDeserializer().Deserialize<List<Order>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("4") || !response.Content.Contains("3") || !response.Content.Contains("2024-07-04"))
                        msg += "Get service is not working correctly. Check logic in 'GetOrdersByCustomer'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetOrdersByCustomer'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetOrdersByCustomer' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(30)]
        public void Test30_GetOrdersInDateRange_StatusCodeTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/by-date-range", Method.GET);
                request.AddQueryParameter("startDate", "2024-07-03");
                request.AddQueryParameter("endDate", "2024-07-04");

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-date-range' is NOT correct when the orders are available.\n";
                }

                RestRequest request1 = new RestRequest("api/Order/by-date-range", Method.GET);
                request1.AddQueryParameter("startDate", "2025-07-03");
                request1.AddQueryParameter("endDate", "2025-07-04");

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-date-range' is NOT correct when the orders are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Order/by-date-range' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(31)] 
        public void Test31_GetOrdersInDateRange_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/by-date-range", Method.GET);
                request.AddQueryParameter("startDate", "2024-07-03");
                request.AddQueryParameter("endDate", "2024-07-04");

                response = client.Execute(request);

                List<Order> responseActual = new JsonDeserializer().Deserialize<List<Order>>(response);

                if (responseActual.Count == 2)
                {
                    if (!response.Content.Contains("3") || !response.Content.Contains("4")||!response.Content.Contains("2024-07-03") || !response.Content.Contains("1"))
                        msg += "Get service is not working correctly. Check logic in 'GetOrdersInDateRange'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetOrdersInDateRange'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetOrdersInDateRange' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(32)] 
        public void Test32_GetOrderWithHighestTotalAmount_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/highest-total-amount", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Order/highest-total-amount' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName); 

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Order/highest-total-amount' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(33)] 
        public void Test33_GetOrderWithHighestTotalAmount_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Order/highest-total-amount", Method.GET);

                response = client.Execute(request);

                List<Order> responseActual = new JsonDeserializer().Deserialize<List<Order>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("4") || !response.Content.Contains("3") || !response.Content.Contains("2024-07-04"))
                        msg += "Get service is not working correctly. Check logic in 'GetOrderWithHighestTotalAmount'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetOrderWithHighestTotalAmount'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetOrderWithHighestTotalAmount' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

    }

    public class AssertFailureMessages
    {
        private string TypeName;
        public AssertFailureMessages(string typeName)
        {
            TypeName = typeName;
        }
        public string GetAssemblyNotFoundMessage(string assemblyName)
        {
            return $"Could not find {assemblyName}.dll";
        }
        public string GetTypeNotFoundMessage(string assemblyName, string typeName = null)
        {
            return $"Could not find {typeName ?? TypeName} in  {assemblyName}.dll";
        }
        public string GetFieldNotFoundMessage(string fieldName, string fieldType, string typeName = null)
        {
            return $"Could not find public field {fieldName} of {fieldType} type in {typeName ?? TypeName} class\n";
        }
        public string GetPropertyNotFoundMessage(string propertyName, string propertyType, string typeName = null)
        {
            return $"Could not find public property {propertyName} of {propertyType} type in {typeName ?? TypeName} class\n";
        }
        public string GetMethodNotFoundMessage(string methodName, string methodType, string[] parameters, string typeName = null)
        {
            string temp = "";
            foreach (var item in parameters)
            {
                temp += item.ToString() + ", ";
            }
            if (temp != string.Empty)
            {
                string errMessage = temp.Substring(0, temp.Length - 2);
                return $"Could not find public method {methodName} of return type {methodType} with parameters {errMessage} in {typeName ?? TypeName} class\n";
            }
            return $"Could not find public method {methodName} of return type {methodType} in {typeName ?? TypeName} class\n";

        }
        public string GetFieldTypeMismatchMessage(string fieldName, string expectedFieldType, string typeName = null)
        {
            return $"{fieldName} is not of {expectedFieldType} data type in {typeName ?? TypeName} class";
        }
        public string GetExceptionTestFailureMessage(string methodName, string customExceptionTypeName, string propertyName, Exception exception, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot throws exception of type {customExceptionTypeName} on validation failure for {propertyName}.\nException Message: {exception.InnerException?.Message}\nStack Trace:{exception.InnerException?.StackTrace}";
        }

        public string GetExceptionMessage(Exception ex, string methodName = null, string fieldName = null, string propertyName = null, string typeName = null)
        {
            string testFor = methodName != null ? methodName + " method" : fieldName != null ? fieldName + " field" : propertyName != null ? propertyName + " property" : "undefined";
            //return $" Exception while testing {testFor} of {typeName ?? TypeName} class.\nException message : {ex.InnerException?.Message}\nStack Trace : {ex.InnerException?.StackTrace}";
            return $" Exception while testing {testFor} of {typeName ?? TypeName} class.\n";
        }

        public string GetReturnTypeAssertionFailMessage(string methodName, string expectedTypeName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return value of {expectedTypeName} data type";
        }
        public string GetReturnValueAssertionFailMessage(string methodName, object expectedValue, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return the value {expectedValue}";
        }

        public string GetValidationFailureMessage(string methodName, string expectedValidationMessage, string propertyName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return '{expectedValidationMessage}' on validation failure for property {propertyName}";
        }

    }

    public class TestBase : ATestBase
    {
        public TestBase(string assemblyName, string namespaceName, string typeName)
        {
            Messages = new AssertFailureMessages(typeName);
            this.assemblyName = assemblyName;
            this.namespaceName = namespaceName;
            this.typeName = typeName;

            Messages = new AssertFailureMessages(typeName);
            assembly = Assembly.Load(assemblyName);
            type = assembly.GetType($"{namespaceName}.{typeName}");
        }
    }

    public abstract class ATestBase
    {
        public string assemblyName;
        public string namespaceName;
        public string typeName;
        public string controllerName;

        public AssertFailureMessages Messages;

        protected Assembly assembly;
        public Type type;


        protected object typeInstance = null;
        protected void CreateNewTypeInstance()
        {
            typeInstance = assembly.CreateInstance(type.FullName);
        }
        public object GetTypeInstance()
        {
            if (typeInstance == null)
                CreateNewTypeInstance();
            return typeInstance;
        }
        public object InvokeMethod(string methodName, Type type, params object[] parameters)
        {
            var method = type.GetMethod(methodName);
            var instance = GetTypeInstance();
            var result = method.Invoke(instance, parameters);
            return result;
        }
        public T InvokeMethod<T>(string methodName, Type type, params object[] parameters)
        {
            var result = InvokeMethod(methodName, type, parameters);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public bool HasField(string fieldName, string fieldType)
        {
            bool Found = false;
            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (field != null)
            {
                Found = field.FieldType.Name == fieldType;
            }
            return Found;
        }

        public bool HasProperty(string propertyName, string propertyType)
        {
            bool Found = false;
            var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (property != null)
            {
                Found = property.PropertyType.Name == propertyType;
            }
            return Found;
        }
        public bool HasMethod(string methodName, string methodType, string[] parameters)
        {
            bool Found = false;
            bool Type = false;
            bool Count = false;
            int flag = 0;

            var method = type.GetMethod(methodName);
            if (method != null)
            {
                string returnType = method.ReturnType.ToString();
                Found = method.Name == methodName;
                Type = methodType == returnType;
                ParameterInfo[] info = method.GetParameters();
                int param = 0;
                foreach (ParameterInfo p in info)
                {
                    if (p.ParameterType.FullName == parameters[param])
                    {
                        param++;
                    }
                    else
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0 && param == parameters.Length)
                {
                    Count = true;
                }
            }
            if (Found && Type && Count)
            {
                return true;
            }
            return false;
        }
        public T GetAttributeFromProperty<T>(string propertyName, Type attribute)
        {

            var attr = type.GetProperty(propertyName).GetCustomAttribute(attribute, false);
            return (T)Convert.ChangeType(attr, typeof(T));
        }
    }
}