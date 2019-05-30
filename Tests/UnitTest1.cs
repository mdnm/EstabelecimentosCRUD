using CRUD.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FooActionReturnsIndexView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
        }
    }
}
