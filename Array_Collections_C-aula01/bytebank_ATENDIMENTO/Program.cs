using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Array em C#
////TestaArrayInt();
////TestaBuscarPalavra();

//void TestaArrayInt()
//{
//    int[] idades = new int[5];
//    idades[0] = 30;
//    idades[1] = 40;
//    idades[2] = 17;
//    idades[3] = 21;
//    idades[4] = 18;

//    Console.WriteLine($"Tamanho do Array {idades.Length}");

//    int acumulador = 0;
//    for (int i = 0; i < idades.Length; i++)
//    {
//        int idade = idades[i];
//        Console.WriteLine($"índice [{i}] = {idade}");
//        acumulador += idade;
//    }

//    int media = acumulador / idades.Length;
//    Console.WriteLine($"Média de idades = {media}");
//}

//void TestaBuscarPalavra()
//{
//    string[] arrayDePalavras = new string[5];

//    for (int i = 0; i < arrayDePalavras.Length; i++)
//    {
//        Console.Write($"Digite {i + 1}ª Palavra: ");
//        arrayDePalavras[i] = Console.ReadLine();
//    }

//    Console.Write("Digite palavara a ser encontrada: ");
//    var busca = Console.ReadLine();

//    foreach (string palavra in arrayDePalavras)
//    {
//        if (palavra.Equals(busca))
//        {
//            Console.WriteLine($"Palavra encontrada = {busca}.");
//            break;
//        }
//    }

//}

//Array amostra = new double[5];
//amostra.SetValue(5.9, 0);
//amostra.SetValue(1.8, 1);
//amostra.SetValue(7.1, 2);
//amostra.SetValue(10, 3);
//amostra.SetValue(6.9, 4);

////[5,9][1,8][7,1][10][6,9]
////TestaMediana(amostra);

//void TestaMediana(Array array)
//{
//    if ((array == null) || (array.Length == 0))
//    {
//        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
//    }

//    double[] numerosOrdenados = (double[])array.Clone();
//    Array.Sort(numerosOrdenados);
//    //[1,8][5,9][6,9][7,1][10]

//    int tamanho = numerosOrdenados.Length;
//    int meio = tamanho / 2;
//    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
//                                   (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
//    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
//}

//void TestaArrayDeContasCorrentes()
//{
//    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
//    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    var contaDoAndre = new ContaCorrente(963, "123456-X");
//    listaDeContas.Adicionar(contaDoAndre);

//    for (int i = 0; i < listaDeContas.Tamanho; i++)
//    {
//        ContaCorrente conta = listaDeContas[i];
//        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
//    }

//}
//TestaArrayDeContasCorrentes();

////void RetornarMaiorValorSaldo()
////{
////    ListaDeContasCorrentes listaDeContasTeste = new ListaDeContasCorrentes();

////    // Adicionando contas com diferentes saldos
////    ContaCorrente conta1 = new ContaCorrente(874, "5679787-A") { Saldo = 1000 };
////    ContaCorrente conta2 = new ContaCorrente(874, "4456668-B") { Saldo = 2000 };
////    ContaCorrente conta3 = new ContaCorrente(874, "7781438-C") { Saldo = 1500 };

////    listaDeContasTeste.Adicionar(conta1);
////    listaDeContasTeste.Adicionar(conta2);
////    listaDeContasTeste.Adicionar(conta3);

////    // Obtendo a conta com o maior saldo
////    ContaCorrente maiorSaldo = listaDeContasTeste.MaiorSaldo();

////    // Exibindo o resultado
////    if (maiorSaldo != null)
////    {
////        Console.WriteLine($"Conta com maior saldo: {maiorSaldo.Conta}, Saldo: {maiorSaldo.Saldo}");
////    }
////    else
////    {
////        Console.WriteLine("Nenhuma conta encontrada.");
////    }
////}

////// Chamando o método
////RetornarMaiorValorSaldo();
#endregion

ArrayList _listaDeContas = new ArrayList();

AtendimentoAoCliente();

void AtendimentoAoCliente()
{
    var opcao = 0;
    while (opcao != '6')
    {
        Console.Clear();
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
        Console.WriteLine("\n\n");
        Console.Write("Digie a opção desejada: ");
        opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1': CadastrarConta();
                break;
            case '2': ListarConta();
                break;
            default:
                Console.WriteLine("Opcao nao implementada.");
                break;
        }
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Numero da Agencia: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

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
void ListarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     LISTA DE CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine("===  Dados da Conta  ===");
        Console.WriteLine("Número da Conta : " + item.Conta);
        Console.WriteLine("Saldo da Conta : " + item.Saldo);
        Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
        Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}
