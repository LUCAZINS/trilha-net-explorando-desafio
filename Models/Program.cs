using System;
using System.Collections.Generic;
using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== SISTEMA DE RESERVA =====\n");

            // suites pré-definidas para escolha
            var suitesDisponiveis = new List<Suite>
            {
                new Suite("Premium", capacidade: 2, valorDiaria: 150),
                new Suite("Master", capacidade: 4, valorDiaria: 250),
                new Suite("Standard", capacidade: 2, valorDiaria: 100)
            };

            Console.WriteLine("Suítes disponíveis:");
            for (int i = 0; i < suitesDisponiveis.Count; i++)
            {
                var s = suitesDisponiveis[i];
                Console.WriteLine($"{i + 1}. {s.TipoSuite} (capacidade {s.Capacidade}, R$ {s.ValorDiaria:N2} por dia)");
            }

            Console.Write("Escolha a suíte pelo número: ");
            if (!int.TryParse(Console.ReadLine(), out int escolha))
            {
                escolha = 1;
            }
            if (escolha < 1 || escolha > suitesDisponiveis.Count)
            {
                Console.WriteLine("Opção inválida, usando primeira suíte.");
                escolha = 1;
            }

            Suite suite = suitesDisponiveis[escolha - 1];

            // Dias reservados
            Console.Write("Quantos dias deseja reservar? ");
            if (!int.TryParse(Console.ReadLine(), out int diasReservados))
            {
                diasReservados = 1;
            }

            Reserva reserva = new Reserva(diasReservados);
            reserva.CadastrarSuite(suite);

            // Cadastro de hóspedes
            Console.WriteLine($"(a suíte escolhida comporta até {suite.Capacidade} hóspedes)");
            int quantidadeHospedes;
            while (true)
            {
                Console.Write("Quantos hóspedes deseja cadastrar? ");
                if (!int.TryParse(Console.ReadLine(), out quantidadeHospedes))
                {
                    quantidadeHospedes = 0;
                }

                if (quantidadeHospedes > suite.Capacidade)
                {
                    Console.WriteLine("A capacidade da suíte é menor que o número de hóspedes informado.");
                    continue; // ask again
                }

                break;
            }

            List<Pessoa> hospedes = new List<Pessoa>();

            for (int i = 0; i < quantidadeHospedes; i++)
            {
                Console.WriteLine($"\nHóspede {i + 1}");

                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? string.Empty;

                Console.Write("Sobrenome: ");
                string sobrenome = Console.ReadLine() ?? string.Empty;

                hospedes.Add(new Pessoa(nome, sobrenome));
            }

            try
            {
                reserva.CadastrarHospedes(hospedes);

                Console.WriteLine("\n===== RESERVA REALIZADA COM SUCESSO =====");
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor total da reserva: R$ {reserva.CalcularValorDiaria()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao realizar reserva: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}