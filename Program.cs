using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

bool executando = true;

while (executando)
{
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1. Exibir quantidade de hóspedes");
    Console.WriteLine("2. Exibir valor da diária");
    Console.WriteLine("3. Sair");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            break;
        case "2":
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            break;
        case "3":
            executando = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}