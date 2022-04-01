using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PromboxUtil.Cryptography
{
    public class Criptografia
    {
        /// <summary>
        /// Instancia a encriptação
        /// </summary>
        public Criptografia()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Encripta os dados usando o algoritmo assimétrico RSA. Esses dados não devem ser maiores que 128 bytes.
        /// Esse algoritmo é muito lento por trabalhar com números primos grandes. Portanto, ele é utilizado para
        /// encriptar pequenos dados, onde sua lentidão é compensada. Em contrapartida é um dos sistemas mais
        /// seguros existentes.
        /// Para maiores informações sobre o algoritmo RSA, consulte:
        /// http://www.rsasecurity.com/rsalabs/ (em inglês)
        /// http://pt.wikipedia.org/wiki/RSA (em português)
        /// </summary>
        /// <param name="Data">Byte Array. Dados que devem ser encriptados.</param>
        /// <param name="RSAKey">Chave pública.</param>
        /// <param name="OAEPPadding">Bool. Formatação dos dados usando encriptação nova ou padrão.
        /// Atenção, o OAEP16 só está disponível nos sistemas operacionais Windows 2000 com high-encryption
        /// pack instalado, Windows XP ou melhor.</param>
        /// <returns>Byte Array encriptado.</returns>
        public static byte[] RSAEncrypt(byte[] Data, string RSAKey, bool OAEPPadding)
        {
            try
            {
                // Instancia novo objeto CryptoProvider RSA
                RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();

                // Importa a chave pública para encriptar os dados
                objRSA.FromXmlString(RSAKey);

                return objRSA.Encrypt(Data, OAEPPadding);
            }
            catch (CryptographicException cEx)
            {
                throw new Exception(cEx.ToString());
            }
        }

        /// <summary>
        /// Desencripta os dados usando a chave privada fornecida. O RSA não é o algoritmo ideal para grandes 
        /// arquivos por ser lento e permitir no máximo 117 bytes de dados úteis, apesar de ser muito seguro.
        /// Por isso, estamos usando ele apenas para as senhas, geradas automaticamente.
        /// </summary>
        /// <param name="Data">Byte Array. Dados que devem ser encriptados.</param>
        /// <param name="RSAKey">Chave privada.</param>
        /// <param name="OAEPPadding">Bool. Formatação dos dados usando encriptação nova ou padrão.
        /// Atenção, o OAEP16 só está disponível nos sistemas operacionais Windows 2000 com high-encryption
        /// pack instalado, Windows XP ou melhor.</param>
        /// <returns>Byte Array desencriptado.</returns>
        public static byte[] RSADecrypt(byte[] Data, string RSAKey, bool OAEPPadding)
        {
            try
            {
                // Cria uma nova instância do provedor RSA
                RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();

                // Importa a chave privada para desencriptar os dados.
                objRSA.FromXmlString(RSAKey);

                return objRSA.Decrypt(Data, OAEPPadding);
            }
            catch (CryptographicException cEx)
            {
                throw new Exception(cEx.ToString());
            }
        }

        /// <summary>
        /// O Rijndael é um algoritmo de rápida execução e bom nível de segurança. É o Avanced Encryption Standard(AES),
        /// escolhido como padrão Federal Information Processing Standards Publications 197 (FIPS PUBS 197), pelo 
        /// National Institute of Standards and Technology (NIST), órgão dos EUA responsável por padronizações técnicas.
        /// 
        /// Essa norma entrou em vigor 26 de Maio de 2002 para todos os órgãos Federais dos EUA e correlacionados para
        /// proteger documentos de conteúdo sensível e classificado.
        /// As normas desse padrão podem ser lidas no documento abaixo:
        ///		http://csrc.nist.gov/publications/fips/fips197/fips-197.pdf
        /// 
        /// A especificação técnica do algoritmo pode ser encontrada no link:
        ///		http://csrc.nist.gov/CryptoToolkit/aes/rijndael/Rijndael.pdf
        /// 
        /// Mais informações sobre esse padrão podem ser encontrados em:
        ///		http://www.iaik.tu-graz.ac.at/research/krypto/AES/
        /// 
        /// A chave escolhida para encriptar os arquivos foi o padrão de 256 bits, o mais alto disponível.
        /// </summary>
        /// <param name="clearData">Dados do arquivo que serão encriptados.</param>
        /// <param name="guidName">Caminho e nome do Global Unique ID criado.</param>
        /// <param name="publicKey">Chave pública usada na encriptação. Essa chave será encriptada logo em seguida,
        /// usando o sistema RSA.</param>
        /// <returns>Byte Array. O fluxo de dados que devem ser encriptados.</returns>
        public static byte[] RijndaelEncrypt(byte[] clearData, string guidName, string publicKey)
        {
            try
            {
                RijndaelManaged alg = new RijndaelManaged();
                byte[] key = new byte[32];
                byte[] IV = new byte[16];
                byte[] keyFile = new byte[48];
                byte[] encryptedKeyFile;

                // Gerar as chaves de criptografia automaticamente
                alg.GenerateIV();
                alg.GenerateKey();

                key = alg.Key;
                IV = alg.IV;

                // Fluxo de dados 
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(clearData, 0, clearData.Length);
                cs.Close();

                // Salvar keyFile
                Buffer.BlockCopy(key, 0, keyFile, 0, key.Length);
                Buffer.BlockCopy(IV, 0, keyFile, key.Length, IV.Length);
                // Encriptar o keyFile

                encryptedKeyFile = RSAEncrypt(keyFile, publicKey, false);

                FileStream newKeyFile = new FileStream(guidName + "_key", FileMode.CreateNew, FileAccess.Write);
                newKeyFile.Write(encryptedKeyFile, 0, encryptedKeyFile.Length);
                newKeyFile.Close();

                byte[] encryptedData = ms.ToArray();
                return encryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Desencripta os arquivos, usando a chave privada, desencriptada.
        /// </summary>
        /// <param name="cipherData">Dados encriptados.</param>
        /// <param name="guidName">Nome da GUID, guardado em banco de dados.</param>
        /// <param name="privateKey">Chave privada, desencriptada.</param>
        /// <returns>Byte Array. Dados desencriptados.</returns>
        public static byte[] RijndaelDecrypt(byte[] cipherData, string guidName, string privateKey)
        {
            try
            {
                Rijndael alg = Rijndael.Create();
                byte[] key = new byte[32];
                byte[] IV = new byte[16];
                byte[] keyFile = new byte[128];
                byte[] decryptedKeyFile;

                // Ler a chave de desencriptação
                FileStream readFile = new FileStream(guidName + "_key", FileMode.Open);
                readFile.Read(keyFile, 0, keyFile.Length);
                readFile.Close();

                decryptedKeyFile = RSADecrypt(keyFile, privateKey, false);

                Buffer.BlockCopy(decryptedKeyFile, 0, key, 0, key.Length);
                Buffer.BlockCopy(decryptedKeyFile, key.Length, IV, 0, IV.Length);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();

                byte[] decryptedData = ms.ToArray();

                return decryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /* EasyCrypto
         * Para facilitar tarefas de criptografia, os métodos abaixo o fazem de forma automatizada, com senhas
         * embarcadas. Apesar da segurança ser enormemente reduzida, ainda assim seria necessário acesso físico ao
         * arquivo de execução para ter acesso às chaves cryptográficas e descobrir quais algoritmos utilizados.
         * Para metodologia mais forte de encriptação, usar o sistema acima, com RSA e AES.
         * */

        /// <summary>
        /// Cria uma sequência em bytes para ser usada no algortimo AES.
        /// </summary>
        /// <param name="text">String Texto para ser criado hash.</param>
        /// <returns>String</returns>
        private byte[] CreateHash(string text)
        {
            Encoding myEncoder = new UnicodeEncoding();
            HashAlgorithm myHash = new SHA1CryptoServiceProvider();
            return myHash.ComputeHash(myEncoder.GetBytes(text));
        }

        /// <summary>
        /// Faz a criptografia propriamente dita, usando entrada de parâmetros em bytes.
        /// </summary>
        /// <param name="clearData">Byte Seqüência de bytes do texto a ser criptografado.</param>
        /// <param name="Key">Byte Chave simétrica para ser usada pelo algoritmo.</param>
        /// <param name="IV">Byte Vetor de inicalização.</param>
        /// <returns>Byte Dados encriptados.</returns>
        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Padding = PaddingMode.ANSIX923;
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherData"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {

            // MemoryStream
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Padding = PaddingMode.ANSIX923;

            // Chave e Vetor de inicialização para encriptar os dados.
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        /// <summary>
        /// Encripta usando uma senha padrão interna. 
        /// </summary>
        /// <param name="clearText">String Texto que irá ser criptografado.</param>
        /// <returns>String</returns>
        public static string EasyEncrypt(string clearText)
        {
            string senha = "SvUt!l1976!3$VnEtas";
            string frase = "CachOrro MaGro nãO coMe manGa!";

            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

            Criptografia myHash = new Criptografia();

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(senha, myHash.CreateHash(frase));

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clearText"></param>
        /// <param name="Password"></param>
        /// <param name="PassPhrase"></param>
        /// <returns></returns>
        public static string EasyEncrypt(string clearText, string Password, string PassPhrase)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

            Criptografia myHash = new Criptografia();

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, myHash.CreateHash(PassPhrase));

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string EasyDecrypt(string cipherText)
        {
            string senha = "SvUt!l1976!3$VnEtas";
            string frase = "CachOrro MaGro nãO coMe manGa!";

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            Criptografia myHash = new Criptografia();
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(senha, myHash.CreateHash(frase));

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Password"></param>
        /// <param name="PassPhrase"></param>
        /// <returns></returns>
        public static string EasyDecrypt(string cipherText, string Password, string PassPhrase)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            Criptografia myHash = new Criptografia();

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, myHash.CreateHash(PassPhrase));

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nChar"></param>
        /// <returns></returns>
        public static string GeradorDeSenha(int nChar)
        {
            Random rnd = new Random();
            string strPassword = string.Empty;

            for (int nCont = 0; nCont < nChar; nCont++)
            {
                int nGerado;

                while (!valida(nGerado = rnd.Next(48, 122))) ;

                strPassword += (char)nGerado;

                rnd.Next();
            }
            return strPassword;
        }

        private static bool valida(int numero)
        {
            if (numero >= 58 && numero <= 64)
                return false;
            else if (numero >= 91 && numero <= 96)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Cria um HASH MD5 a partir de uma string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalcularMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
