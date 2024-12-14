
var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("hotelisPassword");

var mySql = builder
    .AddMySql("mysqlServer", password, 1433)
    .WithDataVolume("hotelisVolumen")
    .AddDatabase("hotelis");

var rabbit = builder.AddRabbitMQ("serverRabbit");


builder.AddProject<Projects.ClientApp>("clientapp")
    .WithReference(mySql)
    .WithReference(rabbit);

builder.Build().Run();
