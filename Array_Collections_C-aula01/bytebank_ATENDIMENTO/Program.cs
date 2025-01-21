﻿using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavara a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }

}

Array amostra = new double[5];
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//[5,9][1,8][7,1][10][6,9]
//TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);
    //[1,8][5,9][6,9][7,1][10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                   (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listadeContas = new ListaDeContasCorrentes();
    listadeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listadeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listadeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listadeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listadeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listadeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
}
TestaArrayDeContasCorrentes();

void RetornarMaiorValorSaldo()
{
    ListaDeContasCorrentes listaDeContasTeste = new ListaDeContasCorrentes();

    // Adicionando contas com diferentes saldos
    ContaCorrente conta1 = new ContaCorrente(874, "5679787-A") { Saldo = 1000 };
    ContaCorrente conta2 = new ContaCorrente(874, "4456668-B") { Saldo = 2000 };
    ContaCorrente conta3 = new ContaCorrente(874, "7781438-C") { Saldo = 1500 };

    listaDeContasTeste.Adicionar(conta1);
    listaDeContasTeste.Adicionar(conta2);
    listaDeContasTeste.Adicionar(conta3);

    // Obtendo a conta com o maior saldo
    ContaCorrente maiorSaldo = listaDeContasTeste.MaiorSaldo();

    // Exibindo o resultado
    if (maiorSaldo != null)
    {
        Console.WriteLine($"Conta com maior saldo: {maiorSaldo.Conta}, Saldo: {maiorSaldo.Saldo}");
    }
    else
    {
        Console.WriteLine("Nenhuma conta encontrada.");
    }
}

// Chamando o método
RetornarMaiorValorSaldo();

