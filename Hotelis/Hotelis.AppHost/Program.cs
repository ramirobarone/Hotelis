using k8s.Models;

var builder = DistributedApplication.CreateBuilder(args);

var parameter = builder.AddParameter("password", true);

var mySql = builder.AddMySql("mysqlServer").WithBindMount("scripts", "/docker-entryPoint-intidb.d").AddDatabase("other");

var sqlServer = builder
    .AddSqlServer("sqlServerHotelis")
    .WithBindMount("scripts", "/docker-entryPoint-intidb.d")
    .AddDatabase("hotelis", "hotelis");

builder.AddProject<Projects.ClientApp>("clientapp").WithReference(sqlServer).WithReference(mySql);

builder.Build().Run();
