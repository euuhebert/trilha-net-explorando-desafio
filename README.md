# DIO - Trilha .NET - Explorando a linguagem C#
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de explorando a linguagem C#, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema de hospedagem, que será usado para realizar uma reserva em um hotel. Você precisará usar a classe Pessoa, que representa o hóspede, a classe Suíte, e a classe Reserva, que fará um relacionamento entre ambos.

O seu programa deverá cálcular corretamente os valores dos métodos da classe Reserva, que precisará trazer a quantidade de hóspedes e o valor da diária, concedendo um desconto de 10% para caso a reserva seja para um período maior que 10 dias.

## Regras e validações
1. Não deve ser possível realizar uma reserva de uma suíte com capacidade menor do que a quantidade de hóspedes. Exemplo: Se é uma suíte capaz de hospedar 2 pessoas, então ao passar 3 hóspedes deverá retornar uma exception.
2. O método ObterQuantidadeHospedes da classe Reserva deverá retornar a quantidade total de hóspedes, enquanto que o método CalcularValorDiaria deverá retornar o valor da diária (Dias reservados x valor da diária).
3. Caso seja feita uma reserva igual ou maior que 10 dias, deverá ser concedido um desconto de 10% no valor da diária.


![Diagrama de classe estacionamento](diagrama_classe_hotel.png)

## Solução

### Melhorias Implementadas

#### 1. Alterações no Program.cs para Menu Interativo

```csharp
using System;
using System.Collections.Generic;
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
```

#### 2. Verificação de Capacidade de Hóspedes na Reserva

```csharp
public void CadastrarHospedes(List<Pessoa> hospedes)
{
    // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
    if (hospedes.Count <= Suite.Capacidade)
    {
        Hospedes = hospedes;
    }
    else
    {
        // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
        throw new Exception("Capacidade inválida");
    }
}
```

#### 3. Cálculo do Valor da Diária com Desconto

```csharp
public decimal CalcularValorDiaria()
{
    // Retorna o valor da diária
    // Cálculo: DiasReservados X Suite.ValorDiaria
    decimal valor = DiasReservados * Suite.ValorDiaria;

    // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
    if (DiasReservados >= 10)
    {
        valor -= (valor / 100) * 10;
    }

    return valor;
}
```

Essas melhorias foram implementadas para garantir uma melhor gestão de reservas e proporcionar uma experiência mais completa no sistema de hospedagem.