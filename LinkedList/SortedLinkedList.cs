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

        internal void Remove(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (found is false && node is not null)
            {
                // Hvis user findes
                if (node.Data.Name == user.Name)
                {
                    // Hvis user er den første i listen
                    if (node == first)
                    {
                        first = node.Next;
                    }
                    else
                    {
                        Console.WriteLine($"{node.Data.Name} er blevet fjernet.");
                        previous.Next = node.Next;
                    }
                    found = true;
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        internal User GetFirst()
        {
            return first.Data;
        }

        internal User GetLast()
        {
            Node node = first;

            while (node is not null)
            {
                if (node.Next is not null)
                {
                    // Gå videre til næste node
                    node = node.Next;
                }
                else
                {
                    // Hvis den finder den sidste node
                    Console.WriteLine($"{node.Data.Name} er den sidste på listen.");
                    return node.Data;
                }
            }
            return null!;
        }

        internal int Count()
        {
            Node node = first;
            bool last = false;

            int count = 0;

            while (last is false)
            {
                // Hvis det ikke er den sidste node i listen
                if (node.Next is not null)
                {
                    // Hvis denne node har en user
                    if (node.Data is not null)
                    {
                        count++;
                    }
                    // Gå videre til næste node
                    node = node.Next;
                }

                // Hvis det er den sidste node i listen
                else
                {
                    // Hvis denne node har en user
                    if (node.Data is not null)
                    {
                        count++;
                    }
                    // Stopper loopet
                    last = true;
                }
            }
            return count;
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