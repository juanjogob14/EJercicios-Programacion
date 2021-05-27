using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer10RepasoDI
{
    public class sFriki
    {

        public string Nombre
        {
            set;get;
        }

        public int Edad
        {
            set;get;
        }

        public enum eAficion
        {
            MANGA, SCIFI, RPG,FANTASIA, TERROR, TECNOLOGIA
        }

        public eAficion AficionPrincipal
        {
            set;get;
        }

        public enum eSexo
        {
            HOMBRE, MUJER
        }

        public eSexo Sexo
        {
            set;get;
        }

        public eSexo SexoOpuesto
        {
            set; get;
        }

        public string Foto
        {
            set;get;
        }

        public sFriki(string nombre, int edad, eAficion aficion, eSexo sexo, eSexo sexoOpuesto, string foto)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.AficionPrincipal = aficion;
            this.Sexo = sexo;
            this.SexoOpuesto = sexoOpuesto;
            this.Foto = foto;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
