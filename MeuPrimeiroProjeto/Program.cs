using System;

class Program {
  static void Main(string[] args){
    Console.Write("Digite seu nome: ");
    string nome = Console.ReadLine();

    if (nome.ToLower() == "zadig") {
      Console.WriteLine("Salve Zadig!");
    }
    else {
      Console.WriteLine("Coe quem e tu parcero??");
    }
  }
}