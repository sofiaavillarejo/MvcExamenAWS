﻿using System.Net;
using Amazon.S3;
using Amazon.S3.Model;

namespace MvcExamenAWS.Services
{
    public class ServiceStorageS3
    {
        private string BucketName;
        private IAmazonS3 ClientS3;

        public ServiceStorageS3(IConfiguration configuration, IAmazonS3 clientS3)
        {
            this.BucketName = configuration.GetValue<string>("AWS:BucketName");
            this.ClientS3 = clientS3;
        }

        public async Task<bool> UploadFileAsync(string FileName, Stream stream)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                Key = FileName,
                BucketName = this.BucketName,
                InputStream = stream
            };
            PutObjectResponse response = await this.ClientS3.PutObjectAsync(request);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
