namespace FundamentosOOBalta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Propriedades, eventos e métodos
            //Um objeto sempre é um tipo de referência
            // -> Endereço dos dados

            Console.WriteLine("Hello!");

            var pagamento = new Pagamento();
        }
    }

    //Private, Protected, Internal e Public
    class Pagamento
    {
        public virtual void Pagar(string numero) { }
    }
    class PagamentoCartaoCredito : Pagamento
    {
        public override void Pagar(string numero) { }
    }
}