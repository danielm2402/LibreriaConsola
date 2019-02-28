using System;

namespace libConsolas
{
    public static class clsCONSOLA
    {
        #region metodos de salida
        /// <summary>
        /// Limpia o borra todo el contenido de la Consola.
        /// </summary>
        public static void Limpiar()
        {
            Console.Clear();
        }
        /// <summary>
        /// Escribe un texto en la Consola, sin saltar linea.
        /// </summary>
        /// <param name="ParMensaje">El texto que se desea Imprimir</param>
        public static void EscribirCon(string ParMensaje)
        {
            Console.Write(ParMensaje);
        }
        /// <summary>
        /// Escribe un Mensaje en la Consola y a continuacion salta una linea.
        /// </summary>
        /// <param name="parMensaje">El texto que se desea imprimir en la Consola.</param>
        public static void EscribirSaltarLineaCon(string parMensaje)
        {
            Console.WriteLine(parMensaje);
        }
        /// <summary>
        /// Imprime un cuadro de dialogo de Tipo:Advertencia, error, confirmacion o ayuda
        /// Con un Mensaje Explicativo que ofrece re-alimentacion al Usuario.
        /// El Mensaje se mantiene hasta tanto el Usuario no oprima alguna tecla.
        /// </summary>
        /// <param name="parTitulo">Titulo del Mensaje Emergente: Adevertencia, Error, Confirmacion o Ayuda</param>
        /// <param name="parMensaje">Texto Explicativo del MEnsaje que se imprime en el cuador de dialogo</param>
        public static void EscribirMensajeEmergenteCon(string parTitulo,string parMensaje)
        {
            clsCONSOLA.Limpiar();
            clsCONSOLA.EscribirSaltarLineaCon("****" + parTitulo + "****");
            clsCONSOLA.EscribirSaltarLineaCon(parMensaje);
            clsCONSOLA.EscribirSaltarLineaCon("*****************************");
            clsCONSOLA.EscribirCon("presione cualquier tecla para continuar...");
            clsCONSOLA.LeerTecla();
        }

        #endregion
        #region metodos de entrada
        /// <summary>
        /// Hace una pausa y espera cualquier tecla para continuar.
        /// </summary>
        public static void LeerTecla()
        {
            Console.ReadKey();
        }
        /// <summary>
        /// Lee a partir de la Consola una variable (con etiqueta) de cualquier tipo de dato.
        /// </summary>
        /// <typeparam name="Tipo">El Tipo de Dato al cual pertenece la variable que se lee.</typeparam>
        /// <param name="parEtiqueta">El texto que acompaña la variable que se lee. Ej.:Nombre, Edad etc.</param>
        /// <returns>Un dato que corresponde al tipo "Tipo"</returns>
        public static Tipo LeerVariableCon <Tipo>(string parEtiqueta)
        {
            bool varDatosEntradaInvalidos = false;
            do
            {
                try
                {
                    clsCONSOLA.EscribirCon(parEtiqueta + ": ");
                    return (Tipo)Convert.ChangeType(Console.ReadLine(), typeof(Tipo));
                   
                }
                catch (Exception)
                {

                    varDatosEntradaInvalidos = true;
                }


            } while (varDatosEntradaInvalidos);
            return default(Tipo);
        }

        public static void LeerVector<Tipo>(string parEtiqueta, ref Tipo[] parVector, int parPosicionPorLeer)
        {
            try
            {
                for(int i=0;  i<parPosicionPorLeer; i++)
                {
                    parVector[i] = clsCONSOLA.LeerVariableCon<Tipo>(parEtiqueta+"[" + i + "]");
                }
            }
            catch (Exception e)
            {

                clsCONSOLA.EscribirCon(e.Message);
                clsCONSOLA.LeerTecla();
            }
        }
        #endregion






    }
}
