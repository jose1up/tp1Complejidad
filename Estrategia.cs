
using System;
using System.Collections.Generic;
using System.Collections;
using tp1;
using tp2;

namespace tpfinal
{

    class Estrategia
    {
        public String Consulta1(ArbolBinario<DecisionData> arbol)
        {
            Queue<ArbolBinario<DecisionData>> Cola = new Queue<ArbolBinario<DecisionData>>();
            ArbolBinario<DecisionData> aux;
            Cola.Enqueue(arbol);
            while (Cola.Count > 0)
            {
                aux = Cola.Dequeue();
                aux.getDatoRaiz().ToString();
                if (aux.getHijoDerecho() != null)
                {
                    Cola.Enqueue(aux.getHijoDerecho());
                }
                if (aux.getHijoIzquierdo() != null)
                {
                    Cola.Enqueue(aux.getHijoIzquierdo());
                }

            }
            return "Fin";


        }


        public String Consulta2(ArbolBinario<DecisionData> arbol)
        {
            string resutl = "Implementar";
            return resutl;
        }

        public String Consulta3(ArbolBinario<DecisionData> arbol)
        {
            string result = "Implementar";
            return result;
        }

        public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
        {
            if (clasificador.crearHoja())
            {
                return new ArbolBinario<DecisionData>(clasificador.obtenerPregunta());
            }
            else
            {

            }

        }
    }
}