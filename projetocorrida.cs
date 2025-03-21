using System;
using System.Threading;

class Carros{
    public string nome;
    public int velMax;
    public string cor;
    public bool turbo;
    public int qtdturbo=3;

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

    public  bool setTurbo(int n){
        if(n > 0 && n < 4){
        turbo=true;
        return turbo;
    }else{
        turbo=false;
        return turbo;
    }
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
    string escolha;
    int[] voltas=new int[20]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    int qtd1=3, qtd2=3, qtd3=3;
    bool r;
    

    Console.Clear();
    Console.WriteLine("\n\tSeja Bem-Vindo(a)\n");
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
    Console.WriteLine("\nMuito bem, as regras são as seguintes: Cada Jogador vai lançar o dado 1 vez por rodada. O dado tem números de 1 a 10. Esses números equivalem a distância da corrida.");
    Console.WriteLine("Para completar a corrida e passar pela linha de chegada são necessarios avançar 100Km");
    Console.WriteLine("Cada corredor pode ativar o seu turbo 3 vezes por corrida. Mas tome cuidado pois, quando ativar o turbo podera jogar um dado que vai de 30 até -20.");
    Console.WriteLine("Pode ser uma grande jogada, ou uma péssima jogada. Depende do resultado.");
     Console.WriteLine("São ao todo 20 voltas. Se nenhum jogador tiver terminado a corrida antes das 20 voltas acabarem, aquele com a maior distância vence\n");
    Console.WriteLine("\n\tVejamos os 3 participantes: \n");
    Console.WriteLine("\n--------------------------------");
    c1.Info();
    Console.WriteLine("\n--------------------------------");
    c2.Info();
    Console.WriteLine("\n--------------------------------");
    c3.Info();
    Console.WriteLine("\n--------------------------------\n");

    Console.WriteLine("\nEntão vamos começar. Quem alcançar os 100km ganha!!\n");
    for(int i=0;i<voltas.Length;i++){
    Console.WriteLine("\n\t\tVolta {0} \n", voltas[i]);
    inicio:
    Console.WriteLine("Lançar os dados? [s/n] Turbo [t]");
    escolha=(Console.ReadLine());
    if(escolha == "s" || escolha == "S"){
        Random random=new Random();
        dado=random.Next(1,10);
        Console.Clear();
        Console.WriteLine("Você tirou: {0}", dado);
        cnt1+=dado;
    }else if(escolha == "n" || escolha == "N"){
        Console.Clear();
        Console.WriteLine("Tem certeza que deseja sair do jogo? [s/n]");
        escolha=(Console.ReadLine());
         if(escolha == "s" || escolha == "S"){
            Console.Clear();
             goto fim;
         }else if(escolha == "n" || escolha == "N"){
            Console.Clear();
            goto inicio;
         }else{
            Console.WriteLine("Tecla invalida!");
            Thread.Sleep(2000);
            Console.Clear();
            goto inicio;
         }
    }else if(escolha == "t" || escolha == "T"){
        Console.Clear();
        Console.WriteLine("Ativando o turbo seus dados vão de 30 a -20\n");
         Console.WriteLine("Quantidade restante de turbos: {0}\n", qtd1);
        Console.WriteLine("Tem certeza que deseja ativar o turbo? [s/n]\n");
        escolha=(Console.ReadLine());
         if(escolha == "s" || escolha == "S"){
            r=c1.setTurbo(qtd1);
            if(r == true){
            Console.WriteLine("Turbo: {0}", c1.getTurbo());
            Random random=new Random();
            dado=random.Next(-20,30);
            Console.WriteLine("Você tirou: {0}", dado);
            cnt1+=dado;
            qtd1--;
            Console.WriteLine("Quantidade restante de turbos: {0}", qtd1);
            }else{
                Console.WriteLine("Turbo Esgotado!");
                Thread.Sleep(3000);
                Console.Clear();
                goto inicio;
            }
         }else if(escolha == "n" || escolha == "N"){
            goto inicio;
         }
    }else{
        Console.WriteLine("Tecla invalida!");
        Thread.Sleep(2000);
        Console.Clear();
        goto inicio;
    }

    Thread.Sleep(3000);
    Console.Clear();
    Console.WriteLine("Clique Enter para o Bot1 jogar!\n");
    tecla=Console.ReadLine();
    if(qtd2>0 && new Random().Next(1,4)==1){
        qtd2--;
        Console.WriteLine("Bot1 usou o turbo!");
        dado = new Random().Next(-20, 30);
        Console.WriteLine("Bot1 tirou: {0}", dado);
        cnt2 += dado;
    }else{
    Random random1=new Random();
        dado=random1.Next(1,10);
        Console.WriteLine("Bot1 tirou: {0}\n", dado);
        cnt2+=dado;
    }
        Thread.Sleep(2000);
    Console.Clear();

     Console.WriteLine("Clique Enter para o Bot2 jogar!\n");
    tecla=Console.ReadLine();
    if(qtd2>0 && new Random().Next(1,4)==1){
        qtd3--;
        Console.WriteLine("Bot2 usou o turbo!");
        dado = new Random().Next(-20, 30);
        Console.WriteLine("Bot2 tirou: {0}", dado);
        cnt3 += dado;
    }else{
    Random random1=new Random();
        dado=random1.Next(1,10);
        Console.WriteLine("Bot2 tirou: {0}\n", dado);
        cnt3+=dado;
    }
        
    Thread.Sleep(2000);
    Console.Clear();
    Console.WriteLine("Atualizando a Corrida: \n");
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c1.nome);
    Console.WriteLine("Já percorreu {0}km de 100km \n",cnt1);
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c2.nome);
    Console.WriteLine("Já percorreu {0}km de 100km \n",cnt2);
    Console.WriteLine("\n-----------------------");
    Console.WriteLine("Nome: {0}\n", c3.nome);
    Console.WriteLine("Já percorreu {0}km de 100km \n",cnt3);
    Console.WriteLine("-----------------------\n");

    if(cnt1 >= 100){
         Console.WriteLine("VENCEDOR: {0}\n", c1);
          Console.WriteLine("\nVocê venceu parabéns!!!\n");
          goto fim;
    }else if(cnt2 >= 100){
         Console.WriteLine("VENCEDOR: {0}\n", c2);
           Console.WriteLine("\nVocê perdeu!!!\n");
           goto fim;
    }else if(cnt3 >= 100){
         Console.WriteLine("VENCEDOR: {0}\n", c3);
           Console.WriteLine("\nVocê perdeu!!!\n");
           goto fim;
    }else{

    }     

    Console.WriteLine("Clique Enter para continuar a corrida!\n");
    tecla=Console.ReadLine();
    }

    if(cnt1 > cnt2 && cnt1 > cnt3){
         Console.WriteLine("VENCEDOR: {0}\n", c1.nome);
          Console.WriteLine("\nVocê venceu parabéns!!!\n");
          goto fim;
    }else if(cnt2 > cnt1 && cnt2 > cnt3){
         Console.WriteLine("VENCEDOR: {0}\n", c2.nome);
           Console.WriteLine("\nVocê perdeu!!!\n");
           goto fim;
    }else if(cnt3 > cnt1 && cnt3 > cnt2){
         Console.WriteLine("VENCEDOR: {0}\n", c3.nome);
           Console.WriteLine("\nVocê perdeu!!!\n");
           goto fim;
    }else{

    }
    fim:
    Console.WriteLine("\nFim de Jogo, obrigado por jogar!");
 }


}



