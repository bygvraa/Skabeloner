namespace Hashing.LinearProbing
{
    public class LinearProbing : IHashSet
    {
        public LinearProbing(int size)      // Konstruktør til at lave en LinkedList med Linear Probing
        {
            buckets = new Object[size];
            this.size = 0;
        }

        private Object[] buckets;           // buckets       = antallet af pladser i LinkedList
        private int size;                   // size          = antallet af fyldte pladser 
        
        private enum State { DELETED }      // State.DELETED = bruges som en placeholder på pladser, hvor et objekt er blevet fjernet

        private readonly double DEFAULT_LOADFACTOR = 0.75;      // Afgør hvor meget plads listen må være fyldt før at listens størrelse fordobles

        public int Size() { return size; }


        public bool Add(Object x)
        {
            ReHash();                   // Tjekker om listen skal gøres større

            int h = HashValue(x);       // Hash-værdien for objektet
            int startIndex = h;         // Indeks for hash-værdien af objektet. Bruges til at forhindre et uendeligt loop

            // While-loopet kører indtil den finder en tom plads, eller indtil den når hele vejen gennem listen
            while (buckets[h] is not null)
            {
                Console.WriteLine($" Pladsen på indeks {h} er optaget; går videre til plads {(h + 1) % buckets.Length}");
                h = (h + 1) % buckets.Length;

                if (h == startIndex)
                {
                    break;
                }
            }

            // Denne if-sætning køres, hvis...
            if (buckets[h] is null ||           // ... while-loopet finder en tom plads ELLER ...
                buckets[h] is State.DELETED)    // ... hvis et objekt på en plads tidligere er blevet fjernet
            {
                // Indsætter objektet på pladsen/indeks 'buckets[h]'
                buckets[h] = x;
                size++;

                Console.WriteLine($"{x} er blevet tilføjet på indeks {h}");
                return true;
            }

            Console.WriteLine($"{x} kunne ikke tilføjes");
            return false;
        }

        public bool Remove(Object x)
        {
            int h = HashValue(x);       // Hash-værdien for objektet
            int startIndex = h;         // Indeks for hash-værdien af objektet. Bruges til at forhindre et uendeligt loop

            // While-loopet kører indtil den finder en tom plads
            while (buckets[h] is not null)
            {
                if (buckets[h].Equals(x))
                {
                    // "Fjerner" objektet på pladsen/indeks 'buckets[h]' ved at erstatte den med 'State.DELETED'
                    buckets[h] = State.DELETED;
                    size--;

                    Console.WriteLine($"{x} er blevet fjernet fra indeks {h}");
                    return true;
                }

                // Går videre til næste plads
                h = (h + 1) % buckets.Length;

                if (h == startIndex)
                {
                    break;
                }
            }

            Console.WriteLine($"{x} findes ikke og kunne derfor ikke fjernes");
            return false;
        }

        public bool Contains(Object x)
        {
            int h = HashValue(x);       // Hash-værdien for objektet
            int startIndex = h;         // Indeks for hash-værdien af objektet. Bruges til at forhindre et uendeligt loop

            while (buckets[h] is not null)
            {
                if (buckets[h].Equals(x))
                {
                    Console.WriteLine($"{x} findes på indeks {h}");
                    return true;
                }

                // Gå videre til næste plads
                h = (h + 1) % buckets.Length;

                if (h == startIndex)
                {
                    break;
                }
            }

            Console.WriteLine($"{x} findes ikke");
            return false;
        }

        public void ReHash()
        {
            double LoadFactor = ((1.0 * size) / buckets.Length);

            // Hvis listens loadfactor overgår grænsen, så rehashes listen
            if (LoadFactor > DEFAULT_LOADFACTOR)
            {
                Console.WriteLine($"--- Rehasher listen ---");

                // Laver en temp kopi af den nuværende liste og dens nuværende size
                Object[] oldBuckets = buckets;
                int oldSize = buckets.Length;

                // Laver en ny 'buckets' der er dobbelt så stor som den gamle, og resetter 'size' til 0
                buckets = new Object[2 * oldSize];
                size = 0;

                // For-loop køres for hvert indeks i den gamle liste
                for (int i = 0; i < oldSize; i++)
                {
                    Object node = oldBuckets[i];

                    // Hvis en bucket i den gamle liste indeholder data, så tilføjes det til den nye liste
                    if (node is not null)
                    {
                        Add(node);
                    }
                }
            }

        }

        private int HashValue(Object x)
        {
            int h = x.GetHashCode();

            if (h < 0)                  // Hvis hash-værdien er et minustal
            {
                h = -h;                 // Omdan minustallet til et plustal
            }

            h = h % buckets.Length;     // Tag restværdien af 'h / antallet af buckets'
            return h;
        }

        public override String ToString()
        {
            String result = "";
            for (int i = 0; i < buckets.Length; i++)
            {
                int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ?
                        HashValue(buckets[i]) : -1;
                result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
            }
            return result;
        }
    }

    public interface IHashSet
    {
        public int Size();

        public bool Add(Object x);
        public bool Remove(Object x);
        public bool Contains(Object x);
        public void ReHash();
    }
}