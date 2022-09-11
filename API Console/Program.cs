using Refit;
using System;
using System.Threading.Tasks;

namespace API_Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
			try
			{
				var CepClient = RestService.For<ICepApiService>("http://viacep.com.br");
				Console.WriteLine("Informe seu cep:");

				string CepInformado = Console.ReadLine();
				Console.WriteLine("Consultando informações do CEP: " + CepInformado);

				var Address = await CepClient.GetAddressAsync(CepInformado);

                Console.WriteLine();
				Console.WriteLine($"Logradouro: {Address.Logradouro},");
                Console.WriteLine($"Complemento: {Address.Complemento},");
                Console.WriteLine($"Bairro: {Address.Bairro},");
                Console.WriteLine($"UF: {Address.Uf},");
                Console.WriteLine($"Ibge: {Address.Ibge},");
                Console.WriteLine($"Gia: {Address.Gia},");
                Console.WriteLine($"DDD: {Address.Ddd},");
                Console.WriteLine($"Siafi: {Address.Siafi}");

                Console.ReadKey(true);
            }
			catch (Exception e)
			{
				Console.WriteLine("Erro na consulta de CEP:" + e.Message);
			}
        }
    }
}
