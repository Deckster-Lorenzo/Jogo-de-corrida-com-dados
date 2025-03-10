using System;
using System.Threading;

class Carros{
    public string nome;
    public int velMax;
    public string cor;
    public bool turbo;

    public Carros(string nome, string cor){
        this.nome=nome;
        this.cor=cor;
        velMax=120;
        turbo=false;

    }

    public void Info(){
        Console.WriteLine("Nome: {0}",nome);
        Console.WriteLine("Velocidade Máxima: {0}",velMax);
        Console.WriteLine("Cor: {0}",cor);
        Console.WriteLine("Turbo: {0}", getTurbo());
    }

    

    public string getTurbo(){
        return(turbo?"Ativado":"Desativado");
    }

}

class Corrida{
 static void Main(){
    string name, color, tecla;
    int dado=0, cnt2=0, cnt3=0;
    int cnt1=0;
    char escolha;


    Console.WriteLine("\n\tSeja Bem-Vindo(a) ao Rise of the Dice Race\n");
    Console.WriteLine("\nEsse é um jogo de corrida com dados. Vamos começar configurando o seu carro.\n");
    Console.WriteLine("Clique Enter para começarmos!\n");
    tecla=Console.ReadLine();
    Console.Clear();
    Console.WriteLine("\n\tQual o nome do seu carro: ");
    name=Console.ReadLine();
     Console.WriteLine("\n\tQual a cor do seu carro: ");
    color=Console.ReadLine();


    Carros c1=new Carros(name, color);
    Carros c2=new Carros("Bot1","Dourado");
    Carros c3=new Carros("Bot2","Ciano");

    Console.Clear();
    Console.WriteLine("\nMuito bem, as regras são as seguintes: Cada Jogador vai lançar o dado 1 vez por rodada. O dado tem números de 1 a 5. Esses números equivalem a distância da corrida.");
    Console.WriteLine("Para completar a corrida e passar pela linha de chegada são necessarios avançar 50Km");
    Console.WriteLine("Cada corredor pode ativar o seu turbo 2 vezes por corrida. Mas tome cuidado pois, quando ativar o turbo podera jogar um dado que vai de 20 até -20.");
    Console.WriteLine("Pode ser uma grande jogada, ou uma péssima jogada. Depende do resultado.\n");
    Console.WriteLine("\n\tVejamos os 3 participantes: \n");
    Console.WriteLine("\n--------------------------------");
    c1.Info();
    Console.WriteLine("\n--------------------------------");
    c2.Info();
    Console.WriteLine("\n--------------------------------");
    c3.Info();
    Console.WriteLine("\n--------------------------------\n");

    Console.WriteLine("\nEntão vamos começar. Quem alcançar os 50km ganha!!\n");
    inicio:
    Console.WriteLine("Lançar os dados? [s/n]");
    escolha=char.Parse(Console.ReadLine());
    if(escolha == 's' || escolha == 'S'){
        Random random=new Random();
        dado=random.Next(1,5);
        Console.Clear();
        Console.WriteLine("Você tirou: {0}", dado);
        cnt1+=dado;
    }else if(escolha == 'n' || escolha == 'N'){
        Console.Clear();
        Console.WriteLine("Tem certeza que deseja sair do jogo? [s/n]");
        escolha=char.Parse(Console.ReadLine());
         if(escolha == 's' || escolha == 'S'){
            goto final;
         }else if(escolha == 'n' || escolha == 'N'){
            Console.Clear();
            goto inicio;
         }else{
            Console.WriteLine("Tecla invalida!");
            Thread.Sleep(3000);
            Console.Clear();
            goto inicio;
         }
    }else{
        Console.WriteLine("Tecla invalida!");
        Thread.Sleep(3000);
        Console.Clear();
        goto inicio;
    }

    Thread.Sleep(3000);
    Console.Clear();
    Console.WriteLine("Clique Enter para o Bot1 jogar!\n");
    tecla=Console.ReadLine();
    Random random1=new Random();
        dado=random1.Next(1,5);
        Console.WriteLine("Bot1 tirou: {0}\n", dado);
        cnt2+=dado;
        Thread.Sleep(3000);
    Console.Clear();

    Console.WriteLine("Clique Enter para o Bot2 jogar!\n");
    tecla=Console.ReadLine();
    Random random2=new Random();
        dado=random2.Next(1,5);
        Console.WriteLine("Bot2 tirou: {0}\n", dado);
        cnt3+=dado;
        Thread.Sleep(3000);
    Console.Clear();

    
    Console.WriteLine("Atualizando a Corrida: \n");
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c1.nome);
    Console.WriteLine("Já percorreu {0}km de 50km \n",cnt1);
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c2.nome);
    Console.WriteLine("Já percorreu {0}km de 50km \n",cnt2);
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c3.nome);
    Console.WriteLine("Já percorreu {0}km de 50km \n",cnt3);
    Console.WriteLine("-----------------------\n");

    Console.WriteLine("Clique Enter para continuar a corrida!\n");
    tecla=Console.ReadLine();
    goto inicio;


    final:

    Console.WriteLine("Fim de Jogo");
 }

}