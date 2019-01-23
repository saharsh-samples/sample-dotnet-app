using System.Collections.Generic;
using System.Threading;

namespace sample_dotnet_app.Services {

    public interface IValuesService {
        void Store(string value);
        bool Update(long id, string newValue);
        bool Delete(long id);
        bool Retrieve(long id, out object retrieved);
        object RetrieveAll();
    }

    public class SimpleValuesService : IValuesService {

        private Dictionary<long, string> values = new Dictionary<long, string>();
        private long idCounter = 0;

        public void Store(string value) {
            values.Add(Interlocked.Increment(ref idCounter), value);
        }

        public bool Update(long id, string newValue) {
            string existing = null;
            if(!values.TryGetValue(id, out existing)) {
                return false;
            }
            values[id] = newValue;
            return true;
        }

        public bool Delete(long id) {
            return values.Remove(id);
        }

        public bool Retrieve(long id, out object retreived) {
            string mapped = "";
            var success = values.TryGetValue(id, out mapped);
            retreived = success ? mapped : null;
            return success;
        }

        public object RetrieveAll() {
            return values;
        }
    }
}