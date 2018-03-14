/*-----------------------Copyright 2017 www.wlniao.com---------------------------
    文件名称：Wlniao\MongoDB\DbContext.cs
    适用环境：NETCoreCLR 1.0/2.0
    最后修改：2016年3月24日02:58:50
    功能描述：DbContext基类

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

               http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
------------------------------------------------------------------------------*/
using System;
using MongoDB.Driver;
namespace Wlniao.MongoDB
{
    /// <summary>
    /// DbContext基类
    /// </summary>
    public partial class DbContext
    {
        private MongoClient Client { get; set; }
        private IMongoDatabase DataBase { get => Client.GetDatabase(DbConnectInfo.WLN_MONGO_NAME); }
        private static string connstr = null;
        private static string ConnStr
        {
            get
            {
                if (connstr == null)
                {
                    connstr = DbConnectInfo.WLN_CONNSTR_MONGO;
                }
                return connstr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DbContext()
        {
            Client = new MongoClient(ConnStr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionStr"></param>
        public DbContext(String ConnectionStr)
        {
            Client = new MongoClient(ConnectionStr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMongoCollection<T> DbSet<T>() where T : IEntity => DataBase.GetCollection<T>(typeof(T).Name);

        //private IMongoCollection<IEntity> IEntity { get => DbSet<IEntity>(); }
    }
}