using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
namespace ActiveMQProducer
{
 class Program
 {
 static void Main(string[] args)
 {
 // Configuração da conexão com o ActiveMQ
 string brokerUri = "activemq:tcp://localhost:61616";
 string queueName = "teste";
 // Criar conexão
 IConnectionFactory factory = new ConnectionFactory(brokerUri);
 using IConnection connection = factory.CreateConnection();
 connection.Start();
 // Criar sessão
 using ISession session =
connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
 // Criar fila
 IDestination destination = session.GetQueue(queueName);
 // Criar produtor
 using IMessageProducer producer = session.CreateProducer(destination);
 // Enviar mensagem
 ITextMessage message = session.CreateTextMessage("Olá, ActiveMQ!");
 producer.Send(message);
 Console.WriteLine("Mensagem enviada para a fila 'teste'.");
 }
 }
}