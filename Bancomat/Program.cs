using Bancomat;

DatiBC datiBC = new DatiBC(1500);

for (int x=1; x <=3; x++)
{
    Console.WriteLine("inserisci il PIN");

    if (datiBC.controlloPin(Console.ReadLine()!))
    {
        Console.WriteLine("pin corretto");
        break;
    }
    else
    {
        Console.WriteLine("pin sbagliato");
        Console.WriteLine("rimangono " + (3 - x) + " tentativi.");
    }

}

ClasseBancomat classeBancomat = new ClasseBancomat();

do
{
    do
    {
        Console.WriteLine("inserisci importo");
        classeBancomat.Prelievo = int.Parse(Console.ReadLine()!);
        if (classeBancomat.maxPrev(classeBancomat.Prelievo, DatiBC.maxPrev))
        {
            if (!classeBancomat.PrelievoConto(classeBancomat.Prelievo, datiBC))
            {
                Console.WriteLine("hai prelevato " + classeBancomat.Prelievo);
                datiBC.Saldo = datiBC.Saldo - classeBancomat.Prelievo;
                Console.WriteLine("saldo attuale è " + datiBC.Saldo);
            }

        }
        else
        {
            Console.WriteLine("importo maggiore non prelevabile");
            Console.WriteLine("riprova");
        }
    } while (classeBancomat.Prelievo > DatiBC.maxPrev);

} while ( datiBC.Saldo != 0);


    








