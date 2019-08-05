using System;
using System.Threading.Tasks;
using Moq;
using StackExchange.Redis;
using Xunit;

namespace Lykke.Common.Redis.Tests
{
    public class DatabaseExtensionTests
    {
        [Fact]
        public async Task StringGetMultiKeyAsync_NullDatabase_RaisesException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                ((IDatabase) null).StringGetMultiKeyAsync(new RedisKey[0]));
        }

        [Fact]
        public async Task StringGetMultiKeyAsync_EmptyKeys_ReturnsEmptyResult()
        {
            var db = new Mock<IDatabase>();

            var result = await db.Object.StringGetMultiKeyAsync(new RedisKey[0]);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}