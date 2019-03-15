namespace KafkaProducer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;

    public class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
      {
        { "bootstrap.servers", "localhost:9092" }
      };

            Random rnd = new Random();

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {

                for (int i = 0; i < 11; i++)
                {
                    int number = rnd.Next(0, 100);
                    producer.ProduceAsync("kafkatopic", null, number.ToString());
                    Thread.Sleep(6000);
                }

                for (int i = 0; i < 101; i++)
                {
                    int number = rnd.Next(0, 100);
                    producer.ProduceAsync("kafkatopic", null, number.ToString());
                    Thread.Sleep(600);
                }

                for (int i = 0; i < 1001; i++)
                {
                    int number = rnd.Next(0, 100);
                    producer.ProduceAsync("kafkatopic", null, number.ToString());
                    Thread.Sleep(60);
                }

                for (int i = 0; i < 10001; i++)
                {
                    int number = rnd.Next(0, 100);
                    producer.ProduceAsync("kafkatopic", null, number.ToString());
                    Thread.Sleep(6);
                }

                producer.Flush(100);
            }
        }
    }
}