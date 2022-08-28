using Account_Balance_Viewer.Core.Repositories;
using Account_Balance_Viewer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
//using Xunit.Sdk;

namespace Account_Balance_Viewer.Test
{
    public class UnitTests
    {
        //[Fact]
        //public async void Add_TestClassObjectPassed_ProperMethodCalled()
        //{
        //    // Arrange
        //    var testObject = new Report();

        //    var context = new Mock<ApplicationDbContext>();
        //    var dbSetMock = new Mock<DbSet<Report>>();
        //    context.Setup(x => x.Set<Report>()).Returns(dbSetMock.Object);
        //    //dbSetMock.Setup(x => x.Add(It.IsAny<Report>())).Returns(testObject);

        //    // Act
        //    var repository = new GenericRepository<Report>(context.Object);
        //    await repository.AddAsync(testObject);

        //    //Assert
        //    context.Verify(x => x.Set<Report>());
        //    //dbSetMock.Verify(x => x.Add(It.Is<Report>(y => y == testObject)));
        //}
    }
}
