
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Tea;
using Tea.Utils;


namespace AliyunSpotPriceHistoryQuery
{
    public class Sample 
    {

        /**
         * 使用 AK & SK 初始化账号 Client
         * @param accessKeyId
         * @param accessKeySecret
         * @return Client
         * @throws Exception
         */
        public static AlibabaCloud.SDK.Ecs20140526.Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                // 自己的 AccessKey ID
                AccessKeyId = accessKeyId,
                // 自己的 AccessKey Secret
                AccessKeySecret = accessKeySecret,
            };
            // 访问的域名
            config.Endpoint = "ecs.cn-chengdu.aliyuncs.com";
            return new AlibabaCloud.SDK.Ecs20140526.Client(config);
        }

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Sample>().Build();
            
            AlibabaCloud.SDK.Ecs20140526.Client client = CreateClient(config["Aliyun:AccessKeyId"], config["Aliyun:AccessKeySecret"]);
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeSpotPriceHistoryRequest describeSpotPriceHistoryRequest = new AlibabaCloud.SDK.Ecs20140526.Models.DescribeSpotPriceHistoryRequest
            {
                RegionId = "cn-chengdu",
                NetworkType = "vpc",
                InstanceType = "ecs.c6e.xlarge",
                StartTime = "2022-01-01T00:00:00Z",
            };

            var res = client.DescribeSpotPriceHistory(describeSpotPriceHistoryRequest);
            
            foreach (var s in res.Body.SpotPrices.SpotPriceType)
            {
                Console.WriteLine(s.SpotPrice);
            }
        }


    }
}