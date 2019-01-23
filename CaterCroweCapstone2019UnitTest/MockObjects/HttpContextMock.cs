using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web;

namespace CaterCroweCapstone2019UnitTest.MockObjects
{
    public static class HttpContextMock
    {
        public static Mock<HttpContextBase> GenerateMockHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var session = new HttpSessionMock();

            context
                .Setup(c => c.Request)
                .Returns(request.Object);
            context
                .Setup(c => c.Session)
                .Returns(session);

            return context;
        }

        public static Mock<HttpContextBase> GenerateMockHttpContext(Dictionary<string, object> keys)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var session = new HttpSessionMock(keys);

            context
                .Setup(c => c.Request)
                .Returns(request.Object);
            context
                .Setup(c => c.Session)
                .Returns(session);

            return context;
        }
    }
}
