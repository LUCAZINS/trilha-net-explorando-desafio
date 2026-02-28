using System;
using System.Collections.Generic;
namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        // initialize list to avoid null reference
        public List<Pessoa> Hospedes { get; private set; } = new List<Pessoa>();
        public Suite? Suite { get; private set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados) => DiasReservados = diasReservados;

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
                throw new ArgumentNullException(nameof(hospedes));

            if (Suite == null)
                throw new InvalidOperationException("Suíte não cadastrada.");

            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite.Capacidade < hospedes.Count)
            {
                throw new InvalidOperationException("A capacidade da suíte é menor que o número de hóspedes informado.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite));
        }

        public int ObterQuantidadeHospedes() => Hospedes.Count;

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("Suíte não cadastrada.");

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se ficar 10 dias ou mais, aplica 10% de desconto
            if (DiasReservados >= 10)
            {
                valor *= 0.90M;

                Console.WriteLine("Desconto de  10% aplicado!");

            }
            else
            {
                Console.WriteLine("Não tem desconto para a baixo de 10 dias!");
            } 
            return valor;
        }
    }
}