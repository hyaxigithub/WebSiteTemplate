
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCache
{
    public class MongoDb
    {
        public MongoDb(string host, string timeOut)
        {
            MONGODB_CONN_HOST = host;
            CONNECT_TIME_OUT = timeOut;
        }
        public MongoDb(string dbName, string host, string timeOut) : this(host, timeOut)
        {
            DB_NAME = dbName;
        }
        /// <summary>
        /// 
        /// </summary>
        private readonly string MONGODB_CONN_HOST;
        /// <summary>
        /// 端口
        /// </summary>
        private readonly int MONGODB_CONN_PORT = 27017;

        private readonly string CONNECT_TIME_OUT;

        private readonly string DB_NAME = "test";

        public MongoDatabase GetDataBase()
        {
            MongoClientSettings mongoSetting = new MongoClientSettings();
            //设置连接超时时间  
            mongoSetting.ConnectTimeout = new TimeSpan(int.Parse(CONNECT_TIME_OUT) * TimeSpan.TicksPerSecond);
            //设置数据库服务器  
            mongoSetting.Server = new MongoServerAddress(MONGODB_CONN_HOST, MONGODB_CONN_PORT);
            //创建Mongo的客户端  
            MongoClient client = new MongoClient(mongoSetting);
            //得到服务器端并且生成数据库实例  
            return client.GetServer().GetDatabase(DB_NAME);
        }
    }
}
