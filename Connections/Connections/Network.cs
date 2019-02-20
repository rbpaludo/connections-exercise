using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public class Network
    {
        private List<int>[] elementsTable;
        
        /// <summary>
        /// Starts the network with the given number of elements.
        /// </summary>
        /// <param name="numElements">Size of the table (number of elements contained)</param>
        /// <exception cref="Exception">Thrown when the given number of elements is invalid (lower than 1).</exception>
        public Network(int numElements)
        {
            if (numElements < 1)
            {
                throw new Exception("The given number of elements is invalid (lower than 1)");
            }
            elementsTable = new List<int>[numElements];

            for (var i = 0; i < elementsTable.Length; i++)
            {
                elementsTable[i] = new List<int>();
            }
        }

        /// <summary>
        /// Makes a new connection between two elements in the table.
        /// </summary>
        /// <param name="elem1">First element of the connection</param>
        /// <param name="elem2">Second element of the connection</param>
        /// <exception cref="Exception">Thrown in two occasions: the desired connection already exists or one of the 
        ///     given numbers is invalid (lower than 1 or higher than the number of existing elements).</exception>
        public void Connect(int elem1, int elem2)
        {
            
            if (elem1 < 1 || elem1 > elementsTable.Length + 1 ||
                elem2 < 1 || elem2 > elementsTable.Length + 1)
            {
                throw new Exception("One of the given elements is invalid (lower than 1 or higher than the number of " +
                                    "existing elements).");
            }
            
            if (elementsTable[elem1 - 1].Contains(elem2))
            {
                throw new Exception("This connection already exists.");
            }
            
            elementsTable[elem1 - 1].Add(elem2);
            elementsTable[elem2 - 1].Add(elem1);
        }
        
        /// <summary>
        /// Looks for a connection between the two given elements.
        /// </summary>
        /// <param name="elem1">First element of the connection</param>
        /// <param name="elem2">Second element of the connection</param>
        /// <returns>True if the connection between the two given elements exists in the network. 
        ///     False if it doesn't.</returns>
        /// <exception cref="Exception">Thrown if one of the given numbers is invalid (lower than 1 or higher than the 
        ///     number of existing elements).</exception>
        public bool Query(int elem1, int elem2)
        {
            
            if (elem1 < 1 || elem1 > elementsTable.Length + 1 ||
                elem2 < 1 || elem2 > elementsTable.Length + 1)
            {
                throw new Exception("Um dos elementos é inválido (menor que 1 ou maior que o número de elementos " +
                                    "existentes)");
            }
            
            // no connections in the required element
            if (elementsTable[elem1 - 1].Count == 0)
            {
                return false;
            }

            // the connection is found
            if (elementsTable[elem1 - 1].Contains(elem2))
            {
                return true;
            }

            // searches recursively for the desired connection through other connections. 
            //TODO Search in a way other than recursively, because it can become really slow in big networks
            foreach (var connections in elementsTable)
            {
                foreach (var connection in connections)
                {
                    if (Query(connection, elem2))
                    {
                        return true;
                    }   
                }
            }
            
            return false;
        }
    }
}