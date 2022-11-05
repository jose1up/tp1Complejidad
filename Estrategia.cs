
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
            // Queue<ArbolBinario<DecisionData>> Cola = new Queue<ArbolBinario<DecisionData>>();
            // ArbolBinario<DecisionData> aux;
            // Cola.Enqueue(arbol);
            // while (Cola.Count != 0)
            // {
            //     aux = Cola.Dequeue();
            //     string result = aux.getDatoRaiz().ToString();
            //     if (aux.getHijoDerecho() != null)
            //     {
            //         Cola.Enqueue(aux.getHijoDerecho());
            //     }
            //     if (aux.getHijoIzquierdo() != null)
            //     {
            //         Cola.Enqueue(aux.getHijoIzquierdo());
            //     }
            //     return result;

            // }
            // return "Fin";

            return "todas las hojas ";


        }

        private void Consulta2Private(ArbolBinario<DecisionData> arbol, ArrayList C, String Act)
        {
            string ACT = Act + "," + arbol.getDatoRaiz().ToString();
            if (arbol.esHoja())
            {
                C.Add(ACT);
            }
            else
            {
                if (arbol.getHijoDerecho() != null)
                {
                    Consulta2Private(arbol.getHijoDerecho(), C, ACT);
                }
                if (arbol.getHijoIzquierdo() != null)
                {
                    Consulta2Private(arbol.getHijoIzquierdo(), C, ACT);
                }
            }



        }


        public String Consulta2(ArbolBinario<DecisionData> arbol)
        {
            string result1 = "";
            ArrayList C = new ArrayList();
            Consulta2Private(arbol, C, result1);
            foreach (var item in C)
            {
                result1 += item.ToString() + '\n';

            }
            return result1;




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
                return new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerDatoHoja()));
            }
            else
            {
                ArbolBinario<DecisionData> res = new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerPregunta()));
                res.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));
                res.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
                return res;

            }

        }
    }
}