using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Services;
using DemoCleanArchitecture.ApplicationCore.Test.Fakes;
using DemoCleanArchitecture.Domain.Modeles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Test.Services
{
    public class AuthorServiceTest
    {
        [Fact]
        public void Get_AllAuthors_ShouldReturnAuthorsResult()
        {

            // Arrange
            List<Author> expectedResult = new List<Author>
            {
            new Author
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Pseudo = null,
                BirthDate = new DateTime(1990, 1, 1)
            },
            new Author
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Pseudo = "janesmith",
                BirthDate = new DateTime(1985, 5, 15)
            },
            new Author
            {
                Id = 2,
                FirstName = "Stephan",
                LastName = "Ledouppe",
                Pseudo = "Froggy",
                BirthDate = new DateTime(1985, 5, 15)
            }
        };
            IAuthorRepository authorRepository = new FakeGetAuthorRepository();
            var authorService = new AuthorService(authorRepository);
            // Act
            var authors = authorService.GetAll(0, 10);
            // Assert
            Assert.NotNull(authors);
            Assert.Equal(3, authors.Count());
            Assert.Equivalent(expectedResult, authors);
        }
    

    public void Get_AuthorById_ShouldReturnOneAuthorResult()
        {
            var mockAuthor = new Author
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Pseudo = null,
                BirthDate = new DateTime(1990, 1, 1)
            };

            var expectedResult = new Author
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Pseudo = null,
                BirthDate = new DateTime(1990, 1, 1)
            };
            Mock<IAuthorRepository> mockAuthorRepository = new Mock<IAuthorRepository>();
            mockAuthorRepository.Setup(repo => repo.GetById(2))
                .Returns(mockAuthor);

            AuthorService authorService = new AuthorService(mockAuthorRepository.Object);

            var actualResult = authorService.GetById(2);

            Assert.Equivalent(expectedResult, actualResult);
            mockAuthorRepository.Verify(repo => repo.GetById(2), Times.Once);



        }
    }
}