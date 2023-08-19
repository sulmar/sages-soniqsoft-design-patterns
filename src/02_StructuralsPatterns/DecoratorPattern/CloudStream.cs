using System;

namespace DecoratorPattern
{
    public interface Stream
    {
        public void Write(string data);
    }

    public class CloudStream : Stream
    {
        public void Write(string data)
        {
            Console.WriteLine($"Storing {data}");
        }
    }

    public class EncryptedCloudStream : Stream
    {
        private Stream stream;

        public EncryptedCloudStream(Stream stream)
        {
            this.stream = stream;
        }

        public void Write(string data)
        {
            var encrypted = Encrypt(data);
            stream.Write(encrypted);
        }

        private string Encrypt(string data)
        {
            return "!@$%^%&^&^$%^#";
        }
    }

    public class CompressedCloudStream : Stream
    {
        private Stream stream;

        public CompressedCloudStream(Stream stream)
        {
            this.stream = stream;
        }

        public void Write(string data)
        {
            var compressed = Compress(data);
            stream.Write(compressed);
        }

        private string Compress(string data)
        {
            return data.Substring(0, 5);
        }
    }

  
}
