namespace LinkedList
{
    internal class SortedLinkedList
    {
        private Node first = null!;

        internal void Add(User user)
        {
            Node newNode = new(user, null!);
            Node current = first;

            // Hvis den første plads er tom
            if (first is null)
            {
                first = newNode;
            }

            // Hvis user skal indsættes på den første plads
            else if (user.Id < first.Data.Id)
            {
                newNode.Next = first;
                first = newNode;
            }
            else
            {
                // Hvis den aktuelle node ('current') har et link til en anden node,
                // og denne anden node har et id, der er større end 'newNode'...
                while (current.Next is not null &&
                       current.Next.Data.Id < newNode.Data.Id)
                {
                    // Gå videre til den næste node i listen
                    current = current.Next;
                }

                // Når while-loopet slutter, har vi fundet den rette plads ('current.Next')

                // 'newNode' sættes ind mellem 'current' og 'current.Next'
                newNode.Next = current.Next!;
                current.Next = newNode;

            }
        }

        internal User GetFirst()
        {
            return first.Data;
        }

        internal static void PrintList(SortedLinkedList list)
        {
            var ptr = list.first;
            while (ptr is not null)
            {
                Console.WriteLine($"{ptr.Data.Id} {ptr.Data.Name}");
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }

    }
}