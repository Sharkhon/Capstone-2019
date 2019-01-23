using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CaterCroweCapstone2019UnitTest.MockObjects
{
    public class HttpSessionMock : HttpSessionStateBase
    {
        private Dictionary<string, object> keys;

        public HttpSessionMock()
        {
            this.keys = new Dictionary<string, object>(); 
        }

        public HttpSessionMock(Dictionary<string, object> keys)
        {
            this.keys = keys;
        }

        public override object this[string index]
        {
            get => this.keys.ContainsKey(index) ? this.keys[index] : null;
            set => this.keys[index] = value;
        }

        public override void Add(string name, object value)
        {
            this.keys.Add(name, value);
        }
    }
}
