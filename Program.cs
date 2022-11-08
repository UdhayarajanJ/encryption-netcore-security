using encryption_netcore_security.Repository;
using System;

namespace encryption_netcore_security
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Net5 Core Microsoft Recommended Security Implementation");




            int _securityOption = 0;
            int _toYouWantOption = 0;
            bool _toYouWantContinueSecurityOption = false;
            bool _toYouWantContinueSecurityOptionCheck = false;
            string cipherText = string.Empty;
            string rawText = string.Empty;

            do
            {
                Console.WriteLine("\n 1.Symmetric   Encryption ");
                Console.WriteLine("\n 2.Asymmetric  Encryption");
                Console.WriteLine("\n 3.Symmetric   Decryption");
                Console.WriteLine("\n 4.Asymmetric  Decryption");
                Console.WriteLine("\n 5.Open SSL PEM RSA Private And Public Key Generate");
                Console.Write("\n\n Enter The Security Option : ");
                bool _securityOptionCheck = int.TryParse(Console.ReadLine(), out _securityOption);

                if (_securityOptionCheck)
                {
                    switch (_securityOption.ToString())
                    {
                        case "1":
                            SymmetricRepository symmetricRepository = new SymmetricRepository();
                            Console.Write("\n Enter Raw Text Value : ");
                            cipherText = symmetricRepository.SymmetricEncryptionMethod(Console.ReadLine());
                            Console.WriteLine("\n Symmetric Encrypted Value : {0}", cipherText);
                            break;

                        case "2":
                            AsymmetricRepository asymmetricRepository = new AsymmetricRepository();
                            Console.Write("\n Enter Raw Text Value : ");
                            cipherText = asymmetricRepository.AsymmetricEncryptionMethod(Console.ReadLine());
                            Console.WriteLine("\n Asymmetric Encrypted Value : {0}", cipherText);
                            break;

                        case "3":
                            try
                            {
                                SymmetricRepository symmetricRepository_ = new SymmetricRepository();
                                Console.Write("\n Enter Raw Text Value : ");
                                rawText = symmetricRepository_.SymmetricDecryptionMethod(Console.ReadLine());
                                Console.WriteLine("\n Symmetric Decrypted Value : {0}", rawText);
                            }
                            catch
                            {
                                Console.WriteLine("\n Symmetric Secret Key Doesn't Decrypted The Value...");
                            }
                            break;

                        case "4":
                            try
                            {
                                AsymmetricRepository asymmetricRepository_ = new AsymmetricRepository();
                                Console.Write("\n Enter Raw Text Value : ");
                                rawText = asymmetricRepository_.AsymmetricDecryptionMethod(Console.ReadLine());
                                Console.WriteLine("\n Asymmetric Decrypted Value : {0}", rawText);

                            }
                            catch
                            {
                                Console.WriteLine("\n Asymmetric Private Key Doesn't Decrypted The Value...");
                            }
                            break;

                        case "5":
                            PemKeyGenerateRepository pemKeyGenerateRepository = new PemKeyGenerateRepository();
                            pemKeyGenerateRepository.GeneratePEMKey();
                            break;

                        default:
                            Console.WriteLine("\n Invalid Option...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n Please Enter Must Be Number...");
                }


                //Check Main Option Do You Want Continue
                Console.Write("\n\n Do you want contrinue [ press : ( 1 ) ]: ");
                _toYouWantContinueSecurityOptionCheck = int.TryParse(Console.ReadLine(), out _toYouWantOption);
                if (_toYouWantOption == 1)
                    _toYouWantContinueSecurityOption = true;
                else
                    _toYouWantContinueSecurityOption = false;


            } while (_toYouWantContinueSecurityOption);
        }
    }
}
