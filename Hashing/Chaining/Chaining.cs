namespace Hashing.Chaining
{
    public class Chaining : IHashSet
    {
        public Chaining(int size)   // Konstruktør til at lave en LinkedList med Separate Chaining
        {
            buckets = new Node[size];
            this.size = 0;
        }

        private Node[] buckets;     // buckets = antallet af pladser i LinkedList
        private int size;           // size    = antallet af fyldte pladser 
        
        private readonly double DEFAULT_LOADFACTOR = 0.75;      // Afgør hvor meget plads listen må være fyldt, før at listens størrelse fordobles

        public int Size() { return size; }


        public bool Add(Object x)
        {
            int h = HashValue(x);       // Hash-værdien for objektet

            Node bucket = buckets[h];   // Den bucket, som 'h' tilhører

            while (bucket is not null)
            {
                // Tjekker om objektet allerede findes på listen
                if (bucket.Data.Equals(x))
                {
                    // Hvis objektet allerede findes på listen
                    Console.WriteLine($"{x} findes allerede.");
                    return false;
                }
                else
                {
                    // Gå videre til næste objekt
                    bucket = bucket.Next;
                }
            }

            // Denne if-sætning køres, hvis while-loopet har været hele sin bucket igennem, og den ikke fandt et ens objekt
            if (bucket is null)
            {
                buckets[h] = new Node(x, buckets[h]);
                size++;
                ReHash();
                Console.WriteLine($"{x} er blevet tilføjet.");

                return true;
            }

            return false;
        }

        public bool Remove(Object x)
        {
            int h = HashValue(x);       // Hash-værdien for objektet

            Node bucket = buckets[h];   // Den bucket, som 'h' tilhører
            Node previous = null!;      // Objektet på værdien 

            while (bucket is not null)
            {
                // Hvis objektet der skal slettes findes
                if (bucket.Data.Equals(x))
                {
                    // Hvis det er det første objekt i sin bucket
                    if (previous is null)
                    {
                        // Fjern objektet ved at sætte det næste objekt til at være den første for denne bucket
                        buckets[h] = bucket.Next;
                    }
                    else
                    {
                        // Fjern objektet ved at ændre linket fra det forrige objekt til at pege på det næste objekt på listen
                        previous.Next = bucket.Next;
                    }

                    size--;
                    Console.WriteLine($"{bucket.Data} er blevet fjernet fra listen.");
                    return true;
                }

                // Gå videre til næste objekt i denne bucket
                previous = bucket;
                bucket = bucket.Next;
            }

            Console.WriteLine($"{x} findes i forvejen ikke på listen.");
            return false;

        }

        public bool Contains(Object x)
        {
            int h = HashValue(x);       // Hash-værdien for objektet

            Node bucket = buckets[h];   // Den bucket, som 'h' tilhører

            while (bucket is not null)
            {
                // Tjekker om denne bucket indeholder objektet
                if (bucket.Data.Equals(x))
                {
                    // Hvis listen indeholder objektet
                    return true;
                }
                else
                {
                    // Gå videre til næste objekt
                    bucket = bucket.Next;
                }
            }

            // Hvis listen ikke indeholder objektet
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
                Node[] oldBuckets = buckets;
                int oldSize = buckets.Length;

                // Laver en ny 'buckets' der er dobbelt så stor som den gamle, og resetter 'size' til 0
                buckets = new Node[2 * oldSize];
                size = 0;

                // For-loop køres for hvert indeks i den gamle liste
                for (int i = 0; i < oldSize; i++)
                {
                    Node bucket = oldBuckets[i];

                    // Hvis en bucket i den gamle liste indeholder data, så tilføjes det til den nye liste
                    while (bucket is not null)
                    {
                        Add(bucket.Data);
                        bucket = bucket.Next;
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
                Node temp = buckets[i];
                if (temp != null)
                {
                    result += i + "\t";
                    while (temp != null)
                    {
                        result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                        temp = temp.Next;
                    }
                    result += "\n";
                }
            }
            return result;
        }
    }

    public interface IHashSet
    {
        public bool Add(Object x);
        public bool Remove(Object x);
        public bool Contains(Object x);
        public int Size();
    }

    public class Node
    {
        public Node(Object Data, Node Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

}
