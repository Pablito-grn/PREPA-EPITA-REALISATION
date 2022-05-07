using System;

namespace CovidMeetsHogwarts
{
    public class Edge
    {
        // Attributes
        private (Node source, Node destination) endpoints; // source and destination
        // can be interchanged because we're working with undirected graphs

        // Methods
        // - constructor
        public Edge(Node source, Node destination)
        {
            endpoints.source = source;
            endpoints.destination = destination;
        }

        // - getters
        public (Node source, Node destination) GetEndpoints()
        {
            return endpoints;
        }

        // - == and != operators overload
        public static bool operator ==(Edge edge1, Edge edge2)
        {
            var e1 = (object) edge1;
            var e2 = (object) edge2;

            if ((e1 == null) ^ (e2 == null))
                throw new ArgumentNullException("Un des arguments en parametre est invalide");
            else if ((e1 == null) && (e2 == null))
                return true;
            return edge1.endpoints.source == edge2.endpoints.source &&
                edge1.endpoints.destination == edge2.endpoints.destination || edge1.endpoints.source ==
                edge2.endpoints.destination &&
                edge1.endpoints.destination == edge2.endpoints.source;
        }

        public static bool operator !=(Edge edge1, Edge edge2)
        {
            var e1 = (object) edge1;
            var e2 = (object) edge2;

            if ((e1 == null) ^ (e2 == null))
                throw new ArgumentNullException("Un des arguments en parametre est invalide");
            else if ((e1 == null) && (e2 == null))
                return true;
            return (edge1.endpoints.source != edge2.endpoints.source &&
                    edge1.endpoints.destination != edge2.endpoints.destination) && (edge1.endpoints.source !=
                edge2.endpoints.destination &&
                edge1.endpoints.destination != edge2.endpoints.source);
        }

        /// <summary>
        /// represent edge by its end points in DOT language
        /// </summary>
        /// <returns>string describing this edge in DOT language followed by a newline character</returns>
        public override string ToString()
        {
            return ("    " + endpoints.source + " -- " + endpoints.destination);
        }
    }
}