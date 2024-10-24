Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");



void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumlador = 0;
    for( int i = 0; i < idades.Length; i++ )
    {
        int idade =  idades[i];
        Console.WriteLine($"indice [{i}] = {idades[i]}");
        acumlador += idades[i];
    }

    int media = acumlador / idades.Length;
    Console.WriteLine($"Media de idades = {media}");

}


void TestaBuscaPalavra()
{
    string[] arraydePalavras = new string[5];

    for( int i = 0;i < arraydePalavras.Length;i++)
    {
        Console.Write($"Digite a {i + 1} Palavra: ");
        arraydePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach(string palavra in arraydePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}");
        }
    }

}

void BuscarPalavra()
{
    string[] strings = new string[5];
    
    for ( int i = 0; i < strings.Length; i++ )
    {
        Console.Write($"Insira a palavra na posicao {i}: ");
        strings[i] = Console.ReadLine();
    }

    Console.Write($"Insira a palavra a ser buscada: ");
    string user = Console.ReadLine();

    foreach(string palavra in strings)
    {
        if(palavra.Equals(user))
        {
            Console.WriteLine($"Achou! A Palavra e: {palavra}");
        }
    }
}

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

TestaMediana(amostra);
void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Bagulho ta vazio fiao");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : 
                                        (numerosOrdenados[meio] + numerosOrdenados[meio-1]) / 2;
    Console.WriteLine($"Segue a mediana = {mediana}");

}