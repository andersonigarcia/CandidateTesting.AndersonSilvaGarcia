using System;

namespace CandidateTesting.AndersonSilvaGarcia
{
    public static class Constant
    {

        #region Adjacent
        
        public const char MatrixItemsSeparation = '-';
        public const string MaxDistanceAdjacent = "\n\t\t A maior distância entre os adjacentes é {0} ";
        public const string MaxDistanceAdjacentMatriz = "";
        public const string SubTitle = "\t Adjacent Max Distance";
        public const string Options = "\n Informe a opção desejada: \n 1-A máxima distância dos adjacentes por indice. \n 2-A maior distância dos adjacentes da matriz \n 3-Baixar 'Meu CDN' e gerar 'Agora.txt' \n";
        public const string InformOption = "Informe o número da sua opção: ";
        public const string DescriptionTitle = "CandidateTesting.AndersonSilvaGarcia";
        public const string AbortMessage = "\n\n\n Pressione uma tecla pra sair... ";
        public const string DefaultInputIndice = "\n Informe o indice {0}:";
        public const string DefaultErrorValue = "O indice está fora das dimensões da matriz: ";
        public const string DefaultErrorMatriz = "Informe apenas números inteiros separado por '-': ";
        public const string MatrizInform = "\n\n Informe os valores da matriz separados '-' (Ex: 0-3-3-12-5-3-7-1): ";
        public const string Nothing = "\n\t\t -2 - Não há indices adjacentes ";

        #endregion

        #region Log
        public const string archiveName = "MeuCdnImport.txt";
        public const string archiveNotExist = "Arquivo não encontrado";
        public const string DescriptionUri = "Informa a URI do arquivo CDN: ";
        public const string DescriptionPathTarget = "Informa a Path de destino do arquivo 'Agora': ";

        public const string Version = "#Verions: 1.0\n";
        public const string Date = "#Date {0}\n";
        public const string Fildes = "#Fields: provider http-method status-code uri-path time-taken response-size cache-status \n";
        public const string Provider = "\"MINHA CDN\" ";

        #endregion
    }
}

