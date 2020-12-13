using System.Collections.Generic;
using System.Linq;
using FiveOursDAL.Configurations;
using FiveOursDAL.Entities;
using FiveOursDAL.Repository;
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
        public void Test1()
        {
            var expectedEntities = new List<IEntity>().AsQueryable();
            var entities = _entitiesRepository.GetAll();

            Assert.AreEqual(entities, expectedEntities);
        }
    }
}