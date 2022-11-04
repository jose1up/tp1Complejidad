
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
            while (Cola.Count != 0)
            {
                aux = Cola.Dequeue();
                string result = aux.getDatoRaiz().ToString();
                if (aux.getHijoDerecho() != null)
                {
                    Cola.Enqueue(aux.getHijoDerecho());
                }
                if (aux.getHijoIzquierdo() != null)
                {
                    Cola.Enqueue(aux.getHijoIzquierdo());
                }
                return result;

            }
            return "Fin";


        }


        public String Consulta2(ArbolBinario<DecisionData> arbol)
        {
            string result1 = "";

            if (arbol.getDatoRaiz() != null)
            {
                result1 += arbol.getDatoRaiz().ToString();
            }
            else
            {
                if (arbol.getHijoIzquierdo() != null && arbol.getHijoDerecho() == null)
                {
                    Consulta2(arbol.getHijoIzquierdo());
                }
                if (arbol.getHijoIzquierdo() == null && arbol.getHijoDerecho() != null)
                {

                    Consulta2(arbol.getHijoDerecho());

                }


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