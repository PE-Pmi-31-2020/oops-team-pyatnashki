using System.Collections.Generic;
using System.Linq;
using FiveOursDAL.Configurations;
using FiveOursDAL.Entities;
using FiveOursDAL.Repository;
using FiveOursInterface;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class RepositoryTests
    {
        private Mock<ProjectDbContext> _mockDbContext;
        private IRepository<IEntity> _entitiesRepository;

        [SetUp]
        public void SetUpMocks()
        {
            var mockEntities = new List<IEntity>().AsQueryable();

            var mockStateSet = new Mock<DbSet<IEntity>>();
            mockStateSet.As<IQueryable<IEntity>>().Setup(m => m.Provider).Returns(mockEntities.Provider);
            mockStateSet.As<IQueryable<IEntity>>().Setup(m => m.Expression).Returns(mockEntities.Expression);
            mockStateSet.As<IQueryable<IEntity>>().Setup(m => m.ElementType).Returns(mockEntities.ElementType);
            mockStateSet.As<IQueryable<IEntity>>().Setup(m => m.GetEnumerator()).Returns(mockEntities.GetEnumerator());

            _mockDbContext = new Mock<ProjectDbContext>();
            _mockDbContext.Setup(o => o.Set<IEntity>()).Returns(mockStateSet.Object);

            _entitiesRepository = new Repository<IEntity>(_mockDbContext.Object);
        }

        [Test]
        public void GetAll_Always_MustCallDbSetGetAllMethod()
        {
            var mockSet = new Mock<DbSet<IEntity>>();
            var mockContext = new Mock<ProjectDbContext>();
            mockContext.Setup(m => m.Set<IEntity>()).Returns(mockSet.Object);
            var repo = new Repository<IEntity>(mockContext.Object);

            repo.GetAll();

            mockSet.Verify(m => m.AsQueryable(), Times.Once());
        }

        [Test]
        public void GetAll_HavingListOfEntities_ReturnsListOfEntities()
        {
            var expectedEntities = new List<IEntity>().AsQueryable();
            var entities = _entitiesRepository.GetAll();

            Assert.AreEqual(entities, expectedEntities);
        }

        [Test]
        public void AddUser_Always_MustCallDbSetAddMethod()
        {
            var mockSet = new Mock<DbSet<IEntity>>();
            var mockContext = new Mock<ProjectDbContext>();
            mockContext.Setup(m => m.Set<IEntity>()).Returns(mockSet.Object);
            var repo = new Repository<IEntity>(mockContext.Object);

            repo.Add(new Result());

            mockSet.Verify(m => m.Add(It.IsAny<IEntity>()), Times.Once());
        }

        [Test]
        public void LogFilePath_Always_MustBeLogTxt()
        {
            var logger = new FileLogger();
            string expectedPath = "log.txt";

            string path = logger.LogFilePath;

            Assert.AreEqual(path, expectedPath);

        }

        [Test]
        public void Result_Always_MustBeInitializedWithCertainData()
        {
            int expectedId = 1;
            string expectedName = "first";
            int expectedNumber = 5;
            int expectedTime = 100;

            var result = new Result()
            {
                ResultId = 1,
                Name = "first",
                NumberOfMoves = 5,
                Time = 100
            };

            Assert.AreEqual(result.ResultId, expectedId);
            Assert.AreEqual(result.Name, expectedName);
            Assert.AreEqual(result.NumberOfMoves, expectedNumber);
            Assert.AreEqual(result.Time, expectedTime);
        }
    }
}