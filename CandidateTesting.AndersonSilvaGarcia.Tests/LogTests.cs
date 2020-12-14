using System;
using System.IO;
using Xunit;

namespace CandidateTesting.AndersonSilvaGarcia.Tests
{
    public class LogTests
    {
        [Fact(DisplayName = "Convers�o de log com sucesso")]
        [Trait("Log", "Teste a convers�o de log")]
        public void Log_ConversaoLog_RetornoComSucesso()
        {
            Uri uri = new Uri("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
            string pathTarget = "c:\\temp\\arquivo.txt";

            var log = new Log(uri, pathTarget);

            log.CreateAgoraArchive();

            Assert.True(File.Exists(pathTarget));
        }

        [Fact(DisplayName = "Convers�o de log com URI incorreta")]
        [Trait("Log", "Teste a convers�o de log")]
        public void Log_ConversaoLog_RetornoComErroUri()
        {
            Uri uri = new Uri("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01");
            string pathTarget = "c:\\temp\\arquivo.txt";

            var log = new Log(uri, pathTarget);

            log.CreateAgoraArchive();

            Assert.True(!log.ErrorMessage.Equals(string.Empty));
        }


        [Fact(DisplayName = "Convers�o de log com path target incorreta")]
        [Trait("Log", "Teste a convers�o de log")]
        public void Log_ConversaoLog_RetornoComErroPathTarget()
        {
            Uri uri = new Uri("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01");
            string pathTarget = "D:\\temp\\arquivo.txt";

            var log = new Log(uri, pathTarget);

            log.CreateAgoraArchive();

            Assert.True(!log.ErrorMessage.Equals(string.Empty));
        }

    }
}
