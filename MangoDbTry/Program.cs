
using Bogus;
using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using DataGenerator;


var faker = new Faker<User>()
         .RuleFor(u => u.UserId, f => f.IndexFaker + 1)
         .RuleFor(u => u.Name, f => f.Name.FullName())
         .RuleFor(u => u.Email, f => f.Internet.Email());        

// generate 100 users
var users = faker.Generate(100);


var json = JsonConvert.SerializeObject(users, Formatting.Indented);


var filePath = "users.json";
File.WriteAllText(filePath, json);

