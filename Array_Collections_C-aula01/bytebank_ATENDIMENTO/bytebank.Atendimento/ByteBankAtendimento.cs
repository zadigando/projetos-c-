using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
            new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique"}},
            new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro"}},
            new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa"}}
        };

        public void AtendimentoAoCliente()
        {
            try
            {
                var opcao = 0;
                while (opcao != '7')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.Write("Digie a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarConta();
                            break;
                        case '3':
                            RemoverConta();
                            break;
                        case '4':
                            OrdenarConta();
                            break;
                        case '5':
                            PesquisaConta();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao nao implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("... ENCERRANDO APLICACAO ...");
            Console.ReadKey();
        }

        private void PesquisaConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2) CPF DO TITULAR? ou (3) NUMERO DA AGENCIA: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o numero da conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o cpf do titular da conta: ");
                        string _cpfTitular = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCpfTitular(_cpfTitular);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe o numero da agencia: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Opcao nao implementada");
                        break;
                    }
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta nao retornou dados ...");
            }
            foreach (var item in contasPorAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
                                 from conta in _listaDeContas
                                 where conta.Numero_agencia == numeroAgencia
                                 select conta).ToList();
            return consulta;
        }

        private ContaCorrente ConsultaPorCpfTitular(string? cpfTitular)
        {
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpfTitular).FirstOrDefault();
        }

        private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            return (from conta in _listaDeContas
                    where conta.Conta.Equals(numeroConta)
                    select conta).FirstOrDefault();
        }

        private void OrdenarConta()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada ...");
            Console.ReadKey();
        }

        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      REMOVER CONTAS     ===");
            Console.WriteLine("===============================");
            Console.Write("Informe o número da Conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine(" ... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.Write("Numero da Agencia: ");
            int numeroAgencia = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Numero da conta [NOVA] : {conta.Conta}");
            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());
            Console.Write("Informe o titular da conta: ");
            conta.Titular.Nome = Console.ReadLine();
            Console.Write("Informe o CPF do titular: ");
            conta.Titular.Cpf = Console.ReadLine();
            Console.Write("Informe a profissao do titular: ");
            conta.Titular.Profissao = Console.ReadLine();
            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

        private void ListarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ===");
            Console.WriteLine("===============================");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
            }
        }
    }
}
