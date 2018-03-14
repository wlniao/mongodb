/*-----------------------Copyright 2017 www.wlniao.com---------------------------
    文件名称：Wlniao\MongoDB\DbConnectInfo.cs
    适用环境：NETCoreCLR 1.0/2.0
    最后修改：2016年3月24日02:58:50
    功能描述：MongoDB数据库链接信息

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
namespace Wlniao.MongoDB
{
    /// <summary>
    /// MongoDB数据库链接信息
    /// </summary>
    public partial class DbConnectInfo
    {
        private static string connstr_mongo = null;
        private static string connstr_mongo_name = null;

        /// <summary>
        /// 连接的MongoDb数据库端口号（默认为27017）
        /// </summary>
        public static string WLN_MONGO_PORT
        {
            get
            {
                var port = Wlniao.Config.GetSetting("WLN_MONGO_PORT");
                if (string.IsNullOrEmpty(port))
                {
                    return "27017";
                }
                return port;
            }
        }
        /// <summary>
        /// 连接的MongoDb数据库服务器地址（默认为127.0.0.1）
        /// </summary>
        public static string WLN_MONGO_HOST
        {
            get
            {
                var host = Wlniao.Config.GetSetting("WLN_MONGO_HOST");
                if (!string.IsNullOrEmpty(WLN_MONGO_NAME) && string.IsNullOrEmpty(host))
                {
                    host = "127.0.0.1";
                    Wlniao.Config.SetConfigs("WLN_MONGO_HOST", host);
                }
                return host;
            }
        }
        /// <summary>
        /// 连接的MongoDb数据库名称
        /// </summary>
        public static string WLN_MONGO_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(connstr_mongo_name))
                {
                    connstr_mongo_name = Wlniao.Config.GetSetting("WLN_MONGO_NAME", "");
                }
                return connstr_mongo_name;
            }
        }
        /// <summary>
        /// 连接Mongo数据库的用户名
        /// </summary>
        public static string WLN_MONGO_UID
        {
            get
            {
                if (string.IsNullOrEmpty(WLN_MONGO_NAME))
                {
                    return Wlniao.Config.GetSetting("WLN_MONGO_UID");
                }
                else
                {
                    return Wlniao.Config.GetSetting("WLN_MONGO_UID", WLN_MONGO_NAME);
                }
            }
        }
        /// <summary>
        /// 连接Mongo数据库的密码
        /// </summary>
        public static string WLN_MONGO_PWD
        {
            get
            {
                if (string.IsNullOrEmpty(WLN_MONGO_NAME))
                {
                    return Wlniao.Config.GetSetting("WLN_MONGO_PWD");
                }
                else
                {
                    return Wlniao.Config.GetSetting("WLN_MONGO_PWD", "");
                }
            }
        }
        /// <summary>
        /// MongoDb数据库连接字符串
        /// </summary>
        public static string WLN_CONNSTR_MONGO
        {
            get
            {
                if (connstr_mongo == null)
                {
                    connstr_mongo = Wlniao.Config.GetSetting("WLN_CONNSTR_MONGO");
                    if (string.IsNullOrEmpty(connstr_mongo))
                    {
                        connstr_mongo = string.Format("mongodb://{3}:{4}@{0}:{1}/{2}"
                            , WLN_MONGO_HOST, WLN_MONGO_PORT, WLN_MONGO_NAME, WLN_MONGO_UID, WLN_MONGO_PWD);
                        if (string.IsNullOrEmpty(WLN_MONGO_UID) || string.IsNullOrEmpty(WLN_MONGO_PWD))
                        {
                            connstr_mongo = "";
                        }
                    }
                }
                return connstr_mongo;
            }
        }
    }
}