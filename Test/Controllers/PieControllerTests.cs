using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using dotnet_fundmentals.Mocks;
using Dessert.Controllers;
using Microsoft.AspNetCore.Mvc;
using Dessert.ViewModels;

namespace dotnet_fundmentals.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            // Arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);
            // Act
            var result = pieController.List("");
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}