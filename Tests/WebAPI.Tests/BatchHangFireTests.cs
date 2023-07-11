using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Hangfire;

namespace WebAPI.Tests
{
    public class BatchHangFireTests
    {
        private const int BatchSize = 10;
        public Mock<IUnitOfWork> _unitOfWork;
        private Mock<ICurrentTime> _currentTime;
        private readonly Mock<IBatchRepository> _batchRepository;

        public BatchHangFireTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _currentTime = new Mock<ICurrentTime>();
            _batchRepository = new Mock<IBatchRepository>();
        }

        [Fact]
        public void AddBatchesForThisSession_ServiceShouldResolveCorrectly()
        {
            HangFireService service = new HangFireService(_currentTime.Object, _unitOfWork.Object);

            _currentTime.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);
            _unitOfWork.Setup(x => x.BatchRepository).Returns(_batchRepository.Object);
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Test
            //var result = 
        }
    }
}
