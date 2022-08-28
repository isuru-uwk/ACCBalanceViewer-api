using Account_Balance_Viewer.Api.Controllers;
using Account_Balance_Viewer.Common.ViewModels;
using Account_Balance_Viewer.Core;
using Account_Balance_Viewer.Core.Interfaces;
using Account_Balance_Viewer.Data.Models;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Account_Balance_Viewer.Test
{

    public class ReportsControllerTest
    {
        private readonly IFixture _fixture;
        private readonly ReportsController _sut;
        private readonly Mock<IUnitOfWork> _unitMock;
        private readonly Mock<IFileReaderService> _fileReaderServiceMock;

        public ReportsControllerTest()
        {
            _fixture = new Fixture();
            _fileReaderServiceMock = _fixture.Freeze<Mock<IFileReaderService>>();
            _unitMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _sut = new ReportsController(_unitMock.Object, _fileReaderServiceMock.Object);

        }

        [Fact]
        public async Task GetReports_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var reportMock = _fixture.Create<IEnumerable<Report>>();
            _unitMock.Setup(x => x.Reports.GetAllAsync()).ReturnsAsync(reportMock);

            //Act
            var result = await _sut.GetAllAccountBalanceReports().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<IEnumerable<Report>>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(reportMock.GetType());
            _unitMock.Verify(x => x.Reports.GetAllAsync(), Times.Once);

        }
    }

}
