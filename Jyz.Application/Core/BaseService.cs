using Jyz.Infrastructure.Data;

namespace Jyz.Application
{
    public abstract class BaseService
    {
        protected JyzContext NewDB()
        {
            return new JyzContext();
        }
    }
}
